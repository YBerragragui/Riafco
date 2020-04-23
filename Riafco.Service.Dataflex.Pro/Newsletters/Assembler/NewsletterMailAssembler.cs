using Riafco.Entity.Dataflex.Pro.Newsletters;
using Riafco.Service.Dataflex.Pro.Newsletters.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Newsletters.Assembler
{
    /// <summary>
    /// The NewsletterMail assembler class.
    /// </summary>
    public static class NewsletterMailAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From NewsletterMail To NewsletterMail Pivot.
        /// </summary>
        /// <param name="newsletterMail">newsletterMail TO ASSEMBLE</param>
        /// <returns>NewsletterMailPivot result.</returns>
        public static NewsletterMailPivot ToPivot(this NewsletterMail newsletterMail)
        {
            if (newsletterMail == null)
            {
                return null;
            }
            return new NewsletterMailPivot()
            {
                NewsletterMailId = newsletterMail.NewsletterMailId,
            };
        }

        /// <summary>
        /// From NewsletterMail list to NewsletterMail pivot list.
        /// </summary>
        /// <param name="newsletterMailList">newsletterMailList to assemble.</param>
        /// <returns>list of NewsletterMailPivot result.</returns>
        public static List<NewsletterMailPivot> ToPivotList(this List<NewsletterMail> newsletterMailList)
        {
            return newsletterMailList?.Select(x => x.ToPivot()).ToList();

        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From NewsletterMailPivot to NewsletterMail.
        /// </summary>
        /// <param name="newsletterMailPivot">newsletterMailPivot to assemble.</param>
        /// <returns>NewsletterMail result.</returns>
        public static NewsletterMail ToEntity(this NewsletterMailPivot newsletterMailPivot)
        {
            if (newsletterMailPivot == null)
            {
                return null;
            }
            return new NewsletterMail()
            {
                NewsletterMailId = newsletterMailPivot.NewsletterMailId,
            };
        }

        /// <summary>
        /// From NewsletterMailPivotList to NewsletterMailList .
        /// </summary>
        /// <param name="newsletterMailPivotList">NewsletterMailPivotList to assemble.</param>
        /// <returns> list of NewsletterMail result.</returns>
        public static List<NewsletterMail> ToEntityList(this List<NewsletterMailPivot> newsletterMailPivotList)
        {
            return newsletterMailPivotList?.Select(x => x?.ToEntity()).ToList();

        }
        #endregion
    }
}