using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Offices.Data;
using Riafco.Service.Dataflex.Pro.Languages.Data;

namespace Riafco.Service.Dataflex.Pro.Offices.Data
{
    /// <summary>
    /// The CountryTranslation pivot class.
    /// </summary>
    public class CountryTranslationPivot
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  CountryName.
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or Sets The  CountryTitle.
        /// </summary>
        public string CountryTitle { get; set; }

        /// <summary>
        /// Gets or Sets The  CountryDescription.
        /// </summary>
        public string CountryDescription { get; set; }

        /// <summary>
        /// Gets or Sets The  CountrySummary.
        /// </summary>
        public string CountrySummary { get; set; }

        #region navigation properties
        /// <summary>
        /// Gets or Sets The  CountryId.
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// Gets or Sets The  Country.
        /// </summary>
        public CountryPivot Country { get; set; }

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