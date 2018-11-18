using System.Threading.Tasks;

namespace GOoDcast
{
    using System;
    using System.Threading;
    using Models;
    using ProtoBuf;

    public interface IChromecastClient : IDisposable
    {
        Task ConnectAsync(string address);
        Task DisconnectAsync();
        Task<ChromecastMessage> RequestAsync(ChromecastMessage request);
        Task SendAsync(ChromecastMessage request);
    }
}