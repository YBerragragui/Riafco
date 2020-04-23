using Riafco.Framework.Dataflex.pro.Web.ResultData.Enum;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.Framework.Dataflex.pro.Web.ResultData
{
    /// <summary>
    /// The result data class.
    /// </summary>
    [DataContract(), Serializable()]
    public class BaseResultData
    {
        /// <summary>
        /// Gets or sets OperationSuccess
        /// </summary>
        [DataMember]
        public bool OperationSuccess { get; set; }

        /// <summary>
        /// Gets or sets ErrorMessage
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets Errors
        /// </summary>
        [DataMember]
        public List<string> Errors { get; set; }

        /// <summary>
        /// Gets or sets ErrorType
        /// </summary>
        [DataMember]
        public ErrorType ErrorType { get; set; }
    }
}
