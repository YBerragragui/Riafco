using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Offices.Request;
using Riafco.Service.Dataflex.Pro.Offices.Response;

namespace Riafco.Service.Dataflex.Pro.Offices.Interface
{
    /// <summary>
    /// The Sheet interface.
    /// </summary>
    public interface IServiceSheet
    {
        /// <summary>
        /// Create SheetPivot.
        /// </summary>
        /// <param name="request"> The SheetRequest Pivot that content SheetPivot to add.</param>
        /// <returns>The SheetResponsePivot result with the SheetPivot added.</returns>
        SheetResponsePivot CreateSheet(SheetRequestPivot request);

        /// <summary>
        /// Update SheetPivot.
        /// </summary>
        /// <param name="request"> The SheetRequest Pivot that content SheetPivot to update.</param>
        void UpdateSheet(SheetRequestPivot request);

        /// <summary>
        /// Delete SheetPivot.
        /// </summary>
        /// <param name="request"> The SheetRequest Pivot that content SheetPivot to remove.</param>
        void DeleteSheet(SheetRequestPivot request);

        /// <summary>
        /// Get Sheet list
        /// </summary>
        /// <returns>Response result.</returns>
        SheetResponsePivot GetAllSheets();

        /// <summary>
        /// Search Sheet.
        /// </summary>
        /// <param name="request"> The SheetRequest Pivot that content SheetPivot to remove.</param>
        /// <returns>Response Result.</returns>
        SheetResponsePivot FindSheets(SheetRequestPivot request);

    }
}