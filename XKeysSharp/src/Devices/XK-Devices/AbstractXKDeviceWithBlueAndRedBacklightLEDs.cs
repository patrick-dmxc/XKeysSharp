using PIEHidNetCore;
using System.ComponentModel;
using XKeysSharp.Devices.Resolver;

namespace XKeysSharp.Devices
{
    public abstract class AbstractXKDeviceWithBlueAndRedBacklightLEDs : AbstractXKDevice, IDeviceWithBlueAndRedBacklightLEDs, IDeviceWithButtons<ButtonWithBlueAndRedLED>
    {
        protected abstract uint ButtonsCount { get; }
        protected virtual uint[]? UnavailableButtons { get; }

        protected TBarResolver? tBarResolver { get; private set; }
        protected JogShuttleResolver? jogShuttleResolver { get; private set; }
        protected JoystickResolver? joystickResolver { get; private set; }
        protected XK_ButtonResolver<ButtonWithBlueAndRedLED>? buttonResolver { get; private set; }
        public IReadOnlyCollection<ButtonWithBlueAndRedLED>? Buttons => buttonResolver?.Buttons;

        public override event PropertyChangedEventHandler? PropertyChanged;


        protected override AbstractXKDevice createXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = internalCreateXKDeviceFromPIEDevice(pieDevice);

            if (instance is IDeviceWithTBar deviceWithTBar)
                instance.tBarResolver = new TBarResolver(deviceWithTBar.TBarResolverIndex);

            if (instance is IDeviceWithJoystick deviceWithJoystick)
                instance.joystickResolver = new JoystickResolver(deviceWithJoystick.JoystickXResolverIndex, deviceWithJoystick.JoystickYResolverIndex, deviceWithJoystick.JoystickZResolverIndex);

            if (instance is IDeviceWithJogShuttle deviceWithJogShuttle)
                instance.jogShuttleResolver = new JogShuttleResolver(deviceWithJogShuttle.JogAnalogResolverIndex, deviceWithJogShuttle.ShuttleAnalogResolverIndex);

            instance.buttonResolver = new XK_ButtonResolver<ButtonWithBlueAndRedLED>(pieDevice, 40);
            instance.addResolver(instance.buttonResolver!);
            return instance;
        }
        protected abstract AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice);

        protected override void onCreated()
        {
            base.onCreated();

            if(this.tBarResolver!=null)
                tBarResolver.PropertyChanged += TBarResolver_PropertyChanged;

            if (this.joystickResolver != null)
                joystickResolver.PropertyChanged += JoystickResolver_PropertyChanged;

            if (this.jogShuttleResolver != null)
                jogShuttleResolver.PropertyChanged += JogShuttleResolver_PropertyChanged;
        }

        private void TBarResolver_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TBarResolver.TBar))
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IDeviceWithTBar.TBarPosition)));
        }

        private void JoystickResolver_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(JoystickResolver.X))
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IDeviceWithJoystick.JoystickX)));
            if (e.PropertyName == nameof(JoystickResolver.Y))
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IDeviceWithJoystick.JoystickY)));
            if (e.PropertyName == nameof(JoystickResolver.Z))
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IDeviceWithJoystick.JoystickZ)));
        }

        private void JogShuttleResolver_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(JogShuttleResolver.Jog))
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IDeviceWithJogShuttle.Jog)));
            if (e.PropertyName == nameof(JogShuttleResolver.Shuttle))
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IDeviceWithJogShuttle.Shuttle)));
        }

        public void SetBacklightIntensity(byte blue, byte red)
        {
            WriteData(0, 187, blue, red);
        }
    }
}