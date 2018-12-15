﻿namespace GOoDcast.Applications
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Channels;
    using Models.Receiver;

    public abstract class ApplicationBase
    {
        protected ApplicationBase(string applicationId, IConnectionChannel connectionChannel, IReceiverChannel receiverChannel)
        {
            ApplicationId = applicationId ?? throw new ArgumentNullException(nameof(applicationId));
            ConnectionChannel = connectionChannel ?? throw new ArgumentNullException(nameof(connectionChannel));
            ReceiverChannel = receiverChannel ?? throw new ArgumentNullException(nameof(receiverChannel));

            ReceiverChannel.StatusChanged += OnReceiverChannelStatusChanged;
        }

        protected string ApplicationId { get; }
      
        protected string TransportId { get; private set; }

        protected string SessionId { get; private set; }

        protected IConnectionChannel ConnectionChannel { get; }

        protected IReceiverChannel ReceiverChannel { get; }

        private void OnReceiverChannelStatusChanged(object sender, EventArgs e)
        {
            Application application =
                ReceiverChannel.Status?.Applications?.FirstOrDefault(a => a.AppId == ApplicationId);

            if (application != null)
            {
                TransportId = application.TransportId;
                SessionId = application.SessionId;
            }
            else
            {
                TransportId = null;
                SessionId = null;
            }
        }

        public async Task LaunchApplicationAsync()
        {
            await ReceiverChannel.LaunchAsync(ApplicationId);
            await ConnectionChannel.ConnectAsync(TransportId);
        }

        public async Task StopApplicationAsync()
        {
            Application application = ReceiverChannel.Status.Applications.FirstOrDefault(a => a.AppId == ApplicationId);

            if (application == null) throw new InvalidOperationException("Application has no active session.");

            await ReceiverChannel.StopAsync(application);
        }
    }
}