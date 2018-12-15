using System.Threading.Tasks;

namespace GOoDcast.Channels
{
    public interface IConnectionChannel : IChromecastChannel
    {
        Task ConnectAsync(string destinationId);
    }
}