using System.Configuration;

namespace Riafco.Framework.Dataflex.pro.Configuration.Section.ServiceSettingSection
{
    /// <summary>
    /// The Adapter section class
    /// </summary>
    public class Adapter : ConfigurationElement
    {
        #region constants
        /// <summary>
        /// The assembly type
        /// </summary>
        private const string AssemblyTypeAttributeKey = "assemblyType";

        /// <summary>
        /// The assembly
        /// </summary>
        private const string AssemblyAttributeKey = "assembly";

        /// <summary>
        /// Types Attribute Key constant
        /// </summary>
        private const string TypesAttributeKey = "types";
        #endregion

        #region public properties
        /// <summary>
        /// Gets or sets the assembly type.
        /// </summary>
        [ConfigurationProperty(AssemblyTypeAttributeKey, IsRequired = false)]
        public string AssemblyType
        {
            get { return (string)base[AssemblyTypeAttributeKey]; }
            set { base[AssemblyTypeAttributeKey] = value; }
        }

        /// <summary>
        /// Gets or sets the assembly.
        /// </summary>
        [ConfigurationProperty(AssemblyAttributeKey, IsRequired = false)]
        public string Assembly
        {
            get { return (string)base[AssemblyAttributeKey]; }
            set { base[AssemblyAttributeKey] = value; }
        }

        /// <summary>
        /// Gets or sets the types.
        /// </summary>
        /// <value>
        /// The adapters.
        /// </value>
        [ConfigurationProperty(TypesAttributeKey)]
        [ConfigurationCollection(typeof(Type), AddItemName = "type")]
        public TypeCollection TypeCollection
        {
            get { return (TypeCollection)base[TypesAttributeKey]; }
            set { base[TypesAttributeKey] = value; }
        }
        #endregion
    }
}
