
using System.Collections.Generic;
using Riafco.Dataflex.Pro.Models.Activities.ItemData;

namespace Riafco.Dataflex.Pro.Models.Activities.ViewData
{
    /// <summary>
    /// The FileViewData class.
    /// </summary>
    public class FileViewData
    {
        /// <summary>
        /// Gets or sets File.
        /// </summary>
        public ActivityFileItemData File { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<ActivityFileTranslationItemData> TranslationsList { get; set; }
    }
}