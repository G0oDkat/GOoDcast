namespace GOoDcast.Applications
{
    using System;
    using System.Threading.Tasks;
    using Channels;
    using Miscellaneous;

    public class DashCastApplication : ApplicationBase
    {
        private readonly IDashCastChannel dashCastChannel;
        private const string DashCastApplicationId = "5C3F0A3C";

        public DashCastApplication(IConnectionChannel connectionChannel, IReceiverChannel receiverChannel, IDashCastChannel dashCastChannel) : base(DashCastApplicationId, connectionChannel, receiverChannel)
        {
            this.dashCastChannel = dashCastChannel ?? throw new ArgumentNullException(nameof(dashCastChannel));
        }

        public Task LoadUrl(string url)
        {
            return dashCastChannel.LoadUrl(DefaultIdentifiers.SourceId, TransportId, url);
        }

    }
}