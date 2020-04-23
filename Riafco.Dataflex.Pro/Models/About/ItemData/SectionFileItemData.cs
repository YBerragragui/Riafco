namespace Riafco.Dataflex.Pro.Models.About.ItemData
{
    /// <summary>
    /// The SectionFileItemData class.
    /// </summary>
    public class SectionFileItemData
    {
        /// <summary>
        /// Gets or Sets The SectionFileId.
        /// </summary>
        public int SectionFileId { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  SectionId.
        /// </summary>
        public int? SectionId { get; set; }

        /// <summary>
        /// Gets or Sets The  Section.
        /// </summary>
        public SectionItemData Section { get; set; }

        #endregion
    }
}