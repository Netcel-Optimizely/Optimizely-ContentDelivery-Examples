using ContentCloud.Domain.PropertyListModels;
using EPiServer.ContentApi.Core.Serialization;
using EPiServer.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentCloud.Domain.PropertySerialization
{
    /// <inheritdoc />
    public class ListPropertyConvertorProvider : IPropertyConverterProvider
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListPropertyConvertorProvider"/> class.
        /// List property convertor provider
        /// </summary>
        /// <param name="serviceProvider"></param>
        public ListPropertyConvertorProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// The provider which has higher order will be called first to see if it handles specified <see cref="PropertyData" /> type
        /// </summary>
        public int SortOrder => 1000;

        /// <summary>
        /// Determines if provider supports specified <paramref name="propertyData" /> type and if so returns a matching
        /// <see cref="IPropertyConverter" /> instance. If <paramref name="propertyData" /> is not supported return null
        /// </summary>
        /// <param name="propertyData">instance of <see /> to resolve <see /> for</param>
        /// <returns>A matching <see /> or null if <paramref name="propertyData" /> is not supported by the provider</returns>
        public IPropertyConverter Resolve(PropertyData propertyData)
        {
            return propertyData switch
            {
                PropertyList<BenefitItemModel> => _serviceProvider.GetService<BenefitItemListPropertyConvertor>(),
                _ => null,
            };
        }
    }
}
