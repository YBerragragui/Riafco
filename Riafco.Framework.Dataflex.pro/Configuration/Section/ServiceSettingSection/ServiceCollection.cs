﻿using System.Configuration;

namespace Riafco.Framework.Dataflex.pro.Configuration.Section.ServiceSettingSection
{
    /// <summary>
    /// The Service Collection class
    /// </summary>
    public class ServiceCollection : OmsConfigurationElementCollection<Service>
    {
        /// <summary>
        /// Item Element property name const
        /// </summary>
        internal const string CollectionPropertyName = "service";

        /// <summary>
        /// CollectionType property
        /// </summary>
        public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMap;

        /// <summary>
        /// this[string name] property
        /// </summary>
        /// <param name="itemName">The element name</param>
        /// <returns>The element value</returns>
        public new Service this[string itemName] => (Service)BaseGet(itemName != null ? itemName.ToLowerInvariant() : null);

        /// <summary>
        /// this[int index] property
        /// </summary>
        /// <param name="index">The index of element name</param>
        /// <returns>The element value</returns>
        public Service this[int index] => (Service)BaseGet(index);

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
        protected override string ElementName => CollectionPropertyName;

        /// <summary>
        /// When overridden in a derived class, creates a new <see cref="T:System.Configuration.ConfigurationElement" />.
        /// </summary>
        /// <returns>
        /// A new <see cref="T:System.Configuration.ConfigurationElement" />.
        /// </returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new Service();
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
            return ((Service)element).ServiceAssembly;
        }
    }
}
