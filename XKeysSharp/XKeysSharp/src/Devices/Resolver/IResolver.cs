using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XKeysSharp.Devices.Resolver
{
    public interface IResolver:INotifyPropertyChanged
    {
        void Resolve(byte[] data);
    }
}
