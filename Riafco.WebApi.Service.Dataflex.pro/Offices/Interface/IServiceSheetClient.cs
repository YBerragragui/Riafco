using Riafco.WebApi.Service.Dataflex.pro.Offices.Request;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Offices.Interface
{
    /// <summary>
    /// The Sheet client interface.
    /// </summary>
    public interface IServiceSheetClient
    {
        /// <summary>
        /// Add Sheet dto.
        /// </summary>
        /// <param name="request"> The SheetRequest that content Sheetdto to add.</param>
        /// <returns>The SheetMessagePivot result with the SheetPivot added.</returns>
        SheetMessage CreateSheet(SheetRequest request);

        /// <summary>
        /// Update Sheet dto.
        /// </summary>
        /// <param name="request"> The SheetRequest that content Sheetdto to update.</param>
        SheetMessage UpdateSheet(SheetRequest request);

        /// <summary>
        /// Delete Sheet dto.
        /// </summary>
        /// <param name="request"> The SheetRequest that content Sheetdto to remove.</param>
        /// <returns>The SheetMessagePivot result with the SheetPivot removed.</returns>
        SheetMessage DeleteSheet(SheetRequest request);

        /// <summary>
        /// Get the list of Sheet.
        /// </summary>
        /// <returns>The SheetMessagePivot result with the SheetPivot list.</returns>
        SheetMessage GetAllSheets();

        /// <summary>
        /// Find Sheet.
        /// </summary>
        /// <returns>The SheetMessagePivot result with the SheetPivot list.</returns>
        SheetMessage FindSheets(SheetRequest request);
    }
}