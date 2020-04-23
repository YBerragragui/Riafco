using System.Configuration;

namespace Riafco.Framework.Dataflex.pro.Configuration.Section.ServiceSettingSection
{
    /// <summary>
    /// The Service class
    /// </summary>
    public class Service : ConfigurationElement
    {
        #region constants
        /// <summary>
        /// The service Assembly 
        /// </summary>
        private const string ServiceAssemblyAttributeKey = "serviceAssembly";

        /// <summary>
        /// The entity Assembly 
        /// </summary>
        private const string EntityAssemblyAttributeKey = "entityAssembly";

        /// <summary>
        /// Dependencies Attribute Key constant
        /// </summary>
        private const string DependenciesAttributeKey = "dependencies";

        /// <summary>
        /// Adapters Attribute Key constant
        /// </summary>
        private const string AdaptersAttributeKey = "adapters";

        #endregion

        #region public properties
        /// <summary>
        /// Gets or sets the service assembly.
        /// </summary>
        [ConfigurationProperty(ServiceAssemblyAttributeKey, IsKey = true, IsRequired = true)]
        public string ServiceAssembly
        {
            get { return (string)base[ServiceAssemblyAttributeKey]; }
            set { base[ServiceAssemblyAttributeKey] = value; }
        }

        /// <summary>
        /// Gets or sets the entity assembly.
        /// </summary>
        [ConfigurationProperty(EntityAssemblyAttributeKey, IsRequired = true)]
        public string EntityAssembly
        {
            get { return (string)base[EntityAssemblyAttributeKey]; }
            set { base[EntityAssemblyAttributeKey] = value; }
        }

        /// <summary>
        /// Gets or sets the dependencies.
        /// </summary>
        /// <value>
        /// The dependencies.
        /// </value>
        [ConfigurationProperty(DependenciesAttributeKey)]
        [ConfigurationCollection(typeof(Dependency), AddItemName = "dependency")]
        public DependencyCollection DependencyCollection
        {
            get { return (DependencyCollection)base[DependenciesAttributeKey]; }
            set { base[DependenciesAttributeKey] = value; }
        }

        /// <summary>
        /// Gets or sets the dependencies.
        /// </summary>
        /// <value>
        /// The dependencies.
        /// </value>
        [ConfigurationProperty(AdaptersAttributeKey)]
        [ConfigurationCollection(typeof(Adapter), AddItemName = "adapter")]
        public AdapterCollection AdapterCollection
        {
            get { return (AdapterCollection)base[AdaptersAttributeKey]; }
            set { base[AdaptersAttributeKey] = value; }
        }

        #endregion
    }
}
