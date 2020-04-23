using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData;

namespace Admin.Riafco.Dataflex.Pro.Models.About.ViewData
{
    /// <summary>
    /// The FileViewData class.
    /// </summary>
    public class FileViewData
    {
        /// <summary>
        /// Gets or sets File.
        /// </summary>
        public SectionFileItemData File { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<SectionFileTranslationItemData> TranslationsList { get; set; }
    }
}