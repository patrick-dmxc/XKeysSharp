using System.ComponentModel;

namespace XKeysSharp.Devices.Resolver
{
    public class FirmwareVersionResolver : AbstractResolver
    {
        private byte? firmwareVersion;
        public byte? FirmwareVersion
        {
            get { return firmwareVersion; }
            private set
            {
                if (firmwareVersion == value)
                    return;
                firmwareVersion = value;
                this.PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(FirmwareVersion)));
            }
        }

        public override event PropertyChangedEventHandler? PropertyChanged;

        public override void Resolve(byte[] data)
        {
            if (data[2] == 214)
                FirmwareVersion = data[11];
        }
    }
}
