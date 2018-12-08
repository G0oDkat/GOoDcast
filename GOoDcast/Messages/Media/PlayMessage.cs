namespace GOoDcast.Messages.Media
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Message to begin playback of the content that was loaded with the load call
    /// </summary>
    [DataContract]
    class PlayMessage : MediaSessionMessage
    {
    }
}
