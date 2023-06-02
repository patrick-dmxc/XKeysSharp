using System.ComponentModel;

namespace XKeysSharp.Devices.Resolver
{
    public class TBarResolver : AbstractResolver
    {
        public readonly byte ResolverIndex;

        public override event PropertyChangedEventHandler? PropertyChanged;

        private byte? tBar;
        public byte? TBar
        {
            get { return tBar; }
            private set
            {
                if (string.Equals(tBar, value))
                    return;
                tBar = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TBar)));
            }
        }

        public TBarResolver(in byte resolverIndex)
        {
            ResolverIndex = resolverIndex;
        }

        public override void Resolve(byte[] data)
        {
            if (data[2] < 4)
            {
                TBar = data[ResolverIndex];
            }
        }
    }
}