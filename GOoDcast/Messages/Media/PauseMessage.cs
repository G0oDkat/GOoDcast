namespace GOoDcast.Messages.Media
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Message to pause playback of the current content
    /// </summary>
    [DataContract]
    class PauseMessage : MediaSessionMessage
    {
    }
}
