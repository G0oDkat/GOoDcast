namespace GOoDcast.Messages.Media
{
    /// <summary>
    /// Message to set the current position in the stream
    /// </summary>
    class SeekMessage : MediaSessionMessage
    {
        /// <summary>
        /// Gets or sets the seconds since beginning of content
        /// </summary>
        /// <remarks>if the content is live content, and position is not specifed, the stream will start at the live position</remarks>
        public double CurrentTime { get; set; }
    }
}
