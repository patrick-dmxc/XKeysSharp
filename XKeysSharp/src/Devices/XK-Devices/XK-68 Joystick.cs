using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XK_68Joystick : AbstractXKDeviceWithBlueAndRedBacklightLEDs, IDeviceWithJoystick
    {
        public override int[] PIDs => new int[] { 1117, 1118, 1119 };
        public override string Name => "XK-68 Joystick";

        public byte? JoystickXResolverIndex => 15;
        public byte? JoystickYResolverIndex => 16;
        public byte? JoystickZResolverIndex => 17;

        public double? JoystickX => joystickResolver?.X;
        public double? JoystickY => joystickResolver?.Y;
        public double? JoystickZ => joystickResolver?.Z;

        protected override uint ButtonsCount => 12;
        protected override uint[]? UnavailableButtons => new uint[] { 27, 28, 29, 35, 36, 37, 43, 44, 45, 51, 52, 53 };

        protected override AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XK_68Joystick();
            return instance;
        }
    }
}