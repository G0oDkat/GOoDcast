namespace GOoDcast.Messages.Receiver
{
    using Models.Receiver;

    /// <summary>
    /// Receiver status message
    /// </summary>
    [ReceptionMessage]
    public class ReceiverStatusMessage : StatusMessage<ReceiverStatus>
    {
    }
}
