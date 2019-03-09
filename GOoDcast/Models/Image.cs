namespace GOoDcast.Models
{
    /// <summary>
    /// Image
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Gets or sets the URI for the image
        /// </summary>        
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the height of the image
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets the width of the image
        /// </summary>
        public int? Width { get; set; }
    }
}
