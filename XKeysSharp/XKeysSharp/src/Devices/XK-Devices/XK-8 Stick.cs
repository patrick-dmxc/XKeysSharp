using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XK_8Stick : AbstractXKDeviceWithBlueBacklightLEDs
    {
        public override int[] PIDs => new int[] { 1130, 1131, 1132, 1252 };
        public override string Name => "XK-8 Stick";
        protected override uint ButtonsCount => 8;

        protected override AbstractXKDeviceWithBlueBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XK_8Stick();
            return instance;
        }
    }
}