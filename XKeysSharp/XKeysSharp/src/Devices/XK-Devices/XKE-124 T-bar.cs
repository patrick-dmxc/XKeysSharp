using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XKE_124_TBar : AbstractXKDeviceWithBlueAndRedBacklightLEDs
    {
        public override int[] PIDs => new int[] { 1275, 1276, 1277, 1278 };
        public override string Name => "XKE-124 T-bar";
        protected override uint ButtonsCount => 124;

        protected override AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XKE_124_TBar();
            return instance;
        }
    }
}