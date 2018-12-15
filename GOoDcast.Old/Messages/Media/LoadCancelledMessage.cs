namespace GOoDcast.Messages.Media
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Load cancelled message
    /// </summary>
    [DataContract]
    [ReceptionMessage]
    class LoadCancelledMessage : MessageWithId
    {
        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            throw new Exception("Load cancelled");
        }
    }
}
