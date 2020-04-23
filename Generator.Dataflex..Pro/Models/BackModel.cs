
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generator.Dataflex.Pro.Models
{
    /// <summary>
    /// The BackModel class.
    /// </summary>
    public class BackModel
    {
        /// <summary>
        /// Gerts or sets NomAssembly.
        /// </summary>
        [Required(ErrorMessage = "Obligatoire.")]
        [DisplayName("Name space de la classe source : ")]
        public string NomAssembly { get; set; }

        /// <summary>
        /// Gets or sets FolderName.
        /// </summary>
        [DisplayName("Nom dossier : ")]
        [Required(ErrorMessage = "Obligatoire.")]
        public string FolderName { get; set; }

        /// <summary>
        /// Gets or sets NomClass.
        /// </summary>
        [DisplayName("Nom classe source : ")]
        [Required(ErrorMessage = "Obligatoire.")]
        public string NomClass { get; set; }

        /// <summary>
        /// Gets or sets ControllerName.
        /// </summary>
        [DisplayName("Nom du controlleur : ")]
        [Required(ErrorMessage = "Obligatoire.")]
        public string ControllerName { get; set; }

        /// <summary>
        /// Gets or sets PerfixName.
        /// </summary>
        [DisplayName("Nom du controlleur : ")]
        [Required(ErrorMessage = "Obligatoire.")]
        public string PerfixName { get; set; }
    }
}