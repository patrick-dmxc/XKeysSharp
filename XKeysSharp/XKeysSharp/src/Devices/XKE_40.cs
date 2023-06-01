using PIEHidNetCore;
using System;
using System.ComponentModel;
using XKeysSharp.Devices.Resolver;

namespace XKeysSharp.Devices
{
    public class XKE_40 : AbstractDevice, INotifyPropertyChanged, IDeviceWithRedLED, IDeviceWithGreenLED
    {
        public override string Name => "XKE-40";
        private List<Button> buttons = new List<Button>();

        private XKE_ButtonResolver? buttonResolver;
        public override IReadOnlyCollection<Button>? Buttons => buttonResolver?.Buttons;

        public event PropertyChangedEventHandler? PropertyChanged;
        public byte Firmware { get; private set; }

        protected override AbstractDevice createFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XKE_40();
            instance.buttonResolver = new XKE_ButtonResolver(40);
            instance.addResolver(instance.buttonResolver!);
            return instance;
        }

        protected override void HandleData(byte[] data)
        {

            if (data[2] < 4)
            {
                int maxcols = 5;
                int maxrows = 8;
                for (int i = 0; i < maxcols; i++)
                {
                    for (int j = 0; j < maxrows; j++)
                    {
                        int keynum = 8 * i + j;
                        var button = buttons.FirstOrDefault(b => b.Number == keynum);
                        if (button != null)
                            button.ButtonState = (byte)(data[i + 3] & (int)Math.Pow(2, j)) == 0 ? EButtonState.Up : EButtonState.Down;
                    }
                }
            }
        }
        public void SetBacklightIntensity(byte blue, byte red)
        {
            WriteData(0, 187, blue, red);
        }

        public void SetBacklightState(byte index, ELEDState state)
        {
            WriteData(0, 181, index, (byte)state);
        }

        public void SetRedLEDState(ELEDState state)
        {
            WriteData(0, 179, 7, (byte)state);
        }

        public void SetGreenLEDState(ELEDState state)
        {
            WriteData(0, 179, 6, (byte)state);
        }

        public void SetFlashFrequency(byte speed)
        {
            WriteData(0, 180, speed);
        }
    }
}