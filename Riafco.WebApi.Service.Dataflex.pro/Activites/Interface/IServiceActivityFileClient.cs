using Riafco.WebApi.Service.Dataflex.pro.Activites.Request;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Interface
{
    /// <summary>
    /// The ActivityFile client interface.
    /// </summary>
    public interface IServiceActivityFileClient
    {
        /// <summary>
        /// Add ActivityFile dto.
        /// </summary>
        /// <param name="activityFileRequest"> The ActivityFileRequest that content ActivityFiledto to add.</param>
        /// <returns>The ActivityFileMessagePivot result with the ActivityFilePivot added.</returns>
        ActivityFileMessage CreateActivityFile(ActivityFileRequest activityFileRequest);

        /// <summary>
        /// Update ActivityFile dto.
        /// </summary>
        /// <param name="activityFileRequest"> The ActivityFileRequest that content ActivityFiledto to update.</param>
        ActivityFileMessage UpdateActivityFile(ActivityFileRequest activityFileRequest);

        /// <summary>
        /// Delete ActivityFile dto.
        /// </summary>
        /// <param name="activityFileRequest"> The ActivityFileRequest that content ActivityFiledto to remove.</param>
        /// <returns>The ActivityFileMessagePivot result with the ActivityFilePivot removed.</returns>
        ActivityFileMessage DeleteActivityFile(ActivityFileRequest activityFileRequest);

        /// <summary>
        /// Get the list of ActivityFile.
        /// </summary>
        /// <returns>The ActivityFileMessagePivot result with the ActivityFilePivot list.</returns>
        ActivityFileMessage GetAllActivityFiles();

        /// <summary>
        /// Find ActivityFile.
        /// </summary>
        /// <returns>The ActivityFileMessagePivot result with the ActivityFilePivot list.</returns>
        ActivityFileMessage FindActivityFiles(ActivityFileRequest activityFileRequest);
    }
}