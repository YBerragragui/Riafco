using Riafco.Service.Dataflex.Pro.About.Request;
using Riafco.Service.Dataflex.Pro.About.Response;

namespace Riafco.Service.Dataflex.Pro.About.Interface
{
    /// <summary>
    /// The SectionFileTranslation interface.
    /// </summary>
    public interface IServiceSectionFileTranslation
    {
        /// <summary>
        /// Create SectionFileTranslationPivot.
        /// </summary>
        /// <param name="request"> The SectionFileTranslationRequest Pivot that content SectionFileTranslationPivot to add.</param>
        /// <returns>The SectionFileTranslationResponsePivot result with the SectionFileTranslationPivot added.</returns>
        SectionFileTranslationResponsePivot CreateSectionFileTranslation(SectionFileTranslationRequestPivot request);

        /// <summary>
        /// Create SectionFileTranslationPivot Range.
        /// </summary>
        /// <param name="request"> The SectionFileTranslationRequest Pivot that content SectionFileTranslationPivotList to create.</param>
        /// <returns>The SectionFileTranslationResponsePivot result with the SectionFileTranslationPivot added.</returns>
        SectionFileTranslationResponsePivot CreateSectionFileTranslationRange(SectionFileTranslationRequestPivot request);

        /// <summary>
        /// Update SectionFileTranslationPivot.
        /// </summary>
        /// <param name="request"> The SectionFileTranslationRequest Pivot that content SectionFileTranslationPivot to update.</param>
        void UpdateSectionFileTranslation(SectionFileTranslationRequestPivot request);

        /// <summary>
        /// Update SectionFileTranslationPivot.
        /// </summary>
        /// <param name="request"> The SectionFileTranslationRequest Pivot that content SectionFileTranslationPivotList to update.</param>
        void UpdateSectionFileTranslationRange(SectionFileTranslationRequestPivot request);

        /// <summary>
        /// Delete SectionFileTranslationPivot.
        /// </summary>
        /// <param name="request"> The SectionFileTranslationRequest Pivot that content SectionFileTranslationPivot to remove.</param>
        void DeleteSectionFileTranslation(SectionFileTranslationRequestPivot request);

        /// <summary>
        /// Get SectionFileTranslation list
        /// </summary>
        /// <returns>Response result.</returns>
        SectionFileTranslationResponsePivot GetAllSectionFileTranslations();

        /// <summary>
        /// Search SectionFileTranslation.
        /// </summary>
        /// <param name="request"> The SectionFileTranslationRequest Pivot that content SectionFileTranslationPivot to remove.</param>
        /// <returns>Response Result.</returns>
        SectionFileTranslationResponsePivot FindSectionFileTranslations(SectionFileTranslationRequestPivot request);

    }
}