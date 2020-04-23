using Riafco.Entity.Dataflex.Pro.Ressources;
using Riafco.Service.Dataflex.Pro.Ressources.Data;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Languages.Assembler;

namespace Riafco.Service.Dataflex.Pro.Ressources.Assembler
{
    /// <summary>
    /// The ThemeTranslation assembler class.
    /// </summary>
    public static class ThemeTranslationAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From ThemeTranslation To ThemeTranslation Pivot.
        /// </summary>
        /// <param name="themeTranslation">themeTranslation TO ASSEMBLE</param>
        /// <returns>ThemeTranslationPivot result.</returns>
        public static ThemeTranslationPivot ToPivot(this ThemeTranslation themeTranslation)
        {
            if (themeTranslation == null)
            {
                return null;
            }
            return new ThemeTranslationPivot
            {
                TranslationId = themeTranslation.TranslationId,
                Language = themeTranslation.Language.ToPivot(),
                Theme = themeTranslation.Theme.ToPivot(),
                LanguageId = themeTranslation.LanguageId,
                ThemeName = themeTranslation.ThemeName,
                ThemeId = themeTranslation.ThemeId
            };
        }

        /// <summary>
        /// From ThemeTranslation list to ThemeTranslation pivot list.
        /// </summary>
        /// <param name="themeTranslationList">themeTranslationList to assemble.</param>
        /// <returns>list of ThemeTranslationPivot result.</returns>
        public static List<ThemeTranslationPivot> ToPivotList(this List<ThemeTranslation> themeTranslationList)
        {
            return themeTranslationList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From ThemeTranslationPivot to ThemeTranslation.
        /// </summary>
        /// <param name="themeTranslationPivot">themeTranslationPivot to assemble.</param>
        /// <returns>ThemeTranslation result.</returns>
        public static ThemeTranslation ToEntity(this ThemeTranslationPivot themeTranslationPivot)
        {
            if (themeTranslationPivot == null)
            {
                return null;
            }
            return new ThemeTranslation
            {
                Language = themeTranslationPivot.Language.ToEntity(),
                TranslationId = themeTranslationPivot.TranslationId,
                Theme = themeTranslationPivot.Theme.ToEntity(),
                LanguageId = themeTranslationPivot.LanguageId,
                ThemeName = themeTranslationPivot.ThemeName,
                ThemeId = themeTranslationPivot.ThemeId
            };
        }

        /// <summary>
        /// From ThemeTranslationPivotList to ThemeTranslationList .
        /// </summary>
        /// <param name="themeTranslationPivotList">ThemeTranslationPivotList to assemble.</param>
        /// <returns> list of ThemeTranslation result.</returns>
        public static List<ThemeTranslation> ToEntityList(this List<ThemeTranslationPivot> themeTranslationPivotList)
        {
            return themeTranslationPivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}