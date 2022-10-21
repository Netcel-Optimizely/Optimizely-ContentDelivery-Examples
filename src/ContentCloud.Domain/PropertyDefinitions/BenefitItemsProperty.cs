using ContentCloud.Domain.PropertyListModels;
using EPiServer.Core;
using EPiServer.PlugIn;

namespace ContentCloud.Domain.PropertyDefinitions
{
    /// <summary>
    /// Benefit items property
    /// </summary>
    [PropertyDefinitionTypePlugIn]
    public class BenefitItemsProperty : PropertyList<BenefitItemModel>
    {
    }
}
