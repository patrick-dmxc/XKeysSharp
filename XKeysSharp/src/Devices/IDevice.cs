﻿using System.ComponentModel;

namespace XKeysSharp.Devices
{
    public interface IDevice: INotifyPropertyChanged
    {
        string Name { get; }
        string? SerialNumber { get; }
        byte? FirmwareVersion { get; }
        void Connect();
    }
}
