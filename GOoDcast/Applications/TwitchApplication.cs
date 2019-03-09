namespace GOoDcast.Applications
{
    using System.Threading.Tasks;
    using Channels;
    using Models.Media;

    public class TwitchApplication : MediaApplicationBase
    {
        public TwitchApplication(IConnectionChannel connectionChannel, IReceiverChannel receiverChannel,
                                 IMediaChannel mediaChannel) : base("B3DCF968", connectionChannel, receiverChannel,
                                                                    mediaChannel)
        {
        }

        public Task LoadLiveStreamAsync()
        {
            return base.LoadAsync(new MediaInformation
            {
                ContentId =
                    "https://usher.ttvnw.net/api/channel/hls/cardsportsleague.m3u8?allow_source=true&baking_bread=true&baking_brownies=true&baking_brownies_timeout=1050&fast_bread=true&p=380444&player_backend=mediaplayer&playlist_include_framerate=true&reassignments_supported=true&rtqos=control&sig=a71f224aa837d694e87ad17be80e8b0fd5246e79&token=%7B%22adblock%22%3Atrue%2C%22authorization%22%3A%7B%22forbidden%22%3Afalse%2C%22reason%22%3A%22%22%7D%2C%22blackout_enabled%22%3Afalse%2C%22channel%22%3A%22pietsmiettv%22%2C%22channel_id%22%3A72793250%2C%22chansub%22%3A%7B%22restricted_bitrates%22%3A%5B%5D%2C%22view_until%22%3A1924905600%7D%2C%22ci_gb%22%3Afalse%2C%22geoblock_reason%22%3A%22%22%2C%22device_id%22%3A%22cd7b27839c0b31fd%22%2C%22expires%22%3A1549732936%2C%22game%22%3A%22%22%2C%22hide_ads%22%3Afalse%2C%22https_required%22%3Atrue%2C%22mature%22%3Afalse%2C%22partner%22%3Afalse%2C%22platform%22%3A%22web%22%2C%22player_type%22%3A%22site%22%2C%22private%22%3A%7B%22allowed_to_view%22%3Atrue%7D%2C%22privileged%22%3Afalse%2C%22server_ads%22%3Atrue%2C%22show_ads%22%3Atrue%2C%22subscriber%22%3Afalse%2C%22turbo%22%3Afalse%2C%22user_id%22%3Anull%2C%22user_ip%22%3A%22109.90.232.169%22%2C%22version%22%3A2%7D",
                StreamType = StreamType.Live,
                ContentType = "application/x-mpegurl",
                Metadata = new GenericMediaMetadata()
                //{
                //    Title = ""
                //},
                //CustomData = new Dictionary<string, string>
                //{
                //    {"channel","pietsmiettv" }
                //}
            });
        }
    }
}

