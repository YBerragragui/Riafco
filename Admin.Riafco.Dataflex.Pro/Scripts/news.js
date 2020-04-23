/******************************
 * NEWS.
 ******************************/

/* CREATE NEWS TABS.*/
$(document).on("click", "#CreateNewsForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    if (panelToClose === 0) {
        var newsFormData = {
            NewsImage: $("#NewsImage").val(),
            NewsDate: $("#NewsDate").val()
        };

        $.ajax({
            type: "POST",
            url: "/News/ValidateNewsFormData",
            data: JSON.stringify(newsFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //newslinks : 
                    $("#CreateNewsForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#CreateNewsForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //newspanels
                    $("#CreateNewsForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#CreateNewsForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#CreateNewsForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#add_news_input").html(jqXhr.responseText);
            }
        });

    } else {
        var newsTranslationFormData = {
            NewsSummary: $("#Sum_" + panelToClose + "").val(),
            NewsDescription: $("#Desc_" + panelToClose + "").val(),
            NewsTitle: $("#Title_" + panelToClose + "").val(),
            LanguageId: $("#Language_" + panelToClose + "").val()
        };

        $.ajax({
            type: "POST",
            url: "/News/ValidateNewsTranslationFormData",
            data: JSON.stringify(newsTranslationFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //newslinks : 
                    $("#CreateNewsForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#CreateNewsForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //newspanels
                    $("#CreateNewsForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#CreateNewsForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                }
                else {
                    $("#CreateNewsForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#add_news_input").html(jqXhr.responseText);
            }
        });
    }
});

$(document).on("click", "#CreateNewsForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //newslinks : 
    $("#CreateNewsForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#CreateNewsForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //newspanels
    $("#CreateNewsForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#CreateNewsForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

/* CREATE NEWS.*/
$(document).on("click", "#add_news_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#add_news_btn", function (e) {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: "/News/GetCreateNews",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_news_input").html(msg);
            $(".date_champ").datepicker({ dateFormat: "dd/mm/yy", minDate: null, autoSize: true, prevText: "<", nextText: ">" });
            $("#add_news_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#add_news_input").text(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#CreateNewsForm", function (e) {
    e.preventDefault();

    $("#add_news_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_news").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#add_news_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/News/GetNews",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_news").html(msg);
                        $("#add_news_input").html("");
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
/* UPDATE NEWS TABS.*/
$(document).on("click", "#UpdateNewsForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    if (panelToClose === 0) {
        var newsFormData = {
            NewsImage: $("#NewsImage").val(),
            NewsDate: $("#NewsDate").val()
        };

        $.ajax({
            type: "POST",
            url: "/News/ValidateNewsFormData",
            data: JSON.stringify(newsFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //newslinks : 
                    $("#UpdateNewsForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#UpdateNewsForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //newspanels
                    $("#UpdateNewsForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#UpdateNewsForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#UpdateNewsForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#update_news_input").html(jqXhr.responseText);
            }
        });

    } else {
        var newsTranslationFormData = {
            NewsSummary: $("#Sum_" + panelToClose + "").val(),
            TranslationId: $("#Translation_" + panelToClose + "").val(),
            NewsDescription: $("#Desc_" + panelToClose + "").val(),
            NewsTitle: $("#Title_" + panelToClose + "").val(),
            LanguageId: $("#Language_" + panelToClose + "").val()
        };

        $.ajax({
            type: "POST",
            url: "/News/ValidateNewsTranslationFormData",
            data: JSON.stringify(newsTranslationFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //newslinks : 
                    $("#UpdateNewsForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#UpdateNewsForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //newspanels
                    $("#UpdateNewsForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#UpdateNewsForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#UpdateNewsForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#update_news_input").html(jqXhr.responseText);
            }
        });
    }
});

$(document).on("click", "#UpdateNewsForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //newslinks : 
    $("#UpdateNewsForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#UpdateNewsForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //newspanels
    $("#UpdateNewsForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#UpdateNewsForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

/* UPDATE NEWS.*/
$(document).on("click", "#update_news_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();

        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#update_news_btn", function (e) {
    e.preventDefault();

    var newsId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/News/GetUpdateNews",
        data: JSON.stringify({ newsId: newsId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_news_input").html(msg);
            $(".date_champ").datepicker({ dateFormat: "dd/mm/yy", minDate: null, autoSize: true, prevText: "<", nextText: ">" });
            $("#update_news_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#update_news_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#UpdateNewsForm", function (e) {
    e.preventDefault();

    $("#update_news_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $("#content_news").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#update_news_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/News/GetNews",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_news").html(msg);
                        $("#update_news_input").html("");
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
            $("#update_news_input").html(jqXhr.responseText);
        }
    });
});

/* DELETE NEWS.*/
$(document).on("click", "#delete_news_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#delete_news_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_news_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_news_btn", function (event) {
    event.preventDefault();
    var newsId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/News/GetDeleteNews",
        data: JSON.stringify({ newsId: newsId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#delete_news_input").html(msg);
            $("#delete_news_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#delete_news_pop_up #yes", function (event) {
    event.preventDefault();
    var newsId = $(this).attr("data");
    $("#delete_news_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: "POST",
        url: "/News/DeleteNews",
        data: JSON.stringify({ newsId: newsId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_news").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#delete_news_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/News/GetNews",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_news").html(msg);
                        $("#delete_news_input").html("");
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


/************************************************
*CROP IMAGE : 
*************************************************/

$()