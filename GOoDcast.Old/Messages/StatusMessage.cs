namespace GOoDcast.Messages
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Status message base class
    /// </summary>
    /// <typeparam name="TStatus">status type</typeparam>
    [DataContract]
    public abstract class StatusMessage<TStatus> : MessageWithId, IStatusMessage<TStatus>
    {
        /// <summary>
        /// Gets or sets the status
        /// </summary>
        [DataMember(Name = "status")]
        public TStatus Status { get; set; }
    }
}
