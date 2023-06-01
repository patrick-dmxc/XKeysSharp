using System.ComponentModel;

namespace XKeysSharp.Devices.Resolver
{
    public abstract class AbstractResolver : IResolver
    {
        public abstract event PropertyChangedEventHandler? PropertyChanged;
        public abstract void Resolve(byte[] data);
    }
}
