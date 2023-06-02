using PIEHidNetCore;
using System.ComponentModel;
using XKeysSharp.Devices.Resolver;

namespace XKeysSharp.Devices
{
    public abstract class AbstractXKDeviceWithBlueAndRedBacklightLEDs : AbstractXKDevice,IDeviceWithBlueAndRedBacklightLEDs, IDeviceWithButtons<ButtonWithBlueAndRedLED>
    {
        protected abstract uint ButtonsCount { get; }

        private XK_ButtonResolver<ButtonWithBlueAndRedLED>? buttonResolver;
        public IReadOnlyCollection<ButtonWithBlueAndRedLED>? Buttons => buttonResolver?.Buttons;

        public override event PropertyChangedEventHandler? PropertyChanged;
        public byte Firmware { get; private set; }


        protected override AbstractXKDevice createXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = internalCreateXKDeviceFromPIEDevice(pieDevice);
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