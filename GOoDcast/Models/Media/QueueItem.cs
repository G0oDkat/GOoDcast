namespace GOoDcast.Models.Media
{
    using System.Collections.Generic;

    /// <summary>
    /// Queue item information
    /// </summary>    
    public class QueueItem
    {
        public QueueItem()
        {
            Autoplay = true;
        }

        /// <summary>
        /// Gets or sets the track identifiers that are active
        /// </summary>

        public IEnumerable<int> ActiveTrackIds { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the media will automatically play
        /// </summary>
        public bool Autoplay { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the item in the queue
        /// </summary>
        /// <remarks>the attribute is optional because for LOAD or INSERT should not be provided
        /// (as it will be assigned by the receiver when an item is first created/inserted).</remarks>        
        public int? ItemId { get; set; }

        /// <summary>
        /// Gets or sets the metadata (including contentId) of the playlist element
        /// </summary>        
        public MediaInformation Media { get; set; }

        /// <summary>
        /// Gets or sets the seconds from the beginning of the media to start playback
        /// </summary>
        public int? StartTime { get; set; }
    }
}
