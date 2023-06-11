using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XK_60 : AbstractXKDeviceWithBlueAndRedBacklightLEDs
    {
        public override int[] PIDs => new int[] { 1122, 1121, 1123, 1254, 1239, 1240 };
        public override string Name => "XK-60";
        protected override uint ButtonsCount => 60;

        protected override AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XK_60();
            return instance;
        }
    }
}