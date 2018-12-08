namespace GOoDcast.Messages.Media
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Message to retrieve the media status
    /// </summary>
    [DataContract]
    class GetStatusMessage : MediaSessionMessage
    {
    }
}
