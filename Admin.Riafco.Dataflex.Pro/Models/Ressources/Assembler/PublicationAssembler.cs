using Admin.Riafco.Dataflex.Pro.Models.Ressources.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.RequestData;
using Riafco.Framework.Dataflex.pro.Util;
using System.Collections.Generic;
using System.Linq;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.Assembler
{
    /// <summary>
    /// The PublicationTranslationAssembler class.
    /// </summary>
    public static class PublicationAssembler
    {
        #region TO ITEM DATA
        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static PublicationItemData ToItemData(this CreatePublicationFormData formData)
        {
            if (formData == null)
            {
                return new PublicationItemData();
            }

            PublicationItemData itemData = new PublicationItemData
            {
                PublicationDate = formData.PublicationDate.StringToDateTime(),
                PublicationImage = formData.PublicationImage?.FileName,
                AuthorId = formData.AuthorId,
                AreaId = formData.AreaId
            };
            return itemData;
        }

        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static PublicationItemData ToItemData(this UpdatePublicationFormData formData)
        {
            if (formData == null)
            {
                return new PublicationItemData();
            }

            PublicationItemData itemData = new PublicationItemData
            {
                PublicationDate = formData.PublicationDate.StringToDateTime(),
                PublicationImage = formData.PublicationImage?.FileName,
                PublicationId = formData.PublicationId,
                AuthorId = formData.AuthorId,
                AreaId = formData.AreaId
            };
            return itemData;
        }

        /// <summary>
        /// FROM CREATE FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static PublicationTranslationItemData ToItemData(this CreatePublicationTranslationFormData formData)
        {
            if (formData == null)
            {
                return new PublicationTranslationItemData();
            }

            PublicationTranslationItemData itemData = new PublicationTranslationItemData
            {
                PublicationFile = formData.PublicationFile?.FileName,
                PublicationSummary = formData.PublicationSummary,
                PublicationTitle = formData.PublicationTitle,
                PublicationId = formData.PublicationId,
                LanguageId = formData.LanguageId
            };
            return itemData;
        }

        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static PublicationTranslationItemData ToItemData(this UpdatePublicationTranslationFormData formData)
        {
            if (formData == null)
            {
                return new PublicationTranslationItemData();
            }

            PublicationTranslationItemData itemData = new PublicationTranslationItemData
            {
                PublicationTranslationId = formData.PublicationTranslationId,
                PublicationFile = formData.PublicationFile?.FileName,
                PublicationSummary = formData.PublicationSummary,
                PublicationTitle = formData.PublicationTitle,
                PublicationId = formData.PublicationId,
                LanguageId = formData.LanguageId
            };
            return itemData;
        }

        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formDataList">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static List<PublicationTranslationItemData> ToItemDataList(this List<CreatePublicationTranslationFormData> formDataList)
        {
            return formDataList?.Select(formData => formData.ToItemData()).ToList() ??
                   new List<PublicationTranslationItemData>();
        }

        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formDataList">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static List<PublicationTranslationItemData> ToItemDataList(this List<UpdatePublicationTranslationFormData> formDataList)
        {
            return formDataList?.Select(formData => formData.ToItemData()).ToList() ??
                   new List<PublicationTranslationItemData>();
        }
        #endregion

        #region TO FORM DATA
        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemData">the itemData to convert</param>
        /// <returns>the formdata result</returns>
        public static CreatePublicationFormData ToCreateFormData(this PublicationItemData itemData)
        {
            if (itemData == null)
            {
                return new CreatePublicationFormData();
            }

            CreatePublicationFormData formData = new CreatePublicationFormData
            {
                PublicationDate = itemData.PublicationDate.ToString("dd/MM/yyyy"),
                AuthorId = itemData.AuthorId,
                AreaId = itemData.AreaId
            };
            return formData;
        }

        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemData">the itemData to convert</param>
        /// <returns>the formdata result</returns>
        public static UpdatePublicationFormData ToUpdateFormData(this PublicationItemData itemData)
        {
            if (itemData == null)
            {
                return new UpdatePublicationFormData();
            }

            UpdatePublicationFormData formData = new UpdatePublicationFormData
            {
                PublicationDate = itemData.PublicationDate.ToString("dd/MM/yyyy"),
                PublicationId = itemData.PublicationId,
                AuthorId = itemData.AuthorId,
                AreaId = itemData.AreaId
            };
            return formData;
        }

        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemDataList">the itemDataList to convert</param>
        /// <returns>the formdata result</returns>
        public static List<CreatePublicationFormData> ToCreateFormDataList(this List<PublicationItemData> itemDataList)
        {
            return itemDataList?.Select(publicationItemData => publicationItemData.ToCreateFormData()).ToList() ?? new List<CreatePublicationFormData>();
        }

        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemDataList">the itemDataList to convert</param>
        /// <returns>the formdata result</returns>
        public static List<UpdatePublicationFormData> ToUpdateFormDataList(this List<PublicationItemData> itemDataList)
        {
            return itemDataList?.Select(publicationItemData => publicationItemData.ToUpdateFormData()).ToList() ?? new List<UpdatePublicationFormData>();
        }

        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemData">the itemData to convert</param>
        /// <returns>the formdata result</returns>
        public static CreatePublicationTranslationFormData ToCreateFormData(this PublicationTranslationItemData itemData)
        {
            if (itemData == null)
            {
                return new CreatePublicationTranslationFormData();
            }

            CreatePublicationTranslationFormData formData = new CreatePublicationTranslationFormData
            {
                LanguagePrefix = itemData.Language.LanguagePrefix,
                PublicationSummary = itemData.PublicationSummary,
                PublicationTitle = itemData.PublicationTitle,
                PublicationId = itemData.PublicationId,
                LanguageId = itemData.LanguageId
            };
            return formData;
        }

        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemData">the itemData to convert</param>
        /// <returns>the formdata result</returns>
        public static UpdatePublicationTranslationFormData ToUpdateFormData(this PublicationTranslationItemData itemData)
        {
            if (itemData == null)
            {
                return new UpdatePublicationTranslationFormData();
            }

            UpdatePublicationTranslationFormData formData = new UpdatePublicationTranslationFormData
            {
                PublicationTranslationId = itemData.PublicationTranslationId,
                LanguagePrefix = itemData.Language.LanguagePrefix,
                PublicationSummary = itemData.PublicationSummary,
                PublicationTitle = itemData.PublicationTitle,
                PublicationId = itemData.PublicationId,
                LanguageId = itemData.LanguageId
            };
            return formData;
        }

        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemDataList">the itemDataList to convert</param>
        /// <returns>the formdata result</returns>
        public static List<CreatePublicationTranslationFormData> ToCreateFormDataList(this List<PublicationTranslationItemData> itemDataList)
        {
            return itemDataList?.Select(publicationTranslationItemData => publicationTranslationItemData.ToCreateFormData()).ToList() ?? new List<CreatePublicationTranslationFormData>();
        }

        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemDataList">the itemDataList to convert</param>
        /// <returns>the formdata result</returns>
        public static List<UpdatePublicationTranslationFormData> ToUpdateFormDataList(this List<PublicationTranslationItemData> itemDataList)
        {
            return itemDataList?.Select(publicationTranslationItemData => publicationTranslationItemData.ToUpdateFormData()).ToList() ?? new List<UpdatePublicationTranslationFormData>();
        }

        /// <summary>
        /// From REQUESTDATA To FORMDATA
        /// </summary>
        /// <param name="authorRequestData"></param>
        /// <returns></returns>
        public static CreatePublicationFormData ToCreateFormData(this PublicationRequestData authorRequestData)
        {
            if (authorRequestData?.PublicationDto == null)
            {
                return new CreatePublicationFormData();
            }
            return new CreatePublicationFormData
            {
                PublicationDate = authorRequestData.PublicationDto.PublicationDate.ToString("dd/MM/yyyy"),
                TranslationsList = new List<CreatePublicationTranslationFormData>(),
                AuthorId = authorRequestData.PublicationDto.AuthorId,
                AreaId = authorRequestData.PublicationDto.AreaId
            };
        }

        /// <summary>
        /// From REQUESTDATA To FORMDATA
        /// </summary>
        /// <param name="authorRequestData"></param>
        /// <returns></returns>
        public static UpdatePublicationFormData ToUpdateFormData(this PublicationRequestData authorRequestData)
        {
            if (authorRequestData?.PublicationDto == null)
            {
                return new UpdatePublicationFormData();
            }
            return new UpdatePublicationFormData
            {
                PublicationDate = authorRequestData.PublicationDto.PublicationDate.ToString("dd/MM/yyyy"),
                TranslationsList = new List<UpdatePublicationTranslationFormData>(),
                PublicationId = authorRequestData.PublicationDto.PublicationId,
                AuthorId = authorRequestData.PublicationDto.AuthorId,
                AreaId = authorRequestData.PublicationDto.AreaId
            };
        }

        /// <summary>
        /// From REQUESTDATA To FORMDATA
        /// </summary>
        /// <param name="authorRequestData"></param>
        /// <returns></returns>
        public static CreatePublicationTranslationFormData ToCreateFormData(this PublicationTranslationRequestData authorRequestData)
        {
            if (authorRequestData?.PublicationTranslationDto == null)
            {
                return new CreatePublicationTranslationFormData();
            }
            return new CreatePublicationTranslationFormData
            {
                LanguagePrefix = authorRequestData.PublicationTranslationDto.Language.LanguagePrefix,
                PublicationSummary = authorRequestData.PublicationTranslationDto.PublicationSummary,
                PublicationTitle = authorRequestData.PublicationTranslationDto.PublicationTitle,
                PublicationId = authorRequestData.PublicationTranslationDto.PublicationId,
                LanguageId = authorRequestData.PublicationTranslationDto.LanguageId
            };
        }

        /// <summary>
        /// From REQUESTDATA To FORMDATA
        /// </summary>
        /// <param name="authorRequestData"></param>
        /// <returns></returns>
        public static UpdatePublicationTranslationFormData ToUpdateFormData(this PublicationTranslationRequestData authorRequestData)
        {
            if (authorRequestData?.PublicationTranslationDto == null)
            {
                return new UpdatePublicationTranslationFormData();
            }
            return new UpdatePublicationTranslationFormData
            {
                PublicationTranslationId = authorRequestData.PublicationTranslationDto.PublicationTranslationId,
                LanguagePrefix = authorRequestData.PublicationTranslationDto.Language.LanguagePrefix,
                PublicationSummary = authorRequestData.PublicationTranslationDto.PublicationSummary,
                PublicationTitle = authorRequestData.PublicationTranslationDto.PublicationTitle,
                PublicationId = authorRequestData.PublicationTranslationDto.PublicationId,
                LanguageId = authorRequestData.PublicationTranslationDto.LanguageId
            };
        }
        #endregion

        #region TO REQUEST DATA
        /// <summary>
        /// From FORMDATA To REQUESTDATA
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        public static PublicationRequestData ToRequestData(this CreatePublicationFormData formData)
        {
            if (formData == null)
            {
                return new PublicationRequestData();
            }
            return new PublicationRequestData
            {
                PublicationDto = formData.ToItemData()
            };
        }

        /// <summary>
        /// From FORMDATA To REQUESTDATA
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        public static PublicationRequestData ToRequestData(this UpdatePublicationFormData formData)
        {
            if (formData == null)
            {
                return new PublicationRequestData();
            }
            return new PublicationRequestData
            {
                PublicationDto = formData.ToItemData()
            };
        }

        /// <summary>
        /// From FORMDATA To REQUESTDATA
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        public static PublicationTranslationRequestData ToRequestData(this CreatePublicationTranslationFormData formData)
        {
            if (formData == null)
            {
                return new PublicationTranslationRequestData();
            }
            return new PublicationTranslationRequestData
            {
                PublicationTranslationDto = formData.ToItemData(),
                PublicationTranslationDtoList = new List<PublicationTranslationItemData>()
            };
        }

        /// <summary>
        /// From FORMDATA To REQUESTDATA
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        public static PublicationTranslationRequestData ToRequestData(this UpdatePublicationTranslationFormData formData)
        {
            if (formData == null)
            {
                return new PublicationTranslationRequestData();
            }
            return new PublicationTranslationRequestData
            {
                PublicationTranslationDto = formData.ToItemData(),
                PublicationTranslationDtoList = new List<PublicationTranslationItemData>()
            };
        }

        /// <summary>
        /// From FORMDATA To REQUESTDATA
        /// </summary>
        /// <param name="formDataList">The authorFormDataList to assemble</param>
        /// <returns></returns>
        public static PublicationTranslationRequestData ToRequestData(this List<CreatePublicationTranslationFormData> formDataList)
        {
            if (formDataList == null)
            {
                return new PublicationTranslationRequestData();
            }
            return new PublicationTranslationRequestData
            {
                PublicationTranslationDto = new PublicationTranslationItemData(),
                PublicationTranslationDtoList = formDataList.ToItemDataList()
            };
        }

        /// <summary>
        /// From FORMDATA To REQUESTDATA
        /// </summary>
        /// <param name="formDataList">The authorFormDataList to assemble</param>
        /// <returns></returns>
        public static PublicationTranslationRequestData ToRequestData(this List<UpdatePublicationTranslationFormData> formDataList)
        {
            if (formDataList == null)
            {
                return new PublicationTranslationRequestData();
            }
            return new PublicationTranslationRequestData
            {
                PublicationTranslationDto = new PublicationTranslationItemData(),
                PublicationTranslationDtoList = formDataList.ToItemDataList()
            };
        }
        #endregion
    }
}