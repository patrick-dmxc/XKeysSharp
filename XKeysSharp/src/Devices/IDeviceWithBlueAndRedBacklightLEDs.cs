namespace XKeysSharp.Devices
{
    public interface IDeviceWithBlueAndRedBacklightLEDs : IDevice
    {
        void SetBacklightIntensity(byte blue, byte red);
    }
}