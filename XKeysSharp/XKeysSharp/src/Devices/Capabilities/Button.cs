using PIEHidNetCore;
using System.ComponentModel;

namespace XKeysSharp
{
    public class Button : IButton
    {
        protected readonly PIEDevice PIEDevice;
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
        public uint Count { get; private set; }

        public Button(in PIEDevice pIEDevice, in uint number, in uint count)
        {
            PIEDevice = pIEDevice;
            Number = number;
            Count = count;
        }
        protected void WriteData(params byte[] data)
        {

            if (PIEDevice == null)
                return;
            var wData = new byte[PIEDevice.WriteLength];
            for (int i = 0; i < Math.Min(data.Length, wData.Length); i++)
                wData[i] = data[i];
            int result = 404;

            while (result == 404) { result = PIEDevice.WriteData(wData); }
            //if (result != 0)
            //    throw new Exception(((EErrorMessage)result).ToString());
        }
    }
    public class ButtonWithBlueLED : Button, IButtonWithBlueLED
    {
        public ButtonWithBlueLED(in PIEDevice pIEDevice, in uint number, in uint count) : base(pIEDevice, number, count)
        {
        }

        public void SetBlueLEDState(ELEDState state)
        {
            WriteData(0, 181, (byte)this.Number, (byte)state);
        }
    }
    public class ButtonWithBlueAndRedLED : ButtonWithBlueLED, IButtonWithBlueAndRedLED
    {
        public ButtonWithBlueAndRedLED(in PIEDevice pIEDevice, in uint number, in uint count) : base(pIEDevice, number, count)
        {
        }

        public void SetRedLEDState(ELEDState state)
        {
            WriteData(0, 181, (byte)(this.Number + this.Count), (byte)state);
        }
    }
    public class ButtonWithRGBLED : Button, IButtonWithRGBLED
    {
        public ButtonWithRGBLED(in PIEDevice pIEDevice, in uint number, in uint count) : base(pIEDevice, number, count)
        {
        }
    }
}
