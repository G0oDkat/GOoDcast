using System.Threading.Tasks;

namespace GOoDcast.Channels
{
    public interface IYouTubeChannel : IChromecastChannel
    {
        Task LoadVideo(string sourceId, string destinationId, string videoId);
    }
}