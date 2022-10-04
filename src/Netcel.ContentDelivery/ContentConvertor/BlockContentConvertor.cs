using EPiServer.ContentApi.Core.Internal;
using EPiServer.ContentApi.Core.Serialization;
using EPiServer.ContentApi.Core.Serialization.Internal;
using EPiServer.ContentApi.Core.Serialization.Models;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netcel.ContentDelivery.ContentConvertor
{
    /// <summary>
    /// Block convertor
    /// </summary>
    public class BlockContentConvertor : DefaultContentConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlockContentConvertor"/> class.
        /// Default page convertor
        /// </summary>
        /// <param name="contentTypeRepository"></param>
        /// <param name="reflectionService"></param>
        /// <param name="contentModelService"></param>
        /// <param name="contentVersionRepository"></param>
        /// <param name="contentLoaderService"></param>
        /// <param name="urlResolverService"></param>
        /// <param name="propertyConverterResolver"></param>
        /// <param name="supportedDisplayOptionsProvider"></param>
        /// <param name="relatedGlobalContentConvertor"></param>
        public BlockContentConvertor(
            IContentTypeRepository contentTypeRepository,
            ReflectionService reflectionService,
            IContentModelReferenceConverter contentModelService,
            IContentVersionRepository contentVersionRepository,
            ContentLoaderService contentLoaderService,
            UrlResolverService urlResolverService,
            IPropertyConverterResolver propertyConverterResolver)
            : base(
                contentTypeRepository,
                reflectionService,
                contentModelService,
                contentVersionRepository,
                contentLoaderService,
                urlResolverService,
                propertyConverterResolver)
        {

        }

        /// <inheritdoc />
        public override ContentApiModel Convert(IContent content, ConverterContext converterContext)
        {
            var model = base.Convert(content, converterContext);

            return model;
        }
    }
}
