namespace Alloy_Vanilla.Models.Media
{
    /// <summary>
    /// Interface used to indicate that the file size is stored with the media item
    /// </summary>
    public interface IHasFileSize
    {
        /// <summary>
        /// Gets or sets the size of the file (in KB).
        /// </summary>
        /// <value>
        /// The size of the file (in KB).
        /// </value>
        int FileSize { get; set; }
    }
}
