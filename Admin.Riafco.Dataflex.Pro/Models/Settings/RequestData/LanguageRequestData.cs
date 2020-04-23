using Admin.Riafco.Dataflex.Pro.Models.Settings.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Settings.ItemData.Enum;

namespace Admin.Riafco.Dataflex.Pro.Models.Settings.RequestData
{
    /// <summary>
    /// The Langue dto class.
    /// </summary>
    public class LanguageRequestData
    {
        /// <summary>
        /// Gets or sets user item data.
        /// </summary>
        public LanguageItemData LanguageDto { get; set; }

        /// <summary>
        /// Gets or sets FindUserItemDataEnum
        /// </summary>
        public FindLanguageItemData FindLanguageDtoEnum { get; set; }
    }
}