// See https://aka.ms/new-console-template for more information
using XKeys = XKeysSharp.XKeysSharp;

Console.WriteLine("Hello, World!");

var devices = XKeys.Instance.getAllDevices();
foreach (var device in devices)
    device.Connect();
foreach (var device in devices.OfType<XKeysSharp.Devices.AbstractXKDeviceWithBlueAndRedBacklightLEDs>())
{
    device.RequestSerialNumber();
    Task.Run(async () =>
    {
        for (int i = 0; i < 10; i++)
        {
            device.SetGreenLEDState(XKeysSharp.ELEDState.ON);
            device.SetRedLEDState(XKeysSharp.ELEDState.OFF);
            await Task.Delay(100);
            device.SetGreenLEDState(XKeysSharp.ELEDState.OFF);
            device.SetRedLEDState(XKeysSharp.ELEDState.ON);
            await Task.Delay(100);
        }
    });
    Task.Run(async () =>
        {
            device.SetBacklightIntensity(255, 255);
            for (int i = 0; i < 10; i++)
            {
                foreach (var button in device.Buttons)
                    button.SetBlueLEDState(XKeysSharp.ELEDState.ON);

                await Task.Delay(100);

                foreach (var button in device.Buttons)
                    button.SetBlueLEDState(XKeysSharp.ELEDState.OFF);

                await Task.Delay(100);

                foreach (var button in device.Buttons)
                    button.SetRedLEDState(XKeysSharp.ELEDState.ON);

                await Task.Delay(100);

                foreach (var button in device.Buttons)
                    button.SetRedLEDState(XKeysSharp.ELEDState.OFF);

                await Task.Delay(100);
            }

            foreach (var button in device.Buttons)
            {
                button.SetBlueLEDState(XKeysSharp.ELEDState.ON);
                button.SetRedLEDState(XKeysSharp.ELEDState.ON);
            }
            for (byte b = 0; b < byte.MaxValue; b++)
            {
                device.SetBacklightIntensity(b, (byte)(byte.MaxValue - b));
                await Task.Delay(10);
            }


            device.SetBacklightIntensity(byte.MaxValue, byte.MaxValue);
            foreach (var button in device.Buttons)
            {
                button.SetBlueLEDState(XKeysSharp.ELEDState.FLASH);
                button.SetRedLEDState(XKeysSharp.ELEDState.FLASH);
            }
            for (byte b = 0; b < byte.MaxValue; b+=5)
            {
                device.SetFlashFrequency((byte)(byte.MaxValue - b));
                await Task.Delay(100);
            }


            foreach (var button in device.Buttons)
            {
                button.SetBlueLEDState(XKeysSharp.ELEDState.OFF);
                button.SetRedLEDState(XKeysSharp.ELEDState.OFF);
            }

            foreach (var button in device.Buttons)
            {
                if (button.Number % 2 == 0)
                {
                    button.SetBlueLEDState(XKeysSharp.ELEDState.OFF);
                    button.SetRedLEDState(XKeysSharp.ELEDState.ON);
                }
                else
                {
                    button.SetBlueLEDState(XKeysSharp.ELEDState.ON);
                    button.SetRedLEDState(XKeysSharp.ELEDState.OFF);
                }
                await Task.Delay(100);
            }
        });
}
while (true)
    Console.ReadLine();