namespace GOoDcast.Channels
{
    using System.Threading.Tasks;

    public interface IChannel
    {
        string Namespace { get; }

        Task OnMessageReceivedAsync(string sourceId, string destinationId, string payload);

        Task OnMessageReceivedAsync(string sourceId, string destinationId, byte[] payload);
    }
}