using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Admin.Riafco.Dataflex.Pro.GlobalResources;

namespace Admin.Riafco.Dataflex.Pro.Models.Offices.FormData
{
    /// <summary>
    /// The CountryParagraphFormData class.
    /// </summary>
    public class SheetFormData
    {
        /// <summary>
        /// Gets or Sets The  ParagraphId.
        /// </summary>
        public int SheetId { get; set; }

        #region navigation proportises

        /// <summary>
        /// Gets or Sets The CountryId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(CountryResources), ErrorMessageResourceName = "RequiredCountryId")]
        public int? CountryId { get; set; }

        /// <summary>
        /// Gets or sets TranslationItemDataList.
        /// </summary>
        public List<SheetTranslationFormData> TranslationsList { get; set; }

        #endregion
    }
}