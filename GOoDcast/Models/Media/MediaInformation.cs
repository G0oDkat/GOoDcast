namespace GOoDcast.Models.Media
{
    using System.Collections.Generic;

    /// <summary>
    ///     Describes a media stream
    /// </summary>
    public class MediaInformation
    {
        public MediaInformation()
        {
            StreamType = StreamType.Buffered;
        }

        /// <summary>
        ///     Gets or sets the service-specific identifier of the content currently loaded by the media player
        /// </summary>
        public string ContentId { get; set; }

        /// <summary>
        ///     Gets or sets the type of media artifact
        /// </summary>
        public StreamType StreamType { get; set; }

        /// <summary>
        ///     Gets or sets the MIME content type of the media being played
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        ///     Gets or sets the media metadata object
        /// </summary>
        public GenericMediaMetadata Metadata { get; set; }

        /// <summary>
        ///     Gets or sets the duration of the currently playing stream in seconds
        /// </summary>
        public double? Duration { get; set; }

        /// <summary>
        ///     Gets or sets the custom data
        /// </summary>
        public IDictionary<string, string> CustomData { get; set; }

        /// <summary>
        ///     Gets or sets the tracks
        /// </summary>
        public IEnumerable<Track> Tracks { get; set; }

        /// <summary>
        ///     Gets or sets the style of text track
        /// </summary>
        public TextTrackStyle TextTrackStyle { get; set; }
    }
}