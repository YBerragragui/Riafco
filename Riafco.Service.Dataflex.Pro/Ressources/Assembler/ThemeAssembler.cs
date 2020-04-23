using Riafco.Entity.Dataflex.Pro.Ressources;
using Riafco.Service.Dataflex.Pro.Ressources.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Ressources.Assembler
{
    /// <summary>
    /// The Theme assembler class.
    /// </summary>
    public static class ThemeAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From Theme To Theme Pivot.
        /// </summary>
        /// <param name="theme">theme TO ASSEMBLE</param>
        /// <returns>ThemePivot result.</returns>
        public static ThemePivot ToPivot(this Theme theme)
        {
            if (theme == null)
            {
                return null;
            }
            return new ThemePivot
            {
                ThemeId = theme.ThemeId
            };
        }

        /// <summary>
        /// From Theme list to Theme pivot list.
        /// </summary>
        /// <param name="themeList">themeList to assemble.</param>
        /// <returns>list of ThemePivot result.</returns>
        public static List<ThemePivot> ToPivotList(this List<Theme> themeList)
        {
            return themeList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From ThemePivot to Theme.
        /// </summary>
        /// <param name="themePivot">themePivot to assemble.</param>
        /// <returns>Theme result.</returns>
        public static Theme ToEntity(this ThemePivot themePivot)
        {
            if (themePivot == null)
            {
                return null;
            }

            return new Theme
            {
                ThemeId = themePivot.ThemeId
            };
        }

        /// <summary>
        /// From ThemePivotList to ThemeList .
        /// </summary>
        /// <param name="themePivotList">ThemePivotList to assemble.</param>
        /// <returns> list of Theme result.</returns>
        public static List<Theme> ToEntityList(this List<ThemePivot> themePivotList)
        {
            return themePivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}