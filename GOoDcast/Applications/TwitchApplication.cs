namespace GOoDcast.Applications
{
    using Channels;

    public class TwitchApplication : MediaApplicationBase
    {
        public TwitchApplication(IConnectionChannel connectionChannel, IReceiverChannel receiverChannel,IMediaChannel mediaChannel) : 
            base("358E83DC", connectionChannel, receiverChannel,mediaChannel)
        {
        }
    }
}