namespace XKeysSharp.Devices
{
    public interface IDeviceWithRGBBacklightLEDs : IDevice
    {
        void SetBacklightIntensity(byte bank1, byte bank2);
        void SetEntireBacklightUpper(byte red, byte green, byte blue);
        void SetEntireBacklightLower(byte red, byte green, byte blue);
    }
}