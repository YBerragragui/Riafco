using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Admin.Riafco.Dataflex.Pro.GlobalResources;

namespace Admin.Riafco.Dataflex.Pro.Models.Offices.ItemData
{
    /// <summary>
    /// The SheetItemData class.
    /// </summary>
    public class SheetItemData
    {
        /// <summary>
        /// Gets or Sets The  SheetId.
        /// </summary>
        public int SheetId { get; set; }


        #region navigation proportises

        /// <summary>
        /// Gets or Sets The  CountryId.
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// Gets or Sets The  Country.
        /// </summary>
        public CountryItemData Country { get; set; }

        /// <summary>
        /// Gets or sets TranslationItemDataList.
        /// </summary>
        public List<SheetTranslationItemData> TranslationItemDataList { get; set; }

        #endregion
    }
}