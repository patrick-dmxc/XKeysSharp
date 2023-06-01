using System.ComponentModel;

namespace XKeysSharp.Devices.Resolver
{
    public class XKE_ButtonResolver : AbstractResolver
    {
        public byte? MaxColumns { get; private set; }
        public byte? MaxRows { get; private set; }

        private List<Button> buttons = new List<Button>();
        public IReadOnlyCollection<Button>? Buttons => buttons.AsReadOnly();

        public override event PropertyChangedEventHandler? PropertyChanged;

        public XKE_ButtonResolver(in uint buttonsCount)
        {
            for (uint i = 0; i < buttonsCount; i++)
                buttons.Add(new Button(i));
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