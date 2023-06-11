using System.ComponentModel;

namespace XKeysSharp.Devices.Resolver
{
    public class JoystickResolver : AbstractResolver
    {
        public readonly byte? XIndex;
        public readonly byte? YIndex;
        public readonly byte? ZIndex;

        public override event PropertyChangedEventHandler? PropertyChanged;

        private byte? x;
        public byte? X
        {
            get { return x; }
            private set
            {
                if (string.Equals(x, value))
                    return;
                x = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(X)));
            }
        }
        private byte? y;
        public byte? Y
        {
            get { return y; }
            private set
            {
                if (string.Equals(y, value))
                    return;
                y = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Y)));
            }
        }
        private byte? z;
        public byte? Z
        {
            get { return z; }
            private set
            {
                if (string.Equals(z, value))
                    return;
                z = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Z)));
            }
        }

        public JoystickResolver(in byte? xIndex, in byte? yIndex, in byte? zIndex)
        {
            XIndex = xIndex;
            YIndex = yIndex;
            ZIndex = zIndex;
        }

        public override void Resolve(byte[] data)
        {
            if (data[2] < 4)
            {
                if (XIndex != null)
                    X = data[XIndex.Value];
                if (YIndex != null)
                    Y = data[YIndex.Value];
                if (ZIndex != null)
                    Z = data[ZIndex.Value];
            }
        }
    }
}