using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generator.Dataflex.Pro.Models
{
    /// <summary>
    /// The HomeModel class
    /// </summary>
    public class HomeModel
    {
        /// <summary>
        /// Gerts or sets NomAssembly.
        /// </summary>
        [DisplayName("Name space de la classe source : ")]
        [Required(ErrorMessage = "Obligatoire.")]
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
    }
}