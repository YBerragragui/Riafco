using Admin.Riafco.Dataflex.Pro.Models.About.FormData;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.About.RequestData;
using System.Collections.Generic;

namespace Admin.Riafco.Dataflex.Pro.Models.About.Assembler
{
    /// <summary>
    /// The SectionParagraphAssembler class.
    /// </summary>
    public static class SectionFileAssembler
    {
        #region TO ITEM DATA

        /// <summary>
        /// From SectionFileFormData from SectionFileItemData.
        /// </summary>
        /// <param name="sectionFileFormData">the sectionFileFormData to convert.</param>
        /// <returns>SectionFileItemData result.</returns>
        public static SectionFileItemData ToItemData(this UpdateSectionFileFormData sectionFileFormData)
        {
            if (sectionFileFormData == null)
            {
                return new SectionFileItemData();
            }
            return new SectionFileItemData
            {
                SectionFileId = sectionFileFormData.SectionFileId,
                SectionId = sectionFileFormData.SectionId
            };
        }

        /// <summary>
        /// From SectionFileTranslationFormDataList to SectionFileTranslationItemDataList.
        /// </summary>
        /// <param name="sectionFileFormDataList">The sectionFileFormDataList to convert.</param>
        /// <returns>SectionFileTranslationItemDataList</returns>
        public static List<SectionFileTranslationItemData> ToItemDataList(this List<UpdateSectionFileTranslationFormData> sectionFileFormDataList)
        {
            if (sectionFileFormDataList == null)
            {
                return new List<SectionFileTranslationItemData>();
            }

            List<SectionFileTranslationItemData> sectionFileTranslationItemDataList = new List<SectionFileTranslationItemData>();
            foreach (var sectionParagraphFormData in sectionFileFormDataList)
            {
                sectionFileTranslationItemDataList.Add(new SectionFileTranslationItemData
                {
                    SectionFileSource = sectionParagraphFormData.SectionFileSource?.FileName,
                    SectionFileText = sectionParagraphFormData.SectionFileText,
                    SectionFileId = sectionParagraphFormData.SectionFileId,
                    TranslationId = sectionParagraphFormData.TranslationId,
                    LanguageId = sectionParagraphFormData.LanguageId
                });
            }
            return sectionFileTranslationItemDataList;
        }

        /// <summary>
        /// From SectionFileFormData from SectionFileItemData.
        /// </summary>
        /// <param name="sectionFileFormData">the sectionFileFormData to convert.</param>
        /// <returns>SectionFileItemData result.</returns>
        public static SectionFileItemData ToItemData(this CreateSectionFileFormData sectionFileFormData)
        {
            if (sectionFileFormData == null)
            {
                return new SectionFileItemData();
            }
            return new SectionFileItemData
            {
                SectionFileId = sectionFileFormData.SectionFileId,
                SectionId = sectionFileFormData.SectionId
            };
        }

        /// <summary>
        /// From SectionFileTranslationFormDataList to SectionFileTranslationItemDataList.
        /// </summary>
        /// <param name="sectionFileFormDataList">The sectionFileFormDataList to convert.</param>
        /// <returns>SectionFileTranslationItemDataList</returns>
        public static List<SectionFileTranslationItemData> ToItemDataList(this List<CreateSectionFileTranslationFormData> sectionFileFormDataList)
        {
            if (sectionFileFormDataList == null)
            {
                return new List<SectionFileTranslationItemData>();
            }

            List<SectionFileTranslationItemData> sectionFileTranslationItemDataList = new List<SectionFileTranslationItemData>();
            foreach (var sectionParagraphFormData in sectionFileFormDataList)
            {
                sectionFileTranslationItemDataList.Add(new SectionFileTranslationItemData
                {
                    SectionFileSource = sectionParagraphFormData.SectionFileSource?.FileName,
                    SectionFileText = sectionParagraphFormData.SectionFileText,
                    SectionFileId = sectionParagraphFormData.SectionFileId,
                    TranslationId = sectionParagraphFormData.TranslationId,
                    LanguageId = sectionParagraphFormData.LanguageId
                });
            }
            return sectionFileTranslationItemDataList;
        }

        #endregion

        #region TO REQUEST DATA

        /// <summary>
        /// From SectionParagraphFormData to SectionParagraphRequestData
        /// </summary>
        /// <param name="sectionFileFormData">the sectionFileFormData to convert.</param>
        /// <returns>the SectionFileRequestData result.</returns>
        public static SectionFileRequestData ToRequestData(this CreateSectionFileFormData sectionFileFormData)
        {
            if (sectionFileFormData == null)
            {
                return new SectionFileRequestData();
            }
            return new SectionFileRequestData
            {
                SectionFileDto = sectionFileFormData.ToItemData()
            };
        }

        /// <summary>
        /// From SectionParagraphFormData to SectionParagraphRequestData
        /// </summary>
        /// <param name="sectionFileFormData">the sectionFileFormData to convert.</param>
        /// <returns>the SectionFileRequestData result.</returns>
        public static SectionFileRequestData ToRequestData(this UpdateSectionFileFormData sectionFileFormData)
        {
            if (sectionFileFormData == null)
            {
                return new SectionFileRequestData();
            }
            return new SectionFileRequestData
            {
                SectionFileDto = sectionFileFormData.ToItemData()
            };
        }
        #endregion
    }
}