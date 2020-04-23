using Riafco.Service.Dataflex.Pro.Activites.Request;
using Riafco.Service.Dataflex.Pro.Activites.Response;

namespace Riafco.Service.Dataflex.Pro.Activites.Interface
{
    /// <summary>
    /// The Activity interface.
    /// </summary>
    public interface IServiceActivity
    {
        /// <summary>
        /// Create ActivityPivot.
        /// </summary>
        /// <param name="request"> The ActivityRequest Pivot that content ActivityPivot to add.</param>
        /// <returns>The ActivityResponsePivot result with the ActivityPivot added.</returns>
        ActivityResponsePivot CreateActivity(ActivityRequestPivot request);

        /// <summary>
        /// Update ActivityPivot.
        /// </summary>
        /// <param name="request"> The ActivityRequest Pivot that content ActivityPivot to update.</param>
        void UpdateActivity(ActivityRequestPivot request);

        /// <summary>
        /// Delete ActivityPivot.
        /// </summary>
        /// <param name="request"> The ActivityRequest Pivot that content ActivityPivot to remove.</param>
        void DeleteActivity(ActivityRequestPivot request);

        /// <summary>
        /// Get Activity list
        /// </summary>
        /// <returns>Response result.</returns>
        ActivityResponsePivot GetAllActivities();

        /// <summary>
        /// Search Activity.
        /// </summary>
        /// <param name="request"> The ActivityRequest Pivot that content ActivityPivot to remove.</param>
        /// <returns>Response Result.</returns>
        ActivityResponsePivot FindActivities(ActivityRequestPivot request);
    }
}