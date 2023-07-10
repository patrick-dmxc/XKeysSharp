namespace XKeysSharp
{
    public interface IButtonWithRGBLED : IButton
    {
        void SetUpperLEDState(byte red, byte green, byte blue, ELEDState state);
        void SetLowerLEDState(byte red, byte green, byte blue, ELEDState state);
    }
}