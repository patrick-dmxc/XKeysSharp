using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XK_12JogShuttle : AbstractXKDeviceWithBlueAndRedBacklightLEDs, IDeviceWithJogShuttle
    {
        public override int[] PIDs => new int[] { 1062, 1063, 1064 };
        public override string Name => "XK-12 Jog Shuttel";

        public byte JogAnalogResolverIndex => 7;
        public byte ShuttleAnalogResolverIndex => 8;

        public long? Jog => jogShuttleResolver?.Jog;
        public double? Shuttle => jogShuttleResolver?.Shuttle;

        protected override uint ButtonsCount => 12;
        protected override uint[]? UnavailableButtons => new uint[] { 3, 4, 5, 6, 7, 11, 12, 13, 14, 15, 19, 20, 21, 22, 23, 27, 28, 29, 30, 31 };

        protected override AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XK_12JogShuttle();
            return instance;
        }
    }
}