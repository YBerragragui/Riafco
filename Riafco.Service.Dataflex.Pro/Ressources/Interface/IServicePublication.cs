using Riafco.Service.Dataflex.Pro.Ressources.Request;
using Riafco.Service.Dataflex.Pro.Ressources.Response;

namespace Riafco.Service.Dataflex.Pro.Ressources.Interface
{
    /// <summary>
    /// The Publication interface.
    /// </summary>
    public interface IServicePublication
    {
        /// <summary>
        /// Create PublicationPivot.
        /// </summary>
        /// <param name="request"> The PublicationRequest Pivot that content PublicationPivot to add.</param>
        /// <returns>The PublicationResponsePivot result with the PublicationPivot added.</returns>
        PublicationResponsePivot CreatePublication(PublicationRequestPivot request);

        /// <summary>
        /// Update PublicationPivot.
        /// </summary>
        /// <param name="request"> The PublicationRequest Pivot that content PublicationPivot to update.</param>
        void UpdatePublication(PublicationRequestPivot request);

        /// <summary>
        /// Delete PublicationPivot.
        /// </summary>
        /// <param name="request"> The PublicationRequest Pivot that content PublicationPivot to remove.</param>
        void DeletePublication(PublicationRequestPivot request);

        /// <summary>
        /// Get Publication list
        /// </summary>
        /// <returns>Response result.</returns>
        PublicationResponsePivot GetAllPublications();

        /// <summary>
        /// Search Publication.
        /// </summary>
        /// <param name="request"> The PublicationRequest Pivot that content PublicationPivot to remove.</param>
        /// <returns>Response Result.</returns>
        PublicationResponsePivot FindPublications(PublicationRequestPivot request);
    }
}