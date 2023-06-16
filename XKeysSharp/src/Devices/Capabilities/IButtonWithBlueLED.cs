namespace XKeysSharp
{
    public interface IButtonWithBlueLED : IButton
    {
        void SetBlueLEDState(ELEDState state);
    }
}