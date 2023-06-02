namespace XKeysSharp.Devices
{
    public interface IDeviceWithTBar
    {
        double? TBarPosition { get; }
        byte TBarResolverIndex { get; }
    }
}
