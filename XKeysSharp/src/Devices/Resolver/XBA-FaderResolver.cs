using PIEHidNetCore;
using System.ComponentModel;

namespace XKeysSharp.Devices.Resolver
{
    public class XBA_FaderResolver : AbstractResolver
    {
        public byte? MaxColumns { get; private set; }
        public byte? MaxRows { get; private set; }

        private List<Fader> faders = new List<Fader>();
        public IReadOnlyCollection<IFader>? Faders => faders.AsReadOnly();

        public override event PropertyChangedEventHandler? PropertyChanged;

        public XBA_FaderResolver(in PIEDevice pIEDevice, in uint fadersCount)
        {
            for (uint i = 0; i < fadersCount; i++)
                faders.Add(new Fader(pIEDevice, i, fadersCount));
        }

        public override void Resolve(byte[] data)
        {
            if (data[2] == 214 && (MaxRows == null || MaxColumns == null))
            {
                MaxColumns = data[8];
                MaxRows = data[9];
            }

            if (data[2] < 4 && MaxRows != null && MaxColumns != null)
            {
                bool[] boolArray = new bool[8];
                for (byte i = 0; i < 8; i++)
                    boolArray[i] = (data[3] & (1 << i)) != 0;

                foreach (Fader fader in faders)
                {
                    if (fader != null)
                    {
                        fader.Position = data[5 + fader.Number];
                        fader.Touched = boolArray[fader.Number];
                    }
                }
            }
        }
    }
}