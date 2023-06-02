using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XK_12JogShuttel : AbstractXKDeviceWithBlueAndRedBacklightLEDs
    {
        public override int[] PIDs => new int[] { 1062, 1063, 1064 };
        public override string Name => "XK-12 Jog Shuttel";
        protected override uint ButtonsCount => 12;

        protected override AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XK_12JogShuttel();
            return instance;
        }
    }
}