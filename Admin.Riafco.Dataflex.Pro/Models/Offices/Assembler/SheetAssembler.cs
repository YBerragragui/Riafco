using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.Offices.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Offices.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Offices.RequestData;

namespace Admin.Riafco.Dataflex.Pro.Models.Offices.Assembler
{
    /// <summary>
    /// The SheetAssembler class.
    /// </summary>
    public static class SheetAssembler
    {
        /// <summary>
        /// From SheetTranslationFormData to SheetTranslationItemData.
        /// </summary>
        /// <param name="sheetFormDataList">sheetFormDataList to convert.</param>
        /// <returns>SheetTranslationItemData list</returns>
        public static List<SheetTranslationItemData> ToItemDataList(this List<SheetTranslationFormData> sheetFormDataList)
        {
            if (sheetFormDataList == null)
            {
                return new List<SheetTranslationItemData>();
            }

            List<SheetTranslationItemData> sheetTranslationItemDataList = new List<SheetTranslationItemData>();
            foreach (var sheetFormData in sheetFormDataList)
            {
                sheetTranslationItemDataList.Add(new SheetTranslationItemData
                {
                    TranslationId = sheetFormData.TranslationId,
                    SheetId = sheetFormData.SheetId,
                    SheetValue = sheetFormData.SheetValue,
                    SheetTitle = sheetFormData.SheetTitle,
                    LanguageId = sheetFormData.LanguageId
                });
            }
            return sheetTranslationItemDataList;
        }

        public static SheetItemData ToItemData(this SheetFormData sheetFormData)
        {
            if (sheetFormData == null)
            {
                return new SheetItemData();
            }
            return new SheetItemData
            {
                TranslationItemDataList = sheetFormData.TranslationsList.ToItemDataList(),
                SheetId = sheetFormData.SheetId,
                CountryId = sheetFormData.CountryId
            };
        }

        /// <summary>
        /// From SheetFormData to SheetRequestData
        /// </summary>
        /// <param name="sheetFormData"></param>
        /// <returns></returns>
        public static SheetRequestData ToRequestData(this SheetFormData sheetFormData)
        {
            if (sheetFormData == null)
            {
                return new SheetRequestData();
            }
            return new SheetRequestData
            {
                SheetDto = sheetFormData.ToItemData()
            };
        }
    }
}