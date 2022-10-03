using EPiServer.ContentApi.Core.Serialization;
using EPiServer.ContentApi.Core.Serialization.Models;
using EPiServer.Core;

namespace Netcel.ContentDelivery.Interfaces
{
    /// <summary>
    /// Content api model property convertor
    /// </summary>
    public interface IContentApiModelConvertor
    {
        /// <summary>
        /// Convert content to api model
        /// </summary>
        /// <param name="content"></param>
        /// <param name="contentApiModel"></param>
        /// <param name="converterContext"></param>
        void Convert(IContent content, ContentApiModel contentApiModel, ConverterContext converterContext);
    }
}
