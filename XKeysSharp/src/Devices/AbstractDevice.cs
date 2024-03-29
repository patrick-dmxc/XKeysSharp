﻿using PIEHidNetCore;
using System.ComponentModel;
using XKeysSharp.Devices.Resolver;
using XKeysSharp.src;

namespace XKeysSharp.Devices
{
    public abstract class AbstractDevice : IDevice, IDeviceP, PIEDataHandler, PIEErrorHandler
    {
        public abstract int[] PIDs { get; }
        public abstract string Name { get; }

        PIEDevice? IDeviceP.PIEDevice { get; set; } = null;
        public bool IsDummy { get { return ((IDeviceP)this).PIEDevice == null; } }

        public event EventHandler<EErrorMessage>? Error;
        public abstract event PropertyChangedEventHandler? PropertyChanged;

        private List<IResolver> resolvers = new List<IResolver>();

        protected virtual SerialNumberResolver snResolver { get; private set; }
        public string? SerialNumber
        {
            get
            {
                return snResolver?.SerialNumber;
            }
        }


        protected virtual FirmwareVersionResolver fwResolver { get; private set; }
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
            ((IDeviceP)instance).PIEDevice = pieDevice;
            instance.snResolver = new SerialNumberResolver();
            instance.fwResolver = new FirmwareVersionResolver();
            instance.addResolver(instance.snResolver);
            instance.addResolver(instance.fwResolver);
            instance.onCreated();
            return instance;
        }
        protected abstract AbstractDevice createFromPIEDevice(PIEDevice pieDevice);

        protected virtual void onCreated()
        {

        }

        protected void addResolver(IResolver resolver)
        {
            if (resolver == null)
                return;
            if (resolvers.Contains(resolver))
                return;
            resolvers.Add(resolver);
        }
        public async Task Connect()
        {
            if (((IDeviceP)this).PIEDevice == null)
                throw new NullReferenceException($"{nameof(PIEDevice)} is null");

            ((IDeviceP)this).PIEDevice.SetupInterface();
            ((IDeviceP)this).PIEDevice.SetErrorCallback(this);
            ((IDeviceP)this).PIEDevice.SetDataCallback(this);

            RequestSerialNumber();
            RequestDescriptor();
            RequestData();
            await Task.Delay(200);
        }

        public void HandlePIEHidData(byte[] data, PIEDevice sourceDevice, int error)
        {
            if (sourceDevice != ((IDeviceP)this).PIEDevice)
                return;

            resolvers.ForEach(resolver => resolver?.Resolve(data));
            HandleData(data);
        }
        protected virtual void HandleData(byte[] data)
        {
        }

        public void HandlePIEHidError(PIEDevice sourceDevices, int error)
        {
            this.Error?.Invoke(this, (EErrorMessage)error);
        }

        protected void WriteData(params byte[] data)
        {

            if (((IDeviceP)this).PIEDevice == null)
                return;
            var wData = new byte[((IDeviceP)this).PIEDevice.WriteLength];
            for (int i = 0; i < Math.Min(data.Length, wData.Length); i++)
                wData[i] = data[i];
            int result = 404;

            while (result == 404) { result = ((IDeviceP)this).PIEDevice.WriteData(wData); }
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
