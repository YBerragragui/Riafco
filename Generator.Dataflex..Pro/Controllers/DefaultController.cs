using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using Generator.Dataflex.Pro.Models;
using Microsoft.CodeDom.Providers.DotNetCompilerPlatform;

namespace Generator.Dataflex.Pro.Controllers
{
    /// <summary>
    /// The home class.
    /// </summary>
    public class DefaultController : Controller
    {
        /// <summary>
        /// The home page action.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(new HomeModel());
        }

        /// <summary>
        /// Generate files
        /// </summary>
        /// <param name="homeModel">the home model</param>
        /// <returns>true if the genaration susseded.</returns>
        public bool Generate(HomeModel homeModel)
        {
            //ENTITY :
            string nameSpaceEntity = ConfigurationManager.AppSettings["nameSpaceEntity"] + "." + homeModel.FolderName;

            //DALL :
            string nameSpaceDal = ConfigurationManager.AppSettings["nameSpaceDal"];
            string folderInterfaceDal = ConfigurationManager.AppSettings["folderInterfaceDal"];
            string folderContextDal = ConfigurationManager.AppSettings["folderContextDal"];
            string folderCoreDal = ConfigurationManager.AppSettings["folderCoreDal"];

            //SERVICE :
            string nameSpaceService = ConfigurationManager.AppSettings["nameSpaceService"] + "." + homeModel.FolderName;
            string nameSpaceServiceFolder = ConfigurationManager.AppSettings["nameSpaceService"];
            string folderInterface = ConfigurationManager.AppSettings["folderInterface"];
            string folderAssembler = ConfigurationManager.AppSettings["folderAssembler"];
            string folderMessage = ConfigurationManager.AppSettings["folderMessage"];
            string folderRequest = ConfigurationManager.AppSettings["folderRequest"];
            string folderPivot = ConfigurationManager.AppSettings["folderPivot"];
            string unitOfWorkFolder = ConfigurationManager.AppSettings["unitOfWorkFolder"];

            //WEB API SERVICE :
            string nameSpaceServiceApi = ConfigurationManager.AppSettings["nameSpaceServiceApi"] + "." + homeModel.FolderName;
            string nameSpaceServiceApiFolder = ConfigurationManager.AppSettings["nameSpaceServiceApi"];
            string folderInterfaceApi = ConfigurationManager.AppSettings["folderInterfaceApi"];
            string folderAssemblerApi = ConfigurationManager.AppSettings["folderAssemblerApi"];
            string folderMessageApi = ConfigurationManager.AppSettings["folderMessageApi"];
            string folderRequestApi = ConfigurationManager.AppSettings["folderRequestApi"];
            string folderDtoApi = ConfigurationManager.AppSettings["folderDtoApi"];

            //FRAMWORK :
            string nameSpaceMessageClass = ConfigurationManager.AppSettings["nameSpaceMessageClass"];
            string nameSpaceMessageEnum = ConfigurationManager.AppSettings["nameSpaceMessageEnum"];
            string classMessage = ConfigurationManager.AppSettings["classMessage"];

            //WEB API :
            string nameSpaceWebApi = ConfigurationManager.AppSettings["nameSpaceWebApi"];
            string folderWebApi = ConfigurationManager.AppSettings["nameSpaceWebApi"];

            bool isSuccess = true;
            try
            {
                string typeName = homeModel.NomAssembly + "." + homeModel.FolderName + "." + homeModel.NomClass + "," + homeModel.NomAssembly;
                Type type = Type.GetType(typeName);
                if (type != null)
                {
                    #region GET TYPE AND PROPS.

                    string assemblyName = type.Assembly.GetName().Name;
                    string classNameAttribute = char.ToLower(type.Name[0]) + type.Name.Substring(1);
                    string className = type.Name;

                    List<PropertyInfo> props = Type.GetType(typeName).GetProperties().ToList();
                    bool hasKey = Type.GetType(typeName).GetProperties().Any(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Any());

                    #endregion

                    #region SERVICE.

                    #region CLASS PIVOT
                    string usingPivotSource = "using System;\nusing System.Collections.Generic;\n";
                    string proprsPivotSource = string.Empty;

                    foreach (var prop in props)
                    {
                        Type typeProp = prop.PropertyType;
                        if (Nullable.GetUnderlyingType(typeProp) != null)
                        {
                            typeProp = Nullable.GetUnderlyingType(typeProp);
                        }

                        if (typeProp.IsGenericType && (typeProp.GetGenericTypeDefinition() == typeof(List<>) || typeProp.GetGenericTypeDefinition() == typeof(ICollection<>)))
                        {
                            proprsPivotSource += "/// <summary>\n";
                            proprsPivotSource += "/// Gets or Sets The  " + prop.Name + ".\n";
                            proprsPivotSource += "/// </summary>\n";
                            proprsPivotSource += "public List<" + typeProp.GenericTypeArguments.FirstOrDefault().Name + "Pivot> " + prop.Name + " { get; set; } \n";

                            var nameSpace = typeProp.GetGenericArguments().FirstOrDefault().Namespace;
                            if (!usingPivotSource.Contains("using " + nameSpaceServiceFolder + "." + nameSpace.Split('.').LastOrDefault() + "." + folderPivot + ";\n\n"))
                                usingPivotSource += "using " + nameSpaceServiceFolder + "." + nameSpace.Split('.').LastOrDefault() + "." + folderPivot + ";\n\n";
                        }
                        else if (typeProp.IsPrimitive || typeProp == typeof(char) || typeProp == typeof(Char) || typeProp == typeof(long) || typeProp == typeof(ulong) || typeProp == typeof(short) || typeProp == typeof(ushort) || typeProp == typeof(int) || typeProp == typeof(byte) || typeProp == typeof(Byte) || typeProp == typeof(sbyte) || typeProp == typeof(sbyte) || typeProp == typeof(string) || typeProp == typeof(String) || typeProp == typeof(DateTime) || typeProp == typeof(float) || typeProp == typeof(float) || typeProp == typeof(Decimal) || typeProp == typeof(decimal))
                        {
                            StringBuilder sb = new StringBuilder();
                            using (StringWriter sw = new StringWriter(sb))
                            {
                                var expr = new CodeTypeReferenceExpression(typeProp);
                                var prov = new CSharpCodeProvider();
                                prov.GenerateCodeFromExpression(expr, sw, new CodeGeneratorOptions());
                            }

                            proprsPivotSource += "/// <summary>\n";
                            proprsPivotSource += "/// Gets or Sets The  " + prop.Name + ".\n";
                            proprsPivotSource += "/// </summary>\n";
                            proprsPivotSource += "public " + sb + " " + prop.Name + " { get; set; } \n\n";
                        }
                        else if (typeProp.IsClass && typeProp != typeof(byte[]) && typeProp != typeof(string) && typeProp != typeof(String) && typeProp != typeof(DateTime) && typeProp != typeof(float) && typeProp != typeof(float) && typeProp != typeof(Decimal) && typeProp != typeof(decimal))
                        {
                            proprsPivotSource += "/// <summary>\n";
                            proprsPivotSource += "/// Gets or Sets The  " + prop.Name + ".\n";
                            proprsPivotSource += "/// </summary>\n";
                            proprsPivotSource += "public " + typeProp.Name + "Pivot" + " " + prop.Name + " { get; set; } \n\n";

                            if (!usingPivotSource.Contains("using " + nameSpaceServiceFolder + "." + typeProp.Namespace.Split('.').LastOrDefault() + "." + folderPivot + ";\n"))
                                usingPivotSource += "using " + nameSpaceServiceFolder + "." + typeProp.Namespace.Split('.').LastOrDefault() + "." + folderPivot + ";\n";
                        }
                        else if (typeProp.IsArray && typeProp != typeof(string) && typeProp != typeof(String) && typeProp != typeof(DateTime) && typeProp != typeof(float) && typeProp != typeof(float) && typeProp != typeof(Decimal) && typeProp != typeof(decimal))
                        {
                            proprsPivotSource += "/// <summary>\n";
                            proprsPivotSource += "/// Gets or Sets The  " + prop.Name + ".\n";
                            proprsPivotSource += "/// </summary>\n";
                            proprsPivotSource += "public " + typeProp.Name + " " + prop.Name + " { get; set; } \n\n";
                        }
                    }

                    string commentPivot = string.Empty;
                    commentPivot += "/// <summary>\n";
                    commentPivot += "/// The " + className + " pivot class.\n";
                    commentPivot += "/// </summary>";

                    string classSourePivot = usingPivotSource + "\n" + "namespace " + nameSpaceService + "." + folderPivot + "\n{\n " + commentPivot + "\npublic class " + className + "Pivot\n{\n " + proprsPivotSource + " }\n}";
                    Directory.CreateDirectory(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + homeModel.FolderName + "/" + folderPivot));
                    System.IO.File.WriteAllText(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + homeModel.FolderName + "/" + folderPivot + "/" + className + "Pivot.cs"), classSourePivot);

                    #endregion

                    #region  ASEMBLER
                    string usingAssomblerSource = "using " + nameSpaceEntity + ";\nusing " + nameSpaceService + "." + folderPivot + ";\nusing " + assemblyName + ";\nusing System;\nusing System.Collections.Generic;\nusing System.Linq;\n";
                    string attributesSource = string.Empty;

                    foreach (var prop in props)
                    {
                        Type typeProp = prop.PropertyType;
                        if (Nullable.GetUnderlyingType(typeProp) != null)
                        {
                            typeProp = Nullable.GetUnderlyingType(typeProp);
                        }

                        if (typeProp.IsGenericType && (typeProp.GetGenericTypeDefinition() == typeof(List<>) || typeProp.GetGenericTypeDefinition() == typeof(ICollection<>)))
                        {
                            var nameSpace = typeProp.GetGenericArguments().FirstOrDefault().Namespace;
                            attributesSource += prop.Name + " = " + classNameAttribute + "." + prop.Name + "?." + "ToPivotList(),\n";
                            if (!usingAssomblerSource.Contains("using " + nameSpaceServiceFolder + "." + nameSpace.Split('.').LastOrDefault() + "." + folderAssembler + ";\n"))
                                usingAssomblerSource += "using " + nameSpaceServiceFolder + "." + nameSpace.Split('.').LastOrDefault() + "." + folderAssembler + ";\n";
                        }
                        else if (typeProp.IsPrimitive || typeProp == typeof(string) || typeProp == typeof(String) || typeProp == typeof(DateTime) || typeProp == typeof(float) || typeProp == typeof(float) || typeProp == typeof(Decimal) || typeProp == typeof(decimal))
                        {
                            if (Nullable.GetUnderlyingType(prop.PropertyType) != null)
                                attributesSource += prop.Name + " = " + classNameAttribute + "." + prop.Name + ".Value,\n";
                            else
                                attributesSource += prop.Name + " = " + classNameAttribute + "." + prop.Name + ",\n";
                        }
                        else if (typeProp.IsClass && typeProp != typeof(byte[]) && typeProp != typeof(string) && typeProp != typeof(String) && typeProp != typeof(DateTime) && typeProp != typeof(float) && typeProp != typeof(float) && typeProp != typeof(Decimal) && typeProp != typeof(decimal))
                        {
                            attributesSource += prop.Name + " = " + classNameAttribute + "." + prop.Name + "?.ToPivot(),\n";
                            if (!usingAssomblerSource.Contains("using " + nameSpaceServiceFolder + "." + typeProp.Namespace.Split('.').LastOrDefault() + "." + folderAssembler + ";\n"))
                                usingAssomblerSource += "using " + nameSpaceServiceFolder + "." + typeProp.Namespace.Split('.').LastOrDefault() + "." + folderAssembler + ";\n";
                        }
                        else if (typeProp.IsArray && typeProp != typeof(string) && typeProp != typeof(String) && typeProp != typeof(DateTime) && typeProp != typeof(float) && typeProp != typeof(float) && typeProp != typeof(Decimal) && typeProp != typeof(decimal))
                        {
                            if (Nullable.GetUnderlyingType(prop.PropertyType) != null)
                                attributesSource += prop.Name + " = " + classNameAttribute + "." + prop.Name + ".Value,\n";
                            else
                                attributesSource += prop.Name + " = " + classNameAttribute + "." + prop.Name + ",\n";
                        }
                    }

                    string convertListSource = "return " + classNameAttribute + "List?.Select(x => x.ToPivot()).ToList();\n";
                    string attributesSourceBis = string.Empty;
                    foreach (var prop in props)
                    {
                        Type typeProp = prop.PropertyType;
                        if (Nullable.GetUnderlyingType(typeProp) != null)
                        {
                            typeProp = Nullable.GetUnderlyingType(typeProp);
                        }

                        if (typeProp.IsGenericType && (typeProp.GetGenericTypeDefinition() == typeof(List<>) || typeProp.GetGenericTypeDefinition() == typeof(ICollection<>)))
                        {
                            attributesSourceBis += prop.Name + " = " + classNameAttribute + "Pivot" + "." + prop.Name + "?.To" + typeProp.GenericTypeArguments.FirstOrDefault().Name + "List(),\n";
                        }
                        else if (typeProp.IsPrimitive || typeProp == typeof(string) || typeProp == typeof(String) || typeProp == typeof(DateTime) || typeProp == typeof(float) || typeProp == typeof(float) || typeProp == typeof(Decimal) || typeProp == typeof(decimal))
                        {
                            attributesSourceBis += prop.Name + " = " + classNameAttribute + "Pivot" + "." + prop.Name + ",\n";
                        }
                        else if (typeProp.IsClass && typeProp != typeof(byte[]) && typeProp != typeof(string) && typeProp != typeof(String) && typeProp != typeof(DateTime) && typeProp != typeof(float) && typeProp != typeof(float) && typeProp != typeof(Decimal) && typeProp != typeof(decimal))
                        {
                            attributesSourceBis += prop.Name + " = " + classNameAttribute + "Pivot" + "." + prop.Name + "?.To" + typeProp.Name + "(),\n";
                        }
                        else if (typeProp.IsArray && typeProp != typeof(string) && typeProp != typeof(String) && typeProp != typeof(DateTime) && typeProp != typeof(float) && typeProp != typeof(float) && typeProp != typeof(Decimal) && typeProp != typeof(decimal))
                        {
                            attributesSourceBis += prop.Name + " = " + classNameAttribute + "Pivot" + "." + prop.Name + ",\n";
                        }
                    }

                    string convertListSourceBis = "return " + classNameAttribute + "PivotList?.Select(x => x?.To" + className + "()).ToList();\n";
                    string methodeSourceToPivot = string.Empty;
                    methodeSourceToPivot += "/// <summary>\n";
                    methodeSourceToPivot += "/// From " + className + " To " + className + " Pivot.\n";
                    methodeSourceToPivot += "/// </summary>\n";
                    methodeSourceToPivot += "/// <param name=\"" + classNameAttribute + "\">" + classNameAttribute + " TO ASSEMBLE</param>\n";
                    methodeSourceToPivot += "/// <returns>" + className + "Pivot" + " result.</returns>\n";
                    methodeSourceToPivot += "public static " + className + "Pivot ToPivot(this " + className + " " + classNameAttribute + ")\n{\nif(" + classNameAttribute + " == null)\n{\n return null; \n}\nreturn new " + className + "Pivot()\n{\n" + attributesSource + "};\n}\n";

                    string methodeSourceToPivotList = string.Empty;
                    methodeSourceToPivotList += "/// <summary>\n";
                    methodeSourceToPivotList += "/// From " + className + " list to " + className + " pivot list.\n";
                    methodeSourceToPivotList += "/// </summary>\n";
                    methodeSourceToPivotList += "/// <param name=\"" + classNameAttribute + "List\">" + classNameAttribute + "List to assemble.</param>\n";
                    methodeSourceToPivotList += "/// <returns>list of " + className + "Pivot result.</returns>\n";
                    methodeSourceToPivotList += "public static List<" + className + "Pivot> ToPivotList(this List<" + className + "> " + classNameAttribute + "List" + ")\n{\n" + convertListSource + "\n}";

                    string regionToPivot = "#region TO PIVOT " + "\n" + methodeSourceToPivot + "\n" + methodeSourceToPivotList + "\n" + " #endregion\n";

                    string methodeSourceToEntity = string.Empty;
                    methodeSourceToEntity += "/// <summary>\n";
                    methodeSourceToEntity += "/// From " + className + "Pivot to " + className + ".\n";
                    methodeSourceToEntity += "/// </summary>\n";
                    methodeSourceToEntity += "/// <param name=\"" + classNameAttribute + "Pivot\">" + classNameAttribute + "Pivot to assemble.</param>\n";
                    methodeSourceToEntity += "/// <returns>" + className + " result.</returns>\n";
                    methodeSourceToEntity += "public static " + className + " To" + className + "(this " + className + "Pivot " + classNameAttribute + "Pivot)\n{\nif(" + classNameAttribute + "Pivot == null)\n{\n return null;\n}\nreturn new " + className + "(){\n" + attributesSourceBis + "};\n}\n";

                    string methodeSourceToEntityList = string.Empty;
                    methodeSourceToEntityList += "/// <summary>\n";
                    methodeSourceToEntityList += "/// From " + className + "PivotList to " + className + "List .\n";
                    methodeSourceToEntityList += "/// </summary>\n";
                    methodeSourceToEntityList += "/// <param name=\"" + classNameAttribute + "PivotList\">" + className + "PivotList to assemble.</param>\n";
                    methodeSourceToEntityList += "/// <returns> list of " + className + " result.</returns>\n";
                    methodeSourceToEntityList += "public static List<" + className + "> To" + className + "List(this List<" + className + "Pivot" + "> " + classNameAttribute + "Pivot" + "List" + ")\n{\n" + convertListSourceBis + "\n}";

                    string regionToEntity = "#region TO ENTITY " + "\n" + methodeSourceToEntity + "\n" + methodeSourceToEntityList + "\n" + " #endregion\n";

                    string commentAssembler = string.Empty;
                    commentAssembler += "/// <summary>\n";
                    commentAssembler += "/// The " + className + " assembler class.\n";
                    commentAssembler += "/// </summary>";
                    string classSoureAssombler = usingAssomblerSource + "\n" + "namespace " + nameSpaceService + "." + folderAssembler + "\n{\n " + commentAssembler + "\n" + "public static class " + className + "Assembler\n{\n " + regionToPivot + "\n\n" + regionToEntity + " }\n}";
                    Directory.CreateDirectory(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + homeModel.FolderName + "/" + folderAssembler));
                    System.IO.File.WriteAllText(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + homeModel.FolderName + "/" + folderAssembler + "/" + className + folderAssembler + ".cs"), classSoureAssombler);

                    #endregion

                    #region REQUEST
                    string usingRequestSource = "using " + nameSpaceService + "." + folderPivot + ";\nusing " + nameSpaceService + "." + folderPivot + ".Enum" + ";\nusing System;\nusing System.Collections.Generic;\n\n";

                    string attributesRequestSource = string.Empty;
                    attributesRequestSource += "/// <summary>\n";
                    attributesRequestSource += "/// Gets or Sets The  " + className + "Pivot requested.\n";
                    attributesRequestSource += "/// </summary>\n";
                    attributesRequestSource += "public " + className + "Pivot " + className + "Pivot { get; set; }\n\n";

                    attributesRequestSource += "/// <summary>\n";
                    attributesRequestSource += "/// Gets or Sets The  Find " + className + "Enum.\n";
                    attributesRequestSource += "/// </summary>\n";
                    attributesRequestSource += "public Find" + className + "Pivot Find" + className + "Pivot { get; set; }\n";

                    string commentRequest = string.Empty;
                    commentRequest += "/// <summary>\n";
                    commentRequest += "/// Gets or Sets The  " + className + " request class.\n";
                    commentRequest += "/// </summary>";

                    string classRequestSource = usingRequestSource;
                    classRequestSource += "namespace " + nameSpaceService + "." + folderRequest + "{\n";
                    classRequestSource += commentRequest + "\n" + "public class " + className + folderRequest + "Pivot" + "{\n";
                    classRequestSource += attributesRequestSource;
                    classRequestSource += "}\n";
                    classRequestSource += "}";

                    Directory.CreateDirectory(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + homeModel.FolderName + "/" + folderRequest));
                    System.IO.File.WriteAllText(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + homeModel.FolderName + "/" + folderRequest + "/" + className + folderRequest + "Pivot" + ".cs"), classRequestSource);

                    #endregion

                    #region RESPONSE
                    string usingMessageSource = "using System;\nusing System.Collections.Generic;\nusing " + nameSpaceService + "." + folderPivot + ";\n\n";

                    string attributeMessageSource = string.Empty;
                    attributeMessageSource += "/// <summary>\n";
                    attributeMessageSource += "/// Gets or Sets The  " + className + "PivotList.\n";
                    attributeMessageSource += "/// </summary>\n";
                    attributeMessageSource += "public List<" + className + "Pivot> " + className + "PivotList { get; set; }\n\n";

                    attributeMessageSource += "/// <summary>\n";
                    attributeMessageSource += "/// Gets or Sets The  " + className + "Pivot.\n";
                    attributeMessageSource += "/// </summary>\n";
                    attributeMessageSource += "public " + className + "Pivot " + className + "Pivot { get; set; }\n\n";

                    string commentResponse = string.Empty;
                    commentResponse += "/// <summary>\n";
                    commentResponse += "/// The " + className + " response class.\n";
                    commentResponse += "/// </summary>\n";

                    string classMessageSource = usingMessageSource;
                    classMessageSource += "namespace " + nameSpaceService + "." + folderMessage + "{\n";
                    classMessageSource += commentResponse + "public class " + className + folderMessage + "Pivot" + "{\n";
                    classMessageSource += attributeMessageSource;
                    classMessageSource += "}\n";
                    classMessageSource += "}";

                    Directory.CreateDirectory(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + homeModel.FolderName + "/" + folderMessage));
                    System.IO.File.WriteAllText(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + homeModel.FolderName + "/" + folderMessage + "/" + className + folderMessage + "Pivot" + ".cs"), classMessageSource);
                    #endregion

                    #region INTERFACE

                    string usingInterfaceSource = "using System;\nusing System.Collections.Generic;\nusing " + nameSpaceService + "." + folderRequest + ";using " + nameSpaceService + "." + folderMessage + ";\n\n";
                    string methodesInterfaceSources = string.Empty;

                    methodesInterfaceSources += "/// <summary>\n";
                    methodesInterfaceSources += "/// Create " + className + "Pivot.\n";
                    methodesInterfaceSources += "/// </summary>\n";
                    methodesInterfaceSources += "/// <param name=\"" + classNameAttribute + folderRequest + "Pivot\"> The " + className + folderRequest + " Pivot that content " + className + "Pivot to add.</param>\n";
                    methodesInterfaceSources += "/// <returns>The " + className + folderMessage + "Pivot result with the " + className + "Pivot added.</returns>\n";
                    methodesInterfaceSources += className + folderMessage + "Pivot" + " Create" + className + "(" + className + folderRequest + "Pivot" + " " + (classNameAttribute + folderRequest + "Pivot") + ");\n\n";

                    methodesInterfaceSources += "/// <summary>\n";
                    methodesInterfaceSources += "/// Update " + className + "Pivot.\n";
                    methodesInterfaceSources += "/// </summary>\n";
                    methodesInterfaceSources += "/// <param name=\"" + classNameAttribute + folderRequest + "Pivot\"> The " + className + folderRequest + " Pivot that content " + className + "Pivot to update.</param>\n";
                    methodesInterfaceSources += "void" + " Update" + className + "(" + className + folderRequest + "Pivot" + " " + (classNameAttribute + folderRequest + "Pivot") + ");\n\n";

                    methodesInterfaceSources += "/// <summary>\n";
                    methodesInterfaceSources += "/// Delete " + className + "Pivot.\n";
                    methodesInterfaceSources += "/// </summary>\n";
                    methodesInterfaceSources += "/// <param name=\"" + classNameAttribute + folderRequest + "Pivot\"> The " + className + folderRequest + " Pivot that content " + className + "Pivot to remove.</param>\n";
                    methodesInterfaceSources += "void" + " Delete" + className + "(" + className + folderRequest + "Pivot" + " " + (classNameAttribute + folderRequest + "Pivot") + ");\n\n";

                    methodesInterfaceSources += "/// <summary>\n";
                    methodesInterfaceSources += "/// Get " + className + " list\n";
                    methodesInterfaceSources += "/// </summary>\n";
                    methodesInterfaceSources += "/// <returns>Response result.</returns>\n";
                    methodesInterfaceSources += className + folderMessage + "Pivot GetAll" + className + "();\n\n";

                    methodesInterfaceSources += "/// <summary>\n";
                    methodesInterfaceSources += "/// Search " + className + ".\n";
                    methodesInterfaceSources += "/// </summary>\n";
                    methodesInterfaceSources += "/// <param name=\"" + classNameAttribute + folderRequest + "Pivot\"> The " + className + folderRequest + " Pivot that content " + className + "Pivot to remove.</param>\n";
                    methodesInterfaceSources += "/// <returns>Response Result.</returns>\n";
                    methodesInterfaceSources += className + folderMessage + "Pivot Find" + className + "(" + className + folderRequest + "Pivot " + classNameAttribute + folderRequest + "Pivot);\n\n";

                    string commentInterface = string.Empty;
                    commentInterface += "/// <summary>\n";
                    commentInterface += "/// The " + className + " interface.\n";
                    commentInterface += "/// </summary>\n";

                    string interfaceSource = usingInterfaceSource;
                    interfaceSource += "namespace " + nameSpaceService + "." + folderInterface + "{\n";
                    interfaceSource += commentInterface + "public interface IService" + className + "{\n";
                    interfaceSource += methodesInterfaceSources;
                    interfaceSource += "}\n";
                    interfaceSource += "}";

                    Directory.CreateDirectory(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + homeModel.FolderName + "/" + folderInterface));
                    System.IO.File.WriteAllText(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + homeModel.FolderName + "/" + folderInterface + "/IService" + className + ".cs"), interfaceSource);

                    #endregion

                    #region ENUM SEARCH

                    string searchNumSources = string.Empty;
                    searchNumSources += "namespace " + nameSpaceService + "." + folderPivot + ".Enum\n{\n";
                    searchNumSources += "/// <summary>\n";
                    searchNumSources += "/// The Search " + className + " Enum.\n";
                    searchNumSources += "/// </summary>\n";
                    searchNumSources += "public enum Find" + className + "Pivot\n{\n";
                    searchNumSources += "/// <summary>\n";
                    searchNumSources += "/// The " + className + " Id.\n";
                    searchNumSources += "/// </summary>\n";
                    searchNumSources += className + "Id";
                    searchNumSources += "\n}\n}";

                    System.IO.Directory.CreateDirectory(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + homeModel.FolderName + "/" + folderPivot + "/Enum"));
                    System.IO.File.WriteAllText(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + homeModel.FolderName + "/" + folderPivot + "/Enum/Find" + className + "Pivot.cs"), searchNumSources);

                    #endregion

                    #region SERVICE CLASSE
                    string usingServiceSource = "using System;\nusing System.Collections.Generic;\nusing System.Linq;\nusing " + nameSpaceService + "." + folderRequest + ";\nusing " + nameSpaceService + "." + folderMessage + ";\nusing " + nameSpaceService + "." + folderInterface + ";\nusing " + nameSpaceServiceFolder + "." + unitOfWorkFolder + ";\nusing " + nameSpaceService + "." + folderAssemblerApi + ";\nusing " + nameSpaceEntity + ";\nusing " + nameSpaceService + "." + folderPivot + ";\nusing " + nameSpaceService + "." + folderPivot + ".Enum;\n\n";

                    string attributesServiceSources = string.Empty;
                    attributesServiceSources += "/// <summary>\n";
                    attributesServiceSources += "/// The " + unitOfWorkFolder + " instance.\n";
                    attributesServiceSources += "/// </summary>\n";
                    attributesServiceSources += "private I" + unitOfWorkFolder + " " + unitOfWorkFolder + ";\n\n";

                    string addMethodesServiceSources = string.Empty;
                    addMethodesServiceSources += "if(" + classNameAttribute + folderRequest + "Pivot == null)\n{\n throw new Exception(\"The request pivot is null.\");\n}\n";
                    addMethodesServiceSources += className + " " + classNameAttribute + " = " + classNameAttribute + folderRequest + "Pivot" + "." + className + "Pivot" + ".To" + className + "();\n";
                    addMethodesServiceSources += unitOfWorkFolder + "." + className + "Repository" + ".Insert(" + classNameAttribute + ");\n";
                    addMethodesServiceSources += unitOfWorkFolder + ".Save();\n";
                    addMethodesServiceSources += "return new " + className + folderMessage + "Pivot()\n{\n " + className + "Pivot = " + classNameAttribute + ".ToPivot()\n};";

                    string updateMethodesServiceSources = string.Empty;
                    updateMethodesServiceSources += "if(" + classNameAttribute + folderRequest + "Pivot == null)\n{\n throw new Exception(\"The request pivot is null.\");\n}\n";
                    if (hasKey)
                    {
                        PropertyInfo primaryKeyAttribute = Type.GetType(typeName).GetProperties().First(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Any());
                        updateMethodesServiceSources += className + " " + classNameAttribute + " = " + unitOfWorkFolder + "." + className + "Repository.GetByID(" + classNameAttribute + folderRequest + "Pivot." + className + "Pivot." + primaryKeyAttribute.Name + ");";
                    }
                    else
                    {
                        updateMethodesServiceSources += "//NO PRIMARY KEY IN YOUR CLASSE. PLEASE CORRECT THE ENTITY CLASS AND TRY TO GENERATE.\n";
                    }
                    updateMethodesServiceSources += "\n" + unitOfWorkFolder + "." + className + "Repository.DetachObject(" + classNameAttribute + ");\n";
                    updateMethodesServiceSources += unitOfWorkFolder + "." + className + "Repository.Update(" + classNameAttribute + folderRequest + "Pivot." + className + "Pivot.To" + className + "());\n";
                    updateMethodesServiceSources += unitOfWorkFolder + ".Save();\n";

                    string deleteMethodesServiceSources = string.Empty;
                    deleteMethodesServiceSources += "if(" + classNameAttribute + folderRequest + "Pivot == null)\n{\n throw new Exception(\"The request pivot is null.\");\n}\n";
                    if (hasKey)
                    {
                        PropertyInfo primaryKeyAttribute = Type.GetType(typeName).GetProperties().First(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Any());
                        deleteMethodesServiceSources += className + " " + classNameAttribute + " = " + unitOfWorkFolder + "." + className + "Repository.GetByID(" + classNameAttribute + folderRequest + "Pivot." + className + "Pivot." + primaryKeyAttribute.Name + ");\n";
                    }
                    else
                    {
                        deleteMethodesServiceSources += "//NO PRIMARY KEY IN YOUR CLASSE. PLEASE CORRECT THE ENTITY CLASS AND TRY TO GENERATE.\n";
                    }
                    deleteMethodesServiceSources += classNameAttribute + ".Deleted = true;\n";
                    deleteMethodesServiceSources += unitOfWorkFolder + ".Save();\n";

                    string listMethodeServiceSources = string.Empty;
                    listMethodeServiceSources += "return new " + className + folderMessage + "Pivot()\n{\n " + className + "PivotList = " + unitOfWorkFolder + "." + className + "Repository.Get().ToList().ToPivotList() };\n";

                    string findMethodeServiceSources = string.Empty;
                    findMethodeServiceSources += "if(" + classNameAttribute + folderRequest + "Pivot == null)\n{\n throw new Exception(\"The request pivot is null.\");\n}\n";
                    findMethodeServiceSources += "List<" + className + "Pivot> results = new List<" + className + "Pivot>();\n";
                    findMethodeServiceSources += className + "Pivot result = new " + className + "Pivot();\n";
                    findMethodeServiceSources += "switch (" + classNameAttribute + folderRequest + "Pivot.Find" + className + "Pivot)\n{\n";
                    findMethodeServiceSources += "case Find" + className + "Pivot." + className + "Id:\n";

                    if (hasKey)
                    {
                        PropertyInfo primaryKeyAttribute = Type.GetType(typeName).GetProperties().First(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Any());
                        findMethodeServiceSources += "result = " + unitOfWorkFolder + "." + className + "Repository.GetById(" + classNameAttribute + folderRequest + "Pivot." + className + "Pivot." + primaryKeyAttribute.Name + ")?.ToPivot();\n";
                    }
                    else
                    {
                        findMethodeServiceSources += "//NO PRIMARY KEY IN YOUR CLASSE. PLEASE CORRECT THE ENTITY CLASS AND TRY TO GENERATE.\n";
                        findMethodeServiceSources += "//result = " + unitOfWorkFolder + "." + className + "Repository.GetById(    ).ToPivot();\n";
                    }

                    findMethodeServiceSources += "break;\n}\n";
                    findMethodeServiceSources += "return new " + className + folderMessage + "Pivot()\n{\n";
                    findMethodeServiceSources += className + "PivotList = results,\n";
                    findMethodeServiceSources += className + "Pivot = result\n";
                    findMethodeServiceSources += "};\n";

                    string consructorServiceSources = string.Empty;
                    consructorServiceSources += "/// <summary>\n";
                    consructorServiceSources += "/// Constructor to create instance of the " + unitOfWorkFolder + ".\n";
                    consructorServiceSources += "/// </summary>\n";
                    consructorServiceSources += "/// <param name=\"injected" + unitOfWorkFolder + "\">the injected " + unitOfWorkFolder + " to instance " + unitOfWorkFolder + " attribute.</param>\n";
                    consructorServiceSources += "public Service" + className + "(I" + unitOfWorkFolder + " injected" + unitOfWorkFolder + ")\n{\n if(injected" + unitOfWorkFolder + " == null){\n throw new ArgumentNullException(\"unitOfWork\");\n}else\n{\n " + unitOfWorkFolder + " = injected" + unitOfWorkFolder + ";\n}\n}\n";

                    string methodesServiceSources = string.Empty;
                    methodesServiceSources += "/// <summary>\n";
                    methodesServiceSources += "/// Create new " + className + ".\n";
                    methodesServiceSources += "/// </summary>\n";
                    methodesServiceSources += "/// <param name=\"" + classNameAttribute + folderRequest + "Pivot\">The " + className + " " + folderRequest + " Pivot to add.</param>\n";
                    methodesServiceSources += "/// <returns>" + className + " " + folderMessage + " Pivot created.</returns>\n";
                    methodesServiceSources += "public " + className + folderMessage + "Pivot" + " Create" + className + "(" + className + folderRequest + "Pivot" + " " + (classNameAttribute + folderRequest + "Pivot") + ")\n{\n " + addMethodesServiceSources + "\n}\n\n";

                    methodesServiceSources += "/// <summary>\n";
                    methodesServiceSources += "/// Change " + className + " values.\n";
                    methodesServiceSources += "/// </summary>\n";
                    methodesServiceSources += "/// <param name=\"" + classNameAttribute + folderRequest + "Pivot\">The " + className + " " + folderRequest + " Pivot to change.</param>\n";
                    methodesServiceSources += "public void Update" + className + "(" + className + folderRequest + "Pivot" + " " + (classNameAttribute + folderRequest + "Pivot") + ")\n{\n " + updateMethodesServiceSources + "\n}\n\n";

                    methodesServiceSources += "/// <summary>\n";
                    methodesServiceSources += "/// Remove " + className + ".\n";
                    methodesServiceSources += "/// </summary>\n";
                    methodesServiceSources += "/// <param name=\"" + classNameAttribute + folderRequest + "Pivot\">The " + className + " " + folderRequest + " Pivot to remove.</param>\n";
                    methodesServiceSources += "public void Delete" + className + "(" + className + folderRequest + "Pivot" + " " + (classNameAttribute + folderRequest + "Pivot") + ")\n{\n " + deleteMethodesServiceSources + "\n}\n\n";

                    methodesServiceSources += "/// <summary>\n";
                    methodesServiceSources += "/// Get the list of the " + className + ".\n";
                    methodesServiceSources += "/// </summary>\n";
                    methodesServiceSources += "/// <returns>" + className + " " + folderMessage + " Pivot response.</returns>\n";
                    methodesServiceSources += "public " + className + folderMessage + "Pivot" + " GetAll" + className + "()\n{\n " + listMethodeServiceSources + "\n}\n\n";

                    methodesServiceSources += "/// <summary>\n";
                    methodesServiceSources += "/// Search " + className + " by id.\n";
                    methodesServiceSources += "/// </summary>\n";
                    methodesServiceSources += "/// <param name=\"" + classNameAttribute + folderRequest + "Pivot\">The " + className + " " + folderRequest + " Pivot to retrive.</param>\n";
                    methodesServiceSources += "/// <returns>" + className + " " + folderMessage + " Pivot response.</returns>\n";
                    methodesServiceSources += "public " + className + folderMessage + "Pivot Find" + className + "(" + className + folderRequest + "Pivot " + classNameAttribute + folderRequest + "Pivot){\n " + findMethodeServiceSources + "}\n";

                    string commentClasse = string.Empty;
                    commentClasse += "/// <summary>\n";
                    commentClasse += "/// The " + className + " service class.\n";
                    commentClasse += "/// </summary>";

                    string serviceclassSource = usingServiceSource;
                    serviceclassSource += "namespace " + nameSpaceService + "{\n";
                    serviceclassSource += commentClasse + "\npublic class " + "Service" + className + " : IService" + className + "{\n";

                    serviceclassSource += attributesServiceSources;

                    serviceclassSource += "#region contructors\n";
                    serviceclassSource += consructorServiceSources;
                    serviceclassSource += "#endregion\n\n";

                    serviceclassSource += "#region public methods\n";
                    serviceclassSource += methodesServiceSources;
                    serviceclassSource += "#endregion\n\n";

                    serviceclassSource += "}\n";
                    serviceclassSource += "}";

                    Directory.CreateDirectory(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + homeModel.FolderName));
                    System.IO.File.WriteAllText(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + homeModel.FolderName + "/" + "Service" + className + ".cs"), serviceclassSource);
                    #endregion

                    #region UNIT OF WORK
                    //INTERFACE :
                    string usingUnitOfWorkInterfaceSource = "using System;\nusing System.Collections.Generic;\nusing System.Linq;\nusing System.Text;\nusing System.Threading.Tasks;\nusing " + nameSpaceDal + "." + folderInterfaceDal + ";\nusing " + nameSpaceEntity + ";\n\n";
                    string methodesUnitOfWorkInterfaceSource = "IGenericRepository<" + className + "> " + className + "Repository { get; }";
                    string UnitOfWorkInterfaceSource = string.Empty;

                    if (System.IO.File.Exists(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + unitOfWorkFolder + "/" + "I" + unitOfWorkFolder + ".cs")))
                    {
                        methodesUnitOfWorkInterfaceSource += "\n//IMETHODE\n";
                        string iUnitCode = System.IO.File.ReadAllText(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + unitOfWorkFolder + "/" + "I" + unitOfWorkFolder + ".cs"));
                        if (iUnitCode.Contains("//IMETHODE"))
                            UnitOfWorkInterfaceSource = iUnitCode.Replace("//IMETHODE", methodesUnitOfWorkInterfaceSource);
                    }
                    else
                    {
                        methodesUnitOfWorkInterfaceSource += "\n//IMETHODE\n";
                        methodesUnitOfWorkInterfaceSource += "void Save();\n";
                        UnitOfWorkInterfaceSource = usingUnitOfWorkInterfaceSource + "namespace " + nameSpaceServiceFolder + "." + unitOfWorkFolder + "\n{\n" + "public interface I" + unitOfWorkFolder + " : IDisposable\n{\n" + methodesUnitOfWorkInterfaceSource + "\n}\n}\n";
                    }

                    Directory.CreateDirectory(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + unitOfWorkFolder));
                    System.IO.File.WriteAllText(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + unitOfWorkFolder + "/" + "I" + unitOfWorkFolder + ".cs"), UnitOfWorkInterfaceSource);

                    //LA CLASSE:
                    string usingUnitOfWorkClassSource = "using System;\nusing System.Collections.Generic;\nusing System.Linq;\nusing System.Text;\nusing System.Threading.Tasks;\nusing " + nameSpaceDal + "." + folderInterfaceDal + ";\nusing " + nameSpaceDal + "." + folderCoreDal + ";\nusing " + nameSpaceEntity + ";\nusing " + nameSpaceDal + "." + folderContextDal + ";\n\n";
                    string methodesUnitOfWorkClasseSource = string.Empty;
                    string UnitOfWorkIClasseSource = string.Empty;

                    if (System.IO.File.Exists(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + unitOfWorkFolder + "/" + unitOfWorkFolder + ".cs")))
                    {
                        string unitCode = System.IO.File.ReadAllText(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + unitOfWorkFolder + "/" + unitOfWorkFolder + ".cs"));
                        methodesUnitOfWorkClasseSource += "private IGenericRepository<" + className + "> " + "_" + className + "Repository;\n\n";
                        methodesUnitOfWorkClasseSource += "public IGenericRepository<" + className + "> " + className + "Repository\n{\n get{ return this._" + className + "Repository ?? (this._" + className + "Repository = new GenericRepository<" + className + ">(_context)); } \n}\n\n";
                        methodesUnitOfWorkClasseSource += "//IMETHODE\n";
                        if (unitCode.Contains("//IMETHODE"))
                            unitCode = unitCode.Replace("//IMETHODE", methodesUnitOfWorkClasseSource);
                        UnitOfWorkIClasseSource = unitCode;
                    }
                    else
                    {
                        methodesUnitOfWorkClasseSource += "private readonly OMSContext _context;\n\n";
                        methodesUnitOfWorkClasseSource += "private IGenericRepository<" + className + "> " + "_" + className + "Repository;\n\n";
                        methodesUnitOfWorkClasseSource += "public " + unitOfWorkFolder + "(OMSContext context)\n{\n this._context = context;\n}\n\n";
                        methodesUnitOfWorkClasseSource += "public IGenericRepository<" + className + "> " + className + "Repository\n{\n get{ return this._" + className + "Repository ?? (this._" + className + "Repository = new GenericRepository<" + className + ">(_context)); } \n}\n\n";
                        methodesUnitOfWorkClasseSource += "//IMETHODE\n";
                        UnitOfWorkIClasseSource = usingUnitOfWorkClassSource + "namespace " + nameSpaceServiceFolder + "." + unitOfWorkFolder + "\n{\n" + "public class " + unitOfWorkFolder + " : I" + unitOfWorkFolder + "\n{\n" + methodesUnitOfWorkClasseSource + "\n}\n}\n";
                    }

                    Directory.CreateDirectory(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + unitOfWorkFolder));
                    System.IO.File.WriteAllText(Server.MapPath("/Files/" + nameSpaceServiceFolder + "/" + unitOfWorkFolder + "/" + unitOfWorkFolder + ".cs"), UnitOfWorkIClasseSource);

                    #endregion

                    #endregion

                    #region WEB API SERVICE.

                    #region CLASS DTO 
                    string usingDtoSource = "using System;\nusing System.Collections.Generic;\n";
                    string proprsDtoSource = string.Empty;
                    foreach (var prop in props)
                    {
                        Type typeProp = prop.PropertyType;
                        if (Nullable.GetUnderlyingType(typeProp) != null)
                        {
                            typeProp = Nullable.GetUnderlyingType(typeProp);
                        }
                        if (typeProp.IsGenericType && (typeProp.GetGenericTypeDefinition() == typeof(List<>) || typeProp.GetGenericTypeDefinition() == typeof(ICollection<>)))
                        {
                            proprsDtoSource += "/// <summary>\n";
                            proprsDtoSource += "/// Gets or Sets The  " + prop.Name + ".\n";
                            proprsDtoSource += "/// </summary>\n";
                            proprsDtoSource += "public List<" + typeProp.GenericTypeArguments.FirstOrDefault().Name + folderDtoApi + "> " + prop.Name + " { get; set; }\n\n";

                            var nameSpace = typeProp.GetGenericArguments().FirstOrDefault().Namespace;
                            if (!usingDtoSource.Contains("using " + nameSpaceServiceApiFolder + "." + nameSpace.Split('.').LastOrDefault() + "." + folderDtoApi + ";\n"))
                                usingDtoSource += "using " + nameSpaceServiceApiFolder + "." + nameSpace.Split('.').LastOrDefault() + "." + folderDtoApi + ";\n";
                        }
                        else if (typeProp.IsPrimitive || typeProp == typeof(char) || typeProp == typeof(Char) || typeProp == typeof(long) || typeProp == typeof(ulong) || typeProp == typeof(short) || typeProp == typeof(ushort) || typeProp == typeof(int) || typeProp == typeof(byte) || typeProp == typeof(Byte) || typeProp == typeof(sbyte) || typeProp == typeof(sbyte) || typeProp == typeof(string) || typeProp == typeof(String) || typeProp == typeof(DateTime) || typeProp == typeof(float) || typeProp == typeof(float) || typeProp == typeof(Decimal) || typeProp == typeof(decimal))
                        {
                            StringBuilder sb = new StringBuilder();
                            using (StringWriter sw = new StringWriter(sb))
                            {
                                var expr = new CodeTypeReferenceExpression(typeProp);
                                var prov = new CSharpCodeProvider();
                                prov.GenerateCodeFromExpression(expr, sw, new CodeGeneratorOptions());
                            }

                            proprsDtoSource += "/// <summary>\n";
                            proprsDtoSource += "/// Gets or Sets The  " + prop.Name + ".\n";
                            proprsDtoSource += "/// </summary>\n";
                            proprsDtoSource += "public " + sb.ToString() + " " + prop.Name + " { get; set; }\n\n";
                        }
                        else if (typeProp.IsClass && typeProp != typeof(byte[]) && typeProp != typeof(string) && typeProp != typeof(String) && typeProp != typeof(DateTime) && typeProp != typeof(float) && typeProp != typeof(float) && typeProp != typeof(Decimal) && typeProp != typeof(decimal))
                        {
                            proprsDtoSource += "/// <summary>\n";
                            proprsDtoSource += "/// Gets or Sets The  " + prop.Name + ".\n";
                            proprsDtoSource += "/// </summary>\n";
                            proprsDtoSource += "public " + typeProp.Name + folderDtoApi + " " + prop.Name + " { get; set; }\n";

                            if (!usingDtoSource.Contains("using " + nameSpaceServiceApiFolder + "." + typeProp.Namespace.Split('.').LastOrDefault() + "." + folderDtoApi + ";\n"))
                                usingDtoSource += "using " + nameSpaceServiceApiFolder + "." + typeProp.Namespace.Split('.').LastOrDefault() + "." + folderDtoApi + ";\n";
                        }
                        else if (typeProp.IsArray && typeProp != typeof(string) && typeProp != typeof(String) && typeProp != typeof(DateTime) && typeProp != typeof(float) && typeProp != typeof(float) && typeProp != typeof(Decimal) && typeProp != typeof(decimal))
                        {
                            proprsDtoSource += "/// <summary>\n";
                            proprsDtoSource += "/// Gets or Sets The  " + prop.Name + ".\n";
                            proprsDtoSource += "/// </summary>\n";
                            proprsDtoSource += "public " + typeProp.Name + " " + prop.Name + " { get; set; }\n\n";
                        }
                    }
                    string commentDto = string.Empty;
                    commentDto += "/// <summary>\n";
                    commentDto += "/// The " + className + " dto class.\n";
                    commentDto += "/// </summary>";
                    string classDtoSource = usingDtoSource + "\n" + "namespace " + nameSpaceServiceApi + "." + folderDtoApi + "\n{\n" + commentDto + "\n public class " + className + folderDtoApi + "\n{\n " + proprsDtoSource + "}\n}";
                    Directory.CreateDirectory(Server.MapPath("/Files/" + nameSpaceServiceApiFolder + "/" + homeModel.FolderName + "/" + folderDtoApi));
                    System.IO.File.WriteAllText(Server.MapPath("/Files/" + nameSpaceServiceApiFolder + "/" + homeModel.FolderName + "/" + folderDtoApi + "/" + className + folderDtoApi + ".cs"), classDtoSource);

                    #endregion

                    #region ASSEMBLER

                    //ASSEMBLER CLASSE PIVOT TO DTO
                    string usingAssomblerApiSource = "using System;\nusing System.Collections.Generic;\nusing System.Linq;\nusing OMS.Socle.Framework.Util;\nusing " + nameSpaceServiceApi + "." + folderDtoApi + ";\nusing " + nameSpaceService + "." + folderPivot + ";\nusing " + nameSpaceServiceApi + "." + folderRequestApi + ";\nusing " + nameSpaceService + "." + folderRequest + ";\nusing " + nameSpaceServiceApi + "." + folderMessageApi + ";\nusing " + nameSpaceService + "." + folderMessage + ";\nusing " + nameSpaceServiceApi + "." + folderDtoApi + ".Enum;\nusing " + nameSpaceService + "." + folderPivot + ".Enum;\n";
                    string attributesApiSource = string.Empty;

                    foreach (var prop in props)
                    {
                        Type typeProp = prop.PropertyType;
                        if (Nullable.GetUnderlyingType(typeProp) != null)
                        {
                            typeProp = Nullable.GetUnderlyingType(typeProp);
                        }

                        if (typeProp.IsGenericType && (typeProp.GetGenericTypeDefinition() == typeof(List<>) || typeProp.GetGenericTypeDefinition() == typeof(ICollection<>)))
                        {
                            attributesApiSource += prop.Name + " = " + classNameAttribute + "Pivot" + "." + prop.Name + "?.To" + folderDtoApi + "List()" + ",\n";
                            var nameSpace = typeProp.GetGenericArguments().FirstOrDefault().Namespace;
                            if (!usingAssomblerApiSource.Contains("using " + nameSpaceServiceApiFolder + "." + nameSpace.Split('.').LastOrDefault() + "." + folderAssemblerApi + ";\n"))
                            {
                                if (nameSpace.Contains(folderPivot))
                                {
                                    usingAssomblerApiSource += "using " + nameSpaceServiceApiFolder + "." + nameSpace.Split('.').LastOrDefault() + "." + folderAssemblerApi + ";\n";
                                }
                            }
                        }
                        else if (typeProp.IsPrimitive || typeProp == typeof(char) || typeProp == typeof(Char) || typeProp == typeof(long) || typeProp == typeof(ulong) || typeProp == typeof(short) || typeProp == typeof(ushort) || typeProp == typeof(int) || typeProp == typeof(byte) || typeProp == typeof(Byte) || typeProp == typeof(sbyte) || typeProp == typeof(sbyte) || typeProp == typeof(string) || typeProp == typeof(String) || typeProp == typeof(DateTime) || typeProp == typeof(float) || typeProp == typeof(float) || typeProp == typeof(Decimal) || typeProp == typeof(decimal))
                        {
                            attributesApiSource += prop.Name + " = " + classNameAttribute + "Pivot" + "." + prop.Name + ",\n";
                        }
                        else if (typeProp.IsClass && typeProp != typeof(byte[]) && typeProp != typeof(string) && typeProp != typeof(String) && typeProp != typeof(DateTime) && typeProp != typeof(float) && typeProp != typeof(float) && typeProp != typeof(Decimal) && typeProp != typeof(decimal))
                        {
                            attributesApiSource += prop.Name + " = " + classNameAttribute + "Pivot" + "." + prop.Name + "?.To" + folderDtoApi + "(),\n";
                            if (!usingAssomblerApiSource.Contains("using " + nameSpaceServiceApiFolder + "." + typeProp.Namespace.Split('.').LastOrDefault() + "." + folderAssemblerApi + ";\n"))
                                usingAssomblerApiSource += "using " + nameSpaceServiceApiFolder + "." + typeProp.Namespace.Split('.').LastOrDefault() + "." + folderAssemblerApi + ";\n";
                        }
                        else if (typeProp.IsArray && typeProp != typeof(string) && typeProp != typeof(String) && typeProp != typeof(DateTime) && typeProp != typeof(float) && typeProp != typeof(float) && typeProp != typeof(Decimal) && typeProp != typeof(decimal))
                        {
                            attributesApiSource += prop.Name + " = " + classNameAttribute + "Pivot" + "." + prop.Name + ",\n";
                        }

                    }
                    string convertListApiSource = "return " + classNameAttribute + "PivotList?.Select(x => x?.ToDto()).ToList();\n";
                    string attributesApiSourceBis = string.Empty;
                    foreach (var prop in props)
                    {
                        Type typeProp = prop.PropertyType;
                        if (Nullable.GetUnderlyingType(typeProp) != null)
                        {
                            typeProp = Nullable.GetUnderlyingType(typeProp);
                        }
                        if (typeProp.IsGenericType && (typeProp.GetGenericTypeDefinition() == typeof(List<>) || typeProp.GetGenericTypeDefinition() == typeof(ICollection<>)))
                        {
                            attributesApiSourceBis += prop.Name + " = " + classNameAttribute + folderDtoApi + "." + prop.Name + "?." + "ToPivotList(),\n";
                        }
                        else if (typeProp.IsPrimitive || typeProp == typeof(char) || typeProp == typeof(Char) || typeProp == typeof(long) || typeProp == typeof(ulong) || typeProp == typeof(short) || typeProp == typeof(ushort) || typeProp == typeof(int) || typeProp == typeof(byte) || typeProp == typeof(Byte) || typeProp == typeof(sbyte) || typeProp == typeof(sbyte) || typeProp == typeof(string) || typeProp == typeof(String) || typeProp == typeof(DateTime) || typeProp == typeof(float) || typeProp == typeof(float) || typeProp == typeof(Decimal) || typeProp == typeof(decimal))
                        {
                            attributesApiSourceBis += prop.Name + " = " + classNameAttribute + folderDtoApi + "." + prop.Name + ",\n";
                        }
                        else if (typeProp.IsClass && typeProp != typeof(byte[]) && typeProp != typeof(string) && typeProp != typeof(String) && typeProp != typeof(DateTime) && typeProp != typeof(float) && typeProp != typeof(float) && typeProp != typeof(Decimal) && typeProp != typeof(decimal))
                        {
                            attributesApiSourceBis += prop.Name + " = " + classNameAttribute + folderDtoApi + "." + prop.Name + "?.ToPivot(),\n";
                        }
                        else if (typeProp.IsArray && typeProp != typeof(string) && typeProp != typeof(String) && typeProp != typeof(DateTime) && typeProp != typeof(float) && typeProp != typeof(float) && typeProp != typeof(Decimal) && typeProp != typeof(decimal))
                        {
                            attributesApiSourceBis += prop.Name + " = " + classNameAttribute + folderDtoApi + "." + prop.Name + ",\n";
                        }
                    }
                    string convertListApiSourceBis = "return " + classNameAttribute + folderDtoApi + "List?.Select(x => x?.ToPivot()).ToList();\n";
                    string methodeToDtoApiSource = string.Empty;
                    methodeToDtoApiSource += "/// <summary>\n";
                    methodeToDtoApiSource += "///    From " + className + " Pivot To " + className + " Dto.\n";
                    methodeToDtoApiSource += "/// </summary>\n";
                    methodeToDtoApiSource += "/// <param name=\"" + classNameAttribute + "Pivot\">" + classNameAttribute + " pivot to assemble.</param>\n";
                    methodeToDtoApiSource += "/// <returns>" + className + "Dto" + " result.</returns>\n";
                    methodeToDtoApiSource += "public static " + className + folderDtoApi + " To" + folderDtoApi + "(this " + className + "Pivot" + " " + classNameAttribute + "Pivot" + ")\n{\n if(" + classNameAttribute + "Pivot == null)\n{\n return null;\n}\n else \n{\n  return new " + className + folderDtoApi + "(){\n" + attributesApiSource + "};\n}\n}\n";

                    string methodeToDtoApiSourceList = string.Empty;
                    methodeToDtoApiSourceList += "/// <summary>\n";
                    methodeToDtoApiSourceList += "///    From " + className + " pivot list to " + className + " dto list.\n";
                    methodeToDtoApiSourceList += "/// </summary>\n";
                    methodeToDtoApiSourceList += "/// <param name=\"" + classNameAttribute + "PivotList\">" + classNameAttribute + " pivot liste to assemble.</param>\n";
                    methodeToDtoApiSourceList += "/// <returns>" + className + "dto" + " result.</returns>\n";
                    methodeToDtoApiSourceList += "public static List<" + className + folderDtoApi + "> To" + folderDtoApi + "List(this List<" + className + "Pivot" + "> " + classNameAttribute + "PivotList" + ")\n{\n " + convertListApiSource + "\n}\n";
                    string regionToDto = "#region TODTO\n " + methodeToDtoApiSource + "\n" + methodeToDtoApiSourceList + " \n#endregion";

                    string methodeToPivotApiSource = string.Empty;
                    methodeToPivotApiSource += "/// <summary>\n";
                    methodeToPivotApiSource += "///    From " + className + " dto To " + className + " pivot.\n";
                    methodeToPivotApiSource += "/// </summary>\n";
                    methodeToPivotApiSource += "/// <param name=\"" + classNameAttribute + "Dto\">" + classNameAttribute + " dto to assemble.</param>\n";
                    methodeToPivotApiSource += "/// <returns>" + className + "pivot" + " result.</returns>\n";
                    methodeToPivotApiSource += "public static " + className + "Pivot" + " ToPivot(this " + className + folderDtoApi + " " + classNameAttribute + folderDtoApi + ")\n{\n if(" + classNameAttribute + folderDtoApi + " == null)\n{\nreturn null; \n}\n else\n{\n return new " + className + "Pivot" + "(){\n" + attributesApiSourceBis + "};\n\n}\n}\n";

                    string methodeToPivotApiSourceList = string.Empty;
                    methodeToPivotApiSourceList += "/// <summary>\n";
                    methodeToPivotApiSourceList += "///    From " + className + "pivot list To " + className + " pivot list.\n";
                    methodeToPivotApiSourceList += "/// </summary>\n";
                    methodeToPivotApiSourceList += "/// <param name=\"" + classNameAttribute + "PivotList\">" + classNameAttribute + " dto list to assemble.</param>\n";
                    methodeToPivotApiSourceList += "/// <returns>" + className + "Pivot list" + " result.</returns>\n";
                    methodeToPivotApiSourceList += "public static List<" + className + "Pivot> ToPivotList(this List<" + className + folderDtoApi + "> " + classNameAttribute + folderDtoApi + "List)\n{\n" + convertListApiSourceBis + "\n}\n";
                    string regionToPivoApi = "#region TO PIVOT\n " + methodeToPivotApiSource + "\n" + methodeToPivotApiSourceList + " \n#endregion";

                    //ASSEMBLER LA CLASSE REQUEST:
                    string methodesApiRequestSource = string.Empty;
                    methodesApiRequestSource += "/// <summary>\n";
                    methodesApiRequestSource += "///    From " + className + " " + folderRequestApi + " to " + className + " " + folderRequest + " pivot.\n";
                    methodesApiRequestSource += "/// </summary>\n";
                    methodesApiRequestSource += "/// <param name=\"" + className + folderRequestApi + "\"></param>\n";
                    methodesApiRequestSource += "/// <returns>" + className + " " + folderRequest + " pivot result.</returns>\n";
                    methodesApiRequestSource += "public static " + className + folderRequest + "Pivot" + " ToPivot(this " + className + folderRequestApi + " " + classNameAttribute + folderRequestApi + ")\n{\n return new " + className + folderRequestApi + "Pivot" + "(){\n" + className + "Pivot = " + classNameAttribute + folderRequestApi + "." + className + folderDtoApi + "?.ToPivot(),\n Find" + className + "Pivot = Utility.EnumToEnum<Find" + className + folderDtoApi + ", Find" + className + "Pivot>(" + classNameAttribute + folderRequestApi + "." + "Find" + className + folderDtoApi + ")\n};\n}";
                    string regionRequestAssembler = "#region REQUEST ASSEMBLERT\n " + methodesApiRequestSource + "\n" + " #endregion";

                    //ASSEMBLER CLASSES RESPONSE : 
                    string attributesApiResponseSource = className + folderDtoApi + "List = " + classNameAttribute + folderMessage + "Pivot" + "." + className + "PivotList" + "?." + "To" + folderDtoApi + "List(),\n";
                    attributesApiResponseSource += className + folderDtoApi + " = " + classNameAttribute + folderMessage + "Pivot" + "." + className + "Pivot" + "?." + "To" + folderDtoApi + "(),\n";
                    string methodesApiResponseSource = string.Empty;
                    methodesApiResponseSource += "/// <summary>\n";
                    methodesApiResponseSource += "/// From " + className + " " + folderMessage + " pivot to " + className + " " + folderMessageApi + ".\n";
                    methodesApiResponseSource += "/// </summary>\n";
                    methodesApiResponseSource += "/// <param name=\"" + className + folderMessage + "\">" + className + " " + folderMessage + " pivot to assemble.</param>\n";
                    methodesApiResponseSource += "/// <returns>" + className + " " + folderMessageApi + " result.</returns>\n";
                    methodesApiResponseSource += "public static " + className + folderMessageApi + " To" + folderMessageApi + "(this " + className + folderMessage + "Pivot" + " " + classNameAttribute + folderMessage + "Pivot" + ")\n{\n if(" + classNameAttribute + folderMessage + "Pivot == null)\n{\nreturn null;}else{ return new " + className + folderMessageApi + "()\n{\n" + attributesApiResponseSource + "};\n}\n}\n";
                    string regionResponseAssembler = "#region MESSAGE ASSEMBLER\n " + methodesApiResponseSource + "\n" + " #endregion\n";

                    string commentAssemblerApi = string.Empty;
                    commentAssemblerApi += "/// <summary>\n";
                    commentAssemblerApi += "/// The " + className + " assembler class.\n";
                    commentAssemblerApi += "/// </summary>\n";
                    string classSoureApiPssombler = usingAssomblerApiSource + "\n" + "namespace " + nameSpaceServiceApi + "." + folderAssemblerApi + "\n{\n" + commentAssemblerApi + "public static class " + className + folderAssemblerApi + "\n{\n " + regionToDto + "\n\n" + regionToPivoApi + "\n\n" + regionRequestAssembler + "\n\n" + regionResponseAssembler + "\n}\n}";
                    Directory.CreateDirectory(Server.MapPath("/Files/" + nameSpaceServiceApiFolder + "/" + homeModel.FolderName + "/" + folderAssemblerApi));
                    System.IO.File.WriteAllText(Server.MapPath("/Files/" + nameSpaceServiceApiFolder + "/" + homeModel.FolderName + "/" + folderAssemblerApi + "/" + className + folderAssemblerApi + ".cs"), classSoureApiPssombler);

                    #endregion

                    #region REQUEST
                    string usingRequestApiSource = "using System.Runtime.Serialization;\nusing System;\nusing System.Collections.Generic;\nusing " + nameSpaceServiceApi + "." + folderDtoApi + ";\nusing " + nameSpaceServiceApi + "." + folderDtoApi + ".Enum;\n\n";
                    string attributesRequestApiSource = string.Empty;

                    attributesRequestApiSource += "/// <summary>\n";
                    attributesRequestApiSource += "/// Gets or Sets The " + className + folderDtoApi + " requested.\n";
                    attributesRequestApiSource += "/// </summary>\n";
                    attributesRequestApiSource += "[DataMember]\n";
                    attributesRequestApiSource += "public " + className + folderDtoApi + " " + className + folderDtoApi + " { get; set; }\n\n";

                    attributesRequestApiSource += "/// <summary>\n";
                    attributesRequestApiSource += "/// Gets or sets The Find " + className + "Dto.\n";
                    attributesRequestApiSource += "/// </summary>\n";
                    attributesRequestApiSource += "[DataMember]\n";
                    attributesRequestApiSource += "public Find" + className + "Dto Find" + className + "Dto { get; set; }\n";

                    string commentRequestApi = string.Empty;
                    commentRequestApi += "/// <summary>\n";
                    commentRequestApi += "/// The " + className + " request class.\n";
                    commentRequestApi += "/// </summary>\n";

                    string classRequestApiSource = usingRequestApiSource;
                    classRequestApiSource += "namespace " + nameSpaceServiceApi + "." + folderRequestApi + "{\n";
                    classRequestApiSource += commentRequestApi + "[DataContract]\n" + "public class " + className + folderRequestApi + "{\n";
                    classRequestApiSource += attributesRequestApiSource;
                    classRequestApiSource += "}\n";
                    classRequestApiSource += "}";

                    Directory.CreateDirectory(Server.MapPath("/Files/" + nameSpaceServiceApiFolder + "/" + homeModel.FolderName + "/" + folderRequestApi));
                    System.IO.File.WriteAllText(Server.MapPath("/Files/" + nameSpaceServiceApiFolder + "/" + homeModel.FolderName + "/" + folderRequestApi + "/" + className + folderRequestApi + ".cs"), classRequestApiSource);

                    #endregion

                    #region ENUM SEARCH
                    string searchApiNumSources = string.Empty;
                    searchApiNumSources += "namespace " + nameSpaceServiceApi + "." + folderDtoApi + ".Enum\n{\n";
                    searchApiNumSources += "/// <summary>\n";
                    searchApiNumSources += "/// The Search " + className + " Enum.\n";
                    searchApiNumSources += "/// </summary>\n";
                    searchApiNumSources += "public enum Find" + className + "Dto\n{\n";
                    searchApiNumSources += "/// <summary>\n";
                    searchApiNumSources += "/// The " + className + " Id.\n";
                    searchApiNumSources += "/// </summary>\n";
                    searchApiNumSources += className + "Id";
                    searchApiNumSources += "\n}\n}";

                    System.IO.Directory.CreateDirectory(Server.MapPath("/Files/" + nameSpaceServiceApiFolder + "/" + homeModel.FolderName + "/" + folderDtoApi + "/Enum"));
                    System.IO.File.WriteAllText(Server.MapPath("/Files/" + nameSpaceServiceApiFolder + "/" + homeModel.FolderName + "/" + folderDtoApi + "/Enum/Find" + className + "Dto.cs"), searchApiNumSources);

                    #endregion

                    #region RESPONSE
                    string usingMessageApiSource = "using " + nameSpaceMessageClass + ";\nusing System.Runtime.Serialization;\nusing System;\nusing System.Collections.Generic;\nusing " + nameSpaceServiceApi + "." + folderDtoApi + ";\n\n";
                    string attributeMessageApiSource = string.Empty;
                    attributeMessageApiSource += "/// <summary>\n";
                    attributeMessageApiSource += "/// Gets or Sets The  " + className + folderDtoApi + "List.\n";
                    attributeMessageApiSource += "/// </summary>\n";
                    attributeMessageApiSource += "[DataMember]\npublic List<" + className + folderDtoApi + "> " + className + folderDtoApi + "List { get; set; }\n\n";

                    attributeMessageApiSource += "/// <summary>\n";
                    attributeMessageApiSource += "/// Gets or Sets The  " + className + folderDtoApi + ".\n";
                    attributeMessageApiSource += "/// </summary>\n";
                    attributeMessageApiSource += "[DataMember]\npublic " + className + folderDtoApi + " " + className + folderDtoApi + " { get; set; }\n";

                    string commentResponseApi = string.Empty;
                    commentResponseApi += "/// <summary>\n";
                    commentResponseApi += "///    The " + className + " message class.\n";
                    commentResponseApi += "/// </summary>\n";

                    string classMessageApiSource = usingMessageApiSource;
                    classMessageApiSource += "namespace " + nameSpaceServiceApi + "." + folderMessageApi + "{\n";
                    classMessageApiSource += commentResponseApi + "[DataContract]\npublic class " + className + folderMessageApi + " : " + classMessage + " {\n";
                    classMessageApiSource += attributeMessageApiSource;
                    classMessageApiSource += "}\n";
                    classMessageApiSource += "}";

                    System.IO.Directory.CreateDirectory(Server.MapPath("/Files/" + nameSpaceServiceApiFolder + "/" + homeModel.FolderName + "/" + folderMessageApi));
                    System.IO.File.WriteAllText(Server.MapPath("/Files/" + nameSpaceServiceApiFolder + "/" + homeModel.FolderName + "/" + folderMessageApi + "/" + className + folderMessageApi + ".cs"), classMessageApiSource);

                    #endregion

                    #region INTERFACE

                    string usingInterfaceApiSource = "using System;\nusing System.Collections.Generic;\nusing " + nameSpaceServiceApi + "." + folderRequestApi + ";using " + nameSpaceServiceApi + "." + folderMessageApi + ";\n\n";

                    string methodesInterfaceApiSources = string.Empty;
                    methodesInterfaceApiSources += "/// <summary>\n";
                    methodesInterfaceApiSources += "/// Add " + className + " dto.\n";
                    methodesInterfaceApiSources += "/// </summary>\n";
                    methodesInterfaceApiSources += "/// <param name=\"" + classNameAttribute + folderRequestApi + "\"> The " + className + folderRequestApi + " that content " + className + "dto to add.</param>\n";
                    methodesInterfaceApiSources += "/// <returns>The " + className + folderMessageApi + "Pivot result with the " + className + "Pivot added.</returns>\n";
                    methodesInterfaceApiSources += className + folderMessageApi + " Create" + className + "(" + className + folderRequestApi + " " + (classNameAttribute + folderRequestApi) + ");\n\n";

                    methodesInterfaceApiSources += "/// <summary>\n";
                    methodesInterfaceApiSources += "/// Update " + className + " dto.\n";
                    methodesInterfaceApiSources += "/// </summary>\n";
                    methodesInterfaceApiSources += "/// <param name=\"" + classNameAttribute + folderRequestApi + "\"> The " + className + folderRequest + " that content " + className + "dto to update.</param>\n";
                    methodesInterfaceApiSources += className + folderMessageApi + " Update" + className + "(" + className + folderRequestApi + " " + (classNameAttribute + folderRequestApi) + ");\n\n";

                    methodesInterfaceApiSources += "/// <summary>\n";
                    methodesInterfaceApiSources += "/// Delete " + className + " dto.\n";
                    methodesInterfaceApiSources += "/// </summary>\n";
                    methodesInterfaceApiSources += "/// <param name=\"" + classNameAttribute + folderRequestApi + "\"> The " + className + folderRequest + " that content " + className + "dto to remove.</param>\n";
                    methodesInterfaceApiSources += "/// <returns>The " + className + folderMessageApi + "Pivot result with the " + className + "Pivot removed.</returns>\n";
                    methodesInterfaceApiSources += className + folderMessageApi + " Delete" + className + "(" + className + folderRequestApi + " " + (classNameAttribute + folderRequestApi) + ");\n\n";

                    methodesInterfaceApiSources += "/// <summary>\n";
                    methodesInterfaceApiSources += "/// Get the list of " + className + ".\n";
                    methodesInterfaceApiSources += "/// </summary>\n";
                    methodesInterfaceApiSources += "/// <returns>The " + className + folderMessageApi + "Pivot result with the " + className + "Pivot list.</returns>\n";
                    methodesInterfaceApiSources += className + folderMessageApi + " GetAll" + className + "();\n\n";

                    methodesInterfaceApiSources += "/// <summary>\n";
                    methodesInterfaceApiSources += "/// Find " + className + ".\n";
                    methodesInterfaceApiSources += "/// </summary>\n";
                    methodesInterfaceApiSources += "/// <returns>The " + className + folderMessageApi + "Pivot result with the " + className + "Pivot list.</returns>\n";
                    methodesInterfaceApiSources += className + folderMessageApi + " Find" + className + "(" + className + folderRequestApi + " " + (classNameAttribute + folderRequestApi) + ");\n";

                    string commentInterfaceApi = string.Empty;
                    commentInterfaceApi += "/// <summary>\n";
                    commentInterfaceApi += "/// The " + className + " client interface.\n";
                    commentInterfaceApi += "/// </summary>\n";

                    string interfaceApiSource = usingInterfaceApiSource;
                    interfaceApiSource += "namespace " + nameSpaceServiceApi + "." + folderInterfaceApi + "{\n";
                    interfaceApiSource += commentInterfaceApi + "public interface IService" + className + "Client" + "{\n";
                    interfaceApiSource += methodesInterfaceApiSources;
                    interfaceApiSource += "}\n";
                    interfaceApiSource += "}";

                    Directory.CreateDirectory(Server.MapPath("/Files/" + nameSpaceServiceApiFolder + "/" + homeModel.FolderName + "/" + folderInterfaceApi));
                    System.IO.File.WriteAllText(Server.MapPath("/Files/" + nameSpaceServiceApiFolder + "/" + homeModel.FolderName + "/" + folderInterfaceApi + "/IService" + className + "Client" + ".cs"), interfaceApiSource);
                    #endregion

                    #region CLASS SERVICE

                    string usingServiceApiSource = "using System;\nusing System.Collections.Generic;\nusing System.Linq;\nusing System.Text;\nusing " + nameSpaceServiceApi + "." + folderRequestApi + ";\nusing " + nameSpaceServiceApi + "." + folderMessageApi + ";\nusing " + nameSpaceService + ";\nusing " + nameSpaceServiceApi + "." + folderInterfaceApi + ";\nusing " + nameSpaceServiceApi + "." + folderAssemblerApi + ";\nusing " + nameSpaceService + "." + folderInterface + ";\nusing " + nameSpaceMessageEnum + ";\n\n";

                    string attributeServiceApiSource = string.Empty;
                    attributeServiceApiSource += "/// <summary>\n";
                    attributeServiceApiSource += "/// The " + className + " service instance.\n";
                    attributeServiceApiSource += "/// </summary>\n";
                    attributeServiceApiSource += "private readonly IService" + className + " service" + className + ";\n\n";

                    string constrictorServiceApiSources = string.Empty;
                    constrictorServiceApiSources += "/// <summary>\n";
                    constrictorServiceApiSources += "/// Set the " + className + " instane with injected instance.\n";
                    constrictorServiceApiSources += "/// </summary>\n";
                    constrictorServiceApiSources += "/// <param name=\"injectedService" + className + "\">injected instance</param>\n";
                    constrictorServiceApiSources += "public Service" + className + "Client(IService" + className + " injectedService" + className + ")\n{\n service" + className + " = injectedService" + className + ";\n}\n";

                    string addCoreMethodeServiceApisource = string.Empty;
                    addCoreMethodeServiceApisource += className + folderMessageApi + " message = new " + className + folderMessageApi + "();\n";
                    addCoreMethodeServiceApisource += "try\n{\nmessage = service" + className + ".Create" + className + "(request.ToPivot()).To" + folderMessageApi + "();\nmessage.OperationSuccess = true;\n}\ncatch(Exception e)\n{\n message.ErrorType = ErrorType.TechnicalError;\n message.ErrorMessage = e.Message;\n}\nreturn message;";

                    string updateCoreMethodeServiceApisource = string.Empty;
                    updateCoreMethodeServiceApisource += className + folderMessageApi + " message = new " + className + folderMessageApi + "();\n";
                    updateCoreMethodeServiceApisource += "try\n{\n service" + className + ".Update" + className + "(request.ToPivot());\nmessage.OperationSuccess = true;\n}\ncatch(Exception e)\n{\n message.ErrorType = ErrorType.TechnicalError;\n message.ErrorMessage = e.Message;\n}\nreturn message;";

                    string deleteCoreMethodeServiceApisource = string.Empty;
                    deleteCoreMethodeServiceApisource += className + folderMessageApi + " message = new " + className + folderMessageApi + "();\n";
                    deleteCoreMethodeServiceApisource += "try\n{\n service" + className + ".Delete" + className + "(request.ToPivot());\nmessage.OperationSuccess = true;\n}\ncatch(Exception e)\n{\n message.ErrorType = ErrorType.TechnicalError;\n message.ErrorMessage = e.Message;\n}\nreturn message;";

                    string listCoreMethodeServiceApisource = string.Empty;
                    listCoreMethodeServiceApisource += className + folderMessageApi + " message = new " + className + folderMessageApi + "();\n";
                    listCoreMethodeServiceApisource += "try\n{\n message" + " = service" + className + ".GetAll" + className + "().To" + folderMessageApi + "();\nmessage.OperationSuccess = true;\n}\ncatch(Exception e)\n{\n message.ErrorType = ErrorType.TechnicalError;\n message.ErrorMessage = e.Message;\n}\nreturn message;";

                    string findCoreMethodeServiceApisource = string.Empty;
                    findCoreMethodeServiceApisource += className + folderMessageApi + " message = new " + className + folderMessageApi + "();\n";
                    findCoreMethodeServiceApisource += "try\n{\n message" + " = service" + className + ".Find" + className + "(request.ToPivot()).To" + folderMessageApi + "();\nmessage.OperationSuccess = true;\n}\ncatch(Exception e)\n{\n message.ErrorType = ErrorType.TechnicalError;\n message.ErrorMessage = e.Message;\n}\nreturn message;";

                    string methodesServiceApiSources = string.Empty;
                    methodesServiceApiSources += "/// <summary>\n";
                    methodesServiceApiSources += "/// Add new " + className + "\n";
                    methodesServiceApiSources += "/// </summary>\n";
                    methodesServiceApiSources += "/// <param name=\"request\">" + classNameAttribute + " request.</param>\n";
                    methodesServiceApiSources += "/// <returns>" + className + " message.</returns>\n";
                    methodesServiceApiSources += "public " + className + folderMessageApi + " Create" + className + "(" + className + folderRequestApi + " " + "request" + ")\n{\n " + addCoreMethodeServiceApisource + " \n}\n\n";

                    methodesServiceApiSources += "/// <summary>\n";
                    methodesServiceApiSources += "/// Change " + className + " informations.\n";
                    methodesServiceApiSources += "/// </summary>\n";
                    methodesServiceApiSources += "/// <param name=\"request\">" + classNameAttribute + " request.</param>\n";
                    methodesServiceApiSources += "/// <returns>" + className + " message.</returns>\n";
                    methodesServiceApiSources += "public " + className + folderMessageApi + " Update" + className + "(" + className + folderRequestApi + " " + "request" + ")\n{\n " + updateCoreMethodeServiceApisource + " \n}\n\n";

                    methodesServiceApiSources += "/// <summary>\n";
                    methodesServiceApiSources += "/// Delete " + className + "\n";
                    methodesServiceApiSources += "/// </summary>\n";
                    methodesServiceApiSources += "/// <param name=\"request\">" + classNameAttribute + " request.</param>\n";
                    methodesServiceApiSources += "/// <returns>" + className + " message.</returns>\n";
                    methodesServiceApiSources += "public " + className + folderMessageApi + " Delete" + className + "(" + className + folderRequestApi + " " + "request" + ")\n{\n  " + deleteCoreMethodeServiceApisource + " \n}\n\n";

                    methodesServiceApiSources += "/// <summary>\n";
                    methodesServiceApiSources += "/// Get list of " + className + "\n";
                    methodesServiceApiSources += "/// </summary>\n";
                    methodesServiceApiSources += "/// <returns>" + className + " message.</returns>\n";
                    methodesServiceApiSources += "public " + className + folderMessageApi + " GetAll" + className + "()\n{\n  " + listCoreMethodeServiceApisource + " \n}\n\n";

                    methodesServiceApiSources += "/// <summary>\n";
                    methodesServiceApiSources += "/// Search " + className + "\n";
                    methodesServiceApiSources += "/// </summary>\n";
                    methodesServiceApiSources += "/// <param name=\"request\">" + classNameAttribute + " request.</param>\n";
                    methodesServiceApiSources += "/// <returns>" + className + " message.</returns>\n";
                    methodesServiceApiSources += "public " + className + folderMessageApi + " Find" + className + "(" + className + folderRequestApi + " " + "request" + ")\n{\n " + findCoreMethodeServiceApisource + " \n}\n\n";

                    string commentClasseApi = string.Empty;
                    commentClasseApi += "/// <summary>\n";
                    commentClasseApi += "/// The " + className + " service client class.\n";
                    commentClasseApi += "/// </summary>\n";

                    string serviceclassApiSource = usingServiceApiSource;
                    serviceclassApiSource += "namespace " + nameSpaceServiceApi + "{\n";
                    serviceclassApiSource += commentClasseApi + "public class Service" + className + "Client" + " : IService" + className + "Client" + "{\n";
                    serviceclassApiSource += attributeServiceApiSource;
                    serviceclassApiSource += constrictorServiceApiSources;
                    serviceclassApiSource += methodesServiceApiSources;
                    serviceclassApiSource += "}\n";
                    serviceclassApiSource += "}";

                    Directory.CreateDirectory(Server.MapPath("/Files/" + nameSpaceServiceApiFolder + "/" + homeModel.FolderName));
                    System.IO.File.WriteAllText(Server.MapPath("/Files/" + nameSpaceServiceApiFolder + "/" + homeModel.FolderName + "/" + "Service" + className + "Client" + ".cs"), serviceclassApiSource);
                    #endregion

                    #endregion

                    #region WEB API.

                    #region CONTROLLER
                    string usingApiSource = "using System;\nusing System.Collections.Generic;\nusing System.Linq;\nusing System.Net;\nusing System.Net.Http;\nusing System.Web.Http;\nusing " + nameSpaceServiceApi + "." + folderInterfaceApi + ";\nusing " + nameSpaceServiceApi + "." + folderRequestApi + ";\nusing " + nameSpaceServiceApi + "." + folderMessageApi + ";\n\n";

                    string attributeApiSource = string.Empty;
                    attributeApiSource += "/// <summary>\n";
                    attributeApiSource += "/// The " + className + " service client instance.\n";
                    attributeApiSource += "/// </summary>\n";
                    attributeApiSource += "private readonly IService" + className + "Client " + "service" + className + "Client" + ";\n\n";

                    string constrictorApiSources = string.Empty;
                    constrictorApiSources += "/// <summary>\n";
                    constrictorApiSources += "/// Set the IService" + className + "Client instane with injected instance.\n";
                    constrictorApiSources += "/// </summary>\n";
                    constrictorApiSources += "/// <param name=\"injectedService" + className + "Client\">injected instance</param>\n";
                    constrictorApiSources += "public " + className + "Controller(IService" + className + "Client injectedService" + className + "Client)\n{\n this.service" + className + "Client = injectedService" + className + "Client;\n}\n";

                    string createCoreMethodeApisource = string.Empty;
                    createCoreMethodeApisource += className + folderMessageApi + " message = service" + className + "Client.Create" + className + "(request);\n";
                    createCoreMethodeApisource += "return Json(message);";

                    string updateCoreMethodeApisource = string.Empty;
                    updateCoreMethodeApisource += className + folderMessageApi + " message = service" + className + "Client.Update" + className + "(request);\n";
                    updateCoreMethodeApisource += "return Json(message);";

                    string deleteCoreMethodeApisource = string.Empty;
                    deleteCoreMethodeApisource += className + folderMessageApi + " message = service" + className + "Client.Delete" + className + "(request);\n";
                    deleteCoreMethodeApisource += "return Json(message);";

                    string findCoreMethodeApisource = string.Empty;
                    findCoreMethodeApisource += className + folderMessageApi + " message = service" + className + "Client.Find" + className + "(request);\n";
                    findCoreMethodeApisource += "return Json(message);";

                    string listCoreMethodeApisource = string.Empty;
                    listCoreMethodeApisource += className + folderMessageApi + " message = service" + className + "Client.GetAll" + className + "();\n";
                    listCoreMethodeApisource += "return Json(message);";

                    string methodesApiSources = string.Empty;
                    methodesApiSources += "/// <summary>\n";
                    methodesApiSources += "/// Create new " + className + "\n";
                    methodesApiSources += "/// </summary>\n";
                    methodesApiSources += "/// <returns>" + className + " message.</returns>\n";
                    methodesApiSources += "[Route(\"Create" + className + "\")]\n";
                    methodesApiSources += "public IHttpActionResult Create" + className + "(" + className + folderRequestApi + " request)\n{\n " + createCoreMethodeApisource + " \n}\n\n";

                    methodesApiSources += "/// <summary>\n";
                    methodesApiSources += "/// Change " + className + " informations.\n";
                    methodesApiSources += "/// </summary>\n";
                    methodesApiSources += "/// <returns>" + className + " message.</returns>\n";
                    methodesApiSources += "[Route(\"Update" + className + "\")]\n";
                    methodesApiSources += "public IHttpActionResult Update" + className + "(" + className + folderRequestApi + " request)\n{\n " + updateCoreMethodeApisource + " \n}\n\n";

                    methodesApiSources += "/// <summary>\n";
                    methodesApiSources += "/// Delete " + className + "\n";
                    methodesApiSources += "/// </summary>\n";
                    methodesApiSources += "/// <returns>" + className + " message.</returns>\n";
                    methodesApiSources += "[Route(\"Remove" + className + "\")]\n";
                    methodesApiSources += "public IHttpActionResult Delete" + className + "(" + className + folderRequestApi + " request)\n{\n " + deleteCoreMethodeApisource + " \n}\n\n";

                    methodesApiSources += "/// <summary>\n";
                    methodesApiSources += "/// Get list of " + className + "\n";
                    methodesApiSources += "/// </summary>\n";
                    methodesApiSources += "/// <returns>" + className + " message.</returns>\n";
                    methodesApiSources += "[Route(\"Get" + className + "s\")]\n";
                    methodesApiSources += "public IHttpActionResult GetAll" + className + "()\n{\n " + listCoreMethodeApisource + " \n}\n\n";

                    methodesApiSources += "/// <summary>\n";
                    methodesApiSources += "/// Find " + className + "\n";
                    methodesApiSources += "/// </summary>\n";
                    methodesApiSources += "/// <returns>" + className + " message.</returns>\n";
                    methodesApiSources += "[Route(\"Find" + className + "\")]\n";
                    methodesApiSources += "public IHttpActionResult Find" + className + "(" + className + folderRequestApi + " request)\n{\n " + findCoreMethodeApisource + " \n}\n\n";

                    string commentControllerApi = string.Empty;
                    commentControllerApi += "/// <summary>\n";
                    commentControllerApi += "/// The " + className + " web api controller.\n";
                    commentControllerApi += "/// </summary>\n";

                    string serviceControllerApiSource = usingApiSource;
                    serviceControllerApiSource += "namespace " + nameSpaceWebApi + "{\n";
                    serviceControllerApiSource += commentControllerApi + "public class " + className + "Controller" + " : ApiController{\n";
                    serviceControllerApiSource += attributeApiSource;
                    serviceControllerApiSource += constrictorApiSources;
                    serviceControllerApiSource += methodesApiSources;
                    serviceControllerApiSource += "}\n";
                    serviceControllerApiSource += "}";

                    Directory.CreateDirectory(Server.MapPath("/Files/" + folderWebApi + "/" + homeModel.FolderName));
                    System.IO.File.WriteAllText(Server.MapPath("/Files/" + folderWebApi + "/" + homeModel.FolderName + "/" + className + "Controller" + ".cs"), serviceControllerApiSource);
                    #endregion

                    #region ACTIVATION

                    string xmlFileSource = string.Empty;
                    xmlFileSource += "<serviceSettings>\n";
                    xmlFileSource += "  <services>\n";
                    xmlFileSource += "    <service serviceAssembly=\"OMS.Socle.Service\" entityAssembly=\"OMS.Socle.Entity\">\n";
                    xmlFileSource += "      <dependencies>\n\n\n";

                    xmlFileSource += "        <dependency classLibrary=\"" + homeModel.NomAssembly + "." + homeModel.FolderName + "." + className + "\" />\n\n\n";

                    xmlFileSource += "      </dependencies>\n";
                    xmlFileSource += "      <adapters>\n";
                    xmlFileSource += "        <adapter assemblyType=\"Service\" assembly=\"OMS.Socle.Service\">\n";
                    xmlFileSource += "          <types>\n";
                    xmlFileSource += "            <type classLibrary=\"OMS.Socle.Service.UnitOfWork.UnitOfWork\" interface=\"OMS.Socle.Service.UnitOfWork.IUnitOfWork\" />\n\n\n";

                    xmlFileSource += "            <type classLibrary=\"" + nameSpaceService + "." + "Service" + className + "\" interface=\"" + nameSpaceService + "." + folderInterface + "." + "IService" + className + "\" />\n\n\n";

                    xmlFileSource += "          </types>\n";
                    xmlFileSource += "        </adapter>\n";
                    xmlFileSource += "        <adapter assemblyType=\"WebApiService\" assembly=\"OMS.Socle.WebApi.Service\">\n";
                    xmlFileSource += "          <types>\n\n\n";

                    xmlFileSource += "            <type classLibrary=\"" + nameSpaceServiceApi + ".Service" + className + "Client\" interface=\"" + nameSpaceServiceApi + "." + folderInterfaceApi + "." + "IService" + className + "Client\" />\n\n\n";

                    xmlFileSource += "          </types>\n";
                    xmlFileSource += "        </adapter>\n";
                    xmlFileSource += "      </adapters>\n";
                    xmlFileSource += "    </service>\n";
                    xmlFileSource += "  </services>\n";
                    xmlFileSource += "</serviceSettings>\n";
                    Directory.CreateDirectory(Server.MapPath("/Files/" + folderWebApi + "/" + homeModel.FolderName));
                    System.IO.File.WriteAllText(Server.MapPath("/Files/" + folderWebApi + "/" + homeModel.FolderName + "/" + className + "Activation" + ".xml"), xmlFileSource);

                    #endregion

                    #endregion
                }
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
    }
}