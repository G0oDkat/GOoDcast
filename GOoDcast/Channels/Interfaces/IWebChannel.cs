using System.Threading.Tasks;

namespace GOoDcast.Channels
{
    public interface IWebChannel : IChromecastChannel
    {
        Task LoadUrl(string sourceId, string destinationId, string applicationId, string url);
    }
}