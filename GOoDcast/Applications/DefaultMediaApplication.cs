namespace GOoDcast.Applications
{
    using System.Threading.Tasks;
    using Channels;
    using Models.Media;

    public class DefaultMediaApplication : MediaApplicationBase
    {
        private const string DefaultMediaApplicationId = "CC1AD845";

        public DefaultMediaApplication(IConnectionChannel connectionChannel, IReceiverChannel receiverChannel,
                                       IMediaChannel mediaChannel) : base(DefaultMediaApplicationId, connectionChannel,
                                                                          receiverChannel, mediaChannel)
        {
        }

        public new Task LoadAsync(MediaInformation mediaInformation)
        {
            return base.LoadAsync(mediaInformation);
        }
    }
}