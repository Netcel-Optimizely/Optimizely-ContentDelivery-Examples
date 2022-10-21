using ContentCloud.Domain.PropertyListModels;
using EPiServer.ContentApi.Core.Serialization.Models;
using EPiServer.Core;

namespace ContentCloud.Domain.PropertySerialization
{
    /// <inheritdoc />
    public class BenefitItemPropertyModel : PropertyModel<IEnumerable<BenefitItemModel>, PropertyList<BenefitItemModel>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BenefitItemPropertyModel"/> class.
        /// </summary>
        /// <param name="type"></param>
        public BenefitItemPropertyModel(PropertyList<BenefitItemModel> type)
            : base(type)
        {
            Value = GetValues(type.List);
        }

        private IEnumerable<BenefitItemModel> GetValues(IList<BenefitItemModel> items)
        {
            return items.Select(x => new BenefitItemModel
            {
                BenefitText = x.BenefitText,
                BenefitIcon = x.BenefitIcon
            });
        }
    }
}
