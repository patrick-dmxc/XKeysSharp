using System.ComponentModel;

namespace XKeysSharp.Devices.Resolver
{
    public class SerialNumberResolver : AbstractResolver
    {
        private string? serialNumber;
        public string? SerialNumber
        {
            get { return serialNumber; }
            private set
            {
                if (string.Equals(serialNumber, value))
                    return;
                    serialNumber = value;
                this.PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(SerialNumber)));
            }
        }

        public override event PropertyChangedEventHandler? PropertyChanged;

        public override void Resolve(byte[] data)
        {
            if (data[2] == 159)
                SerialNumber = $"{data[3]}{data[4]}{data[5]}{data[6]}{data[7]}{data[8]}";
        }
    }
}
