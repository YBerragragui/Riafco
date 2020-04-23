using Riafco.Service.Dataflex.Pro.Activites.Request;
using Riafco.Service.Dataflex.Pro.Activites.Response;

namespace Riafco.Service.Dataflex.Pro.Activites.Interface
{
    /// <summary>
    /// The ActivityFile interface.
    /// </summary>
    public interface IServiceActivityFile
    {
        /// <summary>
        /// Create ActivityFilePivot.
        /// </summary>
        /// <param name="request"> The ActivityFileRequest Pivot that content ActivityFilePivot to add.</param>
        /// <returns>The ActivityFileResponsePivot result with the ActivityFilePivot added.</returns>
        ActivityFileResponsePivot CreateActivityFile(ActivityFileRequestPivot request);

        /// <summary>
        /// Update ActivityFilePivot.
        /// </summary>
        /// <param name="request"> The ActivityFileRequest Pivot that content ActivityFilePivot to update.</param>
        void UpdateActivityFile(ActivityFileRequestPivot request);

        /// <summary>
        /// Delete ActivityFilePivot.
        /// </summary>
        /// <param name="request"> The ActivityFileRequest Pivot that content ActivityFilePivot to remove.</param>
        void DeleteActivityFile(ActivityFileRequestPivot request);

        /// <summary>
        /// Get ActivityFile list
        /// </summary>
        /// <returns>Response result.</returns>
        ActivityFileResponsePivot GetAllActivityFiles();

        /// <summary>
        /// Search ActivityFile.
        /// </summary>
        /// <param name="request"> The ActivityFileRequest Pivot that content ActivityFilePivot to remove.</param>
        /// <returns>Response Result.</returns>
        ActivityFileResponsePivot FindActivityFiles(ActivityFileRequestPivot request);
    }
}