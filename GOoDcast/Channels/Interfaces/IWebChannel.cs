using System.Threading.Tasks;

namespace GOoDcast.Channels
{
    public interface IWebChannel : IChromecastChannel
    {
        Task LoadUrl(string applicationId, string destinationId, string url);
    }
}