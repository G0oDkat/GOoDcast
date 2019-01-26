namespace GOoDcast.Applications
{
    using System.Threading.Tasks;
    using Channels;
    using Models.Media;

    public class TwitchApplication : MediaApplicationBase
    {
        public TwitchApplication(IConnectionChannel connectionChannel, IReceiverChannel receiverChannel,
                                 IMediaChannel mediaChannel) : base(/*"358E83DC",*/ "B3DCF968", connectionChannel, receiverChannel,
                                                                    mediaChannel)
        {
        }

        public Task LoadAsync()
        {
            return base.LoadAsync(new MediaInformation
            {
                ContentId = "https://usher.ttvnw.net/vod/358775639.m3u8?nauth=%7B%22authorization%22%3A%7B%22forbidden%22%3Afalse%2C%22reason%22%3A%22%22%7D%2C%22chansub%22%3A%7B%22restricted_bitrates%22%3A%5B%5D%7D%2C%22device_id%22%3A%22c09ab955af3b461b9bdf887510bd11e0%22%2C%22expires%22%3A1546851958%2C%22https_required%22%3Afalse%2C%22privileged%22%3Afalse%2C%22user_id%22%3A153057335%2C%22version%22%3A2%2C%22vod_id%22%3A358775639%7D&nauthsig=e34e1c1748437d459bfcef5a3a4371a2cca84f4e&allow_audio_only=true&allow_source=true&max_level=52&playlist_include_framerate=true",                
                ContentType = "application/x-mpegurl",
                StreamType = StreamType.Buffered
            });
        }
    }
}