using Microsoft.Extensions.Logging;
using PIEHidNetCore;
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
        private static List<AbstractDevice> deviceTypes { get; } = new();

        private XKeysSharp() 
        {
            ApplicationLogging.LoggerFactory= Tools.LoggerFactory;
            _logger = ApplicationLogging.CreateLogger<XKeysSharp>();
            findDeviceTypes();
        }
        private void findDeviceTypes()
        {
            try
            {
                var type = typeof(AbstractDevice);
                var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
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

        public IEnumerable<IDevice> getAllDevices()
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