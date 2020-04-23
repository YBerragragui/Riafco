using System.Configuration;

namespace Riafco.Framework.Dataflex.pro.Configuration
{
    /// <summary>
    /// The configuration manager helper
    /// </summary>
    public static class ConfigurationManagerHelper
    {
        #region App settings Helper
        /// <summary>
        /// Retrieves the boolean value contained in the key.
        /// </summary>
        /// <param name="key">The appSettings key.</param>
        /// <param name="defaultReturnValue">Nullable default value returned if :
        /// - the key does not exist
        /// - the cast does not work.</param>
        /// <returns>The nullable boolean value contained in the key;
        /// default value returned if :
        /// - the key does not exist
        /// - the cast does not work.</returns>
        public static bool GetAppSettingsToBool(string key, bool defaultReturnValue)
        {
            if (!string.IsNullOrEmpty(key))
            {
                string value = ConfigurationManager.AppSettings[key];
                if (!string.IsNullOrEmpty(value))
                {
                    bool returnValue;
                    if (bool.TryParse(value, out returnValue))
                    {
                        return returnValue;
                    }
                }
            }

            return defaultReturnValue;
        }

        /// <summary>
        /// Retrieves the boolean value contained in the key.
        /// </summary>
        /// <param name="key">The appSettings key.</param>
        /// <param name="defaultReturnValue">Nullable default value returned if :
        /// - the key does not exist
        /// </param>
        /// <returns>The string value contained in the key;
        /// default value returned if :
        /// - the key does not exist
        /// .</returns>
        public static string GetAppSettingsToString(string key, string defaultReturnValue)
        {
            if (!string.IsNullOrEmpty(key))
            {
                string value = ConfigurationManager.AppSettings[key];
                if (!string.IsNullOrEmpty(value))
                {
                    return value;
                }
            }

            return defaultReturnValue;
        }

        /// <summary>
        /// Retrieves the integer value contained in the key.
        /// </summary>
        /// <param name="key">The appSettings key.</param>
        /// <param name="defaultReturnValue">Default value returned if :
        /// - the key does not exist
        /// - the cast does not work.</param>
        /// <returns>The integer value contained in the key;
        /// default value returned if :
        /// - the key does not exist
        /// - the cast does not work.</returns>
        public static int GetAppSettingsToInt(string key, int defaultReturnValue)
        {
            if (!string.IsNullOrEmpty(key))
            {
                string value = ConfigurationManager.AppSettings[key];
                if (!string.IsNullOrEmpty(value))
                {
                    int returnValue;
                    if (int.TryParse(value, out returnValue))
                    {
                        return returnValue;
                    }
                }
            }

            return defaultReturnValue;
        }

        /// <summary>
        /// Retrieves the integer value contained in the key.
        /// </summary>
        /// <param name="key">The appSettings key.</param>
        /// <param name="defaultReturnValue">Nullable default value returned if :
        /// - the key does not exist
        /// - the cast does not work.</param>
        /// <returns>The nullable integer value contained in the key;
        /// default value returned if :
        /// - the key does not exist
        /// - the cast does not work.</returns>
        public static int? GetAppSettingsToInt(string key, int? defaultReturnValue)
        {
            if (!string.IsNullOrEmpty(key))
            {
                string value = ConfigurationManager.AppSettings[key];
                if (!string.IsNullOrEmpty(value))
                {
                    int returnValue;
                    if (int.TryParse(value, out returnValue))
                    {
                        return returnValue;
                    }
                }
            }

            return defaultReturnValue;
        }
        #endregion
    }
}
