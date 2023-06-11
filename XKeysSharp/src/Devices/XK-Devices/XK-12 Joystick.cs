using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XK_12Joystick : AbstractXKDeviceWithBlueAndRedBacklightLEDs, IDeviceWithJoystick
    {
        public override int[] PIDs => new int[] { 1065, 1067 };
        public override string Name => "XK-12 Joystick";

        public byte? JoystickXResolverIndex => 7;
        public byte? JoystickYResolverIndex => 8;
        public byte? JoystickZResolverIndex => 10;

        public double? JoystickX => joystickResolver?.X;
        public double? JoystickY => joystickResolver?.Y;
        public double? JoystickZ => joystickResolver?.Z;

        protected override uint ButtonsCount => 12;
        protected override uint[]? UnavailableButtons => new uint[] { 3, 4, 5, 6, 7, 11, 12, 13, 14, 15, 19, 20, 21, 22, 23, 27, 28, 29, 30, 31 };

        protected override AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XK_12Joystick();
            return instance;
        }
    }
}