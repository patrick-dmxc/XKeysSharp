namespace XKeysSharp.Devices
{
    public interface IDeviceWithBlueBacklightLEDs : IDevice
    {
        void SetBacklightIntensity(byte blue);
    }
}