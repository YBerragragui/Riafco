using System.Configuration;

namespace Riafco.Framework.Dataflex.pro.Configuration.Section.ServiceActivationSection
{
    /// <summary>
    /// The Site class
    /// </summary>
    public class Site : ConfigurationElement
    {
        #region constants
        /// <summary>
        /// The site id attribute key
        /// </summary>
        private const string SiteIdAttributeKey = "siteId";

        #endregion

        #region public properties
        /// <summary>
        /// Gets or sets the site id
        /// </summary>
        [ConfigurationProperty(SiteIdAttributeKey, IsKey = true, IsRequired = false)]
        public int SiteId
        {
            get { return (int)base[SiteIdAttributeKey]; }
            set { base[SiteIdAttributeKey] = value; }
        }

        #endregion
    }
}
