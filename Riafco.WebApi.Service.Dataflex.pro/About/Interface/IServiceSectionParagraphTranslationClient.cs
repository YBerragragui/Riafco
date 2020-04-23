using Riafco.WebApi.Service.Dataflex.pro.About.Request;
using Riafco.WebApi.Service.Dataflex.pro.About.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Interface
{
    /// <summary>
    /// The SectionParagraphTraslation client interface.
    /// </summary>
    public interface IServiceSectionParagraphTranslationClient
    {
        /// <summary>
        /// Create SectionParagraphTraslation dto.
        /// </summary>
        /// <param name="request"> The SectionParagraphTraslationRequest that content SectionParagraphTraslationdto to add.</param>
        /// <returns>The SectionParagraphTraslationMessagePivot result with the SectionParagraphTranslationPivot added.</returns>
        SectionParagraphTranslationMessage CreateSectionParagraphTranslation(SectionParagraphTranslationRequest request);

        /// <summary>
        /// Create SectionParagraphTraslation dto list.
        /// </summary>
        /// <param name="request"> The SectionParagraphTraslationRequest that content SectionParagraphTraslationdto to add.</param>
        /// <returns>The SectionParagraphTraslationMessagePivot result with the SectionParagraphTranslationPivot added.</returns>
        SectionParagraphTranslationMessage CreateSectionParagraphTranslationRange(SectionParagraphTranslationRequest request);

        /// <summary>
        /// Update SectionParagraphTraslation dto.
        /// </summary>
        /// <param name="request"> The SectionParagraphTraslationRequest that content SectionParagraphTraslationdto to update.</param>
        SectionParagraphTranslationMessage UpdateSectionParagraphTranslation(SectionParagraphTranslationRequest request);

        /// <summary>
        /// Update SectionParagraphTraslation dto.
        /// </summary>
        /// <param name="request"> The SectionParagraphTraslationRequest that content SectionParagraphTraslationdto to update.</param>
        SectionParagraphTranslationMessage UpdateSectionParagraphTranslationRange(SectionParagraphTranslationRequest request);

        /// <summary>
        /// Delete SectionParagraphTraslation dto.
        /// </summary>
        /// <param name="request"> The SectionParagraphTraslationRequest that content SectionParagraphTraslationdto to remove.</param>
        /// <returns>The SectionParagraphTraslationMessagePivot result with the SectionParagraphTranslationPivot removed.</returns>
        SectionParagraphTranslationMessage DeleteSectionParagraphTranslation(SectionParagraphTranslationRequest request);

        /// <summary>
        /// Get the list of SectionParagraphTraslation.
        /// </summary>
        /// <returns>The SectionParagraphTraslationMessagePivot result with the SectionParagraphTranslationPivot list.</returns>
        SectionParagraphTranslationMessage GetAllSectionParagraphTranslations();

        /// <summary>
        /// Find SectionParagraphTraslation.
        /// </summary>
        /// <returns>The SectionParagraphTraslationMessagePivot result with the SectionParagraphTranslationPivot list.</returns>
        SectionParagraphTranslationMessage FindSectionParagraphTranslations(SectionParagraphTranslationRequest request);
    }
}