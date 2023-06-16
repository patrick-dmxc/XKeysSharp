using PIEHidNetCore;
using System.ComponentModel;

namespace XKeysSharp.Devices
{
    public abstract class AbstractXKDevice : AbstractDevice, IDeviceWithRedLED, IDeviceWithGreenLED, IDeviceWithFlashingLEDs
    {

        public override event PropertyChangedEventHandler? PropertyChanged;

        protected override AbstractDevice createFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = createXKDeviceFromPIEDevice(pieDevice);
            return instance;
        }
        protected abstract AbstractXKDevice createXKDeviceFromPIEDevice(PIEDevice pieDevice);

        protected override void HandleData(byte[] data)
        {
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