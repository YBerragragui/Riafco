using System.Configuration;

namespace Riafco.Framework.Dataflex.pro.Configuration.Section.ServiceSettingSection
{
    /// <summary>
    /// The Dependency section class
    /// </summary>
    public class Dependency : ConfigurationElement
    {
        #region constants
        /// <summary>
        /// The class library 
        /// </summary>
        private const string ClassLibraryAttributeKey = "classLibrary";

        /// <summary>
        /// The class configuration 
        /// </summary>
        private const string ClassConfigurationAttributeKey = "classConfiguration";

        #endregion

        #region public properties
        /// <summary>
        /// Gets or sets the class library.
        /// </summary>
        [ConfigurationProperty(ClassLibraryAttributeKey, IsRequired = false)]
        public string ClassLibrary
        {
            get { return (string)base[ClassLibraryAttributeKey]; }
            set { base[ClassLibraryAttributeKey] = value; }
        }

        /// <summary>
        /// Gets or sets the class configuration.
        /// </summary>
        [ConfigurationProperty(ClassConfigurationAttributeKey, IsRequired = false)]
        public string ClassConfiguration
        {
            get { return (string)base[ClassConfigurationAttributeKey]; }
            set { base[ClassConfigurationAttributeKey] = value; }
        }

        #endregion
    }
}
