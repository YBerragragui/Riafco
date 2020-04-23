using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.About.Request;
using Riafco.Service.Dataflex.Pro.About.Response;

namespace Riafco.Service.Dataflex.Pro.About.Interface
{
    /// <summary>
    /// The Section interface.
    /// </summary>
    public interface IServiceSection
    {
        /// <summary>
        /// Create SectionPivot.
        /// </summary>
        /// <param name="request"> The SectionRequest Pivot that content SectionPivot to add.</param>
        /// <returns>The SectionResponsePivot result with the SectionPivot added.</returns>
        SectionResponsePivot CreateSection(SectionRequestPivot request);

        /// <summary>
        /// Update SectionPivot.
        /// </summary>
        /// <param name="request"> The SectionRequest Pivot that content SectionPivot to update.</param>
        void UpdateSection(SectionRequestPivot request);

        /// <summary>
        /// Delete SectionPivot.
        /// </summary>
        /// <param name="request"> The SectionRequest Pivot that content SectionPivot to remove.</param>
        void DeleteSection(SectionRequestPivot request);

        /// <summary>
        /// Get Section list
        /// </summary>
        /// <returns>Response result.</returns>
        SectionResponsePivot GetAllSections();

        /// <summary>
        /// Search Section.
        /// </summary>
        /// <param name="request"> The SectionRequest Pivot that content SectionPivot to remove.</param>
        /// <returns>Response Result.</returns>
        SectionResponsePivot FindSections(SectionRequestPivot request);

    }
}