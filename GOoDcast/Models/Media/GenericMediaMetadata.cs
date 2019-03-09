namespace GOoDcast.Models.Media
{
    /// <summary>
    /// Media metadata
    /// </summary>
    public class GenericMediaMetadata
    {
        /// <summary>
        /// Initializes a new instance of <see cref="GenericMediaMetadata"/> class
        /// </summary>
        public GenericMediaMetadata()
        {
            MetadataType = MetadataType.Default;
        }

        /// <summary>
        /// Gets the metadata type
        /// </summary>
        public MetadataType MetadataType { get; protected set; }
        
        /// <summary>
        /// Gets or sets the descriptive title of the content
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the descriptive subtitle of the content
        /// </summary>
        public string Subtitle { get; set; }

        /// <summary>
        /// Gets or sets an array of URL(s) to an image associated with the content
        /// </summary>
        public Image[] Images { get; set; }
    }
}
