using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.About.Request;
using Riafco.WebApi.Service.Dataflex.pro.About.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Interface
{
    /// <summary>
    /// The Section client interface.
    /// </summary>
    public interface IServiceSectionClient
    {
        /// <summary>
        /// Add Section dto.
        /// </summary>
        /// <param name="request"> The SectionRequest that content Sectiondto to add.</param>
        /// <returns>The SectionMessagePivot result with the SectionPivot added.</returns>
        SectionMessage CreateSection(SectionRequest request);

        /// <summary>
        /// Update Section dto.
        /// </summary>
        /// <param name="request"> The SectionRequest that content Sectiondto to update.</param>
        SectionMessage UpdateSection(SectionRequest request);

        /// <summary>
        /// Delete Section dto.
        /// </summary>
        /// <param name="request"> The SectionRequest that content Sectiondto to remove.</param>
        /// <returns>The SectionMessagePivot result with the SectionPivot removed.</returns>
        SectionMessage DeleteSection(SectionRequest request);

        /// <summary>
        /// Get the list of Section.
        /// </summary>
        /// <returns>The SectionMessagePivot result with the SectionPivot list.</returns>
        SectionMessage GetAllSections();

        /// <summary>
        /// Find Section.
        /// </summary>
        /// <returns>The SectionMessagePivot result with the SectionPivot list.</returns>
        SectionMessage FindSections(SectionRequest request);
    }
}