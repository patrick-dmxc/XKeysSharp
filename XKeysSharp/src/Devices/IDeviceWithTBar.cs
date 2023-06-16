namespace XKeysSharp.Devices
{
    public interface IDeviceWithTBar : IDevice
    {
        double? TBarPosition { get; }
        byte TBarResolverIndex { get; }
    }
}