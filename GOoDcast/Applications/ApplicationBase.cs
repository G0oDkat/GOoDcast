namespace GOoDcast.Applications
{
    using System;
    using System.Threading.Tasks;
    using Channels;

    public abstract class ApplicationBase /* : IController*/
    {
        protected ApplicationBase(string applicationId, ReceiverChannel receiverChannel)
        {
            ApplicationId = applicationId ?? throw new ArgumentNullException(nameof(applicationId));
            ReceiverChannel = receiverChannel ?? throw new ArgumentNullException(nameof(receiverChannel));
        }

        protected string ApplicationId { get; }

        protected ReceiverChannel ReceiverChannel { get; }

        public async Task LaunchApplication()
        {
            await ReceiverChannel.LaunchApplication(ApplicationId);
        }

        public async Task StopApplication()
        {
            await ReceiverChannel.StopApplication();
        }
    }
}