namespace GOoDcast.Channels
{
    using System.Threading.Tasks;
    using Models.Receiver;

    /// <summary>
    ///     Interface for the receiver channel
    /// </summary>
    public interface IReceiverChannel : IStatusChannel<ReceiverStatus>
    {
        /// <summary>
        ///     Retrieves the status
        /// </summary>
        /// <returns>the status</returns>
        //Task<ReceiverStatus> GetStatusAsync();

        /// <summary>
        ///     Launches an application
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="destinationId"></param>
        /// <param name="applicationId">application identifier</param>
        Task<ReceiverStatus> LaunchAsync(string sourceId, string destinationId, string applicationId, bool joinExisting);

        /// <summary>
        ///     Checks the connection is well established
        /// </summary>
        /// <param name="ns">namespace</param>
        /// <returns>an application object</returns>
        //Task<Application> EnsureConnectionAsync(string ns);

        /// <summary>
        ///     Sets the volume
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="destinationId"></param>
        /// <param name="level">volume level (0.0 to 1.0)</param>
        /// <returns>receiver status</returns>
        Task<ReceiverStatus> SetVolumeAsync(string sourceId, string destinationId, float level);

        Task<ReceiverStatus> IncreaseVolumeAsync(string sourceId, string destinationId);

        Task<ReceiverStatus> IncreaseVolumeAsync(string sourceId, string destinationId, double amount);

        Task<ReceiverStatus> DecreaseVolumeAsync(string sourceId, string destinationId);

        Task<ReceiverStatus> DecreaseVolumeAsync(string sourceId, string destinationId, double amount);

        /// <summary>
        ///     Sets a value indicating whether the audio should be muted
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="destinationId"></param>
        /// <param name="isMuted">true if audio should be muted; otherwise, false</param>
        /// <returns>receiver status</returns>
        Task<ReceiverStatus> SetIsMutedAsync(string sourceId, string destinationId, bool isMuted);

        /// <summary>
        ///     Stops the current applications
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="destinationId"></param>
        /// <param name="applications">applications to stop</param>
        /// <returns>ReceiverStatus</returns>
        Task<ReceiverStatus> StopAsync(string sourceId, string destinationId, params Application[] applications);
    }
}