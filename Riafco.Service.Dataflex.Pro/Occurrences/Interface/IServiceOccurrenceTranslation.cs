using Riafco.Service.Dataflex.Pro.Occurrences.Request;
using Riafco.Service.Dataflex.Pro.Occurrences.Response;

namespace Riafco.Service.Dataflex.Pro.Occurrences.Interface
{
    /// <summary>
    /// The OccurrenceTranslation interface.
    /// </summary>
    public interface IServiceOccurrenceTranslation
    {
        /// <summary>
        /// Create OccurrenceTranslationPivot.
        /// </summary>
        /// <param name="request"> The OccurrenceTranslationRequest Pivot that content OccurrenceTranslationPivot to add.</param>
        /// <returns>The OccurrenceTranslationResponsePivot result with the OccurrenceTranslationPivot added.</returns>
        OccurrenceTranslationResponsePivot CreateOccurrenceTranslation(OccurrenceTranslationRequestPivot request);

        /// <summary>
        /// Create OccurrenceTranslationPivot.
        /// </summary>
        /// <param name="request"> The CreateOccurrenceTranslationRange Pivot that content CreateOccurrenceTranslationRange to add.</param>
        /// <returns>The OccurrenceTranslationResponsePivot result with the CreateOccurrenceTranslationRange added.</returns>
        OccurrenceTranslationResponsePivot CreateOccurrenceTranslationRange(OccurrenceTranslationRequestPivot request);

        /// <summary>
        /// Update OccurrenceTranslationPivot.
        /// </summary>
        /// <param name="request"> The OccurrenceTranslationRequest Pivot that content OccurrenceTranslationPivot to update.</param>
        void UpdateOccurrenceTranslation(OccurrenceTranslationRequestPivot request);

        /// <summary>
        /// Update UpdateOccurrenceTranslationRange.
        /// </summary>
        /// <param name="request"> The UpdateOccurrenceTranslationRange Pivot that content OccurrenceTranslationPivot to update.</param>
        void UpdateOccurrenceTranslationRange(OccurrenceTranslationRequestPivot request);

        /// <summary>
        /// Delete OccurrenceTranslationPivot.
        /// </summary>
        /// <param name="request"> The OccurrenceTranslationRequest Pivot that content OccurrenceTranslationPivot to remove.</param>
        void DeleteOccurrenceTranslation(OccurrenceTranslationRequestPivot request);

        /// <summary>
        /// Get OccurrenceTranslation list
        /// </summary>
        /// <returns>Response result.</returns>
        OccurrenceTranslationResponsePivot GetAllOccurrenceTranslations();

        /// <summary>
        /// Search OccurrenceTranslation.
        /// </summary>
        /// <param name="request"> The OccurrenceTranslationRequest Pivot that content OccurrenceTranslationPivot to remove.</param>
        /// <returns>Response Result.</returns>
        OccurrenceTranslationResponsePivot FindOccurrenceTranslations(OccurrenceTranslationRequestPivot request);

    }
}