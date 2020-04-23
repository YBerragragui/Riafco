
namespace Riafco.Service.Dataflex.Pro.About.Data
{
    /// <summary>
    /// The SectionFile pivot class.
    /// </summary>
    public class SectionFilePivot
    {
        /// <summary>
        /// Gets or Sets The SectionFileId.
        /// </summary>
        public int SectionFileId { get; set; }

        #region NAVIGATION ATTRIBUTES

        /// <summary>
        /// Gets or Sets The SectionId.
        /// </summary>
        public int? SectionId { get; set; }

        /// <summary>
        /// Gets or Sets The  Section.
        /// </summary>
        public SectionPivot Section { get; set; }
        #endregion
    }
}