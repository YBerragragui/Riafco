using Riafco.WebApi.Service.Dataflex.pro.About.Request;
using Riafco.WebApi.Service.Dataflex.pro.About.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Interface
{
    /// <summary>
    /// The SectionTranslation client interface.
    /// </summary>
    public interface IServiceSectionTranslationClient
    {
        /// <summary>
        /// Add SectionTranslation dto.
        /// </summary>
        /// <param name="request"> The SectionTranslationRequest that content SectionTranslationdto to add.</param>
        /// <returns>The SectionTranslationMessagePivot result with the SectionTranslationPivot added.</returns>
        SectionTranslationMessage CreateSectionTranslation(SectionTranslationRequest request);

        /// <summary>
        /// Add SectionTranslation dto.
        /// </summary>
        /// <param name="request"> The SectionTranslationRequest that content SectionTranslationdto to add.</param>
        /// <returns>The SectionTranslationMessagePivot result with the SectionTranslationPivot added.</returns>
        SectionTranslationMessage CreateSectionTranslationRange(SectionTranslationRequest request);

        /// <summary>
        /// Update SectionTranslation dto.
        /// </summary>
        /// <param name="request"> The SectionTranslationRequest that content SectionTranslationdto to update.</param>
        SectionTranslationMessage UpdateSectionTranslation(SectionTranslationRequest request);

        /// <summary>
        /// Update SectionTranslation dto.
        /// </summary>
        /// <param name="request"> The SectionTranslationRequest that content SectionTranslationdto to update.</param>
        SectionTranslationMessage UpdateSectionTranslationRange(SectionTranslationRequest request);

        /// <summary>
        /// Delete SectionTranslation dto.
        /// </summary>
        /// <param name="request"> The SectionTranslationRequest that content SectionTranslationdto to remove.</param>
        /// <returns>The SectionTranslationMessagePivot result with the SectionTranslationPivot removed.</returns>
        SectionTranslationMessage DeleteSectionTranslation(SectionTranslationRequest request);

        /// <summary>
        /// Get the list of SectionTranslation.
        /// </summary>
        /// <returns>The SectionTranslationMessagePivot result with the SectionTranslationPivot list.</returns>
        SectionTranslationMessage GetAllSectionTranslations();

        /// <summary>
        /// Find SectionTranslation.
        /// </summary>
        /// <returns>The SectionTranslationMessagePivot result with the SectionTranslationPivot list.</returns>
        SectionTranslationMessage FindSectionTranslations(SectionTranslationRequest request);
    }
}