using ContentCloud.Domain.PropertyListModels;
using EPiServer.ContentApi.Core.Serialization;
using EPiServer.Core;

namespace ContentCloud.Domain.PropertySerialization
{
    /// <summary>
    /// Benefit items property convertor
    /// </summary>
    public class BenefitItemListPropertyConvertor : IPropertyConverter
    {
        /// <inheritdoc />
        public IPropertyModel Convert(PropertyData propertyData, ConverterContext contentMappingContext)
        {
            return new BenefitItemPropertyModel((PropertyList<BenefitItemModel>)propertyData);
        }
    }
}
