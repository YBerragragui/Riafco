using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.Framework.Dataflex.pro.Communication.Messages
{
    /// <summary>
    /// Base message service class 
    /// </summary>
    [DataContract(), Serializable()]
    public class ServiceMessage
    {
        /// <summary>
        /// Gets or sets a value indicating whether the operation has succeeded.
        /// </summary>
        [DataMember]
        public bool OperationSuccess { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the error message list
        /// </summary>
        [DataMember]
        public List<string> Errors { get; set; }

        /// <summary>
        /// Gets or sets the error type.
        /// </summary>
        [DataMember]
        public ErrorType ErrorType { get; set; }
    }
}
