namespace GOoDcast.Messages.Connection
{
    using System.Runtime.Serialization;

    /// <summary>
    ///     Close message
    /// </summary>
    [DataContract]
    [ReceptionMessage]
    internal class CloseMessage : Message
    {
    }
}