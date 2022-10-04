namespace Alloy_Vanilla.Models.Media;
/// <summary>
/// Interface defining the process of handing EPiServer Media Data.  This is used by <see cref="MediaEventsInitializationModule"/>
/// <para>
/// This allows for more control over how media files are processed when they are uploaded into the CMS
/// </para>
/// </summary>
public interface IMediaProcessor
{
    /// <summary>
    /// Processes the specified media data content.
    /// </summary>
    /// <param name="content">The media data content to process</param>
    void Process(MediaData content);
}

