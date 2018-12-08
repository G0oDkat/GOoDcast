using System.Threading.Tasks;

namespace GOoDcast
{
    using System;
    using System.Threading;
    using Channels;
    using Messages;
    using Models;
    using ProtoBuf;

    public interface IChromecastClient : IDisposable
    {
        Task ConnectAsync(string address);

        Task DisconnectAsync();

        void BindChannel(IChromecastChannel channel);


        Task SendAsync(string @namespace, IMessage request, string destinationId);

        
        Task<TResponse> RequestAsync<TResponse>(string @namespace, IMessageWithId request,string destinationId) where TResponse : IMessageWithId; 

        
    }
}