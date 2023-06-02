namespace XKeysSharp.Devices
{
    public interface IDeviceWithJoystick
    {
        double? JoystickX { get; }
        double? JoystickY { get; }
        double? JoystickZ { get; }
        byte? JoystickXResolverIndex { get; }
        byte? JoystickYResolverIndex { get; }
        byte? JoystickZResolverIndex { get; }
    }
}
