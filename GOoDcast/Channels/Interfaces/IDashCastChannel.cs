using System.Threading.Tasks;

namespace GOoDcast.Channels
{
    public interface IDashCastChannel : IChannel
    {
        Task LoadUrl(string sourceId, string destinationId, string url);
    }
}