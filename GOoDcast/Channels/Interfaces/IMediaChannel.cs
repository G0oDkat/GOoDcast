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
        /// <param name="transportId"></param>
        /// <param name="autoPlay">true to play the media directly, false otherwise</param>
        /// <param name="activeTrackIds">tracks identifiers that should be active</param>
        Task LoadAsync(MediaInformation media, string transportId, string sessionId, bool autoPlay = true, params int[] activeTrackIds);

        /// <summary>
        ///     Loads a queue items
        /// </summary>
        /// <param name="repeatMode">queue repeat mode</param>
        /// <param name="transportId"></param>
        /// <param name="medias">media items</param>
        Task QueueLoadAsync(RepeatMode repeatMode, string transportId, params MediaInformation[] medias);

        /// <summary>
        ///     Loads a queue items
        /// </summary>
        /// <param name="repeatMode">queue repeat mode</param>
        /// <param name="transportId"></param>
        /// <param name="queueItems">items to load</param>
        Task QueueLoadAsync(RepeatMode repeatMode, string transportId, params QueueItem[] queueItems);

        /// <summary>
        ///     Edits tracks info
        /// </summary>
        /// <param name="enabledTextTracks">true to enable text tracks, false otherwise</param>
        /// <param name="transportId"></param>
        /// <param name="language">language for the tracks that should be active</param>
        /// <param name="activeTrackIds">track identifiers that should be active</param>
        Task EditTracksInfoAsync(string transportId, string language = null, bool enabledTextTracks = true,
                                 params int[] activeTrackIds);

        /// <summary>
        ///     Plays the media
        /// </summary>
        /// <param name="transportId"></param>
        Task PlayAsync(string transportId);

        /// <summary>
        ///     Pauses the media
        /// </summary>
        /// <param name="transportId"></param>
        Task PauseAsync(string transportId);

        /// <summary>
        ///     Stops the media
        /// </summary>
        /// <param name="transportId"></param>
        Task StopAsync(string transportId);

        /// <summary>
        ///     Seeks to the specified time
        /// </summary>
        /// <param name="seconds">time in seconds</param>
        /// <param name="transportId"></param>
        Task SeekAsync(double seconds, string transportId);
    }
}