using Riafco.Service.Dataflex.Pro.About.Request;
using Riafco.Service.Dataflex.Pro.About.Response;

namespace Riafco.Service.Dataflex.Pro.About.Interface
{
    /// <summary>
    /// The SectionFile interface.
    /// </summary>
    public interface IServiceSectionFile
    {
        /// <summary>
        /// Create SectionFilePivot.
        /// </summary>
        /// <param name="request"> The SectionFileRequest Pivot that content SectionFilePivot to add.</param>
        /// <returns>The SectionFileResponsePivot result with the SectionFilePivot added.</returns>
        SectionFileResponsePivot CreateSectionFile(SectionFileRequestPivot request);

        /// <summary>
        /// Update SectionFilePivot.
        /// </summary>
        /// <param name="request"> The SectionFileRequest Pivot that content SectionFilePivot to update.</param>
        void UpdateSectionFile(SectionFileRequestPivot request);

        /// <summary>
        /// Delete SectionFilePivot.
        /// </summary>
        /// <param name="request"> The SectionFileRequest Pivot that content SectionFilePivot to remove.</param>
        void DeleteSectionFile(SectionFileRequestPivot request);

        /// <summary>
        /// Get SectionFile list
        /// </summary>
        /// <returns>Response result.</returns>
        SectionFileResponsePivot GetAllSectionFiles();

        /// <summary>
        /// Search SectionFile.
        /// </summary>
        /// <param name="request"> The SectionFileRequest Pivot that content SectionFilePivot to remove.</param>
        /// <returns>Response Result.</returns>
        SectionFileResponsePivot FindSectionFiles(SectionFileRequestPivot request);
    }
}