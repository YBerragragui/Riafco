using Riafco.Service.Dataflex.Pro.Languages.Data;

namespace Riafco.Service.Dataflex.Pro.Activites.Data
{
    /// <summary>
    /// The ActivityTranslation pivot class.
    /// </summary>
    public class ActivityTranslationPivot
    {
        /// <summary>
        /// Gets or Sets The TranslationId.
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
        public LanguagePivot Language { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityId.
        /// </summary>
        public int? ActivityId { get; set; }

        /// <summary>
        /// Gets or Sets The  Activity.
        /// </summary>
        public ActivityPivot Activity { get; set; }
        #endregion
    }
}