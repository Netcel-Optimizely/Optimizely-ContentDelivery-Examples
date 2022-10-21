using System.ComponentModel.DataAnnotations;

namespace ContentCloud.Domain.PropertyListModels
{
    /// <summary>
    /// Benefit item property model
    /// </summary>
    public class BenefitItemModel
    {
        /// <summary>
        /// Icon
        /// </summary>
        [Display(Name = "Benefit Icon", Order = 10)]
        public virtual string BenefitIcon { get; set; }

        /// <summary>
        /// Text
        /// </summary>
        [Display(Name = "Benefit Text", Order = 20)]
        [Required]
        public virtual string BenefitText { get; set; }
    }
}
