using PIEHidNetCore;
using System.ComponentModel;
using XKeysSharp.Devices.Resolver;

namespace XKeysSharp.Devices
{
    public abstract class AbstractXKDeviceWithBlueAndRedBacklightLEDs : AbstractXKDevice, IDeviceWithBlueAndRedBacklightLEDs, IDeviceWithButtons<ButtonWithBlueAndRedLED>
    {
        protected abstract uint ButtonsCount { get; }
        protected virtual uint[]? UnavailableButtons { get; }

        private TBarResolver? tBarResolver;
        private JogShuttleResolver? jogShuttleResolver;
        private JoystickResolver? joystickResolver;
        private XK_ButtonResolver<ButtonWithBlueAndRedLED>? buttonResolver;
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

        public void SetBacklightIntensity(byte blue, byte red)
        {
            WriteData(0, 187, blue, red);
        }
    }
}