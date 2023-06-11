namespace XKeysSharp.Devices
{
    public interface IDevice
    {
        string Name { get; }
        string? SerialNumber { get; }
        byte? FirmwareVersion { get; }
        void Connect();
    }
}
