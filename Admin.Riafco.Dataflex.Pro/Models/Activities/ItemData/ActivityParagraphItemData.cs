using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Admin.Riafco.Dataflex.Pro.GlobalResources;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData
{
    /// <summary>
    /// The ActivityParagraphItemData class.
    /// </summary>
    public class ActivityParagraphItemData
    {
        /// <summary>
        /// Gets or Sets The  ParagraphId.
        /// </summary>
        public int ParagraphId { get; set; }

        /// <summary>
        /// Gets or Sets The  ParagraphImage.
        /// </summary>
        public string ParagraphImage { get; set; }

        #region navigation proportises

        /// <summary>
        /// Gets or Sets The  ActivityId.
        /// </summary>
        public int? ActivityId { get; set; }

        /// <summary>
        /// Gets or Sets The  Activity.
        /// </summary>
        public ActivityItemData Activity { get; set; }

        /// <summary>
        /// Gets or sets TranslationItemDataList.
        /// </summary>
        public List<ActivityParagraphTranslationItemData> TranslationItemDataList { get; set; }

        #endregion
    }
}