namespace Alloy_Vanilla.Models.Media
{
    using System;
    using System.Drawing;

    using EPiServer.Core;
    using EPiServer.Logging;
    using EPiServer.ServiceLocation;

    /// <summary>
    /// Default Netcel implementation for processing Media files.
    /// </summary>
    /// <remarks>
    /// This will automatically be used unless explicitly overriden by the <see cref="MediaEventsInitializationModule"/>
    /// </remarks>
    /// <seealso cref="Netcel.Framework.CMS.Web.Models.Media.IMediaProcessor" />
    public class DefaultNetcelMediaProcessor : IMediaProcessor
    {
        /// <summary>
        /// Processes the specified media data content.
        /// </summary>
        /// <param name="content">The media data content to process</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Process(MediaData content)
        {
            if (content is IHasPixelSize && content is IHasFileSize)
            {
                var fileInfo = this.GetImage(content);
                ((IHasFileSize)content).FileSize = (int)fileInfo.FileSize;
                ((IHasPixelSize)content).Width = fileInfo.Width;
                ((IHasPixelSize)content).Height = fileInfo.Height;
            }
            else if (content is IHasFileSize)
            {
                var fileSize = this.GetFileSize(content);
                ((IHasFileSize)content).FileSize = (int)fileSize.FileSize;
            }
        }


        /// <summary>
        /// Gets the size of the file.
        /// </summary>
        /// <param name="media">The media.</param>
        /// <returns>Size if the file in KB</returns>
        internal virtual FileProperties GetFileSize(MediaData media)
        {
            try
            {
                if (media?.BinaryData != null)
                {
                    using (var stream = media.BinaryData.OpenRead())
                    {
                        return new FileProperties { FileSize = stream.Length / 1024 };
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = ServiceLocator.Current.GetInstance<ILogger>();

                logger.Error("Error whislt getting properties from media file: ", ex);
            }

            return new FileProperties();
        }

        /// <summary>
        /// Gets the image properties from the media file.
        /// </summary>
        /// <param name="media">The media file.</param>
        /// <returns><see cref="ImageFileProperties"/> with the image dimensions</returns>
        internal virtual ImageFileProperties GetImage(MediaData media)
        {
            try
            {
                if (media?.BinaryData != null)
                {
                    using (var stream = media.BinaryData.OpenRead())
                    {
                        using (var img = new Bitmap(stream))
                        {
                            return new ImageFileProperties
                            {
                                FileSize = stream.Length / 1024,
                                Height = img.Height,
                                Width = img.Width
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = ServiceLocator.Current.GetInstance<ILogger>();

                logger.Error("Error whislt getting image properties from media file: ", ex);
            }

            return new ImageFileProperties();
        }
    }
}
