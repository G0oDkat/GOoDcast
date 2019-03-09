namespace GOoDcast.Models.Media
{
    using System.Drawing;
    using Json.Convertes;
    using Newtonsoft.Json;

    /// <summary>
    ///     Describes style information for a text track
    /// </summary>
    public class TextTrackStyle
    {
        /// <summary>
        ///     Gets or sets the background 32 bit RGBA color
        /// </summary>
        /// <remarks>the alpha channel should be used for transparent backgrounds</remarks>
        [JsonProperty(ItemConverterType = typeof(NullableColorConverter))]
        public Color? BackgroundColor { get; set; }

        /// <summary>
        ///     Gets or sets the RGBA color for the edge
        /// </summary>
        /// <remarks>this value will be ignored if EdgeType is None</remarks>
        [JsonProperty(ItemConverterType = typeof(NullableColorConverter))]
        public Color? EdgeColor { get; set; }

        /// <summary>
        ///     Gets or sets the text track edge type
        /// </summary>
        public TextTrackEdgeType? EdgeType { get; set; }

        /// <summary>
        ///     Gets or sets the font family
        /// </summary>
        /// <remarks>if the font is not available in the receiver, the fontGenericFamily will be used</remarks>
        public string FontFamily { get; set; }

        /// <summary>
        ///     Gets or sets the text track generic family
        /// </summary>
        public TextTrackFontGenericFamily? FontGenericFamily { get; set; }

        /// <summary>
        ///     Gets or sets font scaling factor for the text track
        /// </summary>
        /// <remarks>the default is 1</remarks>
        public float? FontScale { get; set; }

        /// <summary>
        ///     Gets or sets the text track font style
        /// </summary>
        public TextTrackFontStyle? FontStyle { get; set; }

        /// <summary>
        ///     Gets or sets the foreground 32 bit RGBA color
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(NullableColorConverter))]
        public Color? ForegroundColor { get; set; }

        /// <summary>
        ///     Gets or sets the 32 bit RGBA color for the window
        /// </summary>
        /// <remarks>this value will be ignored if WindowType is None</remarks>
        [JsonProperty(ItemConverterType = typeof(NullableColorConverter))]
        public Color? WindowColor { get; set; }

        /// <summary>
        ///     Gets or sets the rounded corner radius absolute value in pixels (px)
        /// </summary>
        /// <remarks>this value will be ignored if windowType is not RoundedCorners</remarks>
        public ushort? WindowRoundedCornerRadius { get; set; }

        /// <summary>
        ///     Gets or sets the window type
        /// </summary>
        /// <remarks>the window concept is defined in CEA-608 and CEA-708. In WebVTT is called a region</remarks>
        public TextTrackWindowType? WindowType { get; set; }
    }
}