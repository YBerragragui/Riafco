/******************************
 * OCCURRENCE.
 ******************************/

/* CREATE OCCURRENCE TABS.*/
$(document).on("click", "#CreateOccurrenceForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    if (panelToClose === 0) {
        var occurrenceFormData = {
            OccurrenceStartDate: $("#OccurrenceStartDate").val(),
            OccurrenceEndDate: $("#OccurrenceEndDate").val(),
            OccurrenceLink: $("#OccurrenceLink").val()
        };

        $.ajax({
            type: "POST",
            url: "/Occurrences/ValidateOccurrenceFormData",
            data: JSON.stringify(occurrenceFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //occurrencelinks : 
                    $("#CreateOccurrenceForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#CreateOccurrenceForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //occurrencepanels
                    $("#CreateOccurrenceForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#CreateOccurrenceForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#CreateOccurrenceForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#add_occurrence_input").html(jqXhr.responseText);
            }
        });

    } else {
        var occurrenceTranslationFormData = {
            OccurrenceDescription: $("#Desc_" + panelToClose + "").val(),
            OccurrenceTitle: $("#Title_" + panelToClose + "").val(),
            LanguageId: $("#Language_" + panelToClose + "").val()
        };

        $.ajax({
            type: "POST",
            url: "/Occurrences/ValidateOccurrenceTranslationFormData",
            data: JSON.stringify(occurrenceTranslationFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //occurrencelinks : 
                    $("#CreateOccurrenceForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#CreateOccurrenceForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //occurrencepanels
                    $("#CreateOccurrenceForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#CreateOccurrenceForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                }
                else {
                    $("#CreateOccurrenceForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#add_occurrence_input").html(jqXhr.responseText);
            }
        });
    }
});

$(document).on("click", "#CreateOccurrenceForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //occurrencelinks : 
    $("#CreateOccurrenceForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#CreateOccurrenceForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //occurrencepanels
    $("#CreateOccurrenceForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#CreateOccurrenceForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

/* CREATE OCCURRENCE.*/
$(document).on("click", "#add_occurrence_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#add_occurrence_btn", function (e) {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: "/Occurrences/GetCreateOccurrence",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_occurrence_input").html(msg);
            $(".date_champ").datepicker({ dateFormat: "dd/mm/yy", minDate: null, autoSize: true, prevText: "<", nextText: ">" });
            $("#add_occurrence_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#add_occurrence_input").text(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#CreateOccurrenceForm", function (e) {
    e.preventDefault();

    $("#add_occurrence_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_occurrences").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#add_occurrence_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Occurrences/GetOccurrences",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_occurrences").html(msg);
                        $("#add_occurrence_input").html("");
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

/* UPDATE OCCURRENCE TABS.*/
$(document).on("click", "#UpdateOccurrenceForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    if (panelToClose === 0) {
        var occurrenceFormData = {
            OccurrenceStartDate: $("#OccurrenceStartDate").val(),
            OccurrenceEndDate: $("#OccurrenceEndDate").val(),
            OccurrenceLink: $("#OccurrenceLink").val()
        };

        $.ajax({
            type: "POST",
            url: "/Occurrences/ValidateOccurrenceFormData",
            data: JSON.stringify(occurrenceFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //occurrencelinks : 
                    $("#UpdateOccurrenceForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#UpdateOccurrenceForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //occurrencepanels
                    $("#UpdateOccurrenceForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#UpdateOccurrenceForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#UpdateOccurrenceForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#update_occurrence_input").html(jqXhr.responseText);
            }
        });

    } else {
        var occurrenceTranslationFormData = {
            TranslationId: $("#Translation_" + panelToClose + "").val(),
            OccurrenceDescription: $("#Desc_" + panelToClose + "").val(),
            OccurrenceTitle: $("#Title_" + panelToClose + "").val(),
            LanguageId: $("#Language_" + panelToClose + "").val()
        };

        $.ajax({
            type: "POST",
            url: "/Occurrences/ValidateOccurrenceTranslationFormData",
            data: JSON.stringify(occurrenceTranslationFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //occurrencelinks : 
                    $("#UpdateOccurrenceForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#UpdateOccurrenceForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //occurrencepanels
                    $("#UpdateOccurrenceForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#UpdateOccurrenceForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#UpdateOccurrenceForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#update_occurrence_input").html(jqXhr.responseText);
            }
        });
    }
});

$(document).on("click", "#UpdateOccurrenceForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //occurrencelinks : 
    $("#UpdateOccurrenceForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#UpdateOccurrenceForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //occurrencepanels
    $("#UpdateOccurrenceForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#UpdateOccurrenceForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

/* UPDATE OCCURRENCE.*/
$(document).on("click", "#update_occurrence_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();

        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#update_occurrence_btn", function (e) {
    e.preventDefault();

    var occurrenceId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Occurrences/GetUpdateOccurrence",
        data: JSON.stringify({ occurrenceId: occurrenceId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_occurrence_input").html(msg);
            $(".date_champ").datepicker({ dateFormat: "dd/mm/yy", minDate: null, autoSize: true, prevText: "<", nextText: ">" });
            $("#update_occurrence_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#update_occurrence_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#UpdateOccurrenceForm", function (e) {
    e.preventDefault();

    $("#update_occurrence_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $("#content_occurrences").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#update_occurrence_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Occurrences/GetOccurrences",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_occurrences").html(msg);
                        $("#update_occurrence_input").html("");
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
            $("#update_occurrence_input").html(jqXhr.responseText);
        }
    });
});


/* DELETE OCCURRENCE.*/
$(document).on("click", "#delete_occurrence_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#delete_occurrence_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_occurrence_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_occurrence_btn", function (event) {
    event.preventDefault();
    var occurrenceId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/Occurrences/GetDeleteOccurrence",
        data: JSON.stringify({ occurrenceId: occurrenceId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#delete_occurrence_input").html(msg);
            $("#delete_occurrence_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#delete_occurrence_pop_up #yes", function (event) {
    event.preventDefault();
    var occurrenceId = $(this).attr("data");
    $("#delete_occurrence_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: "POST",
        url: "/Occurrences/DeleteOccurrence",
        data: JSON.stringify({ occurrenceId: occurrenceId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_occurrences").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#delete_occurrence_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Occurrences/GetOccurrences",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_occurrences").html(msg);
                        $("#delete_occurrence_input").html("");
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
