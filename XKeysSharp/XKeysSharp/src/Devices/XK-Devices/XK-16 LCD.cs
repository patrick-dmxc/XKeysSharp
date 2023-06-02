using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XK_16LCD : AbstractXKDeviceWithBlueAndRedBacklightLEDs, IDeviceWithLCD
    {
        public override int[] PIDs => new int[] { 1316, 1317, 1318, 1319, 1320, 1321, 1322, 1323 };
        public override string Name => "XK-16 LCD";
        protected override uint ButtonsCount => 16;

        protected override AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XK_16LCD();
            return instance;
        }

        public void SetLCDTopText(string text, bool backlightOn)
        {
            byte[] buffer = new byte[16];
            for (byte i = 0; i < 16; i++)
                buffer[i] = 32;

            for (int i = 0; i < text.Length; i++)
                buffer[i + 4] = (byte)text[i];

            WriteData(0,
                      0xce,
                      0,
                      (byte)(backlightOn ? 1 : 0),
                      buffer[0],
                      buffer[1],
                      buffer[2],
                      buffer[3],
                      buffer[4],
                      buffer[5],
                      buffer[6],
                      buffer[7],
                      buffer[8],
                      buffer[9],
                      buffer[10],
                      buffer[11],
                      buffer[12],
                      buffer[13],
                      buffer[14],
                      buffer[15]);
        }

        public void SetLCDBottomText(string text, bool backlightOn)
        {
            byte[] buffer = new byte[16];
            for (byte i = 0; i < 16; i++)
                buffer[i] = 32;

            for (int i = 0; i < text.Length; i++)
                buffer[i + 4] = (byte)text[i];

            WriteData(0,
                      0xce,
                      1,
                      (byte)(backlightOn ? 1 : 0),
                      buffer[0],
                      buffer[1],
                      buffer[2],
                      buffer[3],
                      buffer[4],
                      buffer[5],
                      buffer[6],
                      buffer[7],
                      buffer[8],
                      buffer[9],
                      buffer[10],
                      buffer[11],
                      buffer[12],
                      buffer[13],
                      buffer[14],
                      buffer[15]);
        }
    }
}