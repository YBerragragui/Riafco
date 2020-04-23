using Riafco.Entity.Dataflex.Pro.About;
using Riafco.Service.Dataflex.Pro.About.Assembler;
using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Service.Dataflex.Pro.Languages.Assembler;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.About.Assembler
{
    /// <summary>
    /// The SectionTranslation assembler class.
    /// </summary>
    public static class SectionTranslationAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From SectionTranslation To SectionTranslation Pivot.
        /// </summary>
        /// <param name="sectionTranslation">sectionTranslation TO ASSEMBLE</param>
        /// <returns>SectionTranslationPivot result.</returns>
        public static SectionTranslationPivot ToPivot(this SectionTranslation sectionTranslation)
        {
            if (sectionTranslation == null)
            {
                return null;
            }
            return new SectionTranslationPivot()
            {
                SectionDesciption = sectionTranslation.SectionDesciption,
                Language = sectionTranslation.Language?.ToPivot(),
                TranslationId = sectionTranslation.TranslationId,
                Section = sectionTranslation.Section?.ToPivot(),
                SectionTitle = sectionTranslation.SectionTitle,
                LanguageId = sectionTranslation.LanguageId,
                SectionId = sectionTranslation.SectionId
            };
        }

        /// <summary>
        /// From SectionTranslation list to SectionTranslation pivot list.
        /// </summary>
        /// <param name="sectionTranslationList">sectionTranslationList to assemble.</param>
        /// <returns>list of SectionTranslationPivot result.</returns>
        public static List<SectionTranslationPivot> ToPivotList(this List<SectionTranslation> sectionTranslationList)
        {
            return sectionTranslationList?.Select(x => x.ToPivot()).ToList();

        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From SectionTranslationPivot to SectionTranslation.
        /// </summary>
        /// <param name="sectionTranslationPivot">sectionTranslationPivot to assemble.</param>
        /// <returns>SectionTranslation result.</returns>
        public static SectionTranslation ToEntity(this SectionTranslationPivot sectionTranslationPivot)
        {
            if (sectionTranslationPivot == null)
            {
                return null;
            }
            return new SectionTranslation
            {
                SectionDesciption = sectionTranslationPivot.SectionDesciption,
                Language = sectionTranslationPivot.Language?.ToEntity(),
                Section = sectionTranslationPivot.Section?.ToEntity(),
                TranslationId = sectionTranslationPivot.TranslationId,
                SectionTitle = sectionTranslationPivot.SectionTitle,
                LanguageId = sectionTranslationPivot.LanguageId,
                SectionId = sectionTranslationPivot.SectionId
            };
        }

        /// <summary>
        /// From SectionTranslationPivotList to SectionTranslationList .
        /// </summary>
        /// <param name="sectionTranslationPivotList">SectionTranslationPivotList to assemble.</param>
        /// <returns> list of SectionTranslation result.</returns>
        public static List<SectionTranslation> ToEntityList(this List<SectionTranslationPivot> sectionTranslationPivotList)
        {
            return sectionTranslationPivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}