namespace GOoDcast
{
    using System;
    using System.Threading.Tasks;
    using Channels;

    public interface IChromecastClient : IDisposable
    {
        bool IsConnected { get; }

        Task ConnectAsync(string address);

        Task DisconnectAsync();

        void BindChannel(IChannel channel);

        Task SendAsync(string @namespace, string sourceId, string destinationId, string payload);

        Task SendAsync(string @namespace, string sourceId, string destinationId, byte[] payload);
    }
}