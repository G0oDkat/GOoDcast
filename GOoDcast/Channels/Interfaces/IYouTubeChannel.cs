using System.Threading.Tasks;

namespace GOoDcast.Channels
{
    using System;

    public interface IYouTubeChannel : IChannel
    {
        event EventHandler<string> ScreenIdChanged;

        Task GetScreenId(string sourceId, string destinationId);
    }
}