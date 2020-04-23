using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Riafco.Framework.Dataflex.pro.Configuration.Section.Assembler
{
    /// <summary>
    /// The service activation assembler
    /// </summary>
    public static class ServiceActivationAssembler
    {
        /// <summary>
        /// To system.Type list
        /// </summary>
        /// <param name="dependencies">service list</param>
        /// <returns>list of System.Type</returns>
        public static List<System.Type> ToSystemTypeList(this ICollection<string> dependencies, string entityAssembly)
        {
            List<System.Type> responseTypes = new List<System.Type>();
            Assembly assembly = Assembly.Load(entityAssembly);
            if (dependencies != null && dependencies.Any())
            {
                List<System.Type> types = dependencies.Select(lib => assembly.GetType(lib)).ToList();
                responseTypes.AddRange(types);
            }

            return responseTypes;
        }
    }
}
