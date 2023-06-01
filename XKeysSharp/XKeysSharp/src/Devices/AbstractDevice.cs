using PIEHidNetCore;
using XKeysSharp.Devices.Resolver;
using XKeysSharp.src;

namespace XKeysSharp.Devices
{
    public abstract class AbstractDevice : IDevice, PIEDataHandler, PIEErrorHandler
    {
        public abstract string Name { get; }

        protected PIEDevice? PIEDevice { get; private set; } = null;
        public bool IsDummy { get { return PIEDevice == null; } }

        public virtual IReadOnlyCollection<Button>? Buttons { get; }

        public event EventHandler<EErrorMessage>? Error;

        private List<IResolver> resolvers = new List<IResolver>();

        protected virtual SerialNumberResolver snResolver { get; set; } = new SerialNumberResolver();
        public string? SerialNumber
        {
            get
            {
                return snResolver?.SerialNumber;
            }
        }


        protected virtual FirmwareVersionResolver fwResolver { get; set; } = new FirmwareVersionResolver();
        public byte? FirmwareVersion
        {
            get
            {
                return fwResolver?.FirmwareVersion;
            }
        }

        public AbstractDevice() { }
        internal AbstractDevice CreateFromPIEDevice(PIEDevice pieDevice)
        {
            if (!IsDummy)
                throw new NotSupportedException("Create new Instances is only allowed by Dummys");
            var instance = createFromPIEDevice(pieDevice);
            instance.PIEDevice = pieDevice;
            instance.addResolver(snResolver);
            instance.addResolver(fwResolver);
            return instance;
        }
        protected abstract AbstractDevice createFromPIEDevice(PIEDevice pieDevice);

        protected void addResolver(IResolver resolver)
        {
            if (resolver == null)
                return;
            if (resolvers.Contains(resolver))
                return;
            resolvers.Add(resolver);
        }
        public void Connect()
        {
            if (PIEDevice == null)
                throw new NullReferenceException($"{nameof(PIEDevice)} is null");

            PIEDevice.SetupInterface();
            PIEDevice.SetErrorCallback(this);
            PIEDevice.SetDataCallback(this);
            RequestDescriptor();
            RequestData();
        }

        public void HandlePIEHidData(byte[] data, PIEDevice sourceDevice, int error)
        {
            if (sourceDevice != this.PIEDevice)
                return;

            resolvers.ForEach(resolver => resolver?.Resolve(data));
            HandleData(data);
        }
        protected abstract void HandleData(byte[] data);

        public void HandlePIEHidError(PIEDevice sourceDevices, int error)
        {
            this.Error?.Invoke(this, (EErrorMessage)error);
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


        public virtual void Reboot()
        {
            WriteData(0, 238);
        }

        public virtual void RequestDescriptor()
        {
            WriteData(0, 214);
        }

        public virtual void RequestData()
        {
            WriteData(0, 117);
        }

        public virtual void RequestSerialNumber()
        {
            WriteData(0, 159);
        }
    }
}
