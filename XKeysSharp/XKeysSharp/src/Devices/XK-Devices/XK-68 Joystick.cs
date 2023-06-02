using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XK_68Joystick : AbstractXKDeviceWithBlueAndRedBacklightLEDs
    {
        public override int[] PIDs => new int[] { 1117, 1118, 1119 };
        public override string Name => "XK-68 Joystick";
        protected override uint ButtonsCount => 12;

        protected override AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XK_68Joystick();
            return instance;
        }
    }
}