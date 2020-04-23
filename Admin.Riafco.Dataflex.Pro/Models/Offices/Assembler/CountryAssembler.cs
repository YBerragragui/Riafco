using Admin.Riafco.Dataflex.Pro.Models.Offices.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Offices.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Offices.RequestData;
using System.Collections.Generic;

namespace Admin.Riafco.Dataflex.Pro.Models.Offices.Assembler
{
    /// <summary>
    /// CountryTranslationAssembler
    /// </summary>
    public static class CountryAssembler
    {
        #region TO ITEM DATA
        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static CountryItemData ToItemData(this CreateCountryFormData formData)
        {
            if (formData == null)
            {
                return new CountryItemData();
            }

            CountryItemData itemData = new CountryItemData
            {
                CountryImage = formData.CountryImage?.FileName,
                CountryShortName = formData.CountryShortName,
                CountryCode = formData.CountryCode,
                CountryId = formData.CountryId
            };
            return itemData;
        }

        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static CountryItemData ToItemData(this UpdateCountryFormData formData)
        {
            if (formData == null)
            {
                return new CountryItemData();
            }

            CountryItemData itemData = new CountryItemData
            {
                CountryImage = formData.CountryImage?.FileName,
                CountryShortName = formData.CountryShortName,
                CountryCode = formData.CountryCode,
                CountryId = formData.CountryId
            };
            return itemData;
        }

        /// <summary>
        /// FROM FROM DATA TO ITEM DATA.
        /// </summary>
        /// <param name="formData">the form data to convert.</param>
        /// <returns>the item data.</returns>
        public static CountryTranslationItemData ToItemData(this CountryTranslationFormData formData)
        {
            if (formData == null)
            {
                return new CountryTranslationItemData();
            }

            return new CountryTranslationItemData
            {
                CountryDescription = formData.CountryDescription,
                CountrySummary = formData.CountrySummary,
                TranslationId = formData.TranslationId,
                CountryTitle = formData.CountryTitle,
                CountryName = formData.CountryName,
                LanguageId = formData.LanguageId,
                CountryId = formData.CountryId
            };
        }

        /// <summary>
        /// FROM FROM DATA LIST TO ITEM DATA LIST.
        /// </summary>
        /// <param name="formDataList">the form data lit to convert.</param>
        /// <returns>the item data list.</returns>
        public static List<CountryTranslationItemData> ToItemDataList(this List<CountryTranslationFormData> formDataList)
        {
            List<CountryTranslationItemData> itemDataList = new List<CountryTranslationItemData>();
            foreach (var formData in formDataList)
            {
                itemDataList.Add(formData.ToItemData());
            }
            return itemDataList;
        }
        #endregion

        #region TO FORM DATA
        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemData">the itemData to convert</param>
        /// <returns>the formdata result</returns>
        public static CreateCountryFormData ToCreateFormData(this CountryItemData itemData)
        {
            if (itemData == null)
            {
                return new CreateCountryFormData();
            }

            CreateCountryFormData formData = new CreateCountryFormData
            {
                CountryShortName = itemData.CountryShortName,
                CountryCode = itemData.CountryCode,
                CountryId = itemData.CountryId
            };
            return formData;
        }

        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemData">the itemData to convert</param>
        /// <returns>the formdata result</returns>
        public static UpdateCountryFormData ToUpdateFormData(this CountryItemData itemData)
        {
            if (itemData == null)
            {
                return new UpdateCountryFormData();
            }

            UpdateCountryFormData formData = new UpdateCountryFormData
            {
                CountryShortName = itemData.CountryShortName,
                CountryCode = itemData.CountryCode,
                CountryId = itemData.CountryId
            };
            return formData;
        }

        /// <summary>
        /// FROM itemData TO FORM DATA.
        /// </summary>
        /// <param name="itemData"></param>
        /// <returns></returns>
        public static CountryTranslationFormData ToFormData(this CountryTranslationItemData itemData)
        {
            if (itemData == null)
            {
                return new CountryTranslationFormData();
            }

            CountryTranslationFormData formData = new CountryTranslationFormData
            {
                LanguagePrefix = itemData.Language.LanguagePrefix,
                CountryDescription = itemData.CountryDescription,
                CountrySummary = itemData.CountrySummary,
                TranslationId = itemData.TranslationId,
                LanguageId = itemData.LanguageId ?? 0,
                CountryTitle = itemData.CountryTitle,
                CountryId = itemData.CountryId ?? 0,
                CountryName = itemData.CountryName
            };
            return formData;
        }

        /// <summary>
        /// FROM itemDataList TO CountryTranslationFormDataList
        /// </summary>
        /// <param name="itemDataList">the itemDataList TO CONVERT</param>
        /// <returns>THE countryTranslationFormData list.</returns>
        public static List<CountryTranslationFormData> ToFormDataList(this List<CountryTranslationItemData> itemDataList)
        {
            List<CountryTranslationFormData> formDataList = new List<CountryTranslationFormData>();
            foreach (var itemData in itemDataList)
            {
                formDataList.Add(itemData.ToFormData());
            }
            return formDataList;
        }
        #endregion

        #region REQUEST DATA

        /// <summary>
        /// From FORMDATA To REQUESTDATA
        /// </summary>
        /// <param name="countryFormData"></param>
        /// <returns></returns>
        public static CountryRequestData ToRequestData(this CreateCountryFormData countryFormData)
        {
            if (countryFormData == null)
            {
                return new CountryRequestData();
            }
            return new CountryRequestData
            {
                CountryDto = countryFormData.ToItemData()
            };
        }

        /// <summary>
        /// From FORMDATA To REQUESTDATA
        /// </summary>
        /// <param name="countryFormData"></param>
        /// <returns></returns>
        public static CountryRequestData ToRequestData(this UpdateCountryFormData countryFormData)
        {
            if (countryFormData == null)
            {
                return new CountryRequestData();
            }
            return new CountryRequestData
            {
                CountryDto = countryFormData.ToItemData()
            };
        }

        /// <summary>
        /// From FORMDATA To REQUEST DATA
        /// </summary>
        /// <param name="countryTranslationFormData">form data to convert</param>
        /// <returns></returns>
        public static CountryTranslationRequestData ToRequestData(this CountryTranslationFormData countryTranslationFormData)
        {
            if (countryTranslationFormData == null)
            {
                return new CountryTranslationRequestData();
            }

            return new CountryTranslationRequestData
            {
                CountryTranslationDtoList = new List<CountryTranslationItemData>(),
                CountryTranslationDto = countryTranslationFormData.ToItemData()
            };
        }
        #endregion
    }
}