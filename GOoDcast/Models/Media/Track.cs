namespace GOoDcast.Models.Media
{
    /// <summary>
    ///     Track metadata information
    /// </summary>
    public class Track
    {
        public Track()
        {
            Type = TrackType.Text;
            TrackContentType = "text/vtt";
        }

        /// <summary>
        ///     Gets or sets the unique identifier of the track
        /// </summary>
        public int TrackId { get; set; }

        /// <summary>
        ///     Gets or sets the type of track
        /// </summary>
        public TrackType Type { get; set; }

        /// <summary>
        ///     Gets or sets the MIME type of the track content
        /// </summary>
        public string TrackContentType { get; set; }

        /// <summary>
        ///     Gets or sets the identifier of the track’s content
        /// </summary>
        /// <remarks>
        ///     it can be the url of the track or any other identifier that allows the receiver to find the content
        ///     (when the track is not inband or included in the manifest)
        /// </remarks>
        public string TrackContentId { get; set; }

        /// <summary>
        ///     Gets or sets the type of text track
        /// </summary>
        public TextTrackType SubType { get; set; }

        /// <summary>
        ///     Gets or sets a descriptive, human readable name for the track
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the language tag as per RFC 5646
        /// </summary>
        /// <remarks>mandatory when the subtype is Subtitles</remarks>
        public string Language { get; set; }
    }
}