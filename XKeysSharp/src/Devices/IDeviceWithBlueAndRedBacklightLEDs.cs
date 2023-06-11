namespace XKeysSharp.Devices
{
    public interface IDeviceWithBlueAndRedBacklightLEDs
    {
        void SetBacklightIntensity(byte blue, byte red);
    }
}