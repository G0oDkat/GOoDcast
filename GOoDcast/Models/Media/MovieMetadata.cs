namespace GOoDcast.Models.Media
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Movie metadata
    /// </summary>
    [DataContract]
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
        [DataMember(Name = "studio")]
        public string Studio { get; set; }
    }
}
