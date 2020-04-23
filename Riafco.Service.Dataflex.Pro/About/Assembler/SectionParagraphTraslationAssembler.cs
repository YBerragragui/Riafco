using Riafco.Entity.Dataflex.Pro.About;
using Riafco.Service.Dataflex.Pro.About.Data;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Languages.Assembler;

namespace Riafco.Service.Dataflex.Pro.About.Assembler
{
    /// <summary>
    /// The SectionParagraphTraslation assembler class.
    /// </summary>
    public static class SectionParagraphTraslationAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From SectionParagraphTraslation To SectionParagraphTraslation Pivot.
        /// </summary>
        /// <param name="sectionParagraphTraslation">sectionParagraphTraslation TO ASSEMBLE</param>
        /// <returns>SectionParagraphTranslationPivot result.</returns>
        public static SectionParagraphTranslationPivot ToPivot(this SectionParagraphTranslation sectionParagraphTraslation)
        {
            if (sectionParagraphTraslation == null)
            {
                return null;
            }
            return new SectionParagraphTranslationPivot
            {
                SectionParagraph = sectionParagraphTraslation.SectionParagraph?.ToPivot(),
                ParagraphDescription = sectionParagraphTraslation.ParagraphDescription,
                ParagraphTitle = sectionParagraphTraslation.ParagraphTitle,
                Language = sectionParagraphTraslation.Language?.ToPivot(),
                TranslationId = sectionParagraphTraslation.TranslationId,
                ParagraphId = sectionParagraphTraslation.ParagraphId,
                LanguageId = sectionParagraphTraslation.LanguageId
            };
        }

        /// <summary>
        /// From SectionParagraphTraslation list to SectionParagraphTraslation pivot list.
        /// </summary>
        /// <param name="sectionParagraphTraslationList">sectionParagraphTraslationList to assemble.</param>
        /// <returns>list of SectionParagraphTranslationPivot result.</returns>
        public static List<SectionParagraphTranslationPivot> ToPivotList(this List<SectionParagraphTranslation> sectionParagraphTraslationList)
        {
            return sectionParagraphTraslationList?.Select(x => x?.ToPivot()).ToList();

        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From SectionParagraphTranslationPivot to SectionParagraphTraslation.
        /// </summary>
        /// <param name="sectionParagraphTraslationPivot">sectionParagraphTraslationPivot to assemble.</param>
        /// <returns>SectionParagraphTraslation result.</returns>
        public static SectionParagraphTranslation ToEntity(this SectionParagraphTranslationPivot sectionParagraphTraslationPivot)
        {
            if (sectionParagraphTraslationPivot == null)
            {
                return null;
            }
            return new SectionParagraphTranslation
            {
                SectionParagraph = sectionParagraphTraslationPivot.SectionParagraph?.ToEntity(),
                ParagraphDescription = sectionParagraphTraslationPivot.ParagraphDescription,
                Language = sectionParagraphTraslationPivot.Language?.ToEntity(),
                ParagraphTitle = sectionParagraphTraslationPivot.ParagraphTitle,
                TranslationId = sectionParagraphTraslationPivot.TranslationId,
                ParagraphId = sectionParagraphTraslationPivot.ParagraphId,
                LanguageId = sectionParagraphTraslationPivot.LanguageId
            };
        }

        /// <summary>
        /// From SectionParagraphTranslationPivotList to SectionParagraphTraslationList .
        /// </summary>
        /// <param name="sectionParagraphTraslationPivotList">SectionParagraphTranslationPivotList to assemble.</param>
        /// <returns> list of SectionParagraphTraslation result.</returns>
        public static List<SectionParagraphTranslation> ToEntityList(this List<SectionParagraphTranslationPivot> sectionParagraphTraslationPivotList)
        {
            return sectionParagraphTraslationPivotList?.Select(x => x?.ToEntity()).ToList();
        }
        #endregion
    }
}