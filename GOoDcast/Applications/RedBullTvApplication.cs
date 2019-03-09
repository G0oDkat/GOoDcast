namespace GOoDcast.Applications
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Channels;
    using Models.Media;

    public class RedBullTvApplication : MediaApplicationBase
    {
        public RedBullTvApplication(IConnectionChannel connectionChannel, IReceiverChannel receiverChannel, IMediaChannel mediaChannel) 
            : base("41C88D03", connectionChannel, receiverChannel, mediaChannel)
        {
        }

        public Task LoadTvAsync()
        {
            return base.LoadAsync(new MediaInformation
            {
                ContentId = "AP-1Y2KY9PZ52111",
                StreamType = StreamType.Live,
                ContentType = "application/vnd.apple.mpegurl",
                CustomData = new Dictionary<string, string>
                {
                    {"type", "playlist"},
                    {"playlist", ""}
                }
            });
        }

    }
}