namespace GOoDcast.Channels
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Messages;
    using Newtonsoft.Json.Linq;

    /// <summary>
    ///     Base class for status channels
    /// </summary>
    /// <typeparam name="TStatus">status type</typeparam>
    /// <typeparam name="TStatusMessage">status message type</typeparam>
    public abstract class StatusChannel<TStatus, TStatusMessage> : ChromecastChannel, IStatusChannel<TStatus>
        where TStatusMessage : IStatusMessage<TStatus>
    {
        private TStatus status;

        /// <summary>
        ///     Initialization
        /// </summary>
        /// <param name="client">client</param>
        /// <param name="namespace">namespace</param>
        protected StatusChannel(IChromecastClient client, string @namespace) : base(client, @namespace)
        {
        }

        /// <summary>
        ///     Raised when the status has changed
        /// </summary>
        public event EventHandler StatusChanged;

        /// <summary>
        ///     Gets or sets the status
        /// </summary>
        public TStatus Status
        {
            get => status;
            protected set
            {
                if (!EqualityComparer<TStatus>.Default.Equals(status, value))
                {
                    status = value;
                    OnStatusChanged();
                }
            }
        }


        protected async Task<TStatus> RequestAsync(string sourceId, string destinationId, IMessageWithId message)
        {
            return Status = (await RequestAsync<TStatusMessage>(sourceId, destinationId, message)).Status;
        }

        protected override Task OnPushMessageReceivedAsync(string sourceId, string destinationId, JObject messageObject)
        {
            var message = messageObject.ToObject<TStatusMessage>();

            if (message != null) Status = message.Status;

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Raises the StatusChanged event
        /// </summary>
        protected virtual void OnStatusChanged()
        {
            StatusChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}