
using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.About.Ressource;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Dto
{
    /// <summary>
    /// The SectionFile dto class.
    /// </summary>
    public class SectionFileDto
    {
        /// <summary>
        /// Gets or Sets The  SectionFileId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(FileMessageResource), ErrorMessageResourceName = "RequiredFileSectionId")]
        public int SectionFileId { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  SectionId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ParagraphMessageResource), ErrorMessageResourceName = "RequiredSectionId")]
        public int? SectionId { get; set; }

        /// <summary>
        /// Gets or Sets The  Section.
        /// </summary>
        public SectionDto Section { get; set; }

        #endregion
    }
}