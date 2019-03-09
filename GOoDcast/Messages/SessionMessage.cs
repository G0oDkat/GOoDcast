namespace GOoDcast.Messages
{
    /// <summary>
    /// Session message base class
    /// </summary>
    public abstract class SessionMessage : MessageWithId
    {
        /// <summary>
        /// Gets or sets the session identifier
        /// </summary>
        public string SessionId { get; set; }
    }
}
