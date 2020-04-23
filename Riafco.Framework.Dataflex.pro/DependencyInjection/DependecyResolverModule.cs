using Ninject.Modules;
using Riafco.Framework.Dataflex.pro.Configuration.Section;
using System.Linq;
using System.Reflection;

namespace Riafco.Framework.Dataflex.pro.DependencyInjection
{
    /// <summary>
    /// NINJECT CONFIGORATION.
    /// </summary>
    public class DependecyResolverModule : NinjectModule
    {
        /// <summary>
        /// The overrided load method.
        /// </summary>
        public override void Load()
        {
            // gets activated services
            var activeServices = ServiceActivation.GetAllActivatedServices().ToList();

            foreach (var service in activeServices)
            {
                // gets list of adapters for service
                var serviceAssemblyName = ServiceSettings.GetServiceAssembly(service, Configuration.Section.Enum.AssemblyType.Service);
                if (!string.IsNullOrEmpty(serviceAssemblyName))
                {
                    var serviceAssembly = Assembly.Load(serviceAssemblyName);
                    var adapters = ServiceSettings.GetAllServiceAdapters(service, Configuration.Section.Enum.AssemblyType.Service);
                    foreach (var adapter in adapters)
                    {
                        var _class = serviceAssembly.GetType(adapter.Key);
                        var _interface = serviceAssembly.GetType(adapter.Value);
                        Bind(_interface).To(_class);
                    }
                }

                // gets list of adapters for web Api service
                var webApiServiceAssemblyName = ServiceSettings.GetServiceAssembly(service, Configuration.Section.Enum.AssemblyType.WebApiService);
                if (string.IsNullOrEmpty(webApiServiceAssemblyName)) continue;
                {
                    var webApiServiceAssembly = Assembly.Load(webApiServiceAssemblyName);
                    var adapters = ServiceSettings.GetAllServiceAdapters(service, Configuration.Section.Enum.AssemblyType.WebApiService);
                    foreach (var adapter in adapters)
                    {
                        var _class = webApiServiceAssembly.GetType(adapter.Key);
                        var _interface = webApiServiceAssembly.GetType(adapter.Value);
                        Bind(_interface).To(_class);
                    }
                }
            }
        }
    }
}
