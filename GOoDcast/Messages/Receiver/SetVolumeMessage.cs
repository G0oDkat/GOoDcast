namespace GOoDcast.Messages.Receiver
{
    using Models;

    /// <summary>
    /// Volume Message
    /// </summary>
    class SetVolumeMessage : MessageWithId
    {
        /// <summary>
        /// Gets or sets the volume
        /// </summary>        
        public Volume Volume { get; set; }
    }
}
