using System.Collections.Generic;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData
{
    /// <summary>
    /// The Activite dto class.
    /// </summary>
    public class ActivityItemData
    {
        /// <summary>
        /// Gets or Sets The  ActivityId.
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityIcon.
        /// </summary>
        public string ActivityIcon { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityImage.
        /// </summary>
        public string ActivityImage { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or sets Translations
        /// </summary>
        public List<ActivityTranslationItemData> TranslationItemDataList { get; set; }

        #endregion
    }
}