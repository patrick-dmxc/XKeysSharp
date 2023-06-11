using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XKE_40 : AbstractXKDeviceWithBlueAndRedBacklightLEDs
    {
        public override int[] PIDs => new int[] { 1355, 1356, 1357, 1358, 1359, 1360, 1361, 1362 };
        public override string Name => "XKE-40";

        protected override uint ButtonsCount => 40;

        protected override AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XKE_40();
            return instance;
        }
    }
}