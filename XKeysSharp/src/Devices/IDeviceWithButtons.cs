namespace XKeysSharp.Devices
{
    public interface IDeviceWithButtons<out T> where T : IButton
    {
        IReadOnlyCollection<T>? Buttons { get; }
    }
}