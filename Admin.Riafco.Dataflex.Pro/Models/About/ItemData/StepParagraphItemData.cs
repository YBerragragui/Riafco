namespace Admin.Riafco.Dataflex.Pro.Models.About.ItemData
{
    /// <summary>
    /// The SectionParagraphItemData class.
    /// </summary>
    public class StepParagraphItemData
    {
        /// <summary>
        /// Gets or Sets The ParagraphId.
        /// </summary>
        public int ParagraphId { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The StepId.
        /// </summary>
        public int? StepId { get; set; }

        /// <summary>
        /// Gets or Sets The Step.
        /// </summary>
        public StepItemData Step { get; set; }

        #endregion
    }
}