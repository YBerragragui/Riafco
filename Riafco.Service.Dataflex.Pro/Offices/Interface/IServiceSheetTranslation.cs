using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Offices.Request;
using Riafco.Service.Dataflex.Pro.Offices.Response;

namespace Riafco.Service.Dataflex.Pro.Offices.Interface
{
    /// <summary>
    /// The SheetTranslation interface.
    /// </summary>
    public interface IServiceSheetTranslation
    {
        /// <summary>
        /// Create SheetTranslationPivot.
        /// </summary>
        /// <param name="request"> The SheetTranslationRequest Pivot that content SheetTranslationPivot to add.</param>
        /// <returns>The SheetTranslationResponsePivot result with the SheetTranslationPivot added.</returns>
        SheetTranslationResponsePivot CreateSheetTranslation(SheetTranslationRequestPivot request);

        /// <summary>
        /// Create SheetTranslationRange.
        /// </summary>
        /// <param name="request"> The SheetTranslationRequest Pivot that content CreateSheetTranslationRange to add.</param>
        /// <returns>The SheetTranslationResponsePivot result with the SheetTranslationPivot added.</returns>
        SheetTranslationResponsePivot CreateSheetTranslationRange(SheetTranslationRequestPivot request);

        /// <summary>
        /// Update SheetTranslationPivot.
        /// </summary>
        /// <param name="request"> The SheetTranslationRequest Pivot that content SheetTranslationPivot to update.</param>
        void UpdateSheetTranslation(SheetTranslationRequestPivot request);

        /// <summary>
        /// Update SheetTranslationRange.
        /// </summary>
        /// <param name="request"> The SheetTranslationRequest Pivot that content UpdateSheetTranslationRange to update.</param>
        void UpdateSheetTranslationRange(SheetTranslationRequestPivot request);

        /// <summary>
        /// Delete SheetTranslationPivot.
        /// </summary>
        /// <param name="request"> The SheetTranslationRequest Pivot that content SheetTranslationPivot to remove.</param>
        void DeleteSheetTranslation(SheetTranslationRequestPivot request);

        /// <summary>
        /// Get SheetTranslation list
        /// </summary>
        /// <returns>Response result.</returns>
        SheetTranslationResponsePivot GetAllSheetTranslations();

        /// <summary>
        /// Search SheetTranslation.
        /// </summary>
        /// <param name="request"> The SheetTranslationRequest Pivot that content SheetTranslationPivot to remove.</param>
        /// <returns>Response Result.</returns>
        SheetTranslationResponsePivot FindSheetTranslations(SheetTranslationRequestPivot request);

    }
}