namespace GOoDcast.Messages.Receiver
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Stop message
    /// </summary>
    [DataContract]
    class StopMessage : SessionMessage
    {
    }
}
