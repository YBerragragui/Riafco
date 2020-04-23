using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Partners.Request;
using Riafco.WebApi.Service.Dataflex.pro.Partners.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Partners.Interface
{
    /// <summary>
    /// The Partner client interface.
    /// </summary>
    public interface IServicePartnerClient
    {
        /// <summary>
        /// Add Partner dto.
        /// </summary>
        /// <param name="request"> The PartnerRequest that content Partnerdto to add.</param>
        /// <returns>The PartnerMessagePivot result with the PartnerPivot added.</returns>
        PartnerMessage CreatePartner(PartnerRequest request);

        /// <summary>
        /// Update Partner dto.
        /// </summary>
        /// <param name="request"> The PartnerRequest that content Partnerdto to update.</param>
        PartnerMessage UpdatePartner(PartnerRequest request);

        /// <summary>
        /// Delete Partner dto.
        /// </summary>
        /// <param name="request"> The PartnerRequest that content Partnerdto to remove.</param>
        /// <returns>The PartnerMessagePivot result with the PartnerPivot removed.</returns>
        PartnerMessage DeletePartner(PartnerRequest request);

        /// <summary>
        /// Get the list of Partner.
        /// </summary>
        /// <returns>The PartnerMessagePivot result with the PartnerPivot list.</returns>
        PartnerMessage GetAllPartners();

        /// <summary>
        /// Find Partner.
        /// </summary>
        /// <returns>The PartnerMessagePivot result with the PartnerPivot list.</returns>
        PartnerMessage FindPartners(PartnerRequest request);
    }
}