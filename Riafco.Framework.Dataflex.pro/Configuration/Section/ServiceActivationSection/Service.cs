using System.Configuration;

namespace Riafco.Framework.Dataflex.pro.Configuration.Section.ServiceActivationSection
{
    /// <summary>
    /// The Service class
    /// </summary>
    public class Service : ConfigurationElement
    {
        #region constants
        /// <summary>
        /// The name attribute key
        /// </summary>
        private const string NameAttributeKey = "name";

        /// <summary>
        /// The description attribute key
        /// </summary>
        private const string DescriptionAttributeKey = "description";

        /// <summary>
        /// The provider attribute key
        /// </summary>
        private const string ProviderAttributeKey = "provider";

        /// <summary>
        /// The force attribute key
        /// </summary>
        private const string ForceAttributeKey = "force";

        #endregion

        #region public properties
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [ConfigurationProperty(NameAttributeKey, IsKey = true, IsRequired = false)]
        public string Name
        {
            get { return (string)base[NameAttributeKey]; }
            set { base[NameAttributeKey] = value; }
        }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        [ConfigurationProperty(DescriptionAttributeKey, IsRequired = false)]
        public string Description
        {
            get { return (string)base[DescriptionAttributeKey]; }
            set { base[DescriptionAttributeKey] = value; }
        }

        /// <summary>
        /// Gets or sets the force
        /// </summary>
        [ConfigurationProperty(ForceAttributeKey, IsRequired = false, DefaultValue = null)]
        public bool? Force
        {
            get { return (bool?)base[ForceAttributeKey]; }
            set { base[ForceAttributeKey] = value; }
        }

        /// <summary>
        /// Gets or sets the provider
        /// </summary>
        [ConfigurationProperty(ProviderAttributeKey, IsRequired = false)]
        public Provider Provider
        {
            get { return (Provider)base[ProviderAttributeKey]; }
            set { base[ProviderAttributeKey] = value; }
        }

        #endregion
    }
}
