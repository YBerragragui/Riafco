using Riafco.Service.Dataflex.Pro.Languages.Data;

namespace Riafco.Service.Dataflex.Pro.Contact.Data
{
    /// <summary>
    /// The ContactMessage pivot class.
    /// </summary>
    public class ContactMessagePivot
    {
        /// <summary>
        /// Gets or Sets The  ContactMessageId.
        /// </summary>
        public int ContactMessageId { get; set; }

        /// <summary>
        /// Gets or Sets The  ContactMessageFirstName.
        /// </summary>
        public string ContactMessageFirstName { get; set; }

        /// <summary>
        /// Gets or Sets The  ContactMessageLastName.
        /// </summary>
        public string ContactMessageLastName { get; set; }

        /// <summary>
        /// Gets or Sets The  ContactMessageMail.
        /// </summary>
        public string ContactMessageMail { get; set; }

        /// <summary>
        /// Gets or Sets The  ContactMessageSubject.
        /// </summary>
        public string ContactMessageSubject { get; set; }

        /// <summary>
        /// Gets or Sets The  ContactMessageText.
        /// </summary>
        public string ContactMessageText { get; set; }

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguagePivot Language { get; set; }

    }
}