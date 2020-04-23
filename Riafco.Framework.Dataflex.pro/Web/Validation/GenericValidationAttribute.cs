using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Riafco.Framework.Dataflex.pro.Web.Validation
{
    /// <summary>
    /// The generic validation attribute class
    /// </summary>
    /// <typeparam name="TEntity">The class that contains the propety to validate</typeparam>
    public static class GenericValidationAttribute<TEntity> where TEntity : class
    {
        /// <summary>
        /// The validate attribute method
        /// </summary>
        /// <typeparam name="T">The type of class that inherits from ValidationAttribute class</typeparam>
        /// <param name="propName">The property name</param>
        /// <param name="propValue">The property value</param>
        /// <returns>Returns error message.</returns>   
        public static string ValidateAttribute<T>(string propName, string propValue)
        {
            var propInfo = typeof(TEntity).GetProperty(propName);
            if (propInfo == null) return string.Empty;
            var attribute = propInfo.GetCustomAttributes(typeof(T), true)[0] as ValidationAttribute;
            if (attribute != null && !attribute.IsValid(propValue))
            {
                return attribute.ErrorMessage;
            }

            return string.Empty;
        }

        /// <summary>
        /// The validate attributes method that validate all ValidationAttribute of the property
        /// </summary>
        /// <param name="propName">The property name</param>
        /// <param name="propValue">The property value</param>
        /// <returns>Returns error message list.</returns>
        public static List<string> ValidateAttributes(string propName, string propValue)
        {
            var errorList = new List<string>();
            var propInfo = typeof(TEntity).GetProperty(propName);
            if (propInfo == null) return errorList;
            var attributes = propInfo.GetCustomAttributes(typeof(ValidationAttribute), true);

            foreach (ValidationAttribute attr in attributes)
            {
                if (!attr.IsValid(propValue))
                {
                    errorList.Add(attr.FormatErrorMessage(attr.ErrorMessageResourceName));
                }
            }

            return errorList;
        }

        /// <summary>
        /// The validate attributes method that validate the object
        /// </summary>
        /// <param name="entity">The requested object</param>
        /// <returns>Returns error message list.</returns>
        public static List<string> ValidateAttributes(TEntity entity)
        {
            var errorList = new List<string>();
            var propInfos = typeof(TEntity).GetProperties();
            foreach (var propInfo in propInfos)
            {
                var attributes = propInfo.GetCustomAttributes(typeof(ValidationAttribute), true);

                foreach (ValidationAttribute attr in attributes)
                {
                    propInfo.GetValue(entity);
                    if (!attr.IsValid(propInfo.GetValue(entity)))
                    {
                        errorList.Add(attr.FormatErrorMessage(attr.ErrorMessageResourceName));
                    }
                }
            }
            return errorList;
        }
    }
}
