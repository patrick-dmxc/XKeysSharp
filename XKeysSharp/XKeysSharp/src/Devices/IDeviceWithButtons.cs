namespace XKeysSharp.Devices
{
    public interface IDeviceWithButtons<T> where T : IButton
    {
        IReadOnlyCollection<T>? Buttons { get; }
    }
}
