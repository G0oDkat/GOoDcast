namespace GOoDcast.Device
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Rssdp;

    public static class SsdpDeviceLocator
    {
        private const string DeviceType = "urn:dial-multiscreen-org:device:dial:1";

        public static async Task<IReadOnlyCollection<DeviceInfo>> LocateDevicesAsync()
        {
            using (var locator = new Rssdp.SsdpDeviceLocator { NotificationFilter = DeviceType})
            {
                IEnumerable<DiscoveredSsdpDevice> devices =
                    await locator.SearchAsync(DeviceType, TimeSpan.FromMilliseconds(1001));

                IEnumerable<Task<DeviceInfo>> tasks = devices.Select(CreateDeviceInfoAsync);
                return await Task.WhenAll(tasks);
            }
        }


        private static async Task<DeviceInfo> CreateDeviceInfoAsync(DiscoveredSsdpDevice device)
        {
            SsdpDevice ssdpDevice = await device.GetDeviceInfo();

            return new DeviceInfo(device.DescriptionLocation.Host, ssdpDevice.FriendlyName);
        }
    }
}