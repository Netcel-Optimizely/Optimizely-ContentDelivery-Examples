namespace Alloy_Vanilla.Models.Media
{
    /// <summary>
    /// Interface used to indicate that the pixel size is stored with the media item
    /// </summary>
    public interface IHasPixelSize
    {
        /// <summary>
        /// Gets or sets the height of the image (in pixels).
        /// </summary>
        /// <value>
        /// The height of the image (in pixels).
        /// </value>
        int Height { get; set; }

        /// <summary>
        /// Gets or sets the width of the image (in pixels).
        /// </summary>
        /// <value>
        /// The width of the image (in pixels).
        /// </value>
        int Width { get; set; }
    }
}
