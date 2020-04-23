using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Riafco.Entity.Dataflex.Pro.Languages;

namespace Riafco.Entity.Dataflex.Pro.Contact
{
    [Table("contact_ContactMessages")]
    public class ContactMessage
    {
        /// <summary>
        /// Get & Set ContactMessageId
        /// </summary>
        [Key]
        public int ContactMessageId { get; set; }

        /// <summary>
        /// Get & Set ContactMessageFirstName
        /// </summary>
        public string ContactMessageFirstName { get; set; }

        /// <summary>
        /// Get & Set ContactMessageLastName
        /// </summary>
        public string ContactMessageLastName { get; set; }

        /// <summary>
        /// Get & Set ContactMessageMail
        /// </summary>
        public string ContactMessageMail { get; set; }

        /// <summary>
        /// Get & Set ContactMessageSubject
        /// </summary>
        public string ContactMessageSubject { get; set; }

        /// <summary>
        /// Get & Set ContactMessageText
        /// </summary>
        public string ContactMessageText { get; set; }

        /// <summary>
        /// Gets or sets LangueId
        /// </summary>
        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or sets Language
        /// </summary>
        public virtual Language Language { get; set; }
    }
}
