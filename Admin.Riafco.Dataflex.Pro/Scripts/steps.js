/********************************************************************************************
 * **************************  CREATE STEP **************************************************
 ********************************************************************************************/
$(document).on("click", "#add_step_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#add_step_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#add_step_btn", function (e) {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: "/About/GetCreateStep",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_step_input").html(msg);
            $(".date_champ").datepicker({ dateFormat: "dd/mm/yy", minDate: null, autoSize: true, prevText: "<", nextText: ">" });
            $("#add_step_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#CreateStepForm", function (e) {
    e.preventDefault();

    $("#add_step_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_steps").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#add_step_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/About/GetSteps",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_steps").html(msg);
                        $("#add_step_input").html("");
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



/********************************************************************************************
 * **************************  UPDATE STEP **************************************************
 ********************************************************************************************/
$(document).on("click", "#update_step_pop_up .cd-popup-close", function (event) {
    event.preventDefault();

    $("#update_step_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#update_step_btn", function (e) {
    e.preventDefault();

    var stepId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/About/GetUpdateStep",
        data: JSON.stringify({ stepId: stepId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_step_input").html(msg);
            $(".date_champ").datepicker({ dateFormat: "dd/mm/yy", minDate: null, autoSize: true, prevText: "<", nextText: ">" });
            $("#update_step_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#UpdateStepForm", function (e) {
    e.preventDefault();

    $("#update_step_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_steps").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#update_step_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/About/GetSteps",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_steps").html(msg);
                        $("#update_step_input").html("");
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

/********************************************************************************************
 * **************************  DELETE STEP **************************************************
 ********************************************************************************************/

$(document).on("click", "#delete_step_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#delete_step_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_step_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_step_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_step_btn", function (event) {
    event.preventDefault();
    var stepId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/About/GetDeleteStep",
        data: JSON.stringify({ stepId: stepId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#delete_step_input").html(msg);
            $("#delete_step_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#delete_step_pop_up #yes", function (event) {
    event.preventDefault();

    var stepId = $(this).attr("data");
    $("#delete_step_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: "POST",
        url: "/About/DeleteStep",
        data: JSON.stringify({ stepId: stepId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_steps").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#delete_step_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/About/GetSteps",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_steps").html(msg);
                        $("#delete_step_input").html("");
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

/********************************************************************************************
 * ************************** PARAGRAPHS STEP **********************************************
 ********************************************************************************************/

$(document).on("click", "#paragraph_step_pop_up .cd-popup-close", function (event) {
    event.preventDefault();

    $("#paragraph_step_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#paragraph_step_btn", function (event) {
    event.preventDefault();

    var stepId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/About/StepParagraphs",
        data: JSON.stringify({ stepId: stepId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#paragraph_step_input").html(msg);

            $("#paragraph_step_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#add_step_paragraph_btn", function (event) {
    event.preventDefault();

    var stepId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/About/GetCreateStepParagraph",
        data: JSON.stringify({ stepId: stepId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_paragraph_input").html(msg);

            $("#add_paragraph_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});


$(document).on("submit", "#CreateStepParagraphForm", function (e) {
    e.preventDefault();

    var stepId = $("#CreateStepParagraphForm #StepId").val();
    $("#add_paragraph_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $.ajax({
                    type: "POST",
                    url: "/About/StepParagraphs",
                    data: JSON.stringify({ stepId: stepId }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#paragraph_step_input").html(msg);

                        $("#add_paragraph_pop_up").removeClass("is-visible");
                        $("body").removeClass("hidden_body");
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

/* CREATE PARAGRAPH TABS.*/
$(document).on("click", "#CreateStepParagraphForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);


    var sectionParagraphTranslationFormData = {
        ParagraphDescription: $("#Desc_" + panelToClose + "").val(),
        ParagraphTitle: $("#Title_" + panelToClose + "").val(),
        LanguageId: $("#Language_" + panelToClose + "").val()
    };

    $.ajax({
        type: "POST",
        url: "/About/ValidateStepParagraphTranslation",
        data: JSON.stringify(sectionParagraphTranslationFormData),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg === "True") {
                //sectionlinks : 
                $("#CreateStepParagraphForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                $("#CreateStepParagraphForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                //paragraphpanels :
                $("#CreateStepParagraphForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                $("#CreateStepParagraphForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
            } else {
                $("#CreateStepParagraphForm").submit();
            }
        },
        error: function (jqXhr) {
            $("#add_paragraph_input").html(jqXhr.responseText);
        }
    });

});

$(document).on("click", "#CreateStepParagraphForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //sectionlinks : 
    $("#CreateStepParagraphForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#CreateStepParagraphForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //paragraphpanels
    $("#CreateStepParagraphForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#CreateStepParagraphForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

/* DELETE STEP PARAGRAPH.*/
$(document).on("click", "#delete_step_paragraph_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#delete_step_paragraph_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_step_paragraph_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_step_paragraph_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_step_paragraph_btn", function (event) {
    event.preventDefault();

    var stepId = $(this).attr("data-step");
    var paragraphId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/About/GetDeleteStepParagraph",
        data: JSON.stringify({ paragraphId: paragraphId, stepId: stepId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#delete_step_paragraph_input").html(msg);
            $("#delete_step_paragraph_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#delete_step_paragraph_pop_up #yes", function (event) {
    event.preventDefault();

    var stepId = $(this).attr("data-step");
    var paragraphId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/About/DeleteStepParagraph",
        data: JSON.stringify({ paragraphId: paragraphId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $.toast(msg.SuccessMessage, { 'width': 800 });

                $.ajax({
                    type: "POST",
                    url: "/About/StepParagraphs",
                    data: JSON.stringify({ stepId: stepId }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#paragraph_step_input").html(msg);

                        $("#delete_step_paragraph_pop_up").removeClass("is-visible");
                        $("body").removeClass("hidden_body");
                        $("#delete_step_paragraph_input").html("");
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



/********************************************************************************************
 * ************************** UPDATE PARAGRAPH STEP *****************************************
 ********************************************************************************************/
$(document).on("click", "#update_paragraph_step_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#update_paragraph_step_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#update_step_paragraph_btn", function (event) {
    event.preventDefault();

    var paragraphId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/About/GetUpdateStepParagraph",
        data: JSON.stringify({ paragraphId: paragraphId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_paragraph_step_input").html(msg);

            $("#update_paragraph_step_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});


$(document).on("submit", "#UpdateStepParagraphForm", function (e) {
    e.preventDefault();

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                var stepId = $("#UpdateStepParagraphForm #StepId").val();

                $("#update_paragraph_step_input").html("<img alt='loading'  src='/Images/loading.gif' />");

                $.ajax({
                    type: "POST",
                    url: "/About/StepParagraphs",
                    data: JSON.stringify({ stepId: stepId }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#paragraph_step_input").html(msg);

                        $("#update_paragraph_step_pop_up").removeClass("is-visible");
                        $("body").removeClass("hidden_body");
                        $("#update_paragraph_step_input").html("");
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

/* CREATE PARAGRAPH TABS.*/
$(document).on("click", "#UpdateStepParagraphForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);


    var sectionParagraphTranslationFormData = {
        ParagraphDescription: $("#Desc_" + panelToClose + "").val(),
        ParagraphTitle: $("#Title_" + panelToClose + "").val(),
        LanguageId: $("#Language_" + panelToClose + "").val()
    };

    $.ajax({
        type: "POST",
        url: "/About/ValidateStepParagraphTranslation",
        data: JSON.stringify(sectionParagraphTranslationFormData),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg === "True") {
                //sectionlinks : 
                $("#UpdateStepParagraphForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                $("#UpdateStepParagraphForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                //paragraphpanels :
                $("#UpdateStepParagraphForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                $("#UpdateStepParagraphForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
            } else {
                $("#UpdateStepParagraphForm").submit();
            }
        },
        error: function (jqXhr) {
            $("#add_paragraph_input").html(jqXhr.responseText);
        }
    });

});

$(document).on("click", "#UpdateStepParagraphForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //sectionlinks : 
    $("#UpdateStepParagraphForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#UpdateStepParagraphForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //paragraphpanels
    $("#UpdateStepParagraphForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#UpdateStepParagraphForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});