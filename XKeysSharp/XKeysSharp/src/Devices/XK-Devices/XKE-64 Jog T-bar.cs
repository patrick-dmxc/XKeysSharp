using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XKE_68_Jog_TBar : AbstractXKDeviceWithBlueAndRedBacklightLEDs
    {
        public override int[] PIDs => new int[] { 1325, 1326, 1327, 1328, 1329, 1330, 1331, 1332 };
        public override string Name => "XKE-68 Jog T-bar";
        protected override uint ButtonsCount => 124;

        protected override AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XKE_68_Jog_TBar();
            return instance;
        }
    }
}