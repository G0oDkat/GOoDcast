namespace GOoDcast.Messages.Receiver
{
    /// <summary>
    /// Launch message
    /// </summary>
    class LaunchMessage : MessageWithId
    {
        /// <summary>
        /// Gets or sets the application identifier
        /// </summary>        
        public string AppId { get; set; }
    }
}
