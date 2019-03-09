namespace GOoDcast.Messages
{
    /// <summary>
    /// Interface for status messages
    /// </summary>
    /// <typeparam name="TStatus">status type</typeparam>
    public interface IStatusMessage<out TStatus> : IMessageWithId
    {
        /// <summary>
        /// Gets the status
        /// </summary>
        TStatus Status { get; }
    }
}
