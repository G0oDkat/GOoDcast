namespace GOoDcast.Messages.Media
{
    using System.Collections.Generic;
    using Models.Media;

    /// <summary>
    ///     Media event EDIT_TRACKS_INFO request data
    /// </summary>
    internal class EditTracksInfoMessage : MediaSessionMessage
    {
        /// <summary>
        ///     Gets or sets the track identifiers that should be active
        /// </summary>
        public IEnumerable<int> ActiveTrackIds { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the text tracks should be enabled or not
        /// </summary>
        public bool EnableTextTracks { get; set; }

        /// <summary>
        ///     Gets or sets the language for the tracks that should be active
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        ///     Gets or sets the text track style.
        ///     If it is not provided the existing style will be used (if no style was provided in previous calls, it will be the
        ///     default receiver style)
        /// </summary>
        public TextTrackStyle TextTrackStyle { get; set; }
    }
}