using System.Collections.Generic;

namespace Riafco.Dataflex.Pro.Models.About.ItemData
{
    /// <summary>
    /// The Activite dto class.
    /// </summary>
    public class SectionItemData
    {
        /// <summary>
        /// Gets or Sets The  SectionId.
        /// </summary>
        public int SectionId { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionImage.
        /// </summary>
        public string SectionImage { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or sets Translations
        /// </summary>
        public List<SectionTranslationItemData> TranslationItemDataList { get; set; }

        #endregion
    }
}