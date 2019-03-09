using System.Threading.Tasks;

namespace GOoDcast.Channels
{
    public interface IWebChannel : IChannel
    {
        Task LoadUrl(string sourceId, string destinationId, string applicationId, string url);
    }
}