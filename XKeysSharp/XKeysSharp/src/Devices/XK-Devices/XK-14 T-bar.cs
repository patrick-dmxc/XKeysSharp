using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XK_14TBar : AbstractXKDeviceWithRGBBacklightLEDs, IDeviceWithTBar
    {
        public override int[] PIDs => new int[] { };
        public override string Name => "XK-14 T-bar";

        public byte TBarResolverIndex => throw new NotImplementedException();

        public double? TBarPosition => throw new NotImplementedException();

        protected override uint ButtonsCount => 14;

        protected override AbstractXKDeviceWithRGBBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XK_14TBar();
            return instance;
        }
    }
}