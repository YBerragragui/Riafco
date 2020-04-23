using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Occurrences.Request;
using Riafco.Service.Dataflex.Pro.Occurrences.Response;

namespace Riafco.Service.Dataflex.Pro.Occurrences.Interface
{
    /// <summary>
    /// The Occurrence interface.
    /// </summary>
    public interface IServiceOccurrence
    {
        /// <summary>
        /// Create OccurrencePivot.
        /// </summary>
        /// <param name="request"> The OccurrenceRequest Pivot that content OccurrencePivot to add.</param>
        /// <returns>The OccurrenceResponsePivot result with the OccurrencePivot added.</returns>
        OccurrenceResponsePivot CreateOccurrence(OccurrenceRequestPivot request);

        /// <summary>
        /// Update OccurrencePivot.
        /// </summary>
        /// <param name="request"> The OccurrenceRequest Pivot that content OccurrencePivot to update.</param>
        void UpdateOccurrence(OccurrenceRequestPivot request);

        /// <summary>
        /// Delete OccurrencePivot.
        /// </summary>
        /// <param name="request"> The OccurrenceRequest Pivot that content OccurrencePivot to remove.</param>
        void DeleteOccurrence(OccurrenceRequestPivot request);

        /// <summary>
        /// Get Occurrence list
        /// </summary>
        /// <returns>Response result.</returns>
        OccurrenceResponsePivot GetAllOccurrences();

        /// <summary>
        /// Search Occurrence.
        /// </summary>
        /// <param name="request"> The OccurrenceRequest Pivot that content OccurrencePivot to remove.</param>
        /// <returns>Response Result.</returns>
        OccurrenceResponsePivot FindOccurrences(OccurrenceRequestPivot request);
    }
}