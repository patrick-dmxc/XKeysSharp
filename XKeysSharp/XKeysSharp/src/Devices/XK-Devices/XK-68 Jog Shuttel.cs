using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XK_68JogShuttel : AbstractXKDeviceWithBlueAndRedBacklightLEDs
    {
        public override int[] PIDs => new int[] { 1115, 1114, 1116 };
        public override string Name => "XK-68 Jog Shuttel";
        protected override uint ButtonsCount => 68;

        protected override AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XK_68JogShuttel();
            return instance;
        }
    }
}