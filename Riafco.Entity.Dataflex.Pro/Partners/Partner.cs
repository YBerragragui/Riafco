using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Partners
{
    /// <summary>
    /// The Partner Class
    /// </summary>
    [Table("partner_Partners")]
    public class Partner
    {
        /// <summary>
        /// The PartnerId
        /// </summary>
        [Key]
        public int PartnerId { get; set; }

        /// <summary>
        /// The PartnerImage
        /// </summary>
        public string PartnerImage { get; set; }

        /// <summary>
        /// The PartnerName
        /// </summary>
        public string PartnerName { get; set; }

        /// <summary>
        /// The PartnerLink
        /// </summary>
        public string PartnerLink { get; set; }

        /// <summary>
        /// The PartnerPosition
        /// </summary>
        public int PartnerPosition { get; set; }
    }
}
