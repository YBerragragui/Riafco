using Riafco.WebApi.Service.Dataflex.pro.About.Request;
using Riafco.WebApi.Service.Dataflex.pro.About.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Interface
{
    /// <summary>
    /// The SectionParagraph client interface.
    /// </summary>
    public interface IServiceSectionParagraphClient
    {
        /// <summary>
        /// Create SectionParagraph dto.
        /// </summary>
        /// <param name="request"> The SectionParagraphRequest that content SectionParagraphdto to add.</param>
        /// <returns>The SectionParagraphMessagePivot result with the SectionParagraphPivot added.</returns>
        SectionParagraphMessage CreateSectionParagraph(SectionParagraphRequest request);

        /// <summary>
        /// Update SectionParagraph dto.
        /// </summary>
        /// <param name="request"> The SectionParagraphRequest that content SectionParagraphdto to update.</param>
        SectionParagraphMessage UpdateSectionParagraph(SectionParagraphRequest request);

        /// <summary>
        /// Delete SectionParagraph dto.
        /// </summary>
        /// <param name="request"> The SectionParagraphRequest that content SectionParagraphdto to remove.</param>
        /// <returns>The SectionParagraphMessagePivot result with the SectionParagraphPivot removed.</returns>
        SectionParagraphMessage DeleteSectionParagraph(SectionParagraphRequest request);

        /// <summary>
        /// Get the list of SectionParagraph.
        /// </summary>
        /// <returns>The SectionParagraphMessagePivot result with the SectionParagraphPivot list.</returns>
        SectionParagraphMessage GetAllSectionParagraphs();

        /// <summary>
        /// Find SectionParagraph.
        /// </summary>
        /// <returns>The SectionParagraphMessagePivot result with the SectionParagraphPivot list.</returns>
        SectionParagraphMessage FindSectionParagraphs(SectionParagraphRequest request);
    }
}