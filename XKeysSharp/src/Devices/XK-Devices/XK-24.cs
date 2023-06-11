using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XK_24 : AbstractXKDeviceWithBlueAndRedBacklightLEDs
    {
        public override int[] PIDs => new int[] { 1027, 1028, 1029, 1180, 1181, 1182, 1183, 1235, 1236, 1249 };
        public override string Name => "XK-24";
        protected override uint ButtonsCount => 24;

        protected override AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XK_24();
            return instance;
        }
    }
}