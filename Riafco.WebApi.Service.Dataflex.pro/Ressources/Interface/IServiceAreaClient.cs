using Riafco.WebApi.Service.Dataflex.pro.Ressources.Request;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Interface
{
    /// <summary>
    /// The Area client interface.
    /// </summary>
    public interface IServiceAreaClient
    {
        /// <summary>
        /// Create Area dto.
        /// </summary>
        /// <param name="areaRequest"> The AreaRequest that content Areadto to add.</param>
        /// <returns>The AreaMessagePivot result with the AreaPivot added.</returns>
        AreaMessage CreateArea(AreaRequest areaRequest);

        /// <summary>
        /// Update Area dto.
        /// </summary>
        /// <param name="areaRequest"> The AreaRequest that content Areadto to update.</param>
        AreaMessage UpdateArea(AreaRequest areaRequest);

        /// <summary>
        /// Delete Area dto.
        /// </summary>
        /// <param name="areaRequest"> The AreaRequest that content Areadto to remove.</param>
        /// <returns>The AreaMessagePivot result with the AreaPivot removed.</returns>
        AreaMessage DeleteArea(AreaRequest areaRequest);

        /// <summary>
        /// Get the list of Area.
        /// </summary>
        /// <returns>The AreaMessagePivot result with the AreaPivot list.</returns>
        AreaMessage GetAllAreas();

        /// <summary>
        /// Find Area.
        /// </summary>
        /// <returns>The AreaMessagePivot result with the AreaPivot list.</returns>
        AreaMessage FindAreas(AreaRequest areaRequest);
    }
}