namespace XKeysSharp.Devices
{
    public interface IDeviceWithButtons<out T> : IDevice where T : IButton
    {
        IReadOnlyCollection<T>? Buttons { get; }
    }
}