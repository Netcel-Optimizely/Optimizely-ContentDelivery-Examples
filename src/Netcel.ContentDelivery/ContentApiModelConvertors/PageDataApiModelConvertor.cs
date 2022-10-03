using EPiServer;
using EPiServer.ContentApi.Core.Serialization;
using EPiServer.ContentApi.Core.Serialization.Models;
using EPiServer.Core;
using EPiServer.Web.Routing;
using Netcel.ContentDelivery.Interfaces;
using Netcel.ContentDelivery.Models;

namespace Netcel.ContentDelivery.ContentApiModelConvertors
{
    /// <summary>
    /// Page Data Content Convertor
    /// </summary>
    public class PageDataApiModelConvertor : IContentApiModelConvertor
    {
        private readonly IContentLoader _contentLoader;
        private readonly IUrlResolver _urlResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageDataApiModelConvertor"/> class.
        /// </summary>
        /// <param name="contentLoader"></param>
        /// <param name="urlResolver"></param>
        public PageDataApiModelConvertor(IContentLoader contentLoader, IUrlResolver urlResolver)
        {
            _contentLoader = contentLoader;
            _urlResolver = urlResolver;
        }

        public void Convert(IContent content, ContentApiModel contentApiModel, ConverterContext converterContext)
        {
            if (content is not PageData)
            {
                return;
            }

            // add navigation
            var navigation = new List<NavigationItem>();
            var children = _contentLoader.GetChildren<IContent>(content.ContentLink);
            navigation.AddRange(children.Select(x => CreateNavigationStructure(x, content)));
            contentApiModel.Properties.Add("ChildPages", navigation);


        }

        private NavigationItem CreateNavigationStructure(IContent page, IContent currentContent)
        {
            var model = CreateNavigationItem(page, currentContent);
            var children = _contentLoader.GetChildren<IContent>(page.ContentLink);
            model.Children = children.Select(x => CreateNavigationStructure(x, currentContent));

            return model;
        }

        private NavigationItem CreateNavigationItem(IContent pageContent, IContent currentContent)
        {
            return new NavigationItem
            {
                Title = pageContent.Name,
                Url = _urlResolver.GetUrl(pageContent.ContentLink),
                IsSelected = pageContent.ContentLink == currentContent.ContentLink
            };
        }
    }
}
