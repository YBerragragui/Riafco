/******************************
 * CREATE USER.
 ******************************/
$(document).on("click", "#add_user_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close") || $(event.target).is(".cd-popup")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#add_user_btn", function (e) {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: "/Users/GetCreateUser",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_user_input").html(msg);
            $("#add_user_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#add_user_input").text(jqXhr.responseText);
            $("#add_user_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        }
    });
});

$(document).on("submit", "#CreateUserForm", function (e) {
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
                    url: "/Users/GetUsers",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#users_container").html(msg);
                        $("#add_user_pop_up").removeClass("is-visible");
                        $("body").removeClass("hidden_body");
                        $("#add_user_input").html("");
                    },
                    error: function (jqXhr) {
                        $("#add_user_input").html(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            $("#add_user_input").html(jqXhr.responseText);
        }
    });
});


/******************************
 * UPDATE USER.
 ******************************/

$(document).on("click", "#update_user_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close") || $(event.target).is(".cd-popup")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#update_user_btn", function (e) {
    e.preventDefault();

    var userId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Users/GetUpdateUser",
        data: JSON.stringify({ userId: userId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_user_input").html(msg);
            $("#update_user_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#update_user_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#UpdateUserForm", function (e) {
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
                    url: "/Users/GetUsers",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#users_container").html(msg);
                        $("#update_user_pop_up").removeClass("is-visible");
                        $("body").removeClass("hidden_body");
                        $("#update_user_input").html("");
                    },
                    error: function (jqXhr) {
                        $("#update_user_input").html(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            $("#update_user_input").html(jqXhr.responseText);
        }
    });
});


/******************************
 * DELETE USER.
 ******************************/
$(document).on("click", "#delete_user_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close") || $(event.target).is(".cd-popup")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#delete_user_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_user_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_user_btn", function (event) {
    event.preventDefault();

    var userId = $(this).attr("data");

    $("#delete_user_pop_up #yes").attr("data", userId);
    $("#delete_user_pop_up").addClass("is-visible");
    $("body").addClass("hidden_body");
});

$(document).on("click", "#delete_user_pop_up #yes", function (event) {
    event.preventDefault();
    var userId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Users/DeleteUser",
        data: JSON.stringify({ userId: userId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $.ajax({
                    type: "POST",
                    url: "/Users/GetUsers",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#users_container").html(msg);
                        $("#delete_user_pop_up").removeClass("is-visible");
                        $("body").removeClass("hidden_body");
                    },
                    error: function (jqXhr) {
                        $("#delete_user_input").html(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            $("#delete_user_input").html(jqXhr.responseText);
        }
    });
});


/******************************
 * ACTIVATE USER.
 ******************************/
$(document).on("click", "#activate_user", function (event) {
    event.preventDefault();
    var userId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Users/ActivateUser",
        data: JSON.stringify({ userId: userId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $.ajax({
                    type: "POST",
                    url: "/Users/GetUsers",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#users_container").html(msg);
                        $("#delete_user_pop_up").removeClass("is-visible");
                        $("body").removeClass("hidden_body");
                    },
                    error: function (jqXhr) {
                        $("#delete_user_input").html(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            $("#delete_user_input").html(jqXhr.responseText);
        }
    });
});


/******************************
 * UPDATE USER RULES.
 ******************************/
$(document).on("click", "#user_rules_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close") || $(event.target).is(".cd-popup")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#user_rules_btn", function (e) {
    e.preventDefault();
    var userId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/Users/GetUserRules",
        data: JSON.stringify({ userId: userId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#user_rules_input").html(msg);
            $("#user_rules_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#user_rules_input").html(jqXhr.responseText);
            $("#user_rules_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        }
    });
});

$(document).on("submit", "#user_rules_form", function (e) {
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
                    url: "/Users/GetUsers",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#users_container").html(msg);
                        $("#user_rules_pop_up").removeClass("is-visible");
                        $("body").removeClass("hidden_body");
                        $("#user_rules_input").html("");
                    },
                    error: function (jqXhr) {
                        $("#user_rules_pop_up").html(jqXhr.responseText);
                    }
                });
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            $("#user_rules_input").html(jqXhr.responseText);
        }
    });
});