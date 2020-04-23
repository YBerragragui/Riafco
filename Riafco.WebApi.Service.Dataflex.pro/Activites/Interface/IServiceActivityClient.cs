using Riafco.WebApi.Service.Dataflex.pro.Activites.Message;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Request;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Interface
{
    /// <summary>
    /// The Activity client interface.
    /// </summary>
    public interface IServiceActivityClient
    {
        /// <summary>
        /// Create Activity dto.
        /// </summary>
        /// <param name="request"> The ActivityRequest that content Activitydto to add.</param>
        /// <returns>The ActivityMessagePivot result with the ActivityPivot to add.</returns>
        ActivityMessage CreateActivity(ActivityRequest request);

        /// <summary>
        /// Update Activity dto.
        /// </summary>
        /// <param name="request"> The ActivityRequest that content Activitydto to update.</param>
        ActivityMessage UpdateActivity(ActivityRequest request);

        /// <summary>
        /// Delete Activity dto.
        /// </summary>
        /// <param name="request"> The ActivityRequest that content Activitydto to remove.</param>
        /// <returns>The ActivityMessagePivot result with the ActivityPivot removed.</returns>
        ActivityMessage DeleteActivity(ActivityRequest request);

        /// <summary>
        /// Get the list of Activity.
        /// </summary>
        /// <returns>The ActivityMessagePivot result with the ActivityPivot list.</returns>
        ActivityMessage GetAllActivities();
        
        /// <summary>
        /// Find Activity.
        /// </summary>
        /// <returns>The ActivityMessagePivot result with the ActivityPivot list.</returns>
        ActivityMessage FindActivities(ActivityRequest request);
    }
}