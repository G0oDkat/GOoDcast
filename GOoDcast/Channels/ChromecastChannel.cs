namespace GOoDcast.Channels
{
    using System;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using ProtoBuf;

    public abstract class ChromecastChannel : IChromecastChannel
    {
        protected ChromecastChannel(IChromecastClient client, string ns)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            Namespace = ns ?? throw new ArgumentNullException(nameof(ns));
        }

        private IChromecastClient Client { get; }

        protected string Namespace { get; }

        protected async Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
        {
            ChromecastMessage requestMessage = RequestToMessage(request);
            ChromecastMessage responseMessage = await Client.RequestAsync(requestMessage);

            //TODO response validation

            //if (requestMessage.Namespace != responseMessage.Namespace)
            //{

            //}

            var response = JsonConvert.DeserializeObject<TResponse>(responseMessage.PayloadUtf8);

            return response;
        }

        protected Task SendAsync<TRequest>(TRequest request)
        {
            ChromecastMessage requestMessage = RequestToMessage(request);
            return Client.SendAsync(requestMessage);
        }

        private ChromecastMessage RequestToMessage<TRequest>(TRequest request)
        {
            var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            string payload = JsonConvert.SerializeObject(request, settings);

            return new ChromecastMessage(Namespace, payload);
        }
    }
}