namespace Alloy_Vanilla.Models.Media
{
    /// <summary>
    /// Used to capture the properties of an image file.
    /// </summary>
    /// <seealso cref="Netcel.Framework.CMS.Web.Models.Media.FileProperties" />
    public class ImageFileProperties : FileProperties
    {
        /// <summary>
        /// Gets or sets the width (in px).
        /// </summary>
        /// <value>
        /// The width (in px).
        /// </value>
        public int Width { get; set; } = 0;

        /// <summary>
        /// Gets or sets the height (in px).
        /// </summary>
        /// <value>
        /// The height (in px).
        /// </value>
        public int Height { get; set; } = 0;
    }
}
