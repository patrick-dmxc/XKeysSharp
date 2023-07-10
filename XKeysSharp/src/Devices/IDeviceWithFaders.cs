namespace XKeysSharp.Devices
{
    public interface IDeviceWithFaders : IDevice
    {
        uint FadersCount { get; }
        IReadOnlyCollection<IFader>? Faders { get; }
    }
}