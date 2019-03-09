namespace GOoDcast.Models.Media
{
    /// <summary>
    /// Movie metadata
    /// </summary>
    public class MovieMetadata : GenericMediaMetadata
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MovieMetadata"/> class
        /// </summary>
        public MovieMetadata()
        {
            MetadataType = MetadataType.Movie;
        }

        /// <summary>
        /// Gets or sets the studio
        /// </summary>
        public string Studio { get; set; }
    }
}
