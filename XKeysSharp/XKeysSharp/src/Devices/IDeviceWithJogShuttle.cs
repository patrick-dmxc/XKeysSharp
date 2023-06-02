namespace XKeysSharp.Devices
{
    public interface IDeviceWithJogShuttle
    {
        long? Jog { get; }
        double? Shuttle { get; }
        byte JogAnalogResolverIndex { get; }
        byte ShuttleAnalogResolverIndex { get; }
    }
}
