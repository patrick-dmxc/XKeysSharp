using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XK_68JogShuttle : AbstractXKDeviceWithBlueAndRedBacklightLEDs, IDeviceWithJogShuttle
    {
        public override int[] PIDs => new int[] { 1115, 1114, 1116 };
        public override string Name => "XK-68 Jog Shuttel";

        public byte JogAnalogResolverIndex => 17;
        public byte ShuttleAnalogResolverIndex => 19;

        public long? Jog => jogShuttleResolver?.Jog;
        public double? Shuttle => jogShuttleResolver?.Shuttle;

        protected override uint ButtonsCount => 68;
        protected override uint[]? UnavailableButtons => new uint[] { 29, 30, 31, 37, 38, 39, 45, 46, 47, 53, 54, 55 };

        protected override AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XK_68JogShuttle();
            return instance;
        }
    }
}