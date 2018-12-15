namespace GOoDcast.Device
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Rssdp;

    public static class DeviceLocator
    {
        private const string DeviceType = "urn:dial-multiscreen-org:device:dial:1";

        public static async Task<IReadOnlyCollection<DeviceInfo>> LocateDevicesAsync()
        {
            using (var locator = new SsdpDeviceLocator { NotificationFilter = DeviceType })
            {
                IEnumerable<DiscoveredSsdpDevice> devices =
                    await locator.SearchAsync(DeviceType, TimeSpan.FromSeconds(2));

                var deviceInfos = new HashSet<DeviceInfo>();

                foreach (DiscoveredSsdpDevice device in devices)
                {
                    SsdpDevice fullDevice = await device.GetDeviceInfo();

                    var deviceInfo = new DeviceInfo(device.DescriptionLocation.Host, fullDevice.FriendlyName);
                    deviceInfos.Add(deviceInfo);
                }

                return deviceInfos;
            }
        }
    }
}