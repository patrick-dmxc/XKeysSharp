namespace XKeysSharp.Devices
{
    public interface IDeviceWithFlashingLEDs : IDevice
    {
        void SetFlashFrequency(byte speed);
    }
}
