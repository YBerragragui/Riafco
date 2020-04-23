using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Offices
{
    /// <summary>
    /// The Country class
    /// </summary>
    [Table("office_Countries")]
    public class Country
    {
        /// <summary>
        /// Gets or sets CountryId
        /// </summary>
        [Key]
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets CountryDate
        /// </summary>
        public string CountryImage { get; set; }

        public  int CountryCode { get; set; }
        public  string CountryShortName { get; set; }
    }
}
