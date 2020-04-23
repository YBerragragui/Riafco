using Riafco.Entity.Dataflex.Pro.Ressources;
using Riafco.Service.Dataflex.Pro.Ressources.Data;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Languages.Assembler;

namespace Riafco.Service.Dataflex.Pro.Ressources.Assembler
{
    /// <summary>
    /// The AreaTranslation assembler class.
    /// </summary>
    public static class AreaTranslationAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From AreaTranslation To AreaTranslation Pivot.
        /// </summary>
        /// <param name="areaTranslation">areaTranslation TO ASSEMBLE</param>
        /// <returns>AreaTranslationPivot result.</returns>
        public static AreaTranslationPivot ToPivot(this AreaTranslation areaTranslation)
        {
            if (areaTranslation == null)
            {
                return null;
            }
            return new AreaTranslationPivot
            {
                TranslationId = areaTranslation.TranslationId,
                Language = areaTranslation.Language.ToPivot(),
                LanguageId = areaTranslation.LanguageId,
                Area = areaTranslation.Area?.ToPivot(),
                AreaName = areaTranslation.AreaName,
                AreaId = areaTranslation.AreaId
            };
        }

        /// <summary>
        /// From AreaTranslation list to AreaTranslation pivot list.
        /// </summary>
        /// <param name="areaTranslationList">areaTranslationList to assemble.</param>
        /// <returns>list of AreaTranslationPivot result.</returns>
        public static List<AreaTranslationPivot> ToPivotList(this List<AreaTranslation> areaTranslationList)
        {
            return areaTranslationList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From AreaTranslationPivot to AreaTranslation.
        /// </summary>
        /// <param name="areaTranslationPivot">areaTranslationPivot to assemble.</param>
        /// <returns>AreaTranslation result.</returns>
        public static AreaTranslation ToEntity(this AreaTranslationPivot areaTranslationPivot)
        {
            if (areaTranslationPivot == null)
            {
                return null;
            }
            return new AreaTranslation
            {
                Language = areaTranslationPivot.Language?.ToEntity(),
                TranslationId = areaTranslationPivot.TranslationId,
                Area = areaTranslationPivot.Area?.ToEntity(),
                LanguageId = areaTranslationPivot.LanguageId,
                AreaName = areaTranslationPivot.AreaName,
                AreaId = areaTranslationPivot.AreaId
            };
        }

        /// <summary>
        /// From AreaTranslationPivotList to AreaTranslationList .
        /// </summary>
        /// <param name="areaTranslationPivotList">AreaTranslationPivotList to assemble.</param>
        /// <returns> list of AreaTranslation result.</returns>
        public static List<AreaTranslation> ToEntityList(this List<AreaTranslationPivot> areaTranslationPivotList)
        {
            return areaTranslationPivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}