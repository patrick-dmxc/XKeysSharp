using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XKE_64_Jog_TBar : AbstractXKDeviceWithBlueAndRedBacklightLEDs, IDeviceWithJogShuttle, IDeviceWithTBar
    {
        public override int[] PIDs => new int[] { 1325, 1326, 1327, 1328, 1329, 1330, 1331, 1332 };
        public override string Name => "XKE-64 Jog T-bar";

        public byte TBarResolverIndex => 18;

        public byte JogAnalogResolverIndex => 19;
        public byte ShuttleAnalogResolverIndex => 20;

        protected override uint ButtonsCount => 64;
        protected override uint[]? UnavailableButtons => new uint[] { 5, 6, 7, 13, 14, 15, 21, 22, 23, 29, 30, 31, 72, 73, 74, 75 };

        protected override AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XKE_64_Jog_TBar();
            return instance;
        }
    }
}