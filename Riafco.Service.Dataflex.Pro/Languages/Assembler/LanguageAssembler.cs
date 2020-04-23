using Riafco.Entity.Dataflex.Pro.Languages;
using Riafco.Service.Dataflex.Pro.Languages.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Languages.Assembler
{
    /// <summary>
    /// The Language assembler class.
    /// </summary>
    public static class LanguageAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From Language To Language Pivot.
        /// </summary>
        /// <param name="language">language TO ASSEMBLE</param>
        /// <returns>LanguagePivot result.</returns>
        public static LanguagePivot ToPivot(this Language language)
        {
            if (language == null)
            {
                return null;
            }
            return new LanguagePivot
            {
                LanguageId = language.LanguageId,
                LanguagePrefix = language.LanguagePrefix,
                LanguagePicture = language.LanguagePicture
            };
        }

        /// <summary>
        /// From Language list to Language pivot list.
        /// </summary>
        /// <param name="languageList">languageList to assemble.</param>
        /// <returns>list of LanguagePivot result.</returns>
        public static List<LanguagePivot> ToPivotList(this List<Language> languageList)
        {
            return languageList == null ? new List<LanguagePivot>() : languageList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From LanguagePivot to Language.
        /// </summary>
        /// <param name="languagePivot">languagePivot to assemble.</param>
        /// <returns>Language result.</returns>
        public static Language ToEntity(this LanguagePivot languagePivot)
        {
            if (languagePivot == null)
            {
                return null;
            }
            return new Language
            {
                LanguageId = languagePivot.LanguageId,
                LanguagePrefix = languagePivot.LanguagePrefix,
                LanguagePicture = languagePivot.LanguagePicture
            };
        }

        /// <summary>
        /// From LanguagePivotList to LanguageList .
        /// </summary>
        /// <param name="languagePivotList">LanguagePivotList to assemble.</param>
        /// <returns> list of Language result.</returns>
        public static List<Language> ToEntityList(this List<LanguagePivot> languagePivotList)
        {
            return languagePivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}