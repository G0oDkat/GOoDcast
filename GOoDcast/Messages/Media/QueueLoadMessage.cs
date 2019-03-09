namespace GOoDcast.Messages.Media
{
    using System.Collections.Generic;
    using Miscellaneous;
    using Models.Media;

    /// <summary>
    ///     A request to load and optionally start playback of a new ordered list of media items
    /// </summary>
    internal class QueueLoadMessage : SessionMessage
    {
        /// <summary>
        ///     Gets or sets the array of items to load. It is sorted (first element will be played first)
        /// </summary>
        /// <remarks>must not be null or empty</remarks>
        public IEnumerable<QueueItem> Items { get; set; }

        /// <summary>
        ///     Gets or sets the algorithm for selection of the next item when the current item has ended
        /// </summary>
        public RepeatMode RepeatMode { get; set; }

        /// <summary>
        ///     Gets or sets the index of the item in the items array that must be the first currentItem (the item that will be
        ///     played first)
        /// </summary>
        public int StartIndex { get; set; }
    }
}