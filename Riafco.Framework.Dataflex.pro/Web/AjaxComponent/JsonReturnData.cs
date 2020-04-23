using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Riafco.Framework.Dataflex.pro.Web.AjaxComponent
{
    /// <summary>
    /// The Json Return Data class
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "JsonReturnMessage")]
    public class JsonReturnData
    {
        #region Properties        

        /// <summary>
        /// Gets or sets the script.
        /// </summary>
        /// <value>
        /// The script.
        /// </value>
        [DataMember(Name = "Script")]
        public string Script { get; set; }

        /// <summary>
        /// We need to return html
        /// </summary>
        [DataMember(Name = "Html")]
        public string Html { get; set; }

        /// <summary>
        /// Is Operation Success
        /// </summary>
        [DataMember(Name = "OperationSuccess")]
        public bool OperationSuccess { get; set; }

        /// <summary>
        /// We need to return Success message
        /// </summary>
        [DataMember(Name = "SuccessMessage")]
        public string SuccessMessage { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [DataMember(Name = "ErrorMessage")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The Authorization Message
        /// </summary>
        [DataMember(Name = "AuthorizationMessage")]
        public string AuthorizationMessage { get; set; }

        #endregion Properties
    }
}
