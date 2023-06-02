using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XK_16LCD : AbstractXKDeviceWithBlueAndRedBacklightLEDs
    {
        public override int[] PIDs => new int[] { 1316, 1317, 1318, 1319, 1320, 1321, 1322, 1323 };
        public override string Name => "XK-16 LCD";
        protected override uint ButtonsCount => 16;

        protected override AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XK_16LCD();
            return instance;
        }
    }
}