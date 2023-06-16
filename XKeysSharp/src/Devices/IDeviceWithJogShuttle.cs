namespace XKeysSharp.Devices
{
    public interface IDeviceWithJogShuttle : IDevice
    {
        long? Jog { get; }
        double? Shuttle { get; }
        byte JogAnalogResolverIndex { get; }
        byte ShuttleAnalogResolverIndex { get; }
    }
}