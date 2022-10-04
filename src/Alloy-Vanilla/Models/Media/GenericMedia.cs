using System.ComponentModel.DataAnnotations;

namespace Alloy_Vanilla.Models.Media;

[ContentType(GUID = "EE3BD195-7CB0-4756-AB5F-E5E223CD9820")]
public class GenericMedia : MediaData, IHasFileSize
{
    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    public virtual string Description { get; set; }

    /// <summary>
    /// Gets or sets the size of the file (in KB).
    /// </summary>
    /// <value>
    /// The size of the file (in KB).
    /// </value>
    [Editable(false)]
    public virtual int FileSize { get; set; }
}
