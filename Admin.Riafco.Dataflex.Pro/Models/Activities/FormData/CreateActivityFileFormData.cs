using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.FormData
{
    /// <summary>
    /// The CreateActivityFileFormData class.
    /// </summary>
    public class CreateActivityFileFormData
    {
        /// <summary>
        /// Gets or Sets The  ActivityFileId.
        /// </summary>
        public int ActivityFileId { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  ActivityId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(FileResources), ErrorMessageResourceName = "RequiredActivityId")]
        public int? ActivityId { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<CreateActivityFileTranslationFormData> TranslationsList { get; set; }
        #endregion
    }
}