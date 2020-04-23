
using Riafco.Dataflex.Pro.Models.Settings.ItemData;

namespace Riafco.Dataflex.Pro.Models.About.ItemData
{
    /// <summary>
    /// The ActiviteTraduction dto class.
    /// </summary>
    public class SectionTranslationItemData
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionTitle.
        /// </summary>
        public string SectionTitle { get; set; }

        /// <summary>
        /// Gets or sets SectionDesciption.
        /// </summary>
        public string SectionDesciption { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguageItemData Language { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionId.
        /// </summary>
        public int? SectionId { get; set; }

        /// <summary>
        /// Gets or Sets The  Section.
        /// </summary>
        public SectionItemData Section { get; set; }

        #endregion
    }
}