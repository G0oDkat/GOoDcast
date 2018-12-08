namespace GOoDcast.Messages.Receiver
{
    using System.Runtime.Serialization;
    using Models;

    /// <summary>
    /// Volume Message
    /// </summary>
    [DataContract]
    class SetVolumeMessage : MessageWithId
    {
        /// <summary>
        /// Gets or sets the volume
        /// </summary>
        [DataMember(Name = "volume")]
        public Volume Volume { get; set; }
    }
}
