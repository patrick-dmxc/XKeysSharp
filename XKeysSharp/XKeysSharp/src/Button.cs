using System.ComponentModel;

namespace XKeysSharp
{
    public class Button : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        private EButtonState buttonState = EButtonState.Up;
        public EButtonState ButtonState
        {
            get
            {
                return buttonState;
            }
            internal set
            {
                if (buttonState == value)
                    return;
                buttonState = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ButtonState)));
            }
        }

        public uint Number { get; private set; }

        public Button(uint number)
        {
            Number = number;
        }
    }
    public enum EButtonState
    {
        Up=0,
        Down=1
    }
}
