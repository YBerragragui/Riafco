using System.IO;
using System.Web.Hosting;

namespace Riafco.Framework.Dataflex.pro.ManageFiles
{
    /// <summary>
    /// The ManageFile class
    /// </summary>
    public static class ManageFile
    {
        /// <summary>
        /// read file as byte.
        /// </summary>
        /// <param name="url">the url of the file.</param>
        /// <returns></returns>
        public static byte[] ReadFile(string url)
        {
            string filename = HostingEnvironment.MapPath(url);
            return File.ReadAllBytes(filename);
        }
    }
}

