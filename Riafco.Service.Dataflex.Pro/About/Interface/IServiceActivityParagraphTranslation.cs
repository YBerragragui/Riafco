using Riafco.Service.Dataflex.Pro.About.Request;
using Riafco.Service.Dataflex.Pro.About.Response;

namespace Riafco.Service.Dataflex.Pro.About.Interface
{
    /// <summary>
    /// The SectionParagraphTraslation interface.
    /// </summary>
    public interface IServiceSectionParagraphTranslation
    {
        /// <summary>
        /// Create SectionParagraphTranslationPivot.
        /// </summary>
        /// <param name="request"> The SectionParagraphTraslationRequest Pivot that content SectionParagraphTranslationPivot to add.</param>
        /// <returns>The SectionParagraphTraslationResponsePivot result with the SectionParagraphTranslationPivot added.</returns>
        SectionParagraphTranslationResponsePivot CreateSectionParagraphTranslation(SectionParagraphTranslationRequestPivot request);

        /// <summary>
        /// Create SectionParagraphTranslationPivot List.
        /// </summary>
        /// <param name="request"> The SectionParagraphTraslationRequest Pivot that content SectionParagraphTranslationPivot to add.</param>
        /// <returns>The SectionParagraphTraslationResponsePivot result with the SectionParagraphTranslationPivot added.</returns>
        SectionParagraphTranslationResponsePivot CreateSectionParagraphTranslationRange(SectionParagraphTranslationRequestPivot request);

        /// <summary>
        /// Update SectionParagraphTranslationPivot.
        /// </summary>
        /// <param name="request"> The SectionParagraphTraslationRequest Pivot that content SectionParagraphTranslationPivot to update.</param>
        void UpdateSectionParagraphTranslation(SectionParagraphTranslationRequestPivot request);

        /// <summary>
        /// Update SectionParagraphTranslationPivot List.
        /// </summary>
        /// <param name="request"> The SectionParagraphTraslationRequest Pivot that content SectionParagraphTranslationPivot to update.</param>
        void UpdateSectionParagraphTranslationRange(SectionParagraphTranslationRequestPivot request);

        /// <summary>
        /// Delete SectionParagraphTranslationPivot.
        /// </summary>
        /// <param name="request"> The SectionParagraphTraslationRequest Pivot that content SectionParagraphTranslationPivot to remove.</param>
        void DeleteSectionParagraphTranslation(SectionParagraphTranslationRequestPivot request);

        /// <summary>
        /// Get SectionParagraphTraslation list
        /// </summary>
        /// <returns>Response result.</returns>
        SectionParagraphTranslationResponsePivot GetAllSectionParagraphTraslations();

        /// <summary>
        /// Search SectionParagraphTraslation.
        /// </summary>
        /// <param name="request"> The SectionParagraphTraslationRequest Pivot that content SectionParagraphTranslationPivot to remove.</param>
        /// <returns>Response Result.</returns>
        SectionParagraphTranslationResponsePivot FindSectionParagraphTranslations(SectionParagraphTranslationRequestPivot request);

    }
}