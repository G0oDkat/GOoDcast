namespace GOoDcast.Messages.Media
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Invalid request message
    /// </summary>
    [DataContract]
    [ReceptionMessage]
    class InvalidRequestMessage : MessageWithId
    {
        /// <summary>
        /// Gets or sets the reason
        /// </summary>
        [DataMember(Name = "reason")]
        public string Reason { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            throw new InvalidOperationException(Reason);
        }
    }
}
