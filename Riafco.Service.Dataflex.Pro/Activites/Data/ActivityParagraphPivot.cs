using System;

namespace Riafco.Service.Dataflex.Pro.Activites.Data
{
    /// <summary>
    /// The ActivityParagraph pivot class.
    /// </summary>
    public class ActivityParagraphPivot
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
        public ActivityPivot Activity { get; set; }

        #endregion
    }
}