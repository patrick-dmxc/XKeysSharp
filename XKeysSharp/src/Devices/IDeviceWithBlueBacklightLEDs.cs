namespace XKeysSharp.Devices
{
    public interface IDeviceWithBlueBacklightLEDs
    {
        void SetBacklightIntensity(byte blue);
    }
}