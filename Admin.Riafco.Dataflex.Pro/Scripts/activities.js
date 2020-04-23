/******************************
 * ACTIVITY.
 ******************************/

/*CREATE ACTIVITY TABS.*/
$(document).on("click", "#CreateActivityForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    if (panelToClose === 0) {
        var activityFormData = {
            ActivityImageSource: $("#ActivityImage").val(),
            ActivityIconSource: $("#ActivityIcon").val()
        };

        $.ajax({
            type: "POST",
            url: "/Activities/ValidateCreateActivityFormData",
            data: JSON.stringify(activityFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //activitylinks : 
                    $("#CreateActivityForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#CreateActivityForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //activitypanels
                    $("#CreateActivityForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#CreateActivityForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#CreateActivityForm").submit();
                }
            },
            error: function (jqXhr) {
                alert(jqXhr.responseText);
            }
        });

    } else {
        var activityTranslationFormData = {
            ActivityIntroduction: $("#Intro_" + panelToClose + "").val(),
            ActivityDescription: $("#Desc_" + panelToClose + "").val(),
            ActivityTitle: $("#Title_" + panelToClose + "").val(),
            LanguageId: $("#Language_" + panelToClose + "").val()
        };

        $.ajax({
            type: "POST",
            url: "/Activities/ValidateActivityTranslationFormData",
            data: JSON.stringify(activityTranslationFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //activitylinks : 
                    $("#CreateActivityForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#CreateActivityForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //activitypanels
                    $("#CreateActivityForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#CreateActivityForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                }
                else {
                    $("#CreateActivityForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#add_activity_input").html(jqXhr.responseText);
            }
        });
    }
});

$(document).on("click", "#CreateActivityForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //activitylinks : 
    $("#CreateActivityForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#CreateActivityForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //activitypanels
    $("#CreateActivityForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#CreateActivityForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

/* CREATE ACTIVITY.*/
$(document).on("click", "#add_activity_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#add_activity_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#add_activity_btn", function (e) {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: "/Activities/GetCreateActivity",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_activity_input").html(msg);
            $("#add_activity_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#add_activity_input").text(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#CreateActivityForm", function (e) {
    e.preventDefault();

    $("#add_activity_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_activities").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#add_activity_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Activities/GetActivities",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_activities").html(msg);
                        $("#add_activity_input").html("");
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

/* UPDATE ACTIVITY TABS.*/
$(document).on("click", "#UpdateActivityForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    if (panelToClose === 0) {
        var activityFormData = {
            ActivityImageSource: $("#ActivityImage").val(),
            ActivityIconSource: $("#ActivityIcon").val()
        };

        $.ajax({
            type: "POST",
            url: "/Activities/ValidateUpdateActivityFormData",
            data: JSON.stringify(activityFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //activitylinks : 
                    $("#UpdateActivityForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#UpdateActivityForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //activitypanels
                    $("#UpdateActivityForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#UpdateActivityForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#UpdateActivityForm").submit();
                }
            },
            error: function (jqXhr) {
                alert(jqXhr.responseText);
            }
        });

    } else {
        var activityTranslationFormData = {
            ActivityIntroduction: $("#Intro_" + panelToClose + "").val(),
            TranslationId: $("#Translation_" + panelToClose + "").val(),
            ActivityDescription: $("#Desc_" + panelToClose + "").val(),
            ActivityTitle: $("#Title_" + panelToClose + "").val(),
            LanguageId: $("#Language_" + panelToClose + "").val()
        };

        $.ajax({
            type: "POST",
            url: "/Activities/ValidateActivityTranslationFormData",
            data: JSON.stringify(activityTranslationFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //activitylinks : 
                    $("#UpdateActivityForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#UpdateActivityForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //activitypanels
                    $("#UpdateActivityForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#UpdateActivityForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#UpdateActivityForm").submit();
                }
            },
            error: function (jqXhr) {
                alert(jqXhr.responseText);
            }
        });
    }
});

$(document).on("click", "#UpdateActivityForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //activitylinks : 
    $("#UpdateActivityForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#UpdateActivityForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //activitypanels
    $("#UpdateActivityForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#UpdateActivityForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

/* UPDATE ACTIVITY.*/
$(document).on("click", "#update_activity_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#update_activity_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#update_activity_btn", function (e) {
    e.preventDefault();

    var activityId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Activities/GetUpdateActivity",
        data: JSON.stringify({ activityId: activityId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_activity_input").html(msg);
            $("#update_activity_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#UpdateActivityForm", function (e) {
    e.preventDefault();

    $("#update_activity_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $("#content_activities").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#update_activity_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Activities/GetActivities",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_activities").html(msg);
                        $("#update_activity_input").html("");
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


/* DELETE ACTIVITY.*/
$(document).on("click", "#delete_activity_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#delete_activity_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_activity_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_activity_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_activity_btn", function (event) {
    event.preventDefault();

    var activityId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Activities/GetDeleteActivity",
        data: JSON.stringify({ activityId: activityId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#delete_activity_input").html(msg);
            $("#delete_activity_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#delete_activity_pop_up #yes", function (event) {
    event.preventDefault();
    var activityId = $(this).attr("data");
    $("#delete_activity_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: "POST",
        url: "/Activities/DeleteActivity",
        data: JSON.stringify({ activityId: activityId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_activities").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#delete_activity_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Activities/GetActivities",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_activities").html(msg);
                        $("#delete_activity_input").html("");
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
 * PARAGRAPH ACTIVIRY.
 ******************************/

/* CREATE ACTIVITY PARAGRAPH TABS.*/
$(document).on("click", "#CreateActivityParagraphForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    if (panelToClose === 0) {
        var activityParagraphFormData = {
            activityId: $("#ActivityId").val()
        };

        $.ajax({
            type: "POST",
            url: "/Activities/ValidateActivityParagraph",
            data: JSON.stringify(activityParagraphFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //paragraphlinks : 
                    $("#CreateActivityParagraphForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#CreateActivityParagraphForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //paragraphpanels
                    $("#CreateActivityParagraphForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#CreateActivityParagraphForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#CreateActivityParagraphForm").submit();
                }
            },
            error: function (jqXhr) {
                alert(jqXhr.responseText);
            }
        });

    } else {
        var activityParagraphTranslationFormData = {
            ParagraphDescription: $("#Desc_" + panelToClose + "").val(),
            ParagraphTitle: $("#Title_" + panelToClose + "").val(),
            LanguageId: $("#Language_" + panelToClose + "").val()
        };

        $.ajax({
            type: "POST",
            url: "/Activities/ValidateActivityParagraphTranslation",
            data: JSON.stringify(activityParagraphTranslationFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //activitylinks : 
                    $("#CreateActivityParagraphForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#CreateActivityParagraphForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //paragraphpanels :
                    $("#CreateActivityParagraphForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#CreateActivityParagraphForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#CreateActivityParagraphForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#add_paragraph_input").html(jqXhr.responseText);
            }
        });
    }
});

$(document).on("click", "#CreateActivityParagraphForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //activitylinks : 
    $("#CreateActivityParagraphForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#CreateActivityParagraphForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //paragraphpanels
    $("#CreateActivityParagraphForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#CreateActivityParagraphForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

$(document).on("click", "#paragraph_activity_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#paragraph_activity_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#paragraph_activity_btn", function (event) {
    event.preventDefault();

    var activityId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Activities/GetManageParagraphs",
        data: JSON.stringify({ activityId: activityId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#paragraph_activity_input").html(msg);
            $("#paragraph_activity_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#update_paragraph_input").html(jqXhr.responseText);
        }
    });
});

/* CREATE PARAGRAPH ACTIVITY.*/
$(document).on("click", "#add_paragraph_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#add_paragraph_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#add_paragraph_btn", function (event) {
    event.preventDefault();

    var activityId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Activities/GetCreateActivityParagraph",
        data: JSON.stringify({ activityId: activityId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_paragraph_input").html(msg);
            $("#add_paragraph_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#add_paragraph_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#CreateActivityParagraphForm", function (e) {
    e.preventDefault();

    var activityId = $("#CreateActivityParagraphForm #ActivityId").val();
    $("#add_paragraph_input").html("<img alt='loading' src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $("#paragraph_activity_input").html("<img alt='loading' src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });

                $("#add_paragraph_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Activities/GetManageParagraphs",
                    data: JSON.stringify({ activityId: activityId }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#paragraph_activity_input").html(msg);
                        $("#add_paragraph_input").html("");
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

/* UPDATE PARAGRAPH ACTIVITY.*/
$(document).on("click", "#UpdateActivityParagraphForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    if (panelToClose === 0) {
        var activityParagraphFormData = {
            activityId: $("#ActivityId").val()
        };

        $.ajax({
            type: "POST",
            url: "/Activities/ValidateActivityParagraph",
            data: JSON.stringify(activityParagraphFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //paragraphlinks : 
                    $("#UpdateActivityParagraphForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#UpdateActivityParagraphForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //paragraphpanels
                    $("#UpdateActivityParagraphForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#UpdateActivityParagraphForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#UpdateActivityParagraphForm").submit();
                }
            },
            error: function (jqXhr) {
                alert(jqXhr.responseText);
            }
        });

    } else {
        var activityParagraphTranslationFormData = {
            ParagraphDescription: $("#Desc_" + panelToClose + "").val(),
            ParagraphTitle: $("#Title_" + panelToClose + "").val(),
            LanguageId: $("#Language_" + panelToClose + "").val()
        };

        $.ajax({
            type: "POST",
            url: "/Activities/ValidateActivityParagraphTranslation",
            data: JSON.stringify(activityParagraphTranslationFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //activitylinks : 
                    $("#UpdateActivityParagraphForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#UpdateActivityParagraphForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //paragraphpanels :
                    $("#UpdateActivityParagraphForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#UpdateActivityParagraphForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#UpdateActivityParagraphForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#update_paragraph_input").html(jqXhr.responseText);
            }
        });
    }
});

$(document).on("click", "#UpdateActivityParagraphForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //activitylinks : 
    $("#UpdateActivityParagraphForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#UpdateActivityParagraphForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //paragraphpanels
    $("#UpdateActivityParagraphForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#UpdateActivityParagraphForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

$(document).on("click", "#update_paragraph_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#update_paragraph_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#update_activity_paragraph_btn", function (event) {
    event.preventDefault();

    var paragraphId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Activities/GetUpdateActivityParagraph",
        data: JSON.stringify({ paragraphId: paragraphId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_paragraph_input").html(msg);
            $("#update_paragraph_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#update_paragraph_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#UpdateActivityParagraphForm", function (e) {
    e.preventDefault();

    var activityId = $("#UpdateActivityParagraphForm #ActivityId").val();
    $("#update_paragraph_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $.toast(msg.SuccessMessage, { 'width': 800 });

                $("#paragraph_activity_input").html("<img alt='loading'  src='/Images/loading.gif' />");
                $("#update_paragraph_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Activities/GetManageParagraphs",
                    data: JSON.stringify({ activityId: activityId }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#paragraph_activity_input").html(msg);
                        $("#update_paragraph_input").html("");
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

/* DELETE ACTIVITY PARAGRAPH.*/
$(document).on("click", "#delete_paragraph_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#delete_paragraph_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_paragraph_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_paragraph_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_activity_paragraph_btn", function (event) {
    event.preventDefault();

    var activityId = $(this).attr("data-section");
    var paragraphId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/Activities/GetDeleteActivityParagraph",
        data: JSON.stringify({ activityId: activityId, paragraphId: paragraphId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#delete_paragraph_input").html(msg);
            $("#delete_paragraph_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#delete_paragraph_pop_up #yes", function (event) {
    event.preventDefault();

    var activityId = $(this).attr("data-section");
    var paragraphId = $(this).attr("data");

    $("#delete_paragraph_input").html("<img alt='loading' src='/Images/loading.gif' />");

    $.ajax({
        type: "POST",
        url: "/Activities/DeleteActivityParagraph",
        data: JSON.stringify({ paragraphId: paragraphId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#paragraph_activity_input").html("<img alt='loading'  src='/Images/loading.gif' />");

                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#delete_paragraph_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Activities/GetManageParagraphs",
                    data: JSON.stringify({ activityId: activityId }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#paragraph_activity_input").html(msg);
                        $("#delete_paragraph_input").html("");
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
 * FILE ACTIVIRY.
 ******************************/

/* CREATE ACTIVITY FILE TABS.*/
$(document).on("click", "#CreateActivityFileForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    var activityFileTranslationFormData = {
        ActivityFileSourceValue: $("#File_" + panelToClose + "").val(),
        ActivityFileText: $("#Title_" + panelToClose + "").val(),
        LanguageId: $("#Language_" + panelToClose + "").val()
    };

    $.ajax({
        type: "POST",
        url: "/Activities/ValidateCreateActivityFileTranslation",
        data: JSON.stringify(activityFileTranslationFormData),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg === "True") {
                //activitylinks : 
                $("#CreateActivityFileForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                $("#CreateActivityFileForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                //Filepanels :
                $("#CreateActivityFileForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                $("#CreateActivityFileForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
            } else {
                $("#CreateActivityFileForm").submit();
            }
        },
        error: function (jqXhr) {
            $("#add_file_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#CreateActivityFileForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //activitylinks : 
    $("#CreateActivityFileForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#CreateActivityFileForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //Filepanels
    $("#CreateActivityFileForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#CreateActivityFileForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

$(document).on("click", "#file_activity_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#file_activity_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#file_activity_btn", function (event) {
    event.preventDefault();

    var activityId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Activities/GetManageFiles",
        data: JSON.stringify({ activityId: activityId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#file_activity_input").html(msg);
            $("#file_activity_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#update_file_input").html(jqXhr.responseText);
        }
    });
});

/* CREATE FILE ACTIVITY.*/
$(document).on("click", "#add_file_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#add_file_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#add_file_btn", function (event) {
    event.preventDefault();

    var activityId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Activities/GetCreateActivityFile",
        data: JSON.stringify({ activityId: activityId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_file_input").html(msg);
            $("#add_file_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#add_file_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#CreateActivityFileForm", function (e) {
    e.preventDefault();

    var activityId = $("#CreateActivityFileForm #ActivityId").val();
    $("#add_file_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $("#file_activity_input").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#add_file_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Activities/GetManageFiles",
                    data: JSON.stringify({ activityId: activityId }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#file_activity_input").html(msg);
                        $("#add_file_input").html("");
                    },
                    error: function (jqXhr) {
                        alert(jqXhr.responseText);
                    }
                });
            }
            else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

/* UPDATE File ACTIVITY.*/
$(document).on("click", "#UpdateActivityFileForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    var activityFileSourceValue = $("#File_" + panelToClose + "").val();
    var activityFileTranslationFormData = {
        ActivityFileSourceValue: activityFileSourceValue,
        ActivityFileText: $("#Title_" + panelToClose + "").val(),
        LanguageId: $("#Language_" + panelToClose + "").val()
    };

    $.ajax({
        type: "POST",
        url: "/Activities/ValidateUpdateActivityFileTranslation",
        data: JSON.stringify(activityFileTranslationFormData),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg === "True") {
                //activitylinks : 
                $("#UpdateActivityFileForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                $("#UpdateActivityFileForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                //Filepanels :
                $("#UpdateActivityFileForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                $("#UpdateActivityFileForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
            } else {
                $("#UpdateActivityFileForm").submit();
            }
        },
        error: function (jqXhr) {
            $("#update_file_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#UpdateActivityFileForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //activitylinks : 
    $("#UpdateActivityFileForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#UpdateActivityFileForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //Filepanels
    $("#UpdateActivityFileForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#UpdateActivityFileForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

$(document).on("click", "#update_file_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#update_file_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#update_file_btn", function (event) {
    event.preventDefault();

    var fileId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Activities/GetUpdateActivityFile",
        data: JSON.stringify({ fileId: fileId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_file_input").html(msg);
            $("#update_file_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#update_file_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#UpdateActivityFileForm", function (e) {
    e.preventDefault();

    var activityId = $("#UpdateActivityFileForm #ActivityId").val();
    $("#update_file_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#file_activity_input").html("<img alt='loading' src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });

                $("#update_file_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Activities/GetManageFiles",
                    data: JSON.stringify({ activityId: activityId }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#file_activity_input").html(msg);
                        $("#update_file_input").html("");
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

/* DELETE ACTIVITY File.*/
$(document).on("click", "#delete_file_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#delete_file_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_file_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_file_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_file_btn", function (event) {
    event.preventDefault();

    var activityId = $(this).attr("data-section");
    var fileId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/Activities/GetDeleteActivityFile",
        data: JSON.stringify({ activityId: activityId, fileId: fileId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#delete_file_input").html(msg);
            $("#delete_file_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#delete_file_pop_up #yes", function (event) {
    event.preventDefault();

    var activityId = $(this).attr("data-section");
    var fileId = $(this).attr("data");

    $("#delete_file_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: "POST",
        url: "/Activities/DeleteActivityFile",
        data: JSON.stringify({ fileId: fileId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $.toast(msg.SuccessMessage, { 'width': 800 });

                $("#file_activity_input").html("<img alt='loading'  src='/Images/loading.gif' />");
                $("#delete_file_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Activities/GetManageFiles",
                    data: JSON.stringify({ activityId: activityId }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#file_activity_input").html(msg);
                        $("#delete_file_input").html("");
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