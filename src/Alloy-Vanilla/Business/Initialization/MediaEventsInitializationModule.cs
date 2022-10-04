using Alloy_Vanilla.Models.Media;
using EPiServer.Framework.Initialization;
using EPiServer.Framework;

namespace Alloy_Vanilla.Business.Initialization
{
    using System;

    using EPiServer;
    using EPiServer.Core;
    using EPiServer.Framework;
    using EPiServer.Framework.Initialization;
    using EPiServer.ServiceLocation;
    using EPiServer.Web;

    /// <summary>
    ///     This initialization module intercepts the uploading or creation of a media file.
    ///     <para>
    ///         It will call the registered <see cref="IMediaProcessor" /> to process the media file.  If no explicit process
    ///         has be registered via IOC then the default processor <see cref="DefaultNetcelMediaProcessor" /> will be used.
    ///     </para>
    /// </summary>
    /// <seealso cref="EPiServer.Framework.IInitializableModule" />
    [InitializableModule]
    [ModuleDependency(typeof(InitializationModule))]
    public class MediaEventsInitializationModule : IInitializableModule
    {
        #region Fields

        private Lazy<IMediaProcessor> mediaProcessor;

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the media processor.
        /// </summary>
        /// <value>
        ///     The media processor.
        /// </value>
        public IMediaProcessor MediaProcessor
        {
            get
            {
                if (mediaProcessor == null)
                {
                    object processor = null;

                    if (ServiceLocator.Current.TryGetExistingInstance(typeof(IMediaProcessor), out processor))
                    {
                        mediaProcessor = new Lazy<IMediaProcessor>(() => processor as IMediaProcessor);
                    }
                    else
                    {
                        mediaProcessor = new Lazy<IMediaProcessor>(() => new DefaultNetcelMediaProcessor());
                    }
                }

                return mediaProcessor.Value;
            }
        }

        #endregion

        #region Explicit Interface Events

        /// <summary>
        ///     Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void Initialize(InitializationEngine context)
        {
            var eventRegistry = ServiceLocator.Current.GetInstance<IContentEvents>();

            eventRegistry.CreatingContent += OnCreatingContent;
            eventRegistry.SavingContent += OnSavingContent;
        }

        /// <summary>
        ///     Uninitializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void Uninitialize(InitializationEngine context)
        {
            var eventRegistry = ServiceLocator.Current.GetInstance<IContentEvents>();

            eventRegistry.CreatingContent -= OnCreatingContent;
            eventRegistry.SavingContent -= OnSavingContent;
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Called when [creating content].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ContentEventArgs" /> instance containing the event data.</param>
        private void OnCreatingContent(object sender, ContentEventArgs e)
        {
            var content = e.Content as MediaData;

            if (content == null)
            {
                return;
            }

            MediaProcessor.Process(content);
        }

        /// <summary>
        ///     Called when [saving content].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ContentEventArgs" /> instance containing the event data.</param>
        private void OnSavingContent(object sender, ContentEventArgs e)
        {
            var content = e.Content as MediaData;

            if (content == null)
            {
                return;
            }

            MediaProcessor.Process(content);
        }

        #endregion
    }
}
