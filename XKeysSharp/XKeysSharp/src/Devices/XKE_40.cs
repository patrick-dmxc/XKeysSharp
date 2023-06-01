using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    internal class XKE_40 : AbstractDevice
    {
        public override string Name => "XKE-40";
        protected override AbstractDevice createFromPIEDevice(PIEDevice pieDevice)
        {

            var instance= new XKE_40();
            return instance;
        }
    }
}
