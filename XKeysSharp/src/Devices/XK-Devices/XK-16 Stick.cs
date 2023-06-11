using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XK_16Stick : AbstractXKDeviceWithBlueBacklightLEDs
    {
        public override int[] PIDs => new int[] { 1049, 1050, 1051, 1251, 1269, 1270 };
        public override string Name => "XK-16 Stick";
        protected override uint ButtonsCount => 16;

        protected override AbstractXKDeviceWithBlueBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XK_16Stick();
            return instance;
        }
    }
}