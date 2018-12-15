namespace GOoDcast.Messages.Media
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Message to stop playback of the current content
    /// </summary>
    [DataContract]
    class StopMessage : MediaSessionMessage
    {
    }
}
