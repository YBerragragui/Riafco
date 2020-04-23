using Riafco.Entity.Dataflex.Pro.Newsletters;
using Riafco.Service.Dataflex.Pro.Newsletters.Data;
using Riafco.Entity.Dataflex.Pro;
using System;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Newsletters.Assembler;
using Riafco.Service.Dataflex.Pro.Languages.Assembler;

namespace Riafco.Service.Dataflex.Pro.Newsletters.Assembler
{
    /// <summary>
    /// The NewsletterMailTranslation assembler class.
    /// </summary>
    public static class NewsletterMailTranslationAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From NewsletterMailTranslation To NewsletterMailTranslation Pivot.
        /// </summary>
        /// <param name="newsletterMailTranslation">newsletterMailTranslation TO ASSEMBLE</param>
        /// <returns>NewsletterMailTranslationPivot result.</returns>
        public static NewsletterMailTranslationPivot ToPivot(this NewsletterMailTranslation newsletterMailTranslation)
        {
            if (newsletterMailTranslation == null)
            {
                return null;
            }
            return new NewsletterMailTranslationPivot()
            {
                TranslationId = newsletterMailTranslation.TranslationId,
                NewsletterMailSource = newsletterMailTranslation.NewsletterMailSource,
                NewsletterMailSubject = newsletterMailTranslation.NewsletterMailSubject,
                NewsletterMailId = newsletterMailTranslation.NewsletterMailId.Value,
                NewsletterMail = newsletterMailTranslation.NewsletterMail?.ToPivot(),
                LanguageId = newsletterMailTranslation.LanguageId.Value,
                Language = newsletterMailTranslation.Language?.ToPivot(),
            };
        }

        /// <summary>
        /// From NewsletterMailTranslation list to NewsletterMailTranslation pivot list.
        /// </summary>
        /// <param name="newsletterMailTranslationList">newsletterMailTranslationList to assemble.</param>
        /// <returns>list of NewsletterMailTranslationPivot result.</returns>
        public static List<NewsletterMailTranslationPivot> ToPivotList(this List<NewsletterMailTranslation> newsletterMailTranslationList)
        {
            return newsletterMailTranslationList?.Select(x => x.ToPivot()).ToList();

        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From NewsletterMailTranslationPivot to NewsletterMailTranslation.
        /// </summary>
        /// <param name="newsletterMailTranslationPivot">newsletterMailTranslationPivot to assemble.</param>
        /// <returns>NewsletterMailTranslation result.</returns>
        public static NewsletterMailTranslation ToEntity(this NewsletterMailTranslationPivot newsletterMailTranslationPivot)
        {
            if (newsletterMailTranslationPivot == null)
            {
                return null;
            }
            return new NewsletterMailTranslation()
            {
                TranslationId = newsletterMailTranslationPivot.TranslationId,
                NewsletterMailSource = newsletterMailTranslationPivot.NewsletterMailSource,
                NewsletterMailSubject = newsletterMailTranslationPivot.NewsletterMailSubject,
                NewsletterMailId = newsletterMailTranslationPivot.NewsletterMailId,
                NewsletterMail = newsletterMailTranslationPivot.NewsletterMail?.ToEntity(),
                LanguageId = newsletterMailTranslationPivot.LanguageId,
                Language = newsletterMailTranslationPivot.Language?.ToEntity(),
            };
        }

        /// <summary>
        /// From NewsletterMailTranslationPivotList to NewsletterMailTranslationList .
        /// </summary>
        /// <param name="newsletterMailTranslationPivotList">NewsletterMailTranslationPivotList to assemble.</param>
        /// <returns> list of NewsletterMailTranslation result.</returns>
        public static List<NewsletterMailTranslation> ToEntityList(this List<NewsletterMailTranslationPivot> newsletterMailTranslationPivotList)
        {
            return newsletterMailTranslationPivotList?.Select(x => x?.ToEntity()).ToList();

        }
        #endregion
    }
}