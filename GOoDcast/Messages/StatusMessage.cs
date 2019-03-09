namespace GOoDcast.Messages
{
    /// <summary>
    ///     Status message base class
    /// </summary>
    /// <typeparam name="TStatus">status type</typeparam>
    public abstract class StatusMessage<TStatus> : MessageWithId, IStatusMessage<TStatus>
    {
        /// <summary>
        ///     Gets or sets the status
        /// </summary>
        public TStatus Status { get; set; }
    }
}