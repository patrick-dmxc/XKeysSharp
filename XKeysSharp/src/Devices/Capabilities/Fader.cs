using PIEHidNetCore;
using System.ComponentModel;

namespace XKeysSharp
{
    public class Fader : IFader
    {
        protected readonly PIEDevice PIEDevice;
        public event PropertyChangedEventHandler? PropertyChanged;
        private byte position = 0;
        public byte Position
        {
            get
            {
                return position;
            }
            internal set
            {
                if (position == value)
                    return;
                position = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Position)));
            }
        }

        public void SetPosition(bool position)
        {

        }


        public uint Number { get; private set; }
        public uint Count { get; private set; }

        private bool touched;
        public bool Touched
        {
            get
            {
                return touched;
            }
            internal set
            {
                if (touched == value)
                    return;
                touched = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Position)));
            }
        }

        public Fader(in PIEDevice pIEDevice, in uint number, in uint count)
        {
            PIEDevice = pIEDevice;
            Number = number;
            Count = count;
        }
    }
}