﻿namespace GOoDcast
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Channels;
    using Device;
    using Miscellaneous;

    public class Chromecast : IChromecast
    {
        private readonly HashSet<IChromecastChannel> channels;
        private readonly IChromecastClient client;
        private readonly ConnectionChannel connectionChannel;
        private readonly string IpAddress;
        private readonly HeartbeatChannel heartbeatChannel;

        public Chromecast(DeviceInfo deviceInfo) : this(deviceInfo?.IpAddress, deviceInfo?.FriendlyName)
        {
        }

        public Chromecast(string ipAddress, string name)
        {
            IpAddress = ipAddress ?? throw new ArgumentNullException(nameof(ipAddress));
            Name = name ?? throw new ArgumentNullException(nameof(name));

            client = new ChromecastClient();
            connectionChannel = new ConnectionChannel(client);
            heartbeatChannel = new HeartbeatChannel(client);

            client.BindChannel(connectionChannel);
            client.BindChannel(heartbeatChannel);

            channels = new HashSet<IChromecastChannel> {connectionChannel};
        }

        public string Name { get; }

        public async Task ConnectAsync()
        {
            await client.ConnectAsync(IpAddress);
            await connectionChannel.ConnectAsync(DefaultIdentifiers.DestinationId);
        }

        public Task DisconnectAsync()
        {
            return client.DisconnectAsync();
        }

        public void Dispose()
        {
            client?.Dispose();
        }

        public TChannel GetChannel<TChannel>() where TChannel : IChromecastChannel
        {
            return channels.OfType<TChannel>().FirstOrDefault();
        }

        public TChannel GetOrCreateChannel<TChannel>(Func<IChromecastClient, TChannel> factory)
            where TChannel : IChromecastChannel
        {
            if (factory == null) throw new ArgumentNullException(nameof(factory));

            TChannel channel = channels.OfType<TChannel>().FirstOrDefault();

            if (channel == null)
            {
                channel = factory.Invoke(client);

                client.BindChannel(channel);

                if (channel != null) channels.Add(channel);
            }

            return channel;
        }
    }
}