﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Ressource {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class AreaMessageResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AreaMessageResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Riafco.WebApi.Service.Dataflex.pro.Ressources.Ressource.AreaMessageResource", typeof(AreaMessageResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Request est null..
        /// </summary>
        public static string NullRequest {
            get {
                return ResourceManager.GetString("NullRequest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nom de theme est obligatoire..
        /// </summary>
        public static string RequiredAreaName {
            get {
                return ResourceManager.GetString("RequiredAreaName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Id est obligatoire..
        /// </summary>
        public static string RequiredId {
            get {
                return ResourceManager.GetString("RequiredId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Id de la langue est obligatoire..
        /// </summary>
        public static string RequiredLanguageId {
            get {
                return ResourceManager.GetString("RequiredLanguageId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Id de la traduction est obligatoire..
        /// </summary>
        public static string RequiredTranslationId {
            get {
                return ResourceManager.GetString("RequiredTranslationId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Erreurs de validation..
        /// </summary>
        public static string ValidationErrors {
            get {
                return ResourceManager.GetString("ValidationErrors", resourceCulture);
            }
        }
    }
}
