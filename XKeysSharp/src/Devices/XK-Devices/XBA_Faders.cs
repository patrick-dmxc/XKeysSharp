using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XBAFaders : AbstractXBADeviceWithRGBBacklightLEDs, IDeviceWithFaders
    {
        public override int[] PIDs => new int[] { 1480, 1481, 1482, 1483, 1484, 1485, 1486, 1487 };
        public override string Name => "XBA-Faders";
        public uint FadersCount => 4;
        public IReadOnlyCollection<IFader>? Faders => faderResolver?.Faders;

        protected override uint ButtonsCount => 4;

        protected override AbstractXBADeviceWithRGBBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XBAFaders();
            return instance;
        }
    }
}