/******************************
 * PARTNER.
 ******************************/
/* CREATE PARTNER.*/
$(document).on("click", "#add_partner_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#add_partner_btn", function (e) {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: "/Partners/GetCreatePartner",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_partner_input").html(msg);
            $("#add_partner_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#add_partner_input").text(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#CreatePartnerForm", function (e) {
    e.preventDefault();

    $("#add_partner_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_partners").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#add_partner_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Partners/GetPartners",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_partners").html(msg);
                        $("#add_partner_input").html("");
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

/* UPDATE PARTNER.*/
$(document).on("click", "#update_partner_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();

        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#update_partner_btn", function (e) {
    e.preventDefault();

    var partnerId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Partners/GetUpdatePartner",
        data: JSON.stringify({ partnerId: partnerId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_partner_input").html(msg);
            $("#update_partner_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#update_partner_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#UpdatePartnerForm", function (e) {
    e.preventDefault();

    $("#update_partner_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $("#content_partners").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#update_partner_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Partners/GetPartners",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_partners").html(msg);
                        $("#update_partner_input").html("");
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
            $("#update_partner_input").html(jqXhr.responseText);
        }
    });
});


/* DELETE PARTNER.*/
$(document).on("click", "#delete_partner_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#delete_partner_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_partner_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_partner_btn", function (event) {
    event.preventDefault();
    var partnerId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/Partners/GetDeletePartner",
        data: JSON.stringify({ partnerId: partnerId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#delete_partner_input").html(msg);
            $("#delete_partner_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#delete_partner_pop_up #yes", function (event) {
    event.preventDefault();
    var partnerId = $(this).attr("data");
    $("#delete_partner_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: "POST",
        url: "/Partners/DeletePartner",
        data: JSON.stringify({ partnerId: partnerId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_partners").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#delete_partner_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Partners/GetPartners",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_partners").html(msg);
                        $("#delete_partner_input").html("");
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
