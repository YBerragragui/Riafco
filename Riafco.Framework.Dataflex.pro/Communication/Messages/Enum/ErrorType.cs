using System.Runtime.Serialization;

namespace Riafco.Framework.Dataflex.pro.Communication.Messages.Enum
{
    /// <summary>
    /// The error type enum
    /// </summary>
    [DataContract]
    public enum ErrorType
    {
        /// <summary>
        /// None
        /// </summary>
        [EnumMember]
        None,

        /// <summary>
        /// Functional error
        /// </summary>
        [EnumMember]
        FunctionalError,

        /// <summary>
        /// Technical error
        /// </summary>
        [EnumMember]
        TechnicalError,

        /// <summary>
        /// Service disabled
        /// </summary>
        [EnumMember]
        ServiceDisabled,

        /// <summary>
        /// Validation error
        /// </summary>
        [EnumMember]
        ValidationError
    }
}
