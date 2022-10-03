using EPiServer.ContentApi.Core.Serialization;
using EPiServer.Core;
using Netcel.ContentDelivery.ContentConvertor;

namespace Netcel.ContentDelivery.ContentConvertorProviders
{
    public class PageContentConvertorProvider : IContentConverterProvider
    {
        private readonly PageContentConvertor _pageContentConvertor;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageContentConvertorProvider"/> class.
        /// </summary>
        /// <param name="pageContentConvertor"></param>
        public PageContentConvertorProvider(PageContentConvertor pageContentConvertor)
        {
            _pageContentConvertor = pageContentConvertor;
        }

        public int SortOrder => 200;

        /// <summary>
        /// Resolve custom page convertor
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public IContentConverter Resolve(IContent content)
        {
            // further enhance this to allow different supported convertors
            return content is PageData ? _pageContentConvertor : null;
        }
    }
}
