namespace GOoDcast.Channels
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Media;

    /// <summary>
    ///     Interface for the media channel
    /// </summary>
    public interface IMediaChannel : IStatusChannel<IEnumerable<MediaStatus>>
    {
        /// <summary>
        ///     Loads a media
        /// </summary>
        /// <param name="media">media to load</param>
        /// <param name="sourceId"></param>
        /// <param name="destinationId"></param>
        /// <param name="autoPlay">true to play the media directly, false otherwise</param>
        /// <param name="activeTrackIds">tracks identifiers that should be active</param>
        Task LoadAsync(string sourceId, string destinationId, MediaInformation media, string sessionId, bool autoPlay = true, params int[] activeTrackIds);

        /// <summary>
        ///     Loads a queue items
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="destinationId"></param>
        /// <param name="repeatMode">queue repeat mode</param>
        /// <param name="medias">media items</param>
        Task QueueLoadAsync(string sourceId, string destinationId, RepeatMode repeatMode, params MediaInformation[] medias);

        /// <summary>
        ///     Loads a queue items
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="destinationId"></param>
        /// <param name="repeatMode">queue repeat mode</param>
        /// <param name="queueItems">items to load</param>
        Task QueueLoadAsync(string sourceId, string destinationId, RepeatMode repeatMode, params QueueItem[] queueItems);

        /// <summary>
        ///     Edits tracks info
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="destinationId"></param>
        /// <param name="enabledTextTracks">true to enable text tracks, false otherwise</param>
        /// <param name="language">language for the tracks that should be active</param>
        /// <param name="activeTrackIds">track identifiers that should be active</param>
        Task EditTracksInfoAsync(string sourceId, string destinationId, string language = null, bool enabledTextTracks = true,
                                 params int[] activeTrackIds);

        /// <summary>
        ///     Plays the media
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="destinationId"></param>
        Task PlayAsync(string sourceId, string destinationId);

        /// <summary>
        ///     Pauses the media
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="destinationId"></param>
        Task PauseAsync(string sourceId, string destinationId);

        /// <summary>
        ///     Stops the media
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="destinationId"></param>
        Task StopAsync(string sourceId, string destinationId);

        /// <summary>
        ///     Seeks to the specified time
        /// </summary>

        /// <param name="sourceId"></param>
        /// <param name="destinationId"></param>
        /// <param name="seconds">time in seconds</param>
        Task SeekAsync(string sourceId, string destinationId, double seconds);


        Task NextAsync(string sourceId, string destinationId);


        Task PreviousAsync(string sourceId, string destinationId);


    }
}