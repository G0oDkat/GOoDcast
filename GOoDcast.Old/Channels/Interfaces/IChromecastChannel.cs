namespace GOoDcast.Channels
{
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;

    public interface IChromecastChannel
    {
        /// <summary>
        /// Gets the full namespace
        /// </summary>
        string Namespace { get; }

        /// <summary>
        /// Called when a message for this channel is received
        /// </summary>
        /// <param name="rawMessage">message to process</param>
        Task OnPushMessageReceivedAsync(JObject rawMessage);

    }
}