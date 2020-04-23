using Riafco.Service.Dataflex.Pro.About.Request;
using Riafco.Service.Dataflex.Pro.About.Response;

namespace Riafco.Service.Dataflex.Pro.About.Interface
{
    /// <summary>
    /// The SectionParagraph interface.
    /// </summary>
    public interface IServiceSectionParagraph
    {
        /// <summary>
        /// Create SectionParagraphPivot.
        /// </summary>
        /// <param name="request"> The SectionParagraphRequest Pivot that content SectionParagraphPivot to add.</param>
        /// <returns>The SectionParagraphResponsePivot result with the SectionParagraphPivot added.</returns>
        SectionParagraphResponsePivot CreateSectionParagraph(SectionParagraphRequestPivot request);

        /// <summary>
        /// Update SectionParagraphPivot.
        /// </summary>
        /// <param name="request"> The SectionParagraphRequest Pivot that content SectionParagraphPivot to update.</param>
        void UpdateSectionParagraph(SectionParagraphRequestPivot request);

        /// <summary>
        /// Delete SectionParagraphPivot.
        /// </summary>
        /// <param name="request"> The SectionParagraphRequest Pivot that content SectionParagraphPivot to remove.</param>
        void DeleteSectionParagraph(SectionParagraphRequestPivot request);

        /// <summary>
        /// Get SectionParagraph list
        /// </summary>
        /// <returns>Response result.</returns>
        SectionParagraphResponsePivot GetAllSectionParagraphs();

        /// <summary>
        /// Search SectionParagraph.
        /// </summary>
        /// <param name="request"> The SectionParagraphRequest Pivot that content SectionParagraphPivot to remove.</param>
        /// <returns>Response Result.</returns>
        SectionParagraphResponsePivot FindSectionParagraphs(SectionParagraphRequestPivot request);
    }
}