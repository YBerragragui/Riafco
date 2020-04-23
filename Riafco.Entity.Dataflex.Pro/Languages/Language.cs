using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Languages
{
    /// <summary>
    /// The Language class.
    /// </summary>
    [Table("lang_Languages")]
    public class Language
    {
        /// <summary>
        /// Gets or sets LangueId.
        /// </summary>
        [Key]
        public int LanguageId { get; set; }

        /// <summary>
        /// Gets or sets LanguePrefix.
        /// </summary>
        public string LanguagePrefix { get; set; }

        /// <summary>
        /// Gets or sets LanguePicture.
        /// </summary>
        public string LanguagePicture { get; set; }
    }
}
