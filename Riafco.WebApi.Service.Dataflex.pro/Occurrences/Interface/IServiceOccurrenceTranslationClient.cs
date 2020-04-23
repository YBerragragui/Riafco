using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Request;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Occurrences.Interface
{
    /// <summary>
    /// The OccurrenceTranslation client interface.
    /// </summary>
    public interface IServiceOccurrenceTranslationClient
    {
        /// <summary>
        /// Add OccurrenceTranslation dto.
        /// </summary>
        /// <param name="request"> The OccurrenceTranslationRequest that content OccurrenceTranslationdto to add.</param>
        /// <returns>The OccurrenceTranslationMessagePivot result with the OccurrenceTranslationPivot added.</returns>
        OccurrenceTranslationMessage CreateOccurrenceTranslation(OccurrenceTranslationRequest request);

        /// <summary>
        /// Add CreateOccurrenceTranslationRange dto.
        /// </summary>
        /// <param name="request"> The OccurrenceTranslationRequest that content CreateOccurrenceTranslationRange to add.</param>
        /// <returns>The OccurrenceTranslationMessagePivot result with the OccurrenceTranslationPivot added.</returns>
        OccurrenceTranslationMessage CreateOccurrenceTranslationRange(OccurrenceTranslationRequest request);

        /// <summary>
        /// Update OccurrenceTranslation dto.
        /// </summary>
        /// <param name="request"> The OccurrenceTranslationRequest that content OccurrenceTranslationdto to update.</param>
        OccurrenceTranslationMessage UpdateOccurrenceTranslation(OccurrenceTranslationRequest request);

        /// <summary>
        /// Update UpdateOccurrenceTranslationRange dto.
        /// </summary>
        /// <param name="request"> The request that content UpdateOccurrenceTranslationRange to update.</param>
        OccurrenceTranslationMessage UpdateOccurrenceTranslationRange(OccurrenceTranslationRequest request);

        /// <summary>
        /// Delete OccurrenceTranslation dto.
        /// </summary>
        /// <param name="occurrenceTranslationRequest"> The OccurrenceTranslationRequest that content OccurrenceTranslationdto to remove.</param>
        /// <returns>The OccurrenceTranslationMessagePivot result with the OccurrenceTranslationPivot removed.</returns>
        OccurrenceTranslationMessage DeleteOccurrenceTranslation(OccurrenceTranslationRequest occurrenceTranslationRequest);

        /// <summary>
        /// Get the list of OccurrenceTranslation.
        /// </summary>
        /// <returns>The OccurrenceTranslationMessagePivot result with the OccurrenceTranslationPivot list.</returns>
        OccurrenceTranslationMessage GetAllOccurrenceTranslations();

        /// <summary>
        /// Find OccurrenceTranslation.
        /// </summary>
        /// <returns>The OccurrenceTranslationMessagePivot result with the OccurrenceTranslationPivot list.</returns>
        OccurrenceTranslationMessage FindOccurrenceTranslations(OccurrenceTranslationRequest occurrenceTranslationRequest);
    }
}