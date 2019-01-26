using System.Threading.Tasks;

namespace GOoDcast.Channels
{
    public interface IDashCastChannel : IChromecastChannel
    {
        Task LoadUrl(string sourceId, string destinationId, string url);
    }
}