namespace GOoDcast.Device
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Zeroconf;

    public static class MdnsDeviceLocator
    {
        private const string Protocol = "_googlecast._tcp.local.";

        public static async Task<IReadOnlyCollection<DeviceInfo>> LocateDevicesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IReadOnlyList<IZeroconfHost> hosts = await ZeroconfResolver.ResolveAsync(Protocol, cancellationToken: cancellationToken);

            return hosts.Select(CreateDeviceInfo).ToList();
        }

        public static IObservable<DeviceInfo> LocateDevicesContinuous()
        {
            IObservable<IZeroconfHost> hosts = ZeroconfResolver.ResolveContinuous(Protocol);

            return hosts.Select(CreateDeviceInfo);
        }

        private static DeviceInfo CreateDeviceInfo(IZeroconfHost host)
        {
            var properties = host.Services[Protocol].Properties.First();

            string friendlyName = properties["fn"];

            return new DeviceInfo(host.IPAddress, friendlyName);
        }
    }
}