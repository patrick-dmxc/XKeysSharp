// See https://aka.ms/new-console-template for more information
using XKeys = XKeysSharp.XKeysSharp;

Console.WriteLine("Hello, World!");

var devices = XKeys.Instance.getAllDevices();
foreach (var device in devices)
    device.Connect();
foreach (var device in devices.OfType<XKeysSharp.Devices.XKE_40>())
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
}
while (true)
    Console.ReadLine();