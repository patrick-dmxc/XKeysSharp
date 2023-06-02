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
}
