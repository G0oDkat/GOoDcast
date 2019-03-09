namespace GOoDcast
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Channels;
    using Device;
    using Miscellaneous;
    using Ninject;

    public class Chromecast : IChromecast
    {
        private readonly HashSet<IChannel> channels;
        private readonly IChromecastClient client;
        private readonly IConnectionChannel connectionChannel;
        private readonly string IpAddress;
        private readonly StandardKernel kernel;

        public Chromecast(DeviceInfo deviceInfo) : this(deviceInfo?.IpAddress, deviceInfo?.FriendlyName)
        {
        }

        public Chromecast(string ipAddress, string name)
        {
            IpAddress = ipAddress ?? throw new ArgumentNullException(nameof(ipAddress));
            Name = name ?? throw new ArgumentNullException(nameof(name));

            client = new ChromecastClient();

            var settings = new NinjectSettings { LoadExtensions = false };
            kernel = new StandardKernel(settings, new ChannelModule());
            kernel.Bind<IChromecastClient>().ToConstant(client);

            connectionChannel = kernel.Get<IConnectionChannel>();
            var heartbeatChannel = kernel.Get<IHeartbeatChannel>();

            client.BindChannel(connectionChannel);
            client.BindChannel(heartbeatChannel);

            channels = new HashSet<IChannel> {connectionChannel, heartbeatChannel};
        }

        public string Name { get; }

        public bool IsConnected => client.IsConnected;

        public async Task ConnectAsync()
        {
            await client.ConnectAsync(IpAddress);
            await connectionChannel.ConnectAsync(DefaultIdentifiers.SourceId, DefaultIdentifiers.DestinationId);
        }

        public Task DisconnectAsync()
        {
            return client.DisconnectAsync();
        }

        public void Dispose()
        {
            client?.Dispose();
            kernel?.Dispose();
        }

        public TChannel GetChannel<TChannel>() where TChannel : IChannel
        {
            TChannel channel = channels.OfType<TChannel>().FirstOrDefault();

            if (channel == null)
            {
                channel = kernel.Get<TChannel>();
                client.BindChannel(channel);
                channels.Add(channel);
            }

            return channel;
        }
    }
}