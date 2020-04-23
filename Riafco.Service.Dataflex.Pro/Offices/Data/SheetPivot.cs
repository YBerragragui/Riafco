namespace Riafco.Service.Dataflex.Pro.Offices.Data
{
    /// <summary>
    /// The Sheet pivot class.
    /// </summary>
    public class SheetPivot
    {
        /// <summary>
        /// Gets or Sets The  SheetId.
        /// </summary>
        public int SheetId { get; set; }

        #region navigation properties
        /// <summary>
        /// Gets or Sets The  CountryId.
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// Gets or Sets The  Country.
        /// </summary>
        public CountryPivot Country { get; set; }
        #endregion
    }
}