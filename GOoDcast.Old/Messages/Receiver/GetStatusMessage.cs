namespace GOoDcast.Messages.Receiver
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Get status message
    /// </summary>
    [DataContract]
    class GetStatusMessage : MessageWithId
    {
    }
}
