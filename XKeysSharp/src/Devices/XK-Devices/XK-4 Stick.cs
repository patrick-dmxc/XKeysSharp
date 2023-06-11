using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XK_4Stick : AbstractXKDeviceWithBlueBacklightLEDs
    {
        public override int[] PIDs => new int[] { 1127, 1128, 1129, 1253 };
        public override string Name => "XK-4 Stick";
        protected override uint ButtonsCount => 4;

        protected override AbstractXKDeviceWithBlueBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XK_4Stick();
            return instance;
        }
    }
}