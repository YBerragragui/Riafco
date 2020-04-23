using Riafco.Service.Dataflex.Pro.Languages.Data;

namespace Riafco.Service.Dataflex.Pro.Ressources.Data
{
    /// <summary>
    /// The AreaTranslation pivot class.
    /// </summary>
    public class AreaTranslationPivot
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  AreaName.
        /// </summary>
        public string AreaName { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  AreaId.
        /// </summary>
        public int? AreaId { get; set; }

        /// <summary>
        /// Gets or Sets The  Area.
        /// </summary>
        public AreaPivot Area { get; set; }

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguagePivot Language { get; set; }
        #endregion
    }
}