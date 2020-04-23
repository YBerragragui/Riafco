using System.Configuration;

namespace Riafco.Framework.Dataflex.pro.Configuration.Section.ServiceActivationSection
{
    /// <summary>
    /// The Site Collection Class
    /// </summary>
    public class SiteCollection : OmsConfigurationElementCollection<Site>
    {
        /// <summary>
        /// Item Element property name const
        /// </summary>
        internal const string CollectionPropertyName = "Site";

        /// <summary>
        /// CollectionType property
        /// </summary>
        public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMap;

        /// <summary>
        /// this[string name] property
        /// </summary>
        /// <param name="itemName">The element name</param>
        /// <returns>The element value</returns>
        public new Site this[string itemName] => (Site)BaseGet(itemName != null ? itemName.ToLowerInvariant() : null);

        /// <summary>
        /// this[int index] property
        /// </summary>
        /// <param name="index">The index of element name</param>
        /// <returns>The element value</returns>
        public Site this[int index]
        {
            get { return (Site)BaseGet(index); }
        }

        /// <summary>
        /// IsElementName method
        /// </summary>
        /// <param name="elementName">The element name</param>
        /// <returns>check the element name </returns>
        protected override bool IsElementName(string elementName)
        {
            return elementName == CollectionPropertyName;
        }

        /// <summary>
        /// Gets the name used to identify this collection of elements in the configuration file when overridden in a derived class.
        /// </summary>
        protected override string ElementName
        {
            get
            {
                return CollectionPropertyName;
            }
        }

        /// <summary>
        /// When overridden in a derived class, creates a new <see cref="T:System.Configuration.ConfigurationElement" />.
        /// </summary>
        /// <returns>
        /// A new <see cref="T:System.Configuration.ConfigurationElement" />.
        /// </returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new Site();
        }

        /// <summary>
        /// Gets the element key for a specified configuration element when overridden in a derived class.
        /// </summary>
        /// <param name="element">The <see cref="T:System.Configuration.ConfigurationElement" /> to return the key for.</param>
        /// <returns>
        /// An <see cref="T:System.Object" /> that acts as the key for the specified <see cref="T:System.Configuration.ConfigurationElement" />.
        /// </returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Site)element).SiteId;
        }
    }
}
