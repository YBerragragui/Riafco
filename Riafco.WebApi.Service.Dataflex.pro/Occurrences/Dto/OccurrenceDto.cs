using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Ressource;
using System;
using System.ComponentModel.DataAnnotations;

namespace Riafco.WebApi.Service.Dataflex.pro.Occurrences.Dto
{
    /// <summary>
    /// The Occurrence dto class.
    /// </summary>
    public class OccurrenceDto
    {
        /// <summary>
        /// Gets or Sets The  OccurrenceId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(OccurrenceMessageResource), ErrorMessageResourceName = "RequiredId")]
        public int OccurrenceId { get; set; }

        /// <summary>
        /// Gets or Sets The OccurrenceStartDate.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(OccurrenceMessageResource), ErrorMessageResourceName = "RequiredDate")]
        public DateTime OccurrenceStartDate { get; set; }

        /// <summary>
        /// Gets or Sets The OccurrenceEndDate.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(OccurrenceMessageResource), ErrorMessageResourceName = "RequiredDate")]
        public DateTime OccurrenceEndDate { get; set; }

        /// <summary>
        /// Gets or Sets The  OccurrenceLink.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(OccurrenceMessageResource), ErrorMessageResourceName = "RequiredLink")]
        public string OccurrenceLink { get; set; }

    }
}