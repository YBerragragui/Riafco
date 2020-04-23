using Riafco.Service.Dataflex.Pro.Ressources.Request;
using Riafco.Service.Dataflex.Pro.Ressources.Response;

namespace Riafco.Service.Dataflex.Pro.Ressources.Interface
{
    /// <summary>
    /// The Area interface.
    /// </summary>
    public interface IServiceArea
    {
        /// <summary>
        /// Create AreaPivot.
        /// </summary>
        /// <param name="request"> The AreaRequest Pivot that content AreaPivot to add.</param>
        /// <returns>The AreaResponsePivot result with the AreaPivot added.</returns>
        AreaResponsePivot CreateArea(AreaRequestPivot request);

        /// <summary>
        /// Update AreaPivot.
        /// </summary>
        /// <param name="request"> The AreaRequest Pivot that content AreaPivot to update.</param>
        void UpdateArea(AreaRequestPivot request);

        /// <summary>
        /// Delete AreaPivot.
        /// </summary>
        /// <param name="request"> The AreaRequest Pivot that content AreaPivot to remove.</param>
        void DeleteArea(AreaRequestPivot request);

        /// <summary>
        /// Get Area list
        /// </summary>
        /// <returns>Response result.</returns>
        AreaResponsePivot GetAllAreas();

        /// <summary>
        /// Search Area.
        /// </summary>
        /// <param name="request"> The AreaRequest Pivot that content AreaPivot to remove.</param>
        /// <returns>Response Result.</returns>
        AreaResponsePivot FindAreas(AreaRequestPivot request);
    }
}