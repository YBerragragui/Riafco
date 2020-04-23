using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Ressource;
using System.ComponentModel.DataAnnotations;

namespace Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto
{
    /// <summary>
    /// The Rule dto class.
    /// </summary>
    public class RuleDto
    {
        /// <summary>
        /// Gets or Sets The  RuleId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(RuleMessageResource), ErrorMessageResourceName = "RequiredId")]
        public int RuleId { get; set; }

        /// <summary>
        /// Gets or Sets The  RulePrefix.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(RuleMessageResource), ErrorMessageResourceName = "RequiredPrefix")]
        public string RulePrefix { get; set; }

        /// <summary>
        /// Gets or Sets The  RuleName.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(RuleMessageResource), ErrorMessageResourceName = "RequiredName")]
        public string RuleName { get; set; }
    }
}