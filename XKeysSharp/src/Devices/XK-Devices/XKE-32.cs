using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XKR_32 : AbstractXKDeviceWithBlueAndRedBacklightLEDs
    {
        public override int[] PIDs => new int[] { 1279, 1280, 1281, 1282, 1283, 1284 };
        public override string Name => "XKR-32";

        protected override uint ButtonsCount => 32;

        protected override AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XKR_32();
            return instance;
        }
    }
}