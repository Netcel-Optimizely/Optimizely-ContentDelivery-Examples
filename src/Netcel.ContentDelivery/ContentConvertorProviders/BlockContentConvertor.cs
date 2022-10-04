using EPiServer.ContentApi.Core.Serialization;
using EPiServer.Core;
using Netcel.ContentDelivery.ContentConvertor;

namespace Netcel.ContentDelivery.ContentConvertorProviders
{
    public class BlockContentConvertorProvider : IContentConverterProvider
    {
        private readonly BlockContentConvertor _blockContentConvertor;

        /// <summary />
        /// <param name="blockContentConvertor"></param>
        public BlockContentConvertorProvider(BlockContentConvertor blockContentConvertor)
        {
            _blockContentConvertor = blockContentConvertor;
        }

        /// <summary>
        /// The mapper with higher order is chosen to handle a specific content in different contexts. The Default implementation has Order 100.
        /// </summary>
        public int SortOrder => 190;

        /// <summary>
        /// Determines if provider supports specified <paramref name="content" /> type and if so returns a matching
        /// <see cref="IContentConverter" /> instance. If <paramref name="content" /> is not supported return null
        /// </summary>
        /// <param name="content">instance of <see cref="IContent" /> to resolve <see cref="IContentConverter" /> for</param>
        /// <returns>A matching <see cref="IContentConverter" /> or null if <paramref name="content" /> is not supported by the provider</returns>
        public IContentConverter Resolve(IContent content)
        {
            if (content is BlockData)
            {
                return _blockContentConvertor;
            }

            return null!;
        }
    }
}
