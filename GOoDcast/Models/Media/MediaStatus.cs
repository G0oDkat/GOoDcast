namespace GOoDcast.Models.Media
{
    /// <summary>
    /// Media status
    /// </summary>
    public class MediaStatus
    {
        /// <summary>
        /// Gets or sets the media session identifier
        /// </summary>        
        public long MediaSessionId { get; set; }

        /// <summary>
        /// Gets or sets the playback rate
        /// </summary>        
        public int PlaybackRate { get; set; }

        /// <summary>
        /// Gets or sets the player state
        /// </summary>        
        public string PlayerState { get; set; }

        /// <summary>
        /// Gets or sets the current time
        /// </summary>        
        public double CurrentTime { get; set; }

        /// <summary>
        /// Gets or sets the supported media commands
        /// </summary>        
        public int SupportedMediaCommands { get; set; }

        /// <summary>
        /// Gets or sets the volume
        /// </summary>        
        public Volume Volume { get; set; }

        /// <summary>
        /// Gets or sets the idle reason
        /// </summary>
        public string IdleReason { get; set; }

        /// <summary>
        /// Gets or sets the media
        /// </summary>
        public MediaInformation Media { get; set; }

        /// <summary>
        /// Gets or sets the current item identifier
        /// </summary>
        public int CurrentItemId { get; set; }

        /// <summary>
        /// Gets or sets the extended status
        /// </summary>
        public MediaStatus ExtendedStatus { get; set; }

        /// <summary>
        /// Gets or sets the repeat mode
        /// </summary>
        public string RepeatMode { get; set; }
    }
}
