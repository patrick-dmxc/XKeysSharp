using Microsoft.Extensions.Logging;
using PIEHidNetCore;
using System;
using System.IO;
using XKeysSharp.Devices;

namespace XKeysSharp
{
    public class XKeysSharp
    {
        private static ILogger<XKeysSharp>? _logger = null;
        private static XKeysSharp? instance;
        public static XKeysSharp Instance
        {
            get
            {
                if (instance == null)
                    instance = new XKeysSharp();
                return instance;
            }
        }

        public event EventHandler<IDevice> Connected;
        public event EventHandler<IDevice> Disconnected;
        private List<IDeviceP> devices= new List<IDeviceP>();
        private List<string> deadEndPath= new List<string>();
        public IReadOnlyCollection<IDevice> Devices
        {
            get
            {
                return devices.AsReadOnly();
            }
        }
        private Thread loopThread;
        private static List<AbstractDevice> deviceTypes { get; } = new();

        private XKeysSharp()
        {
            ApplicationLogging.LoggerFactory = Tools.LoggerFactory;
            _logger = ApplicationLogging.CreateLogger<XKeysSharp>();
            findDeviceTypes();
            loopThread = new Thread(
                async () =>
                {
                    do
                    {
                        await Task.Delay(2000);
                        var pds = PIEDevice.EnumeratePIE();
                        foreach (var pd in pds)
                        {
                            bool any;
                            lock (devices)
                                any = devices.Any(d => d.PIEDevice!.Path.Equals(pd.Path));
                            if (!any)
                            {

                                var _new = createDeviceFromPIEDevice(pd);
                                if (_new == null)
                                    break;

                                await _new.Connect();
                                if (string.IsNullOrWhiteSpace(_new.SerialNumber))
                                    break;

                                lock (devices)
                                    devices.Add(_new);
                                Connected?.Invoke(this, _new);

                            }
                        }

                        lock (devices)
                            foreach (var path in devices.Select(d => d.PIEDevice!.Path).ToArray())
                            {
                                if (!pds.Any(pd => pd.Path.Equals(path)))
                                {
                                    var devs = devices.Where(d => d.PIEDevice!.Path.Equals(path)).ToArray();
                                    foreach (var d in devs)
                                    {
                                        devices.Remove(d);
                                        Disconnected?.Invoke(this, d);
                                    }
                                }
                            }
                    }
                    while (true);
                });
            loopThread.IsBackground = true;
            loopThread.Name = "XKeysSharp";
            loopThread.Start();
        }
        private void findDeviceTypes()
        {
            try
            {
                var type = typeof(AbstractDevice);
                var assamblys = AppDomain.CurrentDomain.GetAssemblies().Where(s => !(s.FullName.StartsWith("System.") || s.FullName.StartsWith("Microsoft.") || s.FullName.StartsWith("net") || s.FullName.StartsWith("NAudio"))).ToList();
                List<Type> types = new();
                foreach(var a in assamblys)
                {
                    try
                    {
                        types.AddRange(a.GetTypes());
                    }
                    catch(Exception e)
                    {
                        _logger?.LogError(e, a.FullName);
                    }
                }
                types = types
                    .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface).ToList();

                _logger?.Log(LogLevel.Information, "Search DeviceTypes");
                foreach (var t in types)
                    RegisterDeviceType(t);
            }
            catch(Exception ex)
            {
                _logger?.LogError(ex, string.Empty);
            }
        }
        public void RegisterDeviceType(Type type)
        {
            try
            {
                if (type.GetConstructors().Any(c => c.GetParameters().Length == 0))
                {
                    _logger?.Log(LogLevel.Information, $"Registered: {type.Name}");
                    AbstractDevice? instance = (AbstractDevice?)Activator.CreateInstance(type);
                    if (instance != null)
                        deviceTypes.Add(instance);
                }
                else
                {
                    _logger?.Log(LogLevel.Information, $"NOT Registered: {type.Name}");
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, string.Empty);
            }
        }

        private IEnumerable<IDevice> getAllDevices()
        {
            List<IDevice> result = new();
            var pieDevices = PIEDevice.EnumeratePIE();

            foreach (var pieDevice in pieDevices)
            {
                var device = createDeviceFromPIEDevice(pieDevice);
                if (device != null)
                    result.Add(device);
            }

            return result.AsReadOnly();
        }

        private static AbstractDevice? createDeviceFromPIEDevice(PIEDevice pieDevice)
        {
            var deviceType = deviceTypes.FirstOrDefault(dt => dt.Name.Equals(pieDevice.ProductString));

            if (deviceType != null)
                return deviceType.CreateFromPIEDevice(pieDevice);
            else
                _logger?.Log(LogLevel.Information, $"NO DeviceType found for : {pieDevice.ProductString}. Contact the Developer of this Code");

            return null;
        }
    }
}