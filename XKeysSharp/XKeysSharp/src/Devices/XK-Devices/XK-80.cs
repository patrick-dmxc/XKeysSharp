using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XK_80 : AbstractXKDeviceWithBlueAndRedBacklightLEDs
    {
        public override int[] PIDs => new int[] { 1090, 1089, 1091, 1250, 1237, 1238 };
        public override string Name => "XK-80";
        protected override uint ButtonsCount => 80;

        protected override AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XK_80();
            return instance;
        }
    }
}