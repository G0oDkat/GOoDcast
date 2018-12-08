namespace GOoDcast.Messages.Media
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Load failed message
    /// </summary>
    [DataContract]
    [ReceptionMessage]
    class LoadFailedMessage : MessageWithId
    {
        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            throw new Exception("Load failed");
        }
    }
}
