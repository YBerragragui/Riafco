/******************************
 * CREATE LANGUAGE.
 ******************************/
$(document).on("click", "#add_language_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close") || $(event.target).is(".cd-popup")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#add_language_btn", function (e) {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: "/Settings/GetCreateLanguage",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_language_input").html(msg);
            $("#add_language_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#add_language_input").text(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#create_language_form", function (e) {
    e.preventDefault();
    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $.toast(msg.SuccessMessage, { 'width' : 800 });
                $.ajax({
                    type: "POST",
                    url: "/Settings/GetLanguages",
                    contentType: "application/json; charset=utf-8",
                    success: function(msg) {
                        $("#content_language").html(msg);
                        $("#add_language_pop_up").removeClass("is-visible");
                        $("body").removeClass("hidden_body");
                        $("#add_language_input").html("");
                    },
                    error: function(jqXhr) {
                        $("#add_language_input").html(jqXhr.responseText);

                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            $("#add_language_input").html(jqXhr.responseText);
        }
    });
});


/******************************
 * UPDATE LANGUAGE.
 ******************************/

$(document).on("click", "#update_language_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close") || $(event.target).is(".cd-popup")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#update_language_btn", function (e) {
    e.preventDefault();

    var languageId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Settings/GetUpdateLanguage",
        data: JSON.stringify({ languageId: languageId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_language_input").html(msg);
            $("#update_language_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#update_language_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#update_language_form", function (e) {
    e.preventDefault();
    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $.ajax({
                    type: "POST",
                    url: "/Settings/GetLanguages",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_language").html(msg);
                        $("#update_language_pop_up").removeClass("is-visible");
                        $("body").removeClass("hidden_body");
                        $("#update_language_input").html("");
                    },
                    error: function (jqXhr) {
                        $("#update_language_input").html(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            $("#update_language_input").html(jqXhr.responseText);
        }
    });
});


/******************************
 * DELETE LANGUAGE.
 ******************************/
$(document).on("click", "#delete_language_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close") || $(event.target).is(".cd-popup")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#delete_language_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_language_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_language_btn", function (event) {
    event.preventDefault();
    var languageId = $(this).attr("data");

    $("#delete_language_pop_up #yes").attr("data", languageId);
    $("#delete_language_pop_up").addClass("is-visible");
    $("body").addClass("hidden_body");
});

$(document).on("click", "#delete_language_pop_up #yes", function (event) {
    event.preventDefault();
    var languageId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Settings/DeleteLanguage",
        data: JSON.stringify({ languageId: languageId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $.ajax({
                    type: "POST",
                    url: "/Settings/GetLanguages",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_language").html(msg);
                        $("#delete_language_pop_up").removeClass("is-visible");
                        $("body").removeClass("hidden_body");
                    },
                    error: function (jqXhr) {
                        $("#delete_language_input").html(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            $("#delete_language_input").html(jqXhr.responseText);
        }
    });
});


/******************************
 * CREATE RULE.
 ******************************/
$(document).on("click", "#add_rule_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close") || $(event.target).is(".cd-popup")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#add_rule_btn", function (e) {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: "/Settings/GetCreateRule",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_rule_input").html(msg);
            $("#add_rule_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#add_rule_input").text(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#CreateRuleForm", function (e) {
    e.preventDefault();
    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $.ajax({
                    type: "POST",
                    url: "/Settings/GetRules",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_rule").html(msg);
                        $("#add_rule_pop_up").removeClass("is-visible");
                        $("body").removeClass("hidden_body");
                        $("#add_rule_input").html("");
                    },
                    error: function (jqXhr) {
                        $("#add_rule_input").html(jqXhr.responseText);

                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            $("#add_rule_input").html(jqXhr.responseText);
        }
    });
});


/******************************
 * UPDATE RULE.
 ******************************/

$(document).on("click", "#update_rule_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close") || $(event.target).is(".cd-popup")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#update_rule_btn", function (e) {
    e.preventDefault();

    var ruleId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Settings/GetUpdateRule",
        data: JSON.stringify({ ruleId: ruleId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_rule_input").html(msg);
            $("#update_rule_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#update_rule_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#UpdateRuleForm", function (e) {
    e.preventDefault();
    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $.ajax({
                    type: "POST",
                    url: "/Settings/Getrules",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_rule").html(msg);
                        $("#update_rule_pop_up").removeClass("is-visible");
                        $("body").removeClass("hidden_body");
                        $("#update_rule_input").html("");
                    },
                    error: function (jqXhr) {
                        $("#update_rule_input").html(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            $("#update_rule_input").html(jqXhr.responseText);
        }
    });
});


/******************************
 * DELETE RULE.
 ******************************/
$(document).on("click", "#delete_rule_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close") || $(event.target).is(".cd-popup")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#delete_rule_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_rule_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_rule_btn", function (event) {
    event.preventDefault();

    var ruleId = $(this).attr("data");

    $("#delete_rule_pop_up #yes").attr("data", ruleId);
    $("#delete_rule_pop_up").addClass("is-visible");
    $("body").addClass("hidden_body");
});

$(document).on("click", "#delete_rule_pop_up #yes", function (event) {
    event.preventDefault();
    var ruleId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Settings/DeleteRule",
        data: JSON.stringify({ ruleId: ruleId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $.ajax({
                    type: "POST",
                    url: "/Settings/Getrules",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_rule").html(msg);
                        $("#delete_rule_pop_up").removeClass("is-visible");
                        $("body").removeClass("hidden_body");
                    },
                    error: function (jqXhr) {
                        $("#delete_rule_input").html(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            $("#delete_rule_input").html(jqXhr.responseText);
        }
    });
});