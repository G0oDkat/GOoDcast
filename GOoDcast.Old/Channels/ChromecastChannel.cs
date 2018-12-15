namespace GOoDcast.Channels
{
    using System;
    using System.Threading.Tasks;
    using Messages;
    using Miscellaneous;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using ProtoBuf;

    public abstract class ChromecastChannel : IChromecastChannel
    {
        protected ChromecastChannel(IChromecastClient client, string ns)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            Namespace = ns ?? throw new ArgumentNullException(nameof(ns));
        }

        private IChromecastClient Client { get; }

        public string Namespace { get; }

        public abstract Task OnPushMessageReceivedAsync(JObject rawMessage);


        protected Task<TResponse> RequestAsync<TResponse>(IMessageWithId request, string destinationId) where TResponse : IMessageWithId
        {
            return Client.RequestAsync<TResponse>(Namespace, request, destinationId);            
        }

        protected Task SendAsync(IMessage request, string destinationId)
        {            
            return Client.SendAsync(Namespace, request, destinationId);
        }
    }
}