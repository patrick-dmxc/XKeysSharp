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
}
