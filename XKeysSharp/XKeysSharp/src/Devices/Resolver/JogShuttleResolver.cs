using System.ComponentModel;

namespace XKeysSharp.Devices.Resolver
{
    public class JogShuttleResolver : AbstractResolver
    {
        public readonly byte JogIndex;
        public readonly byte ShuttleIndex;

        public override event PropertyChangedEventHandler? PropertyChanged;

        private byte? jog;
        public byte? Jog
        {
            get { return jog; }
            private set
            {
                if (string.Equals(jog, value))
                    return;
                jog = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Jog)));
            }
        }
        private byte? shuttle;
        public byte? Shuttle
        {
            get { return shuttle; }
            private set
            {
                if (string.Equals(shuttle, value))
                    return;
                shuttle = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Shuttle)));
            }
        }

        public JogShuttleResolver(in byte jogIndex, in byte shuttleIndex)
        {
            JogIndex = jogIndex;
            ShuttleIndex = shuttleIndex;
        }

        public override void Resolve(byte[] data)
        {
            if (data[2] < 4)
            {
                Jog = data[JogIndex];
                Shuttle = data[ShuttleIndex];
            }
        }
    }
}