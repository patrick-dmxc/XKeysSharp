using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XBA_JogShuttle : AbstractXBADeviceWithRGBBacklightLEDs, IDeviceWithJogShuttle
    {
        public override int[] PIDs => new int[] { 1388, 1389, 1390, 1391, 1392, 1363, 1394, 1395 };
        public override string Name => "XBA-Jog Shuttle";

        public byte JogAnalogResolverIndex => 12;
        public byte ShuttleAnalogResolverIndex => 13;

        public long? Jog => jogShuttleResolver?.Jog;
        public double? Shuttle => jogShuttleResolver?.Shuttle;

        protected override uint ButtonsCount => 12;

        protected override AbstractXBADeviceWithRGBBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XBA_JogShuttle();
            return instance;
        }
    }
}