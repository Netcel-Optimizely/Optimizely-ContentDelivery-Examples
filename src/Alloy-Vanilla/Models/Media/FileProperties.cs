namespace Alloy_Vanilla.Models.Media
{
    /// <summary>
    /// Used to capture the properties of a file.
    /// </summary>
    /// <remarks>
    /// These should be generic properties.
    /// </remarks>
    public class FileProperties
    {
        /// <summary>
        /// Gets or sets the size of the file (in KB).
        /// </summary>
        /// <value>
        /// The size of the file (in KB).
        /// </value>
        public long FileSize { get; set; } = 0;
    }
}
