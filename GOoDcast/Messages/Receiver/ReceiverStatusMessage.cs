namespace GOoDcast.Messages.Receiver
{
    using System.Runtime.Serialization;
    using Models.Receiver;

    /// <summary>
    /// Receiver status message
    /// </summary>
    [DataContract]
    [ReceptionMessage]
    public class ReceiverStatusMessage : StatusMessage<ReceiverStatus>
    {
    }
}
