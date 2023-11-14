using System.ComponentModel;

namespace XKeysSharp.Devices.Resolver
{
    public interface IResolver : INotifyPropertyChanged
    {
        void Resolve(byte[] data);
    }
}
