namespace XKeysSharp.Devices
{
    public interface IDeviceWithGreenLED : IDevice
    {
        void SetGreenLEDState(ELEDState state);
    }
}