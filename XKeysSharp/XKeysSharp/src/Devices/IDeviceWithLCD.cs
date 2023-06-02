namespace XKeysSharp.Devices
{
    public interface IDeviceWithLCD
    {
        void SetLCDTopText(string text, bool backlightOn);
        void SetLCDBottomText(string text, bool backlightOn);
    }
}
