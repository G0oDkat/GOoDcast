namespace GOoDcast.Channels
{
    using System.Threading.Tasks;

    public interface IChromecastChannel
    {
        string Namespace { get; }

        Task OnMessageReceivedAsync(string sourceId, string destinationId, string payload);

        Task OnMessageReceivedAsync(string sourceId, string destinationId, byte[] payload);
    }
}