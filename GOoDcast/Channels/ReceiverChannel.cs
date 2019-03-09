namespace GOoDcast.Channels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Messages.Receiver;
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
        public async Task<ReceiverStatus> LaunchAsync(string sourceId, string destinationId, string applicationId, bool joinExisting)
        {
            if (joinExisting)
            {
                IEnumerable<Application> applications = (await CheckStatusAsync(sourceId, destinationId).ConfigureAwait(false)).Applications;

                if (applications.Any(a => a.AppId == applicationId))
                {
                    return Status;
                }
            }

            return await RequestAsync(sourceId, destinationId, new LaunchMessage {AppId = applicationId});
        }

        public Task<ReceiverStatus> SetVolumeAsync(string sourceId, string destinationId, float level)
        {
            return SetVolumeAsync(sourceId, destinationId, level, null);
        }

        public Task<ReceiverStatus> IncreaseVolumeAsync(string sourceId, string destinationId)
        {
            return IncreaseVolumeAsync(sourceId, destinationId, Status.Volume.StepInterval);
        }

        public Task<ReceiverStatus> IncreaseVolumeAsync(string sourceId, string destinationId, double amount)
        {
            double level = Math.Min(Status.Volume.Level ?? 0.5 + amount, 1f);
            return SetVolumeAsync(sourceId, destinationId, (float)level, null);
        }

        public Task<ReceiverStatus> DecreaseVolumeAsync(string sourceId, string destinationId)
        {
            return DecreaseVolumeAsync(sourceId, destinationId, Status.Volume.StepInterval);
        }

        public Task<ReceiverStatus> DecreaseVolumeAsync(string sourceId, string destinationId, double amount)
        {
            double level = Math.Max(Status.Volume.Level ?? 0.5 - amount, 0);
            return SetVolumeAsync(sourceId, destinationId, (float)level, null);
        }

        public Task<ReceiverStatus> SetIsMutedAsync(string sourceId, string destinationId, bool isMuted)
        {
            return SetVolumeAsync(sourceId, destinationId, null, isMuted);
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
        public async Task<ReceiverStatus> StopAsync(string sourceId, string destinationId,
                                                    params Application[] applications)
        {
            IEnumerable<Application> apps = applications;
            if (apps == null || !apps.Any())
            {
                apps = (await CheckStatusAsync(sourceId, destinationId)).Applications;
                if (apps == null || !apps.Any()) return null;
            }

            ReceiverStatusMessage receiverStatusMessage = null;
            foreach (Application application in apps)
                receiverStatusMessage =
                    await RequestAsync<ReceiverStatusMessage>(sourceId, destinationId,
                                                              new StopMessage {SessionId = application.SessionId});

            return Status = receiverStatusMessage.Status;
        }

        private Task<ReceiverStatus> SetVolumeAsync(string sourceId, string destinationId, float? level, bool? isMuted,
                                                    float stepInterval = 0.05f)
        {
            var message = new SetVolumeMessage
            {
                Volume = new Volume {Level = level, Muted = isMuted, StepInterval = stepInterval}
            };

            return RequestAsync(sourceId, destinationId, message);
        }

        private async Task<ReceiverStatus> CheckStatusAsync(string sourceId, string destinationId)
        {
            return Status ?? (Status = await GetStatusAsync(sourceId, destinationId));
        }

        /// <summary>
        ///     Retrieves the status
        /// </summary>
        /// <returns>the status</returns>
        private Task<ReceiverStatus> GetStatusAsync(string sourceId, string destinationId)
        {
            return RequestAsync(sourceId, destinationId, new GetStatusMessage());
        }
    }
}