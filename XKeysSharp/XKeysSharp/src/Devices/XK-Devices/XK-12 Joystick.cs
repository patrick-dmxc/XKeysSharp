﻿using PIEHidNetCore;

namespace XKeysSharp.Devices
{
    public class XK_12Joystick : AbstractXKDeviceWithBlueAndRedBacklightLEDs
    {
        public override int[] PIDs => new int[] { 1065, 1067 };
        public override string Name => "XK-12 Joystick";
        protected override uint ButtonsCount => 12;

        protected override AbstractXKDeviceWithBlueAndRedBacklightLEDs internalCreateXKDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var instance = new XK_12Joystick();
            return instance;
        }
    }
}