using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Offices
{
    /// <summary>
    /// The CountrySheet class.
    /// </summary>
    [Table("office_Sheets")]
    public class Sheet
    {
        /// <summary>
        /// Gets or sets SheetId.
        /// </summary>
        [Key]
        public int SheetId { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or sets CountreId
        /// </summary>
        [ForeignKey("Country")]
        public int? CountryId { get; set; }

        /// <summary>
        /// Gets or sets country
        /// </summary>
        public virtual Country Country { get; set; }

        #endregion
    }
}
