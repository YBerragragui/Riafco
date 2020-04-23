using Riafco.Entity.Dataflex.Pro.About;
using Riafco.Service.Dataflex.Pro.About.Data;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Languages.Assembler;

namespace Riafco.Service.Dataflex.Pro.About.Assembler
{
    /// <summary>
    /// The SectionFileTranslation assembler class.
    /// </summary>
    public static class SectionFileTranslationAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From SectionFileTranslation To SectionFileTranslation Pivot.
        /// </summary>
        /// <param name="sectionFileTranslation">sectionFileTranslation TO ASSEMBLE</param>
        /// <returns>SectionFileTranslationPivot result.</returns>
        public static SectionFileTranslationPivot ToPivot(this SectionFileTranslation sectionFileTranslation)
        {
            if (sectionFileTranslation == null)
            {
                return null;
            }
            return new SectionFileTranslationPivot
            {
                SectionFileSource = sectionFileTranslation.SectionFileSource,
                SectionFile = sectionFileTranslation.SectionFile?.ToPivot(),
                SectionFileText = sectionFileTranslation.SectionFileText,
                SectionFileId = sectionFileTranslation.SectionFileId,
                Language = sectionFileTranslation.Language?.ToPivot(),
                TranslationId = sectionFileTranslation.TranslationId,
                LanguageId = sectionFileTranslation.LanguageId
            };
        }

        /// <summary>
        /// From SectionFileTranslation list to SectionFileTranslation pivot list.
        /// </summary>
        /// <param name="sectionFileTranslationList">sectionFileTranslationList to assemble.</param>
        /// <returns>list of SectionFileTranslationPivot result.</returns>
        public static List<SectionFileTranslationPivot> ToPivotList(this List<SectionFileTranslation> sectionFileTranslationList)
        {
            return sectionFileTranslationList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From SectionFileTranslationPivot to SectionFileTranslation.
        /// </summary>
        /// <param name="sectionFileTranslationPivot">sectionFileTranslationPivot to assemble.</param>
        /// <returns>SectionFileTranslation result.</returns>
        public static SectionFileTranslation ToEntity(this SectionFileTranslationPivot sectionFileTranslationPivot)
        {
            if (sectionFileTranslationPivot == null)
            {
                return null;
            }
            return new SectionFileTranslation
            {
                SectionFile = sectionFileTranslationPivot.SectionFile?.ToEntity(),
                SectionFileSource = sectionFileTranslationPivot.SectionFileSource,
                SectionFileText = sectionFileTranslationPivot.SectionFileText,
                SectionFileId = sectionFileTranslationPivot.SectionFileId,
                Language = sectionFileTranslationPivot.Language?.ToEntity(),
                TranslationId = sectionFileTranslationPivot.TranslationId,
                LanguageId = sectionFileTranslationPivot.LanguageId
            };
        }

        /// <summary>
        /// From SectionFileTranslationPivotList to SectionFileTranslationList.
        /// </summary>
        /// <param name="sectionFileTranslationPivotList">SectionFileTranslationPivotList to assemble.</param>
        /// <returns> list of SectionFileTranslation result.</returns>
        public static List<SectionFileTranslation> ToEntityList(this List<SectionFileTranslationPivot> sectionFileTranslationPivotList)
        {
            return sectionFileTranslationPivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}