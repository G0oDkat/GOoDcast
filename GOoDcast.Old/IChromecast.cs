namespace GOoDcast
{
    using System;
    using System.Threading.Tasks;
    using Channels;

    public interface IChromecast : IDisposable
    {
        string Name { get; }

        Task ConnectAsync();
        Task DisconnectAsync();
        TChannel GetChannel<TChannel>() where TChannel : IChromecastChannel;

        TChannel GetOrCreateChannel<TChannel>(Func<IChromecastClient, TChannel> factory)
            where TChannel : IChromecastChannel;
    }
}