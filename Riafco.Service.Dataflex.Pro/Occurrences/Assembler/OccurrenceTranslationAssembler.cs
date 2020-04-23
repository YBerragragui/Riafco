using Riafco.Entity.Dataflex.Pro.Occurrences;
using Riafco.Service.Dataflex.Pro.Occurrences.Data;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Languages.Assembler;

namespace Riafco.Service.Dataflex.Pro.Occurrences.Assembler
{
    /// <summary>
    /// The OccurrenceTranslation assembler class.
    /// </summary>
    public static class OccurrenceTranslationAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From OccurrenceTranslation To OccurrenceTranslation Pivot.
        /// </summary>
        /// <param name="occurrenceTranslation">occurrenceTranslation TO ASSEMBLE</param>
        /// <returns>OccurrenceTranslationPivot result.</returns>
        public static OccurrenceTranslationPivot ToPivot(this OccurrenceTranslation occurrenceTranslation)
        {
            if (occurrenceTranslation == null)
            {
                return null;
            }
            return new OccurrenceTranslationPivot()
            {
                TranslationId = occurrenceTranslation.TranslationId,
                OccurrenceTitle = occurrenceTranslation.OccurrenceTitle,
                OccurrenceDescription = occurrenceTranslation.OccurrenceDescription,
                OccurrenceId = occurrenceTranslation.OccurrenceId,
                Occurrence = occurrenceTranslation.Occurrence.ToPivot(),
                LanguageId = occurrenceTranslation.LanguageId,
                Language = occurrenceTranslation.Language.ToPivot()
            };
        }

        /// <summary>
        /// From OccurrenceTranslation list to OccurrenceTranslation pivot list.
        /// </summary>
        /// <param name="occurrenceTranslationList">occurrenceTranslationList to assemble.</param>
        /// <returns>list of OccurrenceTranslationPivot result.</returns>
        public static List<OccurrenceTranslationPivot> ToPivotList(this List<OccurrenceTranslation> occurrenceTranslationList)
        {
            return occurrenceTranslationList?.Select(x => x.ToPivot()).ToList();

        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From OccurrenceTranslationPivot to OccurrenceTranslation.
        /// </summary>
        /// <param name="occurrenceTranslationPivot">occurrenceTranslationPivot to assemble.</param>
        /// <returns>OccurrenceTranslation result.</returns>
        public static OccurrenceTranslation ToEntity(this OccurrenceTranslationPivot occurrenceTranslationPivot)
        {
            if (occurrenceTranslationPivot == null)
            {
                return null;
            }
            return new OccurrenceTranslation()
            {
                TranslationId = occurrenceTranslationPivot.TranslationId,
                OccurrenceTitle = occurrenceTranslationPivot.OccurrenceTitle,
                OccurrenceDescription = occurrenceTranslationPivot.OccurrenceDescription,
                OccurrenceId = occurrenceTranslationPivot.OccurrenceId,
                Occurrence = occurrenceTranslationPivot.Occurrence.ToEntity(),
                LanguageId = occurrenceTranslationPivot.LanguageId,
                Language = occurrenceTranslationPivot.Language.ToEntity()
            };
        }

        /// <summary>
        /// From OccurrenceTranslationPivotList to OccurrenceTranslationList .
        /// </summary>
        /// <param name="occurrenceTranslationPivotList">OccurrenceTranslationPivotList to assemble.</param>
        /// <returns> list of OccurrenceTranslation result.</returns>
        public static List<OccurrenceTranslation> ToEntityList(this List<OccurrenceTranslationPivot> occurrenceTranslationPivotList)
        {
            return occurrenceTranslationPivotList?.Select(x => x.ToEntity()).ToList();

        }
        #endregion
    }
}