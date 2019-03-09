namespace GOoDcast.Messages.Media
{
    using System;
    
    /// <summary>
    /// Invalid request message
    /// </summary>
    [ReceptionMessage]
    class InvalidRequestMessage : MessageWithId
    {
        /// <summary>
        /// Gets or sets the reason
        /// </summary>
        public string Reason { get; set; }


        //TODO
        //[OnDeserialized]
        //private void OnDeserialized(StreamingContext context)
        //{
        //    throw new InvalidOperationException(Reason);
        //}
    }
}
