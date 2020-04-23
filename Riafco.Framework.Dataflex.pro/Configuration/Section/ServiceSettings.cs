using Riafco.Framework.Dataflex.pro.Configuration.Section.Enum;
using Riafco.Framework.Dataflex.pro.Configuration.Section.ServiceSettingSection;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Riafco.Framework.Dataflex.pro.Configuration.Section
{
    /// <summary>
    /// The Service Settings class
    /// </summary>
    public class ServiceSettings : ConfigurationSection
    {
        #region constants
        /// <summary>
        /// section constant
        /// </summary>
        internal const string ConfigSectionName = "OMS/serviceSettings";

        /// <summary>
        /// Services Attribute Key constant
        /// </summary>
        private const string ServicesAttributeKey = "services";

        #endregion

        #region static properties
        /// <summary>
        /// Gets Instance property
        /// </summary>
        private static ServiceSettings Configuration
        {
            get
            {
                var section = ConfigurationManager.GetSection(ConfigSectionName);
                if (section is ServiceSettings)
                {
                    return section as ServiceSettings;
                }

                throw new System.Exception("Section ServiceSettings not found");
            }
        }

        #endregion

        #region public properties
        /// <summary>
        /// Gets or sets the services.
        /// </summary>
        /// <value>
        /// The services.
        /// </value>
        [ConfigurationProperty(ServicesAttributeKey)]
        [ConfigurationCollection(typeof(Service), AddItemName = "service")]
        public ServiceCollection ServiceCollection
        {
            get { return (ServiceCollection)base[ServicesAttributeKey]; }
            set { base[ServicesAttributeKey] = value; }
        }

        #endregion

        #region static methods
        /// <summary>
        /// retrieves all dependencies of service
        /// </summary>
        /// <param name="serviceName">service name</param>
        /// <returns>returns list of service dependencies</returns>
        public static ICollection<string> GetAllServiceDependencies(string serviceName)
        {
            Service currentService = Configuration.ServiceCollection.FirstOrDefault(ser => ser.ServiceAssembly == serviceName);
            if (currentService != null)
            {
                return currentService.DependencyCollection.Select(dep => dep.ClassLibrary).ToList();
            }

            return new List<string>();
        }

        /// <summary>
        /// retrieves all configuration dependencies of service
        /// </summary>
        /// <param name="serviceName">service name</param>
        /// <returns>returns list of configuration dependencies</returns>
        public static ICollection<string> GetAllServiceConfigurationDependencies(string serviceName)
        {
            Service currentService = Configuration.ServiceCollection.FirstOrDefault(ser => ser.ServiceAssembly == serviceName);
            if (currentService != null)
            {
                return currentService.DependencyCollection.Where(con => !string.IsNullOrEmpty(con.ClassConfiguration)).Select(dep => dep.ClassConfiguration).ToList();
            }

            return new List<string>();
        }

        /// <summary>
        /// Get All Service Adapters
        /// </summary>
        /// <param name="serviceName">The service name</param>
        /// <param name="assemblyType">The assembly type</param>
        /// <returns>Dictinary that contains couple of class/interface</returns>
        public static Dictionary<string, string> GetAllServiceAdapters(string serviceName, AssemblyType assemblyType)
        {
            Dictionary<string, string> adapterTypes = new Dictionary<string, string>();

            Service currentService = Configuration.ServiceCollection.FirstOrDefault(ser => ser.ServiceAssembly == serviceName);
            if (currentService != null)
            {
                Adapter adapter = currentService.AdapterCollection.FirstOrDefault(ass => ass.AssemblyType == assemblyType.ToString());
                if (adapter != null)
                {
                    foreach (var type in adapter.TypeCollection)
                    {
                        adapterTypes.Add(type.ClassLibrary, type.Interface);
                    }
                }
            }

            return adapterTypes;
        }

        /// <summary>
        /// Get Service Assembly to load service adapters
        /// </summary>
        /// <param name="serviceName">The service name</param>
        /// <param name="assemblyType">The assembly type</param>
        /// <returns>the assembly</returns>
        public static string GetServiceAssembly(string serviceName, AssemblyType assemblyType)
        {
            Service currentService = Configuration.ServiceCollection.FirstOrDefault(ser => ser.ServiceAssembly == serviceName);
            if (currentService != null)
            {
                Adapter adapter = currentService.AdapterCollection.FirstOrDefault(ass => ass.AssemblyType == assemblyType.ToString());
                if (adapter != null)
                {
                    return adapter.Assembly;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Get Entity Assembly
        /// </summary>
        /// <param name="serviceName">The service name</param>
        /// <returns>The entity assembly</returns>
        public static string GetEntityAssembly(string serviceName)
        {
            Service currentService = Configuration.ServiceCollection.FirstOrDefault(ser => ser.ServiceAssembly == serviceName);
            if (currentService != null)
            {
                return currentService.EntityAssembly;
            }

            return string.Empty;
        }

        #endregion
    }
}
