namespace GOoDcast.Messages.Media
{
    /// <summary>
    /// Media session message
    /// </summary>
    abstract class MediaSessionMessage : MessageWithId
    {
        /// <summary>
        /// Gets or sets the media session identifier
        /// </summary>
        public long? MediaSessionId { get; set; }
    }
}
