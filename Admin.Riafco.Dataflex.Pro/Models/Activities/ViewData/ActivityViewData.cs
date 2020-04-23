using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.ViewData
{
    /// <summary>
    /// The ActivityViewData class.
    /// </summary>
    public class ActivityViewData
    {
        /// <summary>
        /// Gets or sets Activity.
        /// </summary>
        public ActivityItemData Activity { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<ActivityTranslationItemData> TranslationsList { get; set; }
    }
}