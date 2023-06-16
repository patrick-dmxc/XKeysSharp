namespace XKeysSharp.Devices
{
    public interface IDeviceWithRedLED : IDevice
    {
        void SetRedLEDState(ELEDState state);
    }
}