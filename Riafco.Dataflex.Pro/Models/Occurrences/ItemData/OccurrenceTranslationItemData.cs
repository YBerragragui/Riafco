
using Riafco.Dataflex.Pro.Models.Settings.ItemData;

namespace Riafco.Dataflex.Pro.Models.Occurrences.ItemData
{
    /// <summary>
    /// The ActiviteTraduction dto class.
    /// </summary>
    public class OccurrenceTranslationItemData
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  OccurrenceTitle.
        /// </summary>
        public string OccurrenceTitle { get; set; }

        /// <summary>
        /// Gets or Sets The  OccurrenceDescription.
        /// </summary>
        public string OccurrenceDescription { get; set; }

        #region navigation properties
        /// <summary>
        /// Gets or Sets The  OccurrenceId.
        /// </summary>
        public int? OccurrenceId { get; set; }

        /// <summary>
        /// Gets or Sets The  Occurrence.
        /// </summary>
        public OccurrenceItemData Occurrence { get; set; }
        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguageItemData Language { get; set; }
        #endregion
    }
}