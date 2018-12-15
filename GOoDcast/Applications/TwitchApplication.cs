namespace GOoDcast.Applications
{
    using Channels;

    public class TwitchApplication: ApplicationBase
    {
        private const string ApplicationId = "358E83DC";

        public TwitchApplication(IConnectionChannel connectionChannel, IReceiverChannel receiverChannel) : base(ApplicationId, connectionChannel, receiverChannel)
        {
        }
    }
}