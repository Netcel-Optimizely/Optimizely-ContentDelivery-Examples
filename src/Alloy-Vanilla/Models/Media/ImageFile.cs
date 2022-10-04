using EPiServer.Framework.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Alloy_Vanilla.Models.Media;

[ContentType(GUID = "0A89E464-56D4-449F-AEA8-2BF774AB8730")]
[MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png")]
public class ImageFile : ImageData, IHasFileSize, IHasPixelSize
{
    /// <summary>
    /// Gets or sets the copyright.
    /// </summary>
    /// <value>
    /// The copyright.
    /// </value>
    public virtual string Copyright { get; set; }

    /// <summary>
    /// Gets or sets the size of the file (in KB).
    /// </summary>
    /// <value>
    /// The size of the file (in KB).
    /// </value>
    [Editable(false)]
    public virtual int FileSize { get; set; }

    /// <summary>
    /// Gets or sets the height of the image (in pixels).
    /// </summary>
    /// <value>
    /// The height of the image (in pixels).
    /// </value>
    [Editable(false)]
    public virtual int Height { get; set; }

    /// <summary>
    /// Gets or sets the width of the image (in pixels).
    /// </summary>
    /// <value>
    /// The width of the image (in pixels).
    /// </value>
    [Editable(false)]
    public virtual int Width { get; set; }
}
