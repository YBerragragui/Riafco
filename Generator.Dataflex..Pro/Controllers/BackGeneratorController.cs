using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Generator.Dataflex.Pro.Models;

namespace Generator.Dataflex.Pro.Controllers
{
    /// <summary>
    /// Generate back code controller.
    /// </summary>
    public class BackGeneratorController : Controller
    {
        /// <summary>
        /// The home page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool Generate(BackModel homeModel)
        {
            //BACK:    
            string nameSpaceBack = ConfigurationManager.AppSettings["nameSpaceBack"];
            string entityName = homeModel.PerfixName.ToLower();

            bool isSuccess = true;
            try
            {
                string typeName = homeModel.NomAssembly + "." + homeModel.FolderName + "." + homeModel.NomClass + "," + homeModel.NomAssembly;
                Type type = Type.GetType(typeName);
                if (type != null)
                {
                    #region GET TYPE AND PROPS.

                    List<PropertyInfo> props = type.GetProperties().ToList();

                    #endregion

                    #region THE INDEX VIEW.

                    //The index page:
                    string pageCode = string.Empty;
                    pageCode += "@model " + nameSpaceBack + ".Models." + homeModel.ControllerName + ".ViewData." + homeModel.ControllerName + "ViewData\n\n";

                    pageCode += "@{\n";
                    pageCode += "    ViewBag.Title = \"" + homeModel.ControllerName + "\";\n";
                    pageCode += "    Layout = \"~/Views/Shared/_Layout.cshtml\";\n";
                    pageCode += "}\n\n";

                    pageCode += "@section Scripts {\n";
                    pageCode += "    <script src=\"~/Scripts/" + homeModel.ControllerName.ToLower() + ".js\"></script>\n";
                    pageCode += "    <script src=\"~/Scripts/Jquery/jquery.validate.min.js\"></script>\n";
                    pageCode += "    <script src=\"~/Scripts/Jquery/jquery.validate.unobtrusive.min.js\"></script>\n";
                    pageCode += "}\n\n";

                    pageCode += "@section Styles {\n";
                    pageCode += "   \n\n";
                    pageCode += "}\n\n";

                    pageCode += "<div class=\"header_container\">\n";
                    pageCode += "    <div class=\"titre_header\">Gérer vos " + homeModel.ControllerName + " : </div>\n";
                    pageCode += "    <span id=\"add_" + entityName + "_btn\" class=\"btn_ajouter\">\n";
                    pageCode += "        <input type=\"image\" src=\"/Images/add.png\" class=\"icon_ajouter\" />\n";
                    pageCode += "        <span class=\"valeur_btn\">Ajouter</span>\n";
                    pageCode += "    </span>\n";
                    pageCode += "</div>\n\n";

                    pageCode += "<div id=\"content_" + homeModel.ControllerName.ToLower() + "\" class=\"content_container\">\n";
                    pageCode += "    @Html.Partial(\"Partials/_ActivitiesList\", Model)\n";
                    pageCode += "</div>\n\n";

                    pageCode += "<div id=\"add_" + entityName + "_pop_up\" class=\"cd-popup\" role=\"alert\">\n";
                    pageCode += "    <div class=\"cd-popup-container\">\n";
                    pageCode += "        <div class=\"modal-header\">\n";
                    pageCode += "            <h4>\n";
                    pageCode += "                <span>ajouter une " + entityName + ": </span>\n";
                    pageCode += "                <a class=\"cd-popup-close img-replace\"></a>\n";
                    pageCode += "            </h4>\n";
                    pageCode += "        </div>\n";
                    pageCode += "        <div id=\"add_" + entityName + "_input\"></div>\n";
                    pageCode += "    </div>\n";
                    pageCode += "</div>\n\n";

                    pageCode += "<div id=\"update_" + entityName + "_pop_up\" class=\"cd-popup\" role=\"alert\">\n";
                    pageCode += "    <div class=\"cd-popup-container\">\n";
                    pageCode += "        <div class=\"modal-header\">\n";
                    pageCode += "            <h4>\n";
                    pageCode += "                <span>modifier une " + entityName + ": </span>\n";
                    pageCode += "                <a class=\"cd-popup-close img-replace\"></a>\n";
                    pageCode += "            </h4>\n";
                    pageCode += "        </div>\n";
                    pageCode += "        <div id=\"update_" + entityName + "_input\"></div>\n";
                    pageCode += "    </div>\n";
                    pageCode += "</div>\n\n";

                    pageCode += "<div id=\"delete_" + entityName + "_pop_up\" class=\"cd-popup\" role=\"alert\">\n";
                    pageCode += "    <div id=\"delete_" + entityName + "_input\" class=\"cd-popup-container cd-popup-container-confirm\">\n";
                    pageCode += "        <p>Est ce que vous êtes sur de cette opération ?</p>\n";
                    pageCode += "        <ul class=\"cd-buttons\">\n";
                    pageCode += "            <li><a id=\"yes\">Oui</a></li>\n";
                    pageCode += "            <li><a id=\"no\">Non</a></li>\n";
                    pageCode += "        </ul>\n";
                    pageCode += "    </div>\n";
                    pageCode += "</div>\n";

                    Directory.CreateDirectory(Server.MapPath("/Files/" + nameSpaceBack + "/Views/" + homeModel.ControllerName + "/"));
                    System.IO.File.WriteAllText(Server.MapPath("/Files/" + nameSpaceBack + "/Views/" + homeModel.ControllerName + "/" + "Index.cshtml"), pageCode);
                    #endregion

                    #region JAVASCRIPT.

                    string scriptCode = string.Empty;

                    if (props.Any(p => p.PropertyType.IsGenericType))
                    {
                        scriptCode += "/******************************\n";
                        scriptCode += " * NAVIGATION TABS.\n";
                        scriptCode += " ******************************/\n";
                        scriptCode += "$(document).on(\"click\", \".next\", function (event) {\n";
                        scriptCode += "    event.preventDefault();\n\n";
                        scriptCode += "    var data = $(this).attr(\"data-navigation\");\n";
                        scriptCode += "    var panelToClose = parseInt(data) - 1;\n";
                        scriptCode += "    var panelToOpen = parseInt(data);\n\n";
                        scriptCode += "    if (panelToClose === 0) {\n\n";
                        scriptCode += "        var formData = {\n\n";
                        foreach (var p in props.Where(p => p.PropertyType.IsGenericType == false).ToList()) { scriptCode += p.Name + ": $(\"#" + p.Name + "\").val(),\n\n"; }
                        scriptCode += "        };\n\n";
                        scriptCode += "        $.ajax({\n";
                        scriptCode += "            type: \"POST\",\n";
                        scriptCode += "            url: \"/" + homeModel.ControllerName + "/Validate" + homeModel.PerfixName + "FormData\",\n";
                        scriptCode += "            data: JSON.stringify(formData),\n";
                        scriptCode += "            contentType: \"application/json; charset=utf-8\",\n";
                        scriptCode += "            success: function (msg) {\n";
                        scriptCode += "                if (msg === \"True\") {\n";
                        scriptCode += "                    //links : \n";
                        scriptCode += "                    $(\"#links\").find(\"li[data-navigation = \"\" + panelToClose + \"\"]\").removeClass(\"active\");\n";
                        scriptCode += "                    $(\"#links\").find(\"li[data-navigation = \"\" + panelToOpen + \"\"]\").addClass(\"active\");\n";
                        scriptCode += "                    //panels\n";
                        scriptCode += "                    $(\"#panels\").find(\".tab-pane[data-navigation = \"\" + panelToClose + \"\"]\").removeClass(\"active in\");\n";
                        scriptCode += "                    $(\"#panels\").find(\".tab-pane[data-navigation = \"\" + panelToOpen + \"\"]\").addClass(\"active in\");\n";
                        scriptCode += "                } else {\n";
                        scriptCode += "                    $(\"#Create" + homeModel.PerfixName + "Form\").submit();\n";
                        scriptCode += "                }\n";
                        scriptCode += "            },\n";
                        scriptCode += "            error: function (jqXhr) {\n";
                        scriptCode += "                $(\"#update_" + homeModel.PerfixName.ToLower() + "_input\").html(jqXhr.responseText);\n";
                        scriptCode += "            }\n";
                        scriptCode += "        });\n";
                        scriptCode += "    } else {\n";

                        var firstOrDefault = props.FirstOrDefault(p => p.PropertyType.IsGenericType);
                        if (firstOrDefault != null)
                        {
                            var propertyType = firstOrDefault.PropertyType;
                            var memberInfo = propertyType.GetGenericArguments().FirstOrDefault();
                            if (memberInfo != null)
                            {
                                string typeTranslationName = homeModel.NomAssembly + "." + homeModel.FolderName + "." + memberInfo.Name + "," + homeModel.NomAssembly;
                                Type typeTraslation = Type.GetType(typeTranslationName);
                                if (typeTraslation != null)
                                {
                                    List<PropertyInfo> propsTraslate = typeTraslation.GetProperties().ToList();
                                    scriptCode += "var formData = {\n";
                                    foreach (var prop in propsTraslate)
                                    {
                                        scriptCode += prop.Name + ": $(\"#" + prop.Name + "_\" + panelToClose + \"\").val(),\n";
                                    }
                                    scriptCode += "        };\n\n";
                                    scriptCode += "        $.ajax({\n";
                                    scriptCode += "            type: \"POST\",\n";
                                    scriptCode += "            url: \"/" + homeModel.ControllerName + "/Validate" + homeModel.PerfixName + "TranslationFormData\",\n";
                                    scriptCode += "            data: JSON.stringify(formData),\n";
                                    scriptCode += "            contentType: \"application/json; charset=utf-8\",\n";
                                    scriptCode += "            success: function (msg) {\n";
                                    scriptCode += "                if (msg === \"True\") {\n";
                                    scriptCode += "                    //links : \n";
                                    scriptCode += "                    $(\"#links\").find(\"li[data-navigation = \"\" + panelToClose + \"\"]\").removeClass(\"active\");\n";
                                    scriptCode += "                    $(\"#links\").find(\"li[data-navigation = \"\" + panelToOpen + \"\"]\").addClass(\"active\");\n";
                                    scriptCode += "                    //panels\n";
                                    scriptCode += "                    $(\"#panels\").find(\".tab-pane[data-navigation = \"\" + panelToClose + \"\"]\").removeClass(\"active in\");\n";
                                    scriptCode += "                    $(\"#panels\").find(\".tab-pane[data-navigation = \"\" + panelToOpen + \"\"]\").addClass(\"active in\");\n";
                                    scriptCode += "                } else {\n";
                                    scriptCode += "                    $(\"#Create" + homeModel.PerfixName + "Form\").submit();\n";
                                    scriptCode += "                }\n";
                                    scriptCode += "            },\n";
                                    scriptCode += "            error: function (jqXhr) {\n";
                                    scriptCode += "                $(\"#update_" + homeModel.PerfixName.ToLower() + "_input\").html(jqXhr.responseText);\n";
                                    scriptCode += "            }\n";
                                    scriptCode += "        });\n";
                                    scriptCode += "    }\n";
                                    scriptCode += "});\n\n";
                                    scriptCode += "$(document).on(\"click\", \".prev\", function (event) {\n";
                                    scriptCode += "    event.preventDefault();\n\n";
                                    scriptCode += "    var data = $(this).attr(\"data-navigation\");\n";
                                    scriptCode += "    var panelToClose = parseInt(data) + 1;\n";
                                    scriptCode += "    var panelToOpen = parseInt(data);\n\n";
                                    scriptCode += "    //links : \n";
                                    scriptCode += "    $(\"#links\").find(\"li[data-navigation = \"\" + panelToClose + \"\"]\").removeClass(\"active\");\n";
                                    scriptCode += "    $(\"#links\").find(\"li[data-navigation = \"\" + panelToOpen + \"\"]\").addClass(\"active\");\n\n";
                                    scriptCode += "    //panels\n";
                                    scriptCode += "    $(\"#panels\").find(\".tab-pane[data-navigation = \"\" + panelToClose + \"\"]\").removeClass(\"active in\");\n";
                                    scriptCode += "    $(\"#panels\").find(\".tab-pane[data-navigation = \"\" + panelToOpen + \"\"]\").addClass(\"active in\");\n";
                                    scriptCode += "});\n\n\n";
                                }
                            }
                        }
                    }


                    scriptCode += "/******************************\n";
                    scriptCode += " * CREATE " + homeModel.PerfixName.ToUpper() + ".\n";
                    scriptCode += " ******************************/\n";
                    scriptCode += "$(document).on(\"click\", \"#add_" + homeModel.PerfixName.ToLower() + "_pop_up\", function (event) {\n";
                    scriptCode += "    if ($(event.target).is(\".cd-popup-close\") || $(event.target).is(\".cd-popup\")) {\n";
                    scriptCode += "        event.preventDefault();\n";
                    scriptCode += "        $(this).removeClass(\"is-visible\");\n";
                    scriptCode += "        $(\"body\").removeClass(\"hidden_body\");\n";
                    scriptCode += "    }\n";
                    scriptCode += "});\n\n";
                    scriptCode += "$(document).on(\"click\", \"#add_" + homeModel.PerfixName.ToLower() + "_btn\", function (e) {\n";
                    scriptCode += "    e.preventDefault();\n\n";
                    scriptCode += "    $.ajax({\n";
                    scriptCode += "        type: \"POST\",\n";
                    scriptCode += "        url: \"/" + homeModel.ControllerName + "/GetCreate" + homeModel.PerfixName + "\",\n";
                    scriptCode += "        contentType: \"application/json; charset=utf-8\",\n";
                    scriptCode += "        success: function (msg) {\n";
                    scriptCode += "            $(\"#add_" + homeModel.PerfixName.ToLower() + "_input\").html(msg);\n";
                    scriptCode += "            $(\"#add_" + homeModel.PerfixName.ToLower() + "_pop_up\").addClass(\"is-visible\");\n";
                    scriptCode += "            $(\"body\").addClass(\"hidden_body\");\n";
                    scriptCode += "        },\n";
                    scriptCode += "        error: function (jqXhr) {\n";
                    scriptCode += "            $(\"#add_" + homeModel.PerfixName.ToLower() + "_input\").text(jqXhr.responseText);\n";
                    scriptCode += "        }\n";
                    scriptCode += "    });\n";
                    scriptCode += "});\n\n";
                    scriptCode += "$(document).on(\"submit\", \"#Create" + homeModel.PerfixName + "Form\", function (e) {\n";
                    scriptCode += "    e.preventDefault();\n\n";
                    scriptCode += "    $.ajax({\n";
                    scriptCode += "        type: this.method,\n";
                    scriptCode += "        url: this.action,\n";
                    scriptCode += "        data: new FormData(this),\n";
                    scriptCode += "        processData: false,\n";
                    scriptCode += "        contentType: false,\n";
                    scriptCode += "        success: function (msg) {\n";
                    scriptCode += "            if (msg.OperationSuccess === true) {\n";
                    scriptCode += "                $.toast(msg.SuccessMessage, { \"width\": 800 });\n";
                    scriptCode += "                $.ajax({\n";
                    scriptCode += "                    type: \"POST\",\n";
                    scriptCode += "                    url: \"/" + homeModel.ControllerName + "/GetActivities\",\n";
                    scriptCode += "                    contentType: \"application/json; charset=utf-8\",\n";
                    scriptCode += "                    success: function (msg) {\n";
                    scriptCode += "                        $(\"#content_" + homeModel.ControllerName.ToLower() + "\").html(msg);\n";
                    scriptCode += "                        $(\"#add_" + homeModel.PerfixName + "_pop_up\").removeClass(\"is-visible\");\n";
                    scriptCode += "                        $(\"body\").removeClass(\"hidden_body\");\n";
                    scriptCode += "                        $(\"#add_" + homeModel.PerfixName.ToLower() + "_input\").html(\"\");\n";
                    scriptCode += "                    },\n";
                    scriptCode += "                    error: function (jqXhr) {\n";
                    scriptCode += "                        $(\"#add_" + homeModel.PerfixName.ToLower() + "_input\").html(jqXhr.responseText);\n";
                    scriptCode += "                    }\n";
                    scriptCode += "                });\n";
                    scriptCode += "            } else {\n";
                    scriptCode += "                $.toast(msg.ErrorMessage, { \"width\": 800 });\n";
                    scriptCode += "            }\n";
                    scriptCode += "        },\n";
                    scriptCode += "        error: function (jqXhr) {\n";
                    scriptCode += "            $(\"#add_" + homeModel.PerfixName.ToLower() + "_input\").html(jqXhr.responseText);\n";
                    scriptCode += "        }\n";
                    scriptCode += "    });\n";
                    scriptCode += "});\n\n";
                    scriptCode += "/******************************\n";
                    scriptCode += " * UPDATE " + homeModel.PerfixName.ToUpper() + ".\n";
                    scriptCode += " ******************************/\n";
                    scriptCode += "$(document).on(\"click\", \"#update_" + homeModel.PerfixName.ToLower() + "_pop_up\", function (event) {\n";
                    scriptCode += "    if ($(event.target).is(\".cd-popup-close\") || $(event.target).is(\".cd-popup\")) {\n";
                    scriptCode += "        event.preventDefault();\n";
                    scriptCode += "        $(this).removeClass(\"is-visible\");\n";
                    scriptCode += "        $(\"body\").removeClass(\"hidden_body\");\n";
                    scriptCode += "    }\n";
                    scriptCode += "});\n\n";
                    scriptCode += "$(document).on(\"click\", \"#update_" + homeModel.PerfixName.ToLower() + "_btn\", function (e) {\n";
                    scriptCode += "    e.preventDefault();\n\n";
                    scriptCode += "    var activityId = $(this).attr(\"data\");\n";
                    scriptCode += "    $.ajax({\n";
                    scriptCode += "        type: \"POST\",\n";
                    scriptCode += "        url: \"/" + homeModel.ControllerName + "/GetUpdateActivity\",\n";
                    scriptCode += "        data: JSON.stringify({ activityId: activityId }),\n";
                    scriptCode += "        contentType: \"application/json; charset=utf-8\",\n";
                    scriptCode += "        success: function (msg) {\n";
                    scriptCode += "            $(\"#update_" + homeModel.PerfixName.ToLower() + "_input\").html(msg);\n";
                    scriptCode += "            $(\"#update_" + homeModel.PerfixName.ToLower() + "_pop_up\").addClass(\"is-visible\");\n";
                    scriptCode += "            $(\"body\").addClass(\"hidden_body\");\n";
                    scriptCode += "        },\n";
                    scriptCode += "        error: function (jqXhr) {\n";
                    scriptCode += "            $(\"#update_" + homeModel.PerfixName.ToLower() + "_input\").html(jqXhr.responseText);\n";
                    scriptCode += "        }\n";
                    scriptCode += "    });\n";
                    scriptCode += "});\n\n";
                    scriptCode += "$(document).on(\"submit\", \"#Update" + homeModel.PerfixName + "Form\", function (e) {\n";
                    scriptCode += "    e.preventDefault();\n";
                    scriptCode += "    $.ajax({\n";
                    scriptCode += "        type: this.method,\n";
                    scriptCode += "        url: this.action,\n";
                    scriptCode += "        data: new FormData(this),\n";
                    scriptCode += "        processData: false,\n";
                    scriptCode += "        contentType: false,\n";
                    scriptCode += "        success: function (msg) {\n";
                    scriptCode += "            if (msg.OperationSuccess === true) {\n";
                    scriptCode += "                $.toast(msg.SuccessMessage, { \"width\": 800 });\n";
                    scriptCode += "                $.ajax({\n";
                    scriptCode += "                    type: \"POST\",\n";
                    scriptCode += "                    url: \"/" + homeModel.ControllerName + "/GetActivities\",\n";
                    scriptCode += "                    contentType: \"application/json; charset=utf-8\",\n";
                    scriptCode += "                    success: function (msg) {\n";
                    scriptCode += "                        $(\"#content_" + homeModel.ControllerName.ToLower() + "\").html(msg);\n";
                    scriptCode += "                        $(\"#update_" + homeModel.PerfixName.ToLower() + "_pop_up\").removeClass(\"is-visible\");\n";
                    scriptCode += "                        $(\"body\").removeClass(\"hidden_body\");\n";
                    scriptCode += "                        $(\"#update_" + homeModel.PerfixName.ToLower() + "_input\").html(\"\");\n";
                    scriptCode += "                    },\n";
                    scriptCode += "                    error: function (jqXhr) {\n";
                    scriptCode += "                        $(\"#update_" + homeModel.PerfixName.ToLower() + "_input\").html(jqXhr.responseText);\n";
                    scriptCode += "                    }\n";
                    scriptCode += "                });\n";
                    scriptCode += "            } else {\n";
                    scriptCode += "                $.toast(msg.ErrorMessage, { \"width\": 800 });\n";
                    scriptCode += "            }\n";
                    scriptCode += "        },\n";
                    scriptCode += "        error: function (jqXhr) {\n";
                    scriptCode += "            $(\"#update_" + homeModel.PerfixName.ToLower() + "_input\").html(jqXhr.responseText);\n";
                    scriptCode += "        }\n";
                    scriptCode += "    });\n";
                    scriptCode += "});\n\n";
                    scriptCode += "/******************************\n";
                    scriptCode += " * DELETE activity.\n";
                    scriptCode += " ******************************/\n";
                    scriptCode += "$(document).on(\"click\", \"#delete_" + homeModel.PerfixName.ToLower() + "_pop_up\", function (event) {\n";
                    scriptCode += "    if ($(event.target).is(\".cd-popup-close\") || $(event.target).is(\".cd-popup\")) {\n";
                    scriptCode += "        event.preventDefault();\n";
                    scriptCode += "        $(this).removeClass(\"is-visible\");\n";
                    scriptCode += "        $(\"body\").removeClass(\"hidden_body\");\n";
                    scriptCode += "    }\n";
                    scriptCode += "});\n\n";
                    scriptCode += "$(document).on(\"click\", \"#delete_" + homeModel.PerfixName.ToLower() + "_pop_up #no\", function (event) {\n";
                    scriptCode += "    event.preventDefault();\n";
                    scriptCode += "    $(\"#delete_" + homeModel.PerfixName.ToLower() + "_pop_up\").removeClass(\"is-visible\");\n";
                    scriptCode += "    $(\"body\").removeClass(\"hidden_body\");\n";
                    scriptCode += "});\n\n";
                    scriptCode += "$(document).on(\"click\", \"#delete_" + homeModel.PerfixName.ToLower() + "_btn\", function (event) {\n";
                    scriptCode += "    event.preventDefault();\n";
                    scriptCode += "    var activityId = $(this).attr(\"data\");\n\n";
                    scriptCode += "    $(\"#delete_" + homeModel.PerfixName.ToLower() + "_pop_up #yes\").attr(\"data\", activityId);\n";
                    scriptCode += "    $(\"#delete_" + homeModel.PerfixName.ToLower() + "_pop_up\").addClass(\"is-visible\");\n";
                    scriptCode += "    $(\"body\").addClass(\"hidden_body\");\n";
                    scriptCode += "});\n\n";
                    scriptCode += "$(document).on(\"click\", \"#delete_" + homeModel.PerfixName.ToLower() + "_pop_up #yes\", function (event) {\n";
                    scriptCode += "    event.preventDefault();\n";
                    scriptCode += "    var " + homeModel.PerfixName.ToLower() + "Id = $(this).attr(\"data\");\n";
                    scriptCode += "    $.ajax({\n";
                    scriptCode += "        type: \"POST\",\n";
                    scriptCode += "        url: \"/" + homeModel.ControllerName + "/DeleteActivity\",\n";
                    scriptCode += "        data: JSON.stringify({ " + homeModel.PerfixName.ToLower() + "Id: " + homeModel.PerfixName.ToLower() + "Id }),\n";
                    scriptCode += "        contentType: \"application/json; charset=utf-8\",\n";
                    scriptCode += "        success: function (msg) {\n";
                    scriptCode += "            if (msg.OperationSuccess === true) {\n";
                    scriptCode += "                $.toast(msg.SuccessMessage, { \"width\": 800 });\n";
                    scriptCode += "                $.ajax({\n";
                    scriptCode += "                    type: \"POST\",\n";
                    scriptCode += "                    url: \"/" + homeModel.ControllerName + "/Get" + homeModel.ControllerName + "\",\n";
                    scriptCode += "                    contentType: \"application/json; charset=utf-8\",\n";
                    scriptCode += "                    success: function (msg) {\n";
                    scriptCode += "                        $(\"#content_" + homeModel.ControllerName.ToLower() + "\").html(msg);\n";
                    scriptCode += "                        $(\"#delete_" + homeModel.PerfixName.ToLower() + "_pop_up\").removeClass(\"is-visible\");\n";
                    scriptCode += "                        $(\"body\").removeClass(\"hidden_body\");\n";
                    scriptCode += "                    },\n";
                    scriptCode += "                    error: function (jqXhr) {\n";
                    scriptCode += "                        $(\"#delete_" + homeModel.PerfixName.ToLower() + "_input\").html(jqXhr.responseText);\n";
                    scriptCode += "                    }\n";
                    scriptCode += "                });\n";
                    scriptCode += "            } else {\n";
                    scriptCode += "                $.toast(msg.ErrorMessage, { \"width\": 800 });\n";
                    scriptCode += "            }\n";
                    scriptCode += "        },\n";
                    scriptCode += "        error: function (jqXhr) {\n";
                    scriptCode += "            $(\"#delete_" + homeModel.PerfixName.ToLower() + "_input\").html(jqXhr.responseText);\n";
                    scriptCode += "        }\n";
                    scriptCode += "    });\n";
                    scriptCode += "});\n";

                    Directory.CreateDirectory(Server.MapPath("/Files/" + nameSpaceBack + "/Scripts/"));
                    System.IO.File.WriteAllText(Server.MapPath("/Files/" + nameSpaceBack + "/Scripts/" + homeModel.ControllerName + ".js"), scriptCode);
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