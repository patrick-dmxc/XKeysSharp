using PIEHidNetCore;
using System.ComponentModel;

namespace XKeysSharp.Devices.Resolver
{
    public class XK_ButtonResolver<T> : AbstractResolver where T : Button
    {
        public byte? MaxColumns { get; private set; }
        public byte? MaxRows { get; private set; }

        private List<T> buttons = new List<T>();
        public IReadOnlyCollection<T>? Buttons => buttons.AsReadOnly();

        public override event PropertyChangedEventHandler? PropertyChanged;

        public XK_ButtonResolver(in PIEDevice pIEDevice, in uint buttonsCount, uint[]? unavailableButtonIndexes = null)
        {
            uint offset = 0;
            uint index = 0;
            for (uint i = 0; i < buttonsCount; i++)
            {
                index = i + offset;
                if (unavailableButtonIndexes != null)
                    while (unavailableButtonIndexes.Any(u => u == index))
                    {
                        offset++;
                        index = i + offset;
                    }
                T button = (T)Activator.CreateInstance(typeof(T), pIEDevice, index, buttonsCount)!;
                buttons.Add(button);
            }
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
                for (int i = 0; i < MaxColumns; i++)
                {
                    for (int j = 0; j < MaxRows; j++)
                    {
                        int keynum = 8 * i + j;
                        var button = buttons.FirstOrDefault(b => b.Number == keynum);
                        if (button != null)
                            button.ButtonState = (byte)(data[i + 3] & (int)Math.Pow(2, j)) == 0 ? EButtonState.Up : EButtonState.Down;
                    }
                }
            }
        }
    }
}