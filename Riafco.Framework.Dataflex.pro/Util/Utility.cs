using System;
using System.IO;
using System.Web;

namespace Riafco.Framework.Dataflex.pro.Util
{
    /// <summary>
    /// The Utility class
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Convert an enum to another enum.
        /// </summary>
        /// <typeparam name="TSource">Type of the base enum.</typeparam>
        /// <typeparam name="TTarget">The type of the target.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <returns>
        /// The converted value.
        /// </returns>
        public static TTarget EnumToEnum<TSource, TTarget>(TSource value)
            where TSource : struct
            where TTarget : struct
        {
            return EnumMapper.Map<TSource, TTarget>(value);
        }

        /// <summary>
        /// Convert an enum to another enum.
        /// </summary>
        /// <typeparam name="TSource">Type of the base enum.</typeparam>
        /// <typeparam name="TTarget">The type of the target.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <returns>
        /// The converted value.
        /// </returns>
        public static TTarget EnumToEnumLegacy<TSource, TTarget>(TSource value)
        {
            try
            {
                return (TTarget)Enum.Parse(typeof(TTarget), value.ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        /// <summary>
        /// Get image byte from httpPostedFileBase
        /// </summary>
        /// <param name="httpPostedFileBase">the httpPostedFileBase</param>
        /// <returns>array byte of the file.</returns>
        public static byte[] ToByte(this HttpPostedFileBase httpPostedFileBase)
        {
            if (httpPostedFileBase == null) return null;
            MemoryStream target = new MemoryStream();
            httpPostedFileBase.InputStream.CopyTo(target);
            byte[] data = target.ToArray();
            return data;
        }

        /// <summary>
        /// Get fileName from httpPostedFileBase.
        /// </summary>
        /// <param name="httpPostedFileBase">the httpPostedFileBase</param>
        /// <returns>the fileName.</returns>
        public static string ToString(this HttpPostedFileBase httpPostedFileBase)
        {
            return httpPostedFileBase?.FileName;
        }

        /// <summary>
        /// Get date from string date.
        /// </summary>
        /// <param name="sDate">the httpPostedFileBase</param>
        /// <returns>array byte of the file.</returns>
        public static DateTime StringToDateTime(this string sDate)
        {
            DateTime date = DateTime.Now;
            try
            {
                if (sDate.Split('/').Length == 3)
                {
                    date = new DateTime(int.Parse(sDate.Split('/')[2]), int.Parse(sDate.Split('/')[1]),
                        int.Parse(sDate.Split('/')[0]));
                }
            }
            catch (Exception)
            {
                date = DateTime.Now;
            }
            return date;
        }
    }
}
