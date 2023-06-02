using XKeysSharp;

namespace XKeysSharp.Devices
{
    public interface IDevice
    {
        string Name { get; }
        string? SerialNumber { get; }
        byte? FirmwareVersion { get; }
        void Connect();
    }
    public interface IDeviceWithRedLED
    {
        void SetRedLEDState(ELEDState state);
    }
    public interface IDeviceWithGreenLED
    {
        void SetGreenLEDState(ELEDState state);
    }
    public interface IDeviceWithButtons<T> where T : IButton
    {
        IReadOnlyCollection<T>? Buttons { get; }
    }

    public interface IDeviceWithBlueBacklightLEDs
    {
        void SetBacklightIntensity(byte blue);
    }

    public interface IDeviceWithBlueAndRedBacklightLEDs
    {
        void SetBacklightIntensity(byte blue, byte red);
    }

    public interface IDeviceWithRGBBacklightLEDs
    {
    }

    public interface IDeviceWithTBar
    {
        byte TBarResolverIndex { get; }
    }
    public interface IDeviceWithJoystick
    {
        byte? JoystickXResolverIndex { get; }
        byte? JoystickYResolverIndex { get; }
        byte? JoystickZResolverIndex { get; }
    }
    public interface IDeviceWithJogShuttle
    {
        byte JogAnalogResolverIndex { get; }
        byte ShuttleAnalogResolverIndex { get; }
    }
    public interface IDeviceWithLCD
    {
        void SetLCDTopText(string text, bool backlightOn);
        void SetLCDBottomText(string text, bool backlightOn);
    }
}
