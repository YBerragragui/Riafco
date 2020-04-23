using Riafco.Framework.Dataflex.pro.Configuration.Section.ServiceActivationSection;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Riafco.Framework.Dataflex.pro.Configuration.Section
{
    /// <summary>
    /// The Service Activation class
    /// </summary>
    public class ServiceActivation : ConfigurationSection
    {
        #region constants
        /// <summary>
        /// section constant
        /// </summary>
        internal const string ConfigSectionName = "OMS/serviceActivation";

        /// <summary>
        /// Services Attribute Key constant
        /// </summary>
        private const string ServicesAttributeKey = "services";

        #endregion

        #region static properties
        /// <summary>
        /// Gets Instance property
        /// </summary>
        private static ServiceActivation Configuration
        {
            get
            {
                var section = ConfigurationManager.GetSection(ConfigSectionName);
                if (section != null && section is ServiceActivation)
                {
                    return section as ServiceActivation;
                }

                throw new System.Exception("Section ServiceActivation not found");
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
        /// Get All Ignored Services
        /// </summary>
        /// <returns>list of ignored service name</returns>
        public static ICollection<string> GetAllIgnoredServices()
        {
            List<string> activeServices = new List<string>();
            foreach (Service service in Configuration.ServiceCollection)
            {
                if (!IsServiceActivationForced(service) && !IsServiceActiveBySiteId(service))
                {
                    activeServices.Add(service.Name);
                }
            }

            return activeServices;
        }

        /// <summary>
        /// Get All activated services
        /// </summary>
        /// <returns>list of activated service name</returns>
        public static ICollection<string> GetAllActivatedServices()
        {
            List<string> activeServices = new List<string>();
            foreach (Service service in Configuration.ServiceCollection)
            {
                if (IsServiceActivationForced(service) || IsServiceActiveBySiteId(service))
                {
                    activeServices.Add(service.Name);
                }
            }

            return activeServices;
        }

        #endregion

        #region private methods
        /// <summary>
        /// Check if the service activation is forced (force == true/false)
        /// </summary>
        /// <param name="service">The service activation</param>
        /// <returns>Bool</returns>
        private static bool IsServiceActivationForced(Service service)
        {
            return service.Force.HasValue && service.Force.Value;
        }

        /// <summary>
        /// check if the service is active by site id
        /// </summary>
        /// <param name="service">The service activation</param>
        /// <returns>Bool</returns>
        private static bool IsServiceActiveBySiteId(Service service)
        {
            bool result = false;
            int? currentSiteId = ConfigurationManagerHelper.GetAppSettingsToInt("currentSiteId", null);

            if (service.Provider != null && currentSiteId != null)
            {
                // check exclude nullity
                if (service.Provider.Exclude.HasValue)
                {
                    // check exclude value
                    if (service.Provider.Exclude.Value)
                    {
                        // check existence site id
                        result = !service.Provider.SiteCollection.Any(sit => sit.SiteId == currentSiteId);
                    }
                    else
                    {
                        // check existence site id
                        result = service.Provider.SiteCollection.Any(sit => sit.SiteId == currentSiteId);
                    }
                }
                else
                {
                    // check existence site id
                    result = service.Provider.SiteCollection.Any(sit => sit.SiteId == currentSiteId);
                }
            }

            return result;
        }

        #endregion
    }
}
