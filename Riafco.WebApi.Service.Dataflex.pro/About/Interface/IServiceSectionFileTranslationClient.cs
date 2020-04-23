using Riafco.WebApi.Service.Dataflex.pro.About.Request;
using Riafco.WebApi.Service.Dataflex.pro.About.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Interface
{
    /// <summary>
    /// The SectionFileTranslation client interface.
    /// </summary>
    public interface IServiceSectionFileTranslationClient
    {
        /// <summary>
        /// Create SectionFileTranslation dto.
        /// </summary>
        /// <param name="sectionFileTranslationRequest"> The SectionFileTranslationRequest that content SectionFileTranslationdto to add.</param>
        /// <returns>The SectionFileTranslationMessagePivot result with the SectionFileTranslationPivot added.</returns>
        SectionFileTranslationMessage CreateSectionFileTranslation(SectionFileTranslationRequest sectionFileTranslationRequest);

        /// <summary>
        /// Create SectionFileTranslation dto list.
        /// </summary>
        /// <param name="sectionFileTranslationRequest"> The SectionFileTranslationRequest that content SectionFileTranslationdto to add.</param>
        /// <returns>The SectionFileTranslationMessagePivot result with the SectionFileTranslationPivot added.</returns>
        SectionFileTranslationMessage CreateSectionFileTranslationRange(SectionFileTranslationRequest sectionFileTranslationRequest);

        /// <summary>
        /// Update SectionFileTranslation dto.
        /// </summary>
        /// <param name="sectionFileTranslationRequest"> The SectionFileTranslationRequest that content SectionFileTranslationdto to update.</param>
        SectionFileTranslationMessage UpdateSectionFileTranslation(SectionFileTranslationRequest sectionFileTranslationRequest);

        /// <summary>
        /// Update SectionFileTranslation dto lmist
        /// </summary>
        /// <param name="sectionFileTranslationRequest"> The SectionFileTranslationRequest that content SectionFileTranslationdto to update.</param>
        SectionFileTranslationMessage UpdateSectionFileTranslationRange(SectionFileTranslationRequest sectionFileTranslationRequest);

        /// <summary>
        /// Delete SectionFileTranslation dto.
        /// </summary>
        /// <param name="sectionFileTranslationRequest"> The SectionFileTranslationRequest that content SectionFileTranslationdto to remove.</param>
        /// <returns>The SectionFileTranslationMessagePivot result with the SectionFileTranslationPivot removed.</returns>
        SectionFileTranslationMessage DeleteSectionFileTranslation(SectionFileTranslationRequest sectionFileTranslationRequest);

        /// <summary>
        /// Get the list of SectionFileTranslation.
        /// </summary>
        /// <returns>The SectionFileTranslationMessagePivot result with the SectionFileTranslationPivot list.</returns>
        SectionFileTranslationMessage GetAllSectionFileTranslations();

        /// <summary>
        /// Find SectionFileTranslation.
        /// </summary>
        /// <returns>The SectionFileTranslationMessagePivot result with the SectionFileTranslationPivot list.</returns>
        SectionFileTranslationMessage FindSectionFileTranslations(SectionFileTranslationRequest sectionFileTranslationRequest);
    }
}