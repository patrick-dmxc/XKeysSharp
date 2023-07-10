using PIEHidNetCore;
using System.ComponentModel;
using XKeysSharp.Devices.Resolver;

namespace XKeysSharp.Devices
{
    public abstract class AbstractXKDeviceWithBlueBacklightLEDs : AbstractXKDevice,IDeviceWithBlueBacklightLEDs, IDeviceWithButtons<ButtonWithBlueLED>
    {
        protected virtual uint[]? UnavailableButtons { get; }

        private XK_ButtonResolver<ButtonWithBlueLED>? buttonResolver;
        public IReadOnlyCollection<ButtonWithBlueLED>? Buttons => buttonResolver?.Buttons;

        public override event PropertyChangedEventHandler? PropertyChanged;


        protected override AbstractXKDevice createXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = internalCreateXKDeviceFromPIEDevice(pieDevice);
            instance.buttonResolver = new XK_ButtonResolver<ButtonWithBlueLED>(pieDevice, ButtonsCount);
            instance.addResolver(instance.buttonResolver!);
            return instance;
        }
        protected abstract AbstractXKDeviceWithBlueBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice);

        public void SetBacklightIntensity(byte blue)
        {
            WriteData(0, 187, blue);
        }
    }
}