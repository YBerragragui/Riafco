using Riafco.Service.Dataflex.Pro.About.Request;
using Riafco.Service.Dataflex.Pro.About.Response;

namespace Riafco.Service.Dataflex.Pro.About.Interface
{
    /// <summary>
    /// The SectionTranslation interface.
    /// </summary>
    public interface IServiceSectionTranslation
    {
        /// <summary>
        /// Create SectionTranslationPivot.
        /// </summary>
        /// <param name="request"> The SectionTranslationRequest Pivot that content SectionTranslationPivot to add.</param>
        /// <returns>The SectionTranslationResponsePivot result with the SectionTranslationPivot added.</returns>
        SectionTranslationResponsePivot CreateSectionTranslation(SectionTranslationRequestPivot request);

        /// <summary>
        /// Create SectionTranslationPivot.
        /// </summary>
        /// <param name="request"> The SectionTranslationRequest Pivot that content SectionTranslationPivot to add.</param>
        /// <returns>The SectionTranslationResponsePivot result with the SectionTranslationPivot added.</returns>
        SectionTranslationResponsePivot CreateSectionTranslationRange(SectionTranslationRequestPivot request);

        /// <summary>
        /// Update SectionTranslationPivot.
        /// </summary>
        /// <param name="request"> The SectionTranslationRequest Pivot that content SectionTranslationPivot to update.</param>
        void UpdateSectionTranslation(SectionTranslationRequestPivot request);

        /// <summary>
        /// Update SectionTranslationPivot.
        /// </summary>
        /// <param name="request"> The SectionTranslationRequest Pivot that content SectionTranslationPivot to update.</param>
        void UpdateSectionTranslationRange(SectionTranslationRequestPivot request);

        /// <summary>
        /// Delete SectionTranslationPivot.
        /// </summary>
        /// <param name="request"> The SectionTranslationRequest Pivot that content SectionTranslationPivot to remove.</param>
        void DeleteSectionTranslation(SectionTranslationRequestPivot request);

        /// <summary>
        /// Get SectionTranslation list
        /// </summary>
        /// <returns>Response result.</returns>
        SectionTranslationResponsePivot GetAllSectionTranslations();

        /// <summary>
        /// Search SectionTranslation.
        /// </summary>
        /// <param name="request"> The SectionTranslationRequest Pivot that content SectionTranslationPivot to remove.</param>
        /// <returns>Response Result.</returns>
        SectionTranslationResponsePivot FindSectionTranslations(SectionTranslationRequestPivot request);

    }
}