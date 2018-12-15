﻿namespace GOoDcast.Messages.Receiver
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Launch message
    /// </summary>
    [DataContract]
    class LaunchMessage : MessageWithId
    {
        /// <summary>
        /// Gets or sets the application identifier
        /// </summary>
        [DataMember(Name = "appId")]
        public string ApplicationId { get; set; }
    }
}
