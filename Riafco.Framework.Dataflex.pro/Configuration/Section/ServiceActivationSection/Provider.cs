using System.Configuration;

namespace Riafco.Framework.Dataflex.pro.Configuration.Section.ServiceActivationSection
{
    /// <summary>
    /// The Service class
    /// </summary>
    public class Provider : ConfigurationElement
    {
        #region constants
        /// <summary>
        /// The name attribute key
        /// </summary>
        private const string NameAttributeKey = "name";

        /// <summary>
        /// The exclude attribute key
        /// </summary>
        private const string ExcludeAttributeKey = "exclude";

        /// <summary>
        /// Sites Attribute Key constant
        /// </summary>
        private const string SitesAttributeKey = "Sites";

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
        /// Gets or sets the exclude
        /// </summary>
        [ConfigurationProperty(ExcludeAttributeKey, IsRequired = false)]
        public bool? Exclude
        {
            get { return (bool)base[ExcludeAttributeKey]; }
            set { base[ExcludeAttributeKey] = value; }
        }

        /// <summary>
        /// Gets or sets the sites.
        /// </summary>
        /// <value>
        /// The sites.
        /// </value>
        [ConfigurationProperty(SitesAttributeKey)]
        [ConfigurationCollection(typeof(Site), AddItemName = "Site")]
        public SiteCollection SiteCollection
        {
            get { return (SiteCollection)base[SitesAttributeKey]; }
            set { base[SitesAttributeKey] = value; }
        }

        #endregion
    }
}
