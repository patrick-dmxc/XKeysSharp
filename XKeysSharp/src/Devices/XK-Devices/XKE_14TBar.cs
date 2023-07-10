using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XKE_14TBar : AbstractXBADeviceWithRGBBacklightLEDs, IDeviceWithTBar
    {
        public override int[] PIDs => new int[] { 1396, 1397, 1398, 1399, 1400, 1401, 1402, 1403 };
        public override string Name => "XKE-14 T-bar";

        public byte TBarResolverIndex => 9;

        public double? TBarPosition => tBarResolver?.TBar;

        protected override uint ButtonsCount => 14;

        protected override AbstractXBADeviceWithRGBBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XKE_14TBar();
            return instance;
        }
    }
}