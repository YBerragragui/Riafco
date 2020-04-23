/******************************
 * AUTHOR.
 ******************************/

/* CREATE AUTHOR.*/
$(document).on("click", "#add_author_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#add_author_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#add_author_btn", function (e) {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: "/Ressources/GetCreateAuthor",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_author_input").html(msg);
            $("#add_author_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#CreateAuthorForm", function (e) {
    e.preventDefault();

    $("#add_author_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_authors").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#add_author_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Ressources/GetAuthors",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_authors").html(msg);
                        $("#add_author_input").html("");
                    },
                    error: function (jqXhr) {
                        alert(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

/* UPDATE AUTHOR.*/
$(document).on("click", "#update_author_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#update_author_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#update_author_btn", function (e) {
    e.preventDefault();

    var authorId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Ressources/GetUpdateAuthor",
        data: JSON.stringify({ authorId: authorId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_author_input").html(msg);
            $("#update_author_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#UpdateAuthorForm", function (e) {
    e.preventDefault();

    $("#update_author_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $("#content_authors").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#update_author_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Ressources/GetAuthors",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_authors").html(msg);
                        $("#update_author_input").html("");
                    },
                    error: function (jqXhr) {
                        alert(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

/* DELETE AUTHOR.*/
$(document).on("click", "#delete_author_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#delete_author_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_author_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_author_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_author_btn", function (event) {
    event.preventDefault();

    var authorId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Ressources/GetDeleteAuthor",
        data: JSON.stringify({ authorId: authorId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#delete_author_input").html(msg);
            $("#delete_author_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#delete_author_pop_up #yes", function (event) {
    event.preventDefault();

    $("#delete_author_input").html("<img alt='loading'  src='/Images/loading.gif' />");
    var authorId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/Ressources/DeleteAuthor",
        data: JSON.stringify({ authorId: authorId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_authors").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#delete_author_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Ressources/GetAuthors",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_authors").html(msg);
                        $("#delete_author_input").html("");
                    },
                    error: function (jqXhr) {
                        alert(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

/******************************
 * THEME.
 ******************************/

/*CREATE THEME TABS.*/
$(document).on("click", "#CreateThemeForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    var themeTranslationFormData = {
        ThemeName: $("#Name_" + panelToClose + "").val(),
        LanguageId: $("#Language_" + panelToClose + "").val()
    };

    $.ajax({
        type: "POST",
        url: "/Ressources/ValidateThemeTranslationFormData",
        data: JSON.stringify(themeTranslationFormData),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg === "True") {
                //themelinks : 
                $("#CreateThemeForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                $("#CreateThemeForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                //themepanels
                $("#CreateThemeForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                $("#CreateThemeForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
            }
            else {
                $("#CreateThemeForm").submit();
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#CreateThemeForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    $("#CreateThemeForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#CreateThemeForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    $("#CreateThemeForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#CreateThemeForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

/* CREATE THEME.*/
$(document).on("click", "#add_theme_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#add_theme_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#add_theme_btn", function (e) {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: "/Ressources/GetCreateTheme",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_theme_input").html(msg);
            $("#add_theme_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#add_theme_input").text(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#CreateThemeForm", function (e) {
    e.preventDefault();

    $("#add_theme_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_themes").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });

                $("#add_theme_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Ressources/GetThemes",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_themes").html(msg);
                        $("#add_theme_input").html("");
                    },
                    error: function (jqXhr) {
                        alert(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

/* UPDATE THEME TABS.*/
$(document).on("click", "#UpdateThemeForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    var themeTranslationFormData = {
        ThemeName: $("#Name_" + panelToClose + "").val(),
        LanguageId: $("#Language_" + panelToClose + "").val()
    };

    $.ajax({
        type: "POST",
        url: "/Ressources/ValidateThemeTranslationFormData",
        data: JSON.stringify(themeTranslationFormData),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg === "True") {
                //themelinks : 
                $("#UpdateThemeForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                $("#UpdateThemeForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                //themepanels
                $("#UpdateThemeForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                $("#UpdateThemeForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
            } else {
                $("#UpdateThemeForm").submit();
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#UpdateThemeForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //themelinks : 
    $("#UpdateThemeForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#UpdateThemeForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //themepanels
    $("#UpdateThemeForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#UpdateThemeForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

/* UPDATE THEME.*/
$(document).on("click", "#update_theme_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#update_theme_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#update_theme_btn", function (e) {
    e.preventDefault();

    var themeId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Ressources/GetUpdateTheme",
        data: JSON.stringify({ themeId: themeId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_theme_input").html(msg);
            $("#update_theme_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#UpdateThemeForm", function (e) {
    e.preventDefault();

    $("#update_theme_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $("#content_themes").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });

                $("#update_theme_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Ressources/GetThemes",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_themes").html(msg);
                        $("#update_theme_input").html("");
                    },
                    error: function (jqXhr) {
                        alert(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

/* DELETE THEME.*/
$(document).on("click", "#delete_theme_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#delete_theme_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_theme_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_theme_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_theme_btn", function (event) {
    event.preventDefault();

    var themeId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Ressources/GetDeleteTheme",
        data: JSON.stringify({ themeId: themeId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#delete_theme_input").html(msg);
            $("#delete_theme_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#delete_theme_pop_up #yes", function (event) {
    event.preventDefault();
    var themeId = $(this).attr("data");
    $("#delete_theme_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: "POST",
        url: "/Ressources/DeleteTheme",
        data: JSON.stringify({ themeId: themeId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_themes").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#delete_theme_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Ressources/GetThemes",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_themes").html(msg);
                        $("#delete_theme_input").html("");
                    },
                    error: function (jqXhr) {
                        alert(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

/******************************
 * AREA.
 ******************************/

/*CREATE AREA TABS.*/
$(document).on("click", "#CreateAreaForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    var areaTranslationFormData = {
        AreaName: $("#Name_" + panelToClose + "").val(),
        LanguageId: $("#Language_" + panelToClose + "").val()
    };

    $.ajax({
        type: "POST",
        url: "/Ressources/ValidateAreaTranslationFormData",
        data: JSON.stringify(areaTranslationFormData),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg === "True") {
                //arealinks : 
                $("#CreateAreaForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                $("#CreateAreaForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                //areapanels
                $("#CreateAreaForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                $("#CreateAreaForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
            }
            else {
                $("#CreateAreaForm").submit();
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#CreateAreaForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    $("#CreateAreaForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#CreateAreaForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    $("#CreateAreaForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#CreateAreaForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

/* CREATE AREA.*/
$(document).on("click", "#add_area_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#add_area_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#add_area_btn", function (e) {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: "/Ressources/GetCreateArea",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_area_input").html(msg);
            $("#add_area_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#add_area_input").text(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#CreateAreaForm", function (e) {
    e.preventDefault();

    $("#add_area_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_areas").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });

                $("#add_area_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Ressources/GetAreas",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_areas").html(msg);
                        $("#add_area_input").html("");
                    },
                    error: function (jqXhr) {
                        alert(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

/* UPDATE AREA TABS.*/
$(document).on("click", "#UpdateAreaForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    var areaTranslationFormData = {
        AreaName: $("#Name_" + panelToClose + "").val(),
        LanguageId: $("#Language_" + panelToClose + "").val()
    };

    $.ajax({
        type: "POST",
        url: "/Ressources/ValidateAreaTranslationFormData",
        data: JSON.stringify(areaTranslationFormData),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg === "True") {
                //arealinks : 
                $("#UpdateAreaForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                $("#UpdateAreaForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                //areapanels
                $("#UpdateAreaForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                $("#UpdateAreaForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
            } else {
                $("#UpdateAreaForm").submit();
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#UpdateAreaForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //arealinks : 
    $("#UpdateAreaForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#UpdateAreaForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //areapanels
    $("#UpdateAreaForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#UpdateAreaForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

/* UPDATE AREA.*/
$(document).on("click", "#update_area_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#update_area_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#update_area_btn", function (e) {
    e.preventDefault();

    var areaId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Ressources/GetUpdateArea",
        data: JSON.stringify({ areaId: areaId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_area_input").html(msg);
            $("#update_area_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#UpdateAreaForm", function (e) {
    e.preventDefault();

    $("#update_area_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $("#content_areas").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });

                $("#update_area_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Ressources/GetAreas",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_areas").html(msg);
                        $("#update_area_input").html("");
                    },
                    error: function (jqXhr) {
                        alert(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

/* DELETE AREA.*/
$(document).on("click", "#delete_area_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#delete_area_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_area_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_area_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_area_btn", function (event) {
    event.preventDefault();

    var areaId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Ressources/GetDeleteArea",
        data: JSON.stringify({ areaId: areaId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#delete_area_input").html(msg);
            $("#delete_area_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#delete_area_pop_up #yes", function (event) {
    event.preventDefault();
    var areaId = $(this).attr("data");
    $("#delete_area_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: "POST",
        url: "/Ressources/DeleteArea",
        data: JSON.stringify({ areaId: areaId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_areas").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#delete_area_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Ressources/GetAreas",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_areas").html(msg);
                        $("#delete_area_input").html("");
                    },
                    error: function (jqXhr) {
                        alert(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});


/******************************
 * PUBLICATION.
 ******************************/

/*CREATE PUBLICATION TABS.*/
$(document).on("click", "#CreatePublicationForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    if (panelToClose === 0) {
        var publicationFormData = {
            PublicationDate: $("#PublicationDate").val(),
            AuthorId: $("#AuthorId").val(),
            AreaId: $("#AreaId").val()
        };

        $.ajax({
            type: "POST",
            url: "/Ressources/ValidateCreatePublicationFormData",
            data: JSON.stringify(publicationFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //publication links : 
                    $("#CreatePublicationForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#CreatePublicationForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //publication panels
                    $("#CreatePublicationForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#CreatePublicationForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#CreatePublicationForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#add_publication_input").html(jqXhr.responseText);
            }
        });

    } else {
        var publicationTranslationFormData = {
            PublicationFileSource: $("#File_" + panelToClose + "").val(),
            PublicationSummary: $("#Desc_" + panelToClose + "").val(),
            PublicationTitle: $("#Title_" + panelToClose + "").val(),
            LanguageId: $("#Language_" + panelToClose + "").val(),
        };

        $.ajax({
            type: "POST",
            url: "/Ressources/ValidateCreatePublicationTranslationFormData",
            data: JSON.stringify(publicationTranslationFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //publicationlinks : 
                    $("#CreatePublicationForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#CreatePublicationForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //publicationpanels
                    $("#CreatePublicationForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#CreatePublicationForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                }
                else {
                    $("#CreatePublicationForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#add_publication_input").html(jqXhr.responseText);
            }
        });
    }
});

$(document).on("click", "#CreatePublicationForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //publicationlinks : 
    $("#CreatePublicationForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#CreatePublicationForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //publicationpanels
    $("#CreatePublicationForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#CreatePublicationForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

/* CREATE PUBLICATION.*/
$(document).on("click", "#add_publication_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#add_publication_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#add_publication_btn", function (e) {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: "/Ressources/GetCreatePublication",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_publication_input").html(msg);
            $(".date_champ").datepicker({ dateFormat: "dd/mm/yy", minDate: null, autoSize: true, prevText: "<", nextText: ">" });
            $("#add_publication_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#add_publication_input").text(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#CreatePublicationForm", function (e) {
    e.preventDefault();

    $("#add_publication_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_publications").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#add_publication_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Ressources/GetPublications",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_publications").html(msg);
                        $("#add_publication_input").html("");
                    },
                    error: function (jqXhr) {
                        alert(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

/* UPDATE PUBLICATION TABS.*/
$(document).on("click", "#UpdatePublicationForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    if (panelToClose === 0) {
        var publicationFormData = {
            PublicationDate: $("#PublicationDate").val(),
            AuthorId: $("#AuthorId").val(),
            AreaId: $("#AreaId").val()
        };

        $.ajax({
            type: "POST",
            url: "/Ressources/ValidateUpdatePublicationFormData",
            data: JSON.stringify(publicationFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //publication links : 
                    $("#UpdatePublicationForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#UpdatePublicationForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //publication panels
                    $("#UpdatePublicationForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#UpdatePublicationForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#UpdatePublicationForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#update_publication_input").html(jqXhr.responseText);
            }
        });

    } else {
        var publicationTranslationFormData = {
            PublicationFileSource: $("#File_" + panelToClose + "").val(),
            PublicationId: $("#Publication_" + panelToClose + "").val(),
            PublicationSummary: $("#Desc_" + panelToClose + "").val(),
            PublicationTitle: $("#Title_" + panelToClose + "").val(),
            LanguageId: $("#Language_" + panelToClose + "").val(),
            PublicationFile: $("#File_" + panelToClose + "").val()
        };

        $.ajax({
            type: "POST",
            url: "/Ressources/ValidateUpdatePublicationTranslationFormData",
            data: JSON.stringify(publicationTranslationFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //publicationlinks : 
                    $("#UpdatePublicationForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#UpdatePublicationForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //publicationpanels
                    $("#UpdatePublicationForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#UpdatePublicationForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#UpdatePublicationForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#update_publication_input").html(jqXhr.responseText);
            }
        });
    }
});

$(document).on("click", "#UpdatePublicationForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //publicationlinks : 
    $("#UpdatePublicationForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#UpdatePublicationForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //publicationpanels
    $("#UpdatePublicationForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#UpdatePublicationForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

/* UPDATE PUBLICATION.*/
$(document).on("click", "#update_publication_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#update_publication_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#update_publication_btn", function (e) {
    e.preventDefault();

    var publicationId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Ressources/GetUpdatePublication",
        data: JSON.stringify({ publicationId: publicationId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_publication_input").html(msg);
            $(".date_champ").datepicker({ dateFormat: "dd/mm/yy", minDate: null, autoSize: true, prevText: "<", nextText: ">" });
            $("#update_publication_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
           alert(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#UpdatePublicationForm", function (e) {
    e.preventDefault();

    $("#update_publication_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $("#content_publications").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#update_publication_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Ressources/GetPublications",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_publications").html(msg);
                        $("#update_publication_input").html("");
                    },
                    error: function (jqXhr) {
                        alert(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            $("#update_publication_input").html(jqXhr.responseText);
        }
    });
});


/* DELETE PUBLICATION.*/
$(document).on("click", "#delete_publication_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#delete_publication_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_publication_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_publication_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_publication_btn", function (event) {
    event.preventDefault();

    var publicationId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Ressources/GetDeletePublication",
        data: JSON.stringify({ publicationId: publicationId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#delete_publication_input").html(msg);
            $("#delete_publication_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#delete_publication_pop_up #yes", function (event) {
    event.preventDefault();
    var publicationId = $(this).attr("data");
    $("#delete_publication_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: "POST",
        url: "/Ressources/DeletePublication",
        data: JSON.stringify({ publicationId: publicationId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_publications").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#delete_publication_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Ressources/GetPublications",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_publications").html(msg);
                        $("#delete_publication_input").html("");
                    },
                    error: function (jqXhr) {
                        alert(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

//PUBLICATION THEMES
$(document).on("click", "#publication_themes_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#publication_themes_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#publication_themes_btn", function (event) {
    event.preventDefault();
    var publicationId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/Ressources/PublicationThemes",
        data: JSON.stringify({ publicationId: publicationId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#themes_publication_input").html(msg);
            $("#publication_themes_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

//CREATE PUBLICATION THEME.
$(document).on("click", "#add_publication_theme_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#add_publication_theme_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
    $("#add_publication_theme_input").html("");
});

$(document).on("click", "#add_publication_theme_btn", function (event) {
    event.preventDefault();
    var publicationId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/Ressources/GetCreatePublicationTheme",
        data: JSON.stringify({ publicationId: publicationId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_publication_theme_input").html(msg);
            $("#add_publication_theme_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#CreatePublicationThemeForm", function (e) {
    e.preventDefault();

    var publicationId = $("#CreatePublicationThemeForm #PublicationId").val();
    $("#add_publication_theme_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $("#content_publication_themes").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });

                $.ajax({
                    type: "POST",
                    url: "/Ressources/GetPublicationThemes",
                    data: JSON.stringify({ publicationId: publicationId }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_publication_themes").html(msg);
                        $("#add_publication_theme_pop_up").removeClass("is-visible");
                        $("body").removeClass("hidden_body");
                        $("#add_publication_theme_input").html("");
                    },
                    error: function (jqXhr) {
                        alert(jqXhr.responseText);
                    }
                });

            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

//DELETE PUBLICATION THEME:
$(document).on("click", "#delete_publication_theme_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#delete_publication_theme_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
    $("#delete_publication_theme_input").html("");
});

$(document).on("click", "#delete_publication_theme_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_publication_theme_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
    $("#delete_publication_theme_input").html("");
});

$(document).on("click", "#delete_publication_theme_btn", function (event) {
    event.preventDefault();

    var publicationId = $(this).attr("publication-data");
    var publicationThemeId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/Ressources/GetDeletePublicationTheme",
        data: JSON.stringify({ publicationThemeId: publicationThemeId, publicationId: publicationId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#delete_publication_theme_input").html(msg);
            $("#delete_publication_theme_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#delete_publication_theme_pop_up #yes", function (event) {
    event.preventDefault();

    var publicationId = $(this).attr("data-publication");
    var publicationThemeId = $(this).attr("data");
    $("#delete_publication_theme_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: "POST",
        url: "/Ressources/DeletePublicationTheme",
        data: JSON.stringify({ publicationThemeId: publicationThemeId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_publication_themes").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });

                $.ajax({
                    type: "POST",
                    url: "/Ressources/GetPublicationThemes",
                    data: JSON.stringify({ publicationId: publicationId }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_publication_themes").html(msg);
                        $("#delete_publication_theme_pop_up").removeClass("is-visible");
                        $("body").removeClass("hidden_body");
                        $("#delete_publication_theme_input").html("");
                    },
                    error: function (jqXhr) {
                        alert(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});