using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Request;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Occurrences.Interface
{
    /// <summary>
    /// The Occurrence client interface.
    /// </summary>
    public interface IServiceOccurrenceClient
    {
        /// <summary>
        /// Add Occurrence dto.
        /// </summary>
        /// <param name="request"> The OccurrenceRequest that content Occurrencedto to add.</param>
        /// <returns>The OccurrenceMessagePivot result with the OccurrencePivot added.</returns>
        OccurrenceMessage CreateOccurrence(OccurrenceRequest request);

        /// <summary>
        /// Update Occurrence dto.
        /// </summary>
        /// <param name="request"> The OccurrenceRequest that content Occurrencedto to update.</param>
        OccurrenceMessage UpdateOccurrence(OccurrenceRequest request);

        /// <summary>
        /// Delete Occurrence dto.
        /// </summary>
        /// <param name="request"> The OccurrenceRequest that content Occurrencedto to remove.</param>
        /// <returns>The OccurrenceMessagePivot result with the OccurrencePivot removed.</returns>
        OccurrenceMessage DeleteOccurrence(OccurrenceRequest request);

        /// <summary>
        /// Get the list of Occurrence.
        /// </summary>
        /// <returns>The OccurrenceMessagePivot result with the OccurrencePivot list.</returns>
        OccurrenceMessage GetAllOccurrences();

        /// <summary>
        /// Find Occurrence.
        /// </summary>
        /// <returns>The OccurrenceMessagePivot result with the OccurrencePivot list.</returns>
        OccurrenceMessage FindOccurrences(OccurrenceRequest request);
    }
}