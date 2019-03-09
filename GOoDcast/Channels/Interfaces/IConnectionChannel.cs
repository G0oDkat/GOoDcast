using System.Threading.Tasks;

namespace GOoDcast.Channels
{
    public interface IConnectionChannel : IChannel
    {
        Task ConnectAsync(string sourceId, string destinationId);
    }
}