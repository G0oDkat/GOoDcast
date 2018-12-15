namespace GOoDcast.Channels
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Messages.Receiver;
    using Miscellaneous;
    using Models;
    using Models.Receiver;

    /// <summary>
    ///     Receiver channel
    /// </summary>
    public class ReceiverChannel : StatusChannel<ReceiverStatus, ReceiverStatusMessage>, IReceiverChannel
    {
        /// <summary>
        ///     Initializes a new instance of <see cref="ReceiverChannel" /> class
        /// </summary>
        public ReceiverChannel(IChromecastClient client) : base(client, "urn:x-cast:com.google.cast.receiver")
        {
        }

        /// <summary>
        ///     Launches an application
        /// </summary>
        /// <param name="applicationId">application identifier</param>
        /// <returns>receiver status</returns>
        public Task<ReceiverStatus> LaunchAsync(string applicationId)
        {
            return RequestAsync(new LaunchMessage {ApplicationId = applicationId}, DefaultIdentifiers.DestinationId);
        }

        /// <summary>
        ///     Sets the volume
        /// </summary>
        /// <param name="level">volume level (0.0 to 1.0)</param>
        /// <returns>receiver status</returns>
        public Task<ReceiverStatus> SetVolumeAsync(float level)
        {
            return SetVolumeAsync(level, null);
        }

        /// <summary>
        ///     Sets a value indicating whether the audio should be muted
        /// </summary>
        /// <param name="isMuted">true if audio should be muted; otherwise, false</param>
        /// <returns>receiver status</returns>
        public Task<ReceiverStatus> SetIsMutedAsync(bool isMuted)
        {
            return SetVolumeAsync(null, isMuted);
        }

        /// <summary>
        /// Checks the connection is well established
        /// </summary>
        /// <param name="ns">namespace</param>
        /// <returns>an application object</returns>
        //public async Task<Application> EnsureConnectionAsync(string ns)
        //{
        //    var status = await CheckStatusAsync();
        //    var application = status.Applications.First(a => a.Namespaces.Any(n => n.Name == ns));
        //    if (!IsConnected)
        //    {
        //        await Sender.GetChannel<IConnectionChannel>().ConnectAsync(application.TransportId);
        //        IsConnected = true;
        //    }
        //    return application;
        //}

        //private void Disconnected(object sender, System.EventArgs e)
        //{
        //    IsConnected = false;
        //}

        /// <summary>
        ///     Stops the current applications
        /// </summary>
        /// <param name="applications">applications to stop</param>
        /// <returns>ReceiverStatus</returns>
        public async Task<ReceiverStatus> StopAsync(params Application[] applications)
        {
            IEnumerable<Application> apps = applications;
            if (apps == null || !apps.Any())
            {
                apps = (await CheckStatusAsync()).Applications;
                if (apps == null || !apps.Any()) return null;
            }

            ReceiverStatusMessage receiverStatusMessage = null;
            foreach (Application application in apps)
                receiverStatusMessage =
                    await RequestAsync<ReceiverStatusMessage>(new StopMessage {SessionId = application.SessionId},
                                                              DefaultIdentifiers.DestinationId);

            return Status = receiverStatusMessage.Status;
        }

        private Task<ReceiverStatus> SetVolumeAsync(float? level, bool? isMuted, float stepInterval = 0.05f)
        {
            var message = new SetVolumeMessage
            {
                Volume = new Volume {Level = level, IsMuted = isMuted, StepInterval = stepInterval}
            };

            return RequestAsync(message, DefaultIdentifiers.DestinationId);
        }

        private async Task<ReceiverStatus> CheckStatusAsync()
        {
            return Status ?? (Status = await GetStatusAsync());
        }

        /// <summary>
        ///     Retrieves the status
        /// </summary>
        /// <returns>the status</returns>
        private Task<ReceiverStatus> GetStatusAsync()
        {
            return RequestAsync(new GetStatusMessage(), DefaultIdentifiers.DestinationId);
        }
    }
}