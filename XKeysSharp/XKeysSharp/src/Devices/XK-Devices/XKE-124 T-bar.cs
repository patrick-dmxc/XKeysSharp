using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XKE_124_TBar : AbstractXKDeviceWithBlueAndRedBacklightLEDs, IDeviceWithTBar
    {
        public override int[] PIDs => new int[] { 1275, 1276, 1277, 1278 };
        public override string Name => "XKE-124 T-bar";

        public byte TBarResolverIndex => 29;

        public double? TBarPosition => tBarResolver?.TBar;

        protected override uint ButtonsCount => 124;
        protected override uint[]? UnavailableButtons => new uint[] { 108, 109, 110, 111 };

        protected override AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XKE_124_TBar();
            return instance;
        }
    }
}