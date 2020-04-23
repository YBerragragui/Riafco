using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Ressource;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto
{
    /// <summary>
    /// The AreaTranslation dto class.
    /// </summary>
    public class AreaTranslationDto
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(AreaMessageResource), ErrorMessageResourceName = "RequiredTranslationId")]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  AreaName.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(AreaMessageResource), ErrorMessageResourceName = "RequiredAreaName")]
        public string AreaName { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  AreaId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(AreaMessageResource), ErrorMessageResourceName = "RequiredId")]
        public int? AreaId { get; set; }

        /// <summary>
        /// Gets or Sets The  Area.
        /// </summary>
        public virtual AreaDto Area { get; set; }

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(AreaMessageResource), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public virtual LanguageDto Language { get; set; }

        #endregion
    }
}