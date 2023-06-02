using PIEHidNetCore;
using System.ComponentModel;
using XKeysSharp.Devices.Resolver;

namespace XKeysSharp.Devices
{
    public abstract class AbstractXKDeviceWithRGBBacklightLEDs : AbstractXKDevice,IDeviceWithRGBBacklightLEDs, IDeviceWithButtons<ButtonWithRGBLED>
    {
        protected abstract uint ButtonsCount { get; }
        protected virtual uint[]? UnavailableButtons { get; }

        private XK_ButtonResolver<ButtonWithRGBLED>? buttonResolver;
        public IReadOnlyCollection<ButtonWithRGBLED>? Buttons => buttonResolver?.Buttons;

        public override event PropertyChangedEventHandler? PropertyChanged;


        protected override AbstractXKDevice createXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = internalCreateXKDeviceFromPIEDevice(pieDevice);
            instance.buttonResolver = new XK_ButtonResolver<ButtonWithRGBLED>(pieDevice, 40);
            instance.addResolver(instance.buttonResolver!);
            return instance;
        }
        protected abstract AbstractXKDeviceWithRGBBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice);
    }
}