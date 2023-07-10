using System.ComponentModel;

namespace XKeysSharp
{
    public interface IFader : INotifyPropertyChanged
    {
        uint Number { get; }
        uint Count { get; }
        byte Position { get; }
        void SetPosition(bool position);
        bool Touched { get; }
    }
}