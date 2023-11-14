namespace XKeysSharp
{
    public interface IButtonWithRedLED : IButton
    {
        void SetRedLEDState(ELEDState state);
    }
}
