namespace GOoDcast
{
    using System;
    using System.Threading.Tasks;
    using Channels;

    public interface IChromecast : IDisposable
    {
        string Name { get; }
        bool IsConnected { get; }

        Task ConnectAsync();
        Task DisconnectAsync();
        TChannel GetChannel<TChannel>() where TChannel : IChromecastChannel;
    }
}