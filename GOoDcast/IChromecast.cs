using System.Threading;
using System.Threading.Tasks;

namespace GOoDcast
{
    using System;
    using Channels;

    public interface IChromecast : IDisposable
    {
        string Name { get; }

        Task ConnectAsync();
        Task DisconnectAsync();

        TChannel GetChannel<TChannel>() where TChannel : IChromecastChannel;
    }
}