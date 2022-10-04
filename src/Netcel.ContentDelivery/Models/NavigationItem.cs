using System.Collections.Generic;
using System.Linq;

namespace Netcel.ContentDelivery.Models
{    
    /// <summary>
     /// Navigation Item Dto.
     /// </summary>
    public class NavigationItem
    {
        /// <summary>
        /// Gets or sets navigation Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets navigation Url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether true if it matches the current page.
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// Is Visibly in Menu Property Set
        /// </summary>
        public bool VisibleInMenu { get; set; }

        public IEnumerable<NavigationItem> Children { get; set; } = Enumerable.Empty<NavigationItem>();
    }
}
