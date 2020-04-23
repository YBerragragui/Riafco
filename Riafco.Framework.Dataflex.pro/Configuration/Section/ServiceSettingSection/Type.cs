using System.Configuration;

namespace Riafco.Framework.Dataflex.pro.Configuration.Section.ServiceSettingSection
{
    /// <summary>
    /// The Type section class
    /// </summary>
    public class Type : ConfigurationElement
    {
        #region constants
        /// <summary>
        /// The class library 
        /// </summary>
        private const string ClassLibraryAttributeKey = "classLibrary";

        /// <summary>
        /// The interface 
        /// </summary>
        private const string InterfaceAttributeKey = "interface";

        #endregion

        #region public properties
        /// <summary>
        /// Gets or sets the class library.
        /// </summary>
        [ConfigurationProperty(ClassLibraryAttributeKey, IsRequired = true)]
        public string ClassLibrary
        {
            get { return (string)base[ClassLibraryAttributeKey]; }
            set { base[ClassLibraryAttributeKey] = value; }
        }

        /// <summary>
        /// Gets or sets the interface.
        /// </summary>
        [ConfigurationProperty(InterfaceAttributeKey, IsRequired = true)]
        public string Interface
        {
            get { return (string)base[InterfaceAttributeKey]; }
            set { base[InterfaceAttributeKey] = value; }
        }

        #endregion
    }
}
