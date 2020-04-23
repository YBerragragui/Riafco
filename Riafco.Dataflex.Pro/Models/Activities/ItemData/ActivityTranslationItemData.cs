
using Riafco.Dataflex.Pro.Models.Settings.ItemData;

namespace Riafco.Dataflex.Pro.Models.Activities.ItemData
{
    /// <summary>
    /// The ActiviteTraduction dto class.
    /// </summary>
    public class ActivityTranslationItemData
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityTitle.
        /// </summary>
        public string ActivityTitle { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityIntroduction.
        /// </summary>
        public string ActivityIntroduction { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityDescription.
        /// </summary>
        public string ActivityDescription { get; set; }

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
        /// Gets or Sets The  ActivityId.
        /// </summary>
        public int? ActivityId { get; set; }

        /// <summary>
        /// Gets or Sets The  Activity.
        /// </summary>
        public ActivityItemData Activity { get; set; }

        #endregion
    }
}