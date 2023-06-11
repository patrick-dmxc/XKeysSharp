using System.ComponentModel;

namespace XKeysSharp
{
    public interface IButton : INotifyPropertyChanged
    {
        uint Number { get; }
        uint Count { get; }
        EButtonState ButtonState { get; }
    }
}
