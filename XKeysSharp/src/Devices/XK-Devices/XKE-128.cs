using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XKE_128 : AbstractXKDeviceWithBlueAndRedBacklightLEDs
    {
        public override int[] PIDs => new int[] { 1227, 1228, 1229, 1230, 1290, 1291 };
        public override string Name => "XKE-128";
        protected override uint ButtonsCount => 128;

        protected override AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XKE_128();
            return instance;
        }
    }
}