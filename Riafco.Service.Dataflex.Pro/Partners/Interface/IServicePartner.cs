using Riafco.Service.Dataflex.Pro.Partners.Request;
using Riafco.Service.Dataflex.Pro.Partners.Response;

namespace Riafco.Service.Dataflex.Pro.Partners.Interface
{
    /// <summary>
    /// The Partner interface.
    /// </summary>
    public interface IServicePartner
    {
        /// <summary>
        /// Create PartnerPivot.
        /// </summary>
        /// <param name="request"> The PartnerRequest Pivot that content PartnerPivot to add.</param>
        /// <returns>The PartnerResponsePivot result with the PartnerPivot added.</returns>
        PartnerResponsePivot CreatePartner(PartnerRequestPivot request);

        /// <summary>
        /// Update PartnerPivot.
        /// </summary>
        /// <param name="request"> The PartnerRequest Pivot that content PartnerPivot to update.</param>
        void UpdatePartner(PartnerRequestPivot request);

        /// <summary>
        /// Delete PartnerPivot.
        /// </summary>
        /// <param name="request"> The PartnerRequest Pivot that content PartnerPivot to remove.</param>
        void DeletePartner(PartnerRequestPivot request);

        /// <summary>
        /// Get Partner list
        /// </summary>
        /// <returns>Response result.</returns>
        PartnerResponsePivot GetAllPartners();

        /// <summary>
        /// Search Partner.
        /// </summary>
        /// <param name="request"> The PartnerRequest Pivot that content PartnerPivot to remove.</param>
        /// <returns>Response Result.</returns>
        PartnerResponsePivot FindPartners(PartnerRequestPivot request);

    }
}