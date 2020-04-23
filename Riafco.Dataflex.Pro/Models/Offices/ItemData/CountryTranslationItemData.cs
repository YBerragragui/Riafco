
using Riafco.Dataflex.Pro.Models.Settings.ItemData;

namespace Riafco.Dataflex.Pro.Models.Offices.ItemData
{
    /// <summary>
    /// The CountreTraduction dto class.
    /// </summary>
    public class CountryTranslationItemData
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  CountryTitle.
        /// </summary>
        public string CountryName { get; set; }


        /// <summary>
        /// Gets or Sets The  CountryTitle.
        /// </summary>
        public string CountryTitle { get; set; }

        /// <summary>
        /// Gets or Sets The  CountryIntroduction.
        /// </summary>
        public string CountrySummary { get; set; }

        /// <summary>
        /// Gets or Sets The  CountryDescription.
        /// </summary>
        public string CountryDescription { get; set; }

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
        /// Gets or Sets The  CountryId.
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// Gets or Sets The  Country.
        /// </summary>
        public CountryItemData Country { get; set; }

        #endregion
    }
}