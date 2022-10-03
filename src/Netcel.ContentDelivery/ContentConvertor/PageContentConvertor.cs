using System.Collections.Generic;
using EPiServer.ContentApi.Core.Internal;
using EPiServer.ContentApi.Core.Serialization;
using EPiServer.ContentApi.Core.Serialization.Internal;
using EPiServer.ContentApi.Core.Serialization.Models;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Security;
using EPiServer.Web;
using Microsoft.AspNetCore.Http;
using Netcel.ContentDelivery.Interfaces;

namespace Netcel.ContentDelivery.ContentConvertor
{
    public class PageContentConvertor : DefaultContentConverter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEnumerable<IContentApiModelConvertor> _contentApiModelConvertors;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageContentConvertor"/> class.
        /// </summary>
        public PageContentConvertor()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageContentConvertor"/> class.
        /// Default page convertor
        /// </summary>
        /// <param name="contentTypeRepository"></param>
        /// <param name="reflectionService"></param>
        /// <param name="contentModelService"></param>
        /// <param name="contentVersionRepository"></param>
        /// <param name="contentLoaderService"></param>
        /// <param name="urlResolverService"></param>
        /// <param name="propertyConverterResolver"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="contentApiModelConvertors"></param>
        public PageContentConvertor(
            IContentTypeRepository contentTypeRepository,
            ReflectionService reflectionService,
            IContentModelReferenceConverter contentModelService,
            IContentVersionRepository contentVersionRepository,
            ContentLoaderService contentLoaderService,
            UrlResolverService urlResolverService,
            IPropertyConverterResolver propertyConverterResolver,
            IHttpContextAccessor httpContextAccessor,
            IEnumerable<IContentApiModelConvertor> contentApiModelConvertors)
            : base(
                contentTypeRepository,
                reflectionService,
                contentModelService,
                contentVersionRepository,
                contentLoaderService,
                urlResolverService,
                propertyConverterResolver)
        {
            _httpContextAccessor = httpContextAccessor;
            _contentApiModelConvertors = contentApiModelConvertors;
        }

        /// <summary />
        /// <param name="content"></param>
        /// <param name="converterContext"></param>
        /// <returns></returns>
        public override ContentApiModel Convert(IContent content, ConverterContext converterContext)
        {
            if (converterContext.ContextMode.EditOrPreview())
            {
                _httpContextAccessor.HttpContext.SetupVisitorGroupImpersonation(content, AccessLevel.Read);
            }

            var model = base.Convert(content, converterContext);

            foreach (var convertor in _contentApiModelConvertors)
            {
                convertor.Convert(content, model, converterContext);
            }

            if (converterContext.Options.FlattenPropertyModel)
            {
                FlattenPropertyMap(model);
            }

            return model;
        }
    }
}
