using System.Threading.Tasks;

namespace GOoDcast.Channels
{
    public interface IConnectionChannel
    {
        Task ConnectAsync(string destinationId);
    }
}