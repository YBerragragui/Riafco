using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.About.FormData;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.About.RequestData;

namespace Admin.Riafco.Dataflex.Pro.Models.About.Assembler
{
    /// <summary>
    /// The SectionParagraphAssembler class.
    /// </summary>
    public static class SectionParagraphAssembler
    {
        /// <summary>
        /// From SectionParagraphTranslationFormData to SectionParagraphTranslationItemData.
        /// </summary>
        /// <param name="sectionParagraphFormDataList">sectionParagraphFormDataList to convert.</param>
        /// <returns>SectionParagraphTranslationItemData list</returns>
        public static List<SectionParagraphTranslationItemData> ToItemDataList(this List<SectionParagraphTranslationFormData> sectionParagraphFormDataList)
        {
            if (sectionParagraphFormDataList == null)
            {
                return new List<SectionParagraphTranslationItemData>();
            }

            List<SectionParagraphTranslationItemData> sectionParagraphTranslationItemDataList = new List<SectionParagraphTranslationItemData>();
            foreach (var sectionParagraphFormData in sectionParagraphFormDataList)
            {
                sectionParagraphTranslationItemDataList.Add(new SectionParagraphTranslationItemData
                {
                    ParagraphDescription = sectionParagraphFormData.ParagraphDescription,
                    ParagraphTitle = sectionParagraphFormData.ParagraphTitle,
                    TranslationId = sectionParagraphFormData.TranslationId,
                    ParagraphId = sectionParagraphFormData.ParagraphId,
                    LanguageId = sectionParagraphFormData.LanguageId
                });
            }
            return sectionParagraphTranslationItemDataList;
        }

        public static SectionParagraphItemData ToItemData(this SectionParagraphFormData sectionParagraphFormData)
        {
            if (sectionParagraphFormData == null)
            {
                return new SectionParagraphItemData();
            }
            return new SectionParagraphItemData
            {
                TranslationItemDataList = sectionParagraphFormData.TranslationsList.ToItemDataList(),
                ParagraphId = sectionParagraphFormData.ParagraphId,
                SectionId = sectionParagraphFormData.SectionId
            };
        }

        /// <summary>
        /// From SectionParagraphFormData to SectionParagraphRequestData
        /// </summary>
        /// <param name="sectionParagraphFormData"></param>
        /// <returns></returns>
        public static SectionParagraphRequestData ToRequestData(this SectionParagraphFormData sectionParagraphFormData)
        {
            if (sectionParagraphFormData == null)
            {
                return new SectionParagraphRequestData();
            }
            return new SectionParagraphRequestData
            {
                SectionParagraphDto = sectionParagraphFormData.ToItemData()
            };
        }
    }
}