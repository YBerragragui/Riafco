using Riafco.WebApi.Service.Dataflex.pro.About.Request;
using Riafco.WebApi.Service.Dataflex.pro.About.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Interface
{
    /// <summary>
    /// The SectionFile client interface.
    /// </summary>
    public interface IServiceSectionFileClient
    {
        /// <summary>
        /// Add SectionFile dto.
        /// </summary>
        /// <param name="sectionFileRequest"> The SectionFileRequest that content SectionFiledto to add.</param>
        /// <returns>The SectionFileMessagePivot result with the SectionFilePivot added.</returns>
        SectionFileMessage CreateSectionFile(SectionFileRequest sectionFileRequest);

        /// <summary>
        /// Update SectionFile dto.
        /// </summary>
        /// <param name="sectionFileRequest"> The SectionFileRequest that content SectionFiledto to update.</param>
        SectionFileMessage UpdateSectionFile(SectionFileRequest sectionFileRequest);

        /// <summary>
        /// Delete SectionFile dto.
        /// </summary>
        /// <param name="sectionFileRequest"> The SectionFileRequest that content SectionFiledto to remove.</param>
        /// <returns>The SectionFileMessagePivot result with the SectionFilePivot removed.</returns>
        SectionFileMessage DeleteSectionFile(SectionFileRequest sectionFileRequest);

        /// <summary>
        /// Get the list of SectionFile.
        /// </summary>
        /// <returns>The SectionFileMessagePivot result with the SectionFilePivot list.</returns>
        SectionFileMessage GetAllSectionFiles();

        /// <summary>
        /// Find SectionFile.
        /// </summary>
        /// <returns>The SectionFileMessagePivot result with the SectionFilePivot list.</returns>
        SectionFileMessage FindSectionFiles(SectionFileRequest sectionFileRequest);
    }
}