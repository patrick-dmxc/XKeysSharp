using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public abstract class AbstractDevice : IDevice
    {
        public abstract string Name { get; }

        protected PIEDevice? PIEDevice { get; private set; } = null;
        public bool IsDummy { get { return PIEDevice == null; } }

        public AbstractDevice() { }
        internal AbstractDevice CreateFromPIEDevice(PIEDevice pieDevice)
        {
            if(!IsDummy)
                throw new NotSupportedException("Create new Instances is only allowed by Dummys");
            var instance= createFromPIEDevice(pieDevice);
            instance.PIEDevice = pieDevice;
            return instance;
        }
        protected abstract AbstractDevice createFromPIEDevice(PIEDevice pieDevice);
    }
}
