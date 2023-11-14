using PIEHidNetCore;
using System.ComponentModel;
using XKeysSharp.Devices.Resolver;

namespace XKeysSharp.Devices
{
    public abstract class AbstractXBADeviceWithRGBBacklightLEDs : AbstractXKDevice, IDeviceWithRGBBacklightLEDs, IDeviceWithButtons<ButtonWithRGBLED>
    {
        protected virtual uint[]? UnavailableButtons { get; }
        protected TBarResolver? tBarResolver { get; private set; }
        protected JogShuttleResolver? jogShuttleResolver { get; private set; }
        protected JoystickResolver? joystickResolver { get; private set; }
        protected XBA_FaderResolver? faderResolver { get; private set; }

        private XK_ButtonResolver<ButtonWithRGBLED>? buttonResolver;
        public IReadOnlyCollection<ButtonWithRGBLED>? Buttons => buttonResolver?.Buttons;

        public override event PropertyChangedEventHandler? PropertyChanged;


        protected override AbstractXKDevice createXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = internalCreateXKDeviceFromPIEDevice(pieDevice);

            if (instance is IDeviceWithTBar deviceWithTBar)
            {
                instance.tBarResolver = new TBarResolver(deviceWithTBar.TBarResolverIndex);
                instance.addResolver(instance.tBarResolver!);
            }
            if (instance is IDeviceWithJoystick deviceWithJoystick)
            {
                instance.joystickResolver = new JoystickResolver(deviceWithJoystick.JoystickXResolverIndex, deviceWithJoystick.JoystickYResolverIndex, deviceWithJoystick.JoystickZResolverIndex);
                instance.addResolver(instance.joystickResolver!);
            }
            if (instance is IDeviceWithJogShuttle deviceWithJogShuttle)
            {
                instance.jogShuttleResolver = new JogShuttleResolver(deviceWithJogShuttle.JogAnalogResolverIndex, deviceWithJogShuttle.ShuttleAnalogResolverIndex);
                instance.addResolver(instance.jogShuttleResolver!);
            }
            if (instance is IDeviceWithFaders deviceWithFaders)
            {
                instance.faderResolver = new XBA_FaderResolver(pieDevice, deviceWithFaders.FadersCount);
                instance.addResolver(instance.faderResolver!);
            }

            instance.buttonResolver = new XK_ButtonResolver<ButtonWithRGBLED>(pieDevice, ButtonsCount);
            instance.addResolver(instance.buttonResolver!);
            return instance;
        }
        protected abstract AbstractXBADeviceWithRGBBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice);

        public void SetBacklightIntensity(byte bank1, byte bank2)
        {
            WriteData(0, 164, bank1, bank2);
        }

        public void SetEntireBacklightUpper(byte red, byte green, byte blue)
        {
            WriteData(0, 166, 0, red, green, blue);
        }

        public void SetEntireBacklightLower(byte red, byte green, byte blue)
        {
            WriteData(0, 166, 1, red, green, blue);
        }
    }
}