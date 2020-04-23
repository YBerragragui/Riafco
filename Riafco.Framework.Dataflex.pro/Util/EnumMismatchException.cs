using System;
using System.Runtime.Serialization;

namespace Riafco.Framework.Dataflex.pro.Util
{
    /// <summary>
    /// An exception throws when a mismatch value occurred.
    /// </summary>
    /// <typeparam name="T">Type of the enum.</typeparam>
    [Serializable]
    public class EnumMismatchException<T>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumMismatchException&lt;T&gt;"/> class.
        /// </summary>
        public EnumMismatchException()

        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumMismatchException&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public EnumMismatchException(string message)

        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumMismatchException&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public EnumMismatchException(string message, Exception inner)

        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumMismatchException&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        ///   
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        protected EnumMismatchException(SerializationInfo info, StreamingContext context)

        {
        }
    }
}