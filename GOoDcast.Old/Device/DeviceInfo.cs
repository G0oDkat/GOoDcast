namespace GOoDcast.Device
{
    using System;

    public class DeviceInfo
    {
        public DeviceInfo(string ipAddress, string friendlyName)
        {
            IpAddress = ipAddress ?? throw new ArgumentNullException(nameof(ipAddress));
            FriendlyName = friendlyName ?? throw new ArgumentNullException(nameof(friendlyName));
        }

        public string IpAddress { get; }

        public string FriendlyName { get; }
    }
}
