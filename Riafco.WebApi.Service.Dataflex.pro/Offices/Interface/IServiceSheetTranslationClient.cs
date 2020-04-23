using Riafco.WebApi.Service.Dataflex.pro.Offices.Request;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Offices.Interface
{
    /// <summary>
    /// The SheetTranslation client interface.
    /// </summary>
    public interface IServiceSheetTranslationClient
    {
        /// <summary>
        /// Add SheetTranslation dto.
        /// </summary>
        /// <param name="request"> The SheetTranslationRequest that content SheetTranslationdto to add.</param>
        /// <returns>The SheetTranslationMessagePivot result with the SheetTranslationPivot added.</returns>
        SheetTranslationMessage CreateSheetTranslation(SheetTranslationRequest request);

        /// <summary>
        /// Add SheetTranslationRange dto.
        /// </summary>
        /// <param name="request"> The SheetTranslationRequest that content SheetTranslationRange to add.</param>
        /// <returns>The SheetTranslationMessagePivot result with the SheetTranslationPivot added.</returns>
        SheetTranslationMessage CreateSheetTranslationRange(SheetTranslationRequest request);

        /// <summary>
        /// Update SheetTranslation dto.
        /// </summary>
        /// <param name="request"> The SheetTranslationRequest that content SheetTranslationdto to update.</param>
        SheetTranslationMessage UpdateSheetTranslation(SheetTranslationRequest request);

        /// <summary>
        /// Update SheetTranslationRange dto.
        /// </summary>
        /// <param name="request"> The SheetTranslationRequest that content SheetTranslationRange to update.</param>
        SheetTranslationMessage UpdateSheetTranslationRange(SheetTranslationRequest request);

        /// <summary>
        /// Delete SheetTranslation dto.
        /// </summary>
        /// <param name="request"> The SheetTranslationRequest that content SheetTranslationdto to remove.</param>
        /// <returns>The SheetTranslationMessagePivot result with the SheetTranslationPivot removed.</returns>
        SheetTranslationMessage DeleteSheetTranslation(SheetTranslationRequest request);

        /// <summary>
        /// Get the list of SheetTranslation.
        /// </summary>
        /// <returns>The SheetTranslationMessagePivot result with the SheetTranslationPivot list.</returns>
        SheetTranslationMessage GetAllSheetTranslations();

        /// <summary>
        /// Find SheetTranslation.
        /// </summary>
        /// <returns>The SheetTranslationMessagePivot result with the SheetTranslationPivot list.</returns>
        SheetTranslationMessage FindSheetTranslations(SheetTranslationRequest request);
    }
}