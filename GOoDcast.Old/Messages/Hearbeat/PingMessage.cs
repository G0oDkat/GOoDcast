namespace GOoDcast.Messages.Hearbeat
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Ping message
    /// </summary>
    [DataContract]
    [ReceptionMessage]
    class PingMessage : Message
    {
    }
}
