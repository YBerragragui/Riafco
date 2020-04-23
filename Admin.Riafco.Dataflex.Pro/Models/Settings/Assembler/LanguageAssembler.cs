using Admin.Riafco.Dataflex.Pro.Models.Settings.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Settings.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Settings.RequestData;
using Admin.Riafco.Dataflex.Pro.Models.Settings.ResultData;
using Riafco.Framework.Dataflex.pro.Util;

namespace Admin.Riafco.Dataflex.Pro.Models.Settings.Assembler
{
    /// <summary>
    /// The LangueAssembler class. 
    /// </summary>
    public static class LanguageAssembler
    {
        /// <summary>
        /// From Langue result data to connection form data
        /// </summary>
        /// <param name="resultData">the Langue result data from web api.</param>
        /// <returns>the form data.</returns>
        public static AddLanguageFormData ToAddLangueFormData(this LanguageResultData resultData)
        {
            AddLanguageFormData formData = new AddLanguageFormData();
            if (resultData?.LanguageDto != null)
            {
                formData = new AddLanguageFormData
                {
                    LanguageId = resultData.LanguageDto.LanguageId,
                    LanguagePrefix = resultData.LanguageDto.LanguagePrefix
                };
            }
            return formData;
        }

        /// <summary>
        /// From LanguageItemData to AddLanguageFormData
        /// </summary>
        /// <param name="itemData">the LanguageItemData to convert.</param>
        /// <returns>AddLanguageFormData result.</returns>
        public static AddLanguageFormData ToAddLangueFormData(this LanguageItemData itemData)
        {
            AddLanguageFormData formData = new AddLanguageFormData();
            if (itemData != null)
            {
                formData = new AddLanguageFormData
                {
                    LanguageId = itemData.LanguageId,
                    LanguagePrefix = itemData.LanguagePrefix
                };
            }
            return formData;
        }

        /// <summary>
        /// From Langue result data to connection form data
        /// </summary>
        /// <param name="resultData">the Langue result data from web api.</param>
        /// <returns>the form data.</returns>
        public static UpdateLanguageFormData ToUpdateLangueFormData(this LanguageResultData resultData)
        {
            UpdateLanguageFormData formData = new UpdateLanguageFormData();
            if (resultData?.LanguageDto != null)
            {
                formData = new UpdateLanguageFormData
                {
                    LanguageId = resultData.LanguageDto.LanguageId,
                    LanguagePrefix = resultData.LanguageDto.LanguagePrefix
                };
            }
            return formData;
        }

        /// <summary>
        /// From LanguageItemData to UpdateLanguageFormData
        /// </summary>
        /// <param name="itemData"></param>
        /// <returns></returns>
        public static UpdateLanguageFormData ToUpdateLangueFormData(this LanguageItemData itemData)
        {
            UpdateLanguageFormData formData = new UpdateLanguageFormData();
            if (itemData != null)
            {
                formData = new UpdateLanguageFormData
                {
                    LanguageId = itemData.LanguageId,
                    LanguagePrefix = itemData.LanguagePrefix
                };
            }
            return formData;
        }

        /// <summary>
        /// From Form data to request data.
        /// </summary>
        /// <param name="formData">the form data to convert.</param>
        /// <returns>the request data.</returns>
        public static LanguageRequestData ToAddRequestData(this AddLanguageFormData formData)
        {
            LanguageRequestData request = new LanguageRequestData();
            if (formData != null)
            {
                request.LanguageDto = new LanguageItemData
                {
                    LanguageId = formData.LanguageId,
                    LanguagePrefix = formData.LanguagePrefix,
                    LanguagePicture = formData.LanguagePicture?.FileName
                };
            }
            return request;
        }

        /// <summary>
        /// From Form data to request data.
        /// </summary>
        /// <param name="formData">the form data to convert.</param>
        /// <returns>the request data.</returns>
        public static LanguageRequestData ToUpdateRequestData(this UpdateLanguageFormData formData)
        {
            LanguageRequestData request = new LanguageRequestData();
            if (formData != null)
            {
                request.LanguageDto = new LanguageItemData
                {
                    LanguageId = formData.LanguageId,
                    LanguagePrefix = formData.LanguagePrefix,
                    LanguagePicture = formData.LanguagePicture?.FileName
                };
            }
            return request;
        }
    }
}