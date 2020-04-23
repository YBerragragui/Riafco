/******************************
 * SUBSCRIBER.
 ******************************/
/* CREATE SUBSCRIBER.*/
$(document).on("click", "#add_subscriber_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#add_subscriber_btn", function (e) {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: "/Newsletters/GetCreateSubscriber",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_subscriber_input").html(msg);
            $("#add_subscriber_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#add_subscriber_input").text(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#CreateSubscriberForm", function (e) {
    e.preventDefault();

    $("#add_subscriber_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_subscribers").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#add_subscriber_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Newsletters/GetSubscribers",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_subscribers").html(msg);
                        $("#add_subscriber_input").html("");
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

/* UPDATE SUBSCRIBER.*/
$(document).on("click", "#update_subscriber_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();

        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#update_subscriber_btn", function (e) {
    e.preventDefault();

    var subscriberId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Newsletters/GetUpdateSubscriber",
        data: JSON.stringify({ subscriberId: subscriberId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_subscriber_input").html(msg);
            $("#update_subscriber_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#update_subscriber_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#UpdateSubscriberForm", function (e) {
    e.preventDefault();

    $("#update_subscriber_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $("#content_subscribers").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#update_subscriber_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Newsletters/GetSubscribers",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_subscribers").html(msg);
                        $("#update_subscriber_input").html("");
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
            $("#update_subscriber_input").html(jqXhr.responseText);
        }
    });
});


/* DELETE SUBSCRIBER.*/
$(document).on("click", "#delete_subscriber_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#delete_subscriber_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_subscriber_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_subscriber_btn", function (event) {
    event.preventDefault();
    var subscriberId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/Newsletters/GetDeleteSubscriber",
        data: JSON.stringify({ subscriberId: subscriberId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#delete_subscriber_input").html(msg);
            $("#delete_subscriber_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#delete_subscriber_pop_up #yes", function (event) {
    event.preventDefault();
    var subscriberId = $(this).attr("data");
    $("#delete_subscriber_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: "POST",
        url: "/Newsletters/DeleteSubscriber",
        data: JSON.stringify({ subscriberId: subscriberId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_subscribers").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#delete_subscriber_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Newsletters/GetSubscribers",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_subscribers").html(msg);
                        $("#delete_subscriber_input").html("");
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
 * NEWSLETTER.
 ******************************/

/* CREATE NEWSLETTER TABS.*/
$(document).on("click", "#CreateNewsletterMailForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    var newsletterMailTranslationFormData = {
        NewsletterMailSubject: $("#Subject_" + panelToClose + "").val(),
        NewsletterMailSourceName: $("#Source_" + panelToClose + "").val(),
        LanguageId: $("#Language_" + panelToClose + "").val()
    };

    $.ajax({
        type: "POST",
        url: "/Newsletters/ValidateCreateNewsletterMailTranslationFormData",
        data: JSON.stringify(newsletterMailTranslationFormData),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg === "True") {
                //newsletterMaillinks : 
                $("#CreateNewsletterMailForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                $("#CreateNewsletterMailForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                //newsletterMailpanels
                $("#CreateNewsletterMailForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                $("#CreateNewsletterMailForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
            }
            else {
                $("#CreateNewsletterMailForm").submit();
            }
        },
        error: function (jqXhr) {
            $("#add_newsletter_mail_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#CreateNewsletterMailForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //newsletterMaillinks : 
    $("#CreateNewsletterMailForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#CreateNewsletterMailForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //newsletterMailpanels
    $("#CreateNewsletterMailForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#CreateNewsletterMailForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

/* CREATE NEWSLETTER.*/
$(document).on("click", "#add_newsletter_mail_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#add_newsletter_mail_btn", function (e) {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: "/Newsletters/GetCreateNewsletterMail",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_newsletter_mail_input").html(msg);
            $("#add_newsletter_mail_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#add_newsletter_mail_input").text(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#CreateNewsletterMailForm", function (e) {
    e.preventDefault();

    $("#add_newsletter_mail_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_newsletter_mails").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#add_newsletter_mail_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Newsletters/GetNewsletterMails",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_newsletter_mails").html(msg);
                        $("#add_newsletter_mail_input").html("");
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

/* UPDATE NEWSLETTER TABS.*/
$(document).on("click", "#UpdateNewsletterMailForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    var newsletterMailTranslationFormData = {
        TranslationId: $("#Translation_" + panelToClose + "").val(),
        NewsletterMailSubject: $("#Subject_" + panelToClose + "").val(),
        NewsletterMailSourceName: $("#Source_" + panelToClose + "").val(),
        LanguageId: $("#Language_" + panelToClose + "").val()
    };

    $.ajax({
        type: "POST",
        url: "/Newsletters/ValidateUpdateNewsletterMailTranslationFormData",
        data: JSON.stringify(newsletterMailTranslationFormData),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg === "True") {
                //newsletterMaillinks : 
                $("#UpdateNewsletterMailForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                $("#UpdateNewsletterMailForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                //newsletterMailpanels
                $("#UpdateNewsletterMailForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                $("#UpdateNewsletterMailForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
            } else {
                $("#UpdateNewsletterMailForm").submit();
            }
        },
        error: function (jqXhr) {
            $("#update_newsletter_mail_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#UpdateNewsletterMailForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //newsletterMaillinks : 
    $("#UpdateNewsletterMailForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#UpdateNewsletterMailForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //newsletterMailpanels
    $("#UpdateNewsletterMailForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#UpdateNewsletterMailForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

/* UPDATE NEWSLETTER.*/
$(document).on("click", "#update_newsletter_mail_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();

        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#update_newsletter_mail_btn", function (e) {
    e.preventDefault();

    var newsletterMailId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Newsletters/GetUpdateNewsletterMail",
        data: JSON.stringify({ newsletterMailId: newsletterMailId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_newsletter_mail_input").html(msg);
            $("#update_newsletter_mail_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#update_newsletter_mail_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#UpdateNewsletterMailForm", function (e) {
    e.preventDefault();

    $("#update_newsletter_mail_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $("#content_newsletter_mails").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#update_newsletter_mail_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Newsletters/GetNewsletterMails",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_newsletter_mails").html(msg);
                        $("#update_newsletter_mail_input").html("");
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
            $("#update_newsletter_mail_input").html(jqXhr.responseText);
        }
    });
});


/* DELETE NEWSLETTER.*/
$(document).on("click", "#delete_newsletter_mail_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#delete_newsletter_mail_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_newsletter_mail_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_newsletter_mail_btn", function (event) {
    event.preventDefault();
    var newsletterMailId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/Newsletters/GetDeleteNewsletterMail",
        data: JSON.stringify({ newsletterMailId: newsletterMailId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#delete_newsletter_mail_input").html(msg);
            $("#delete_newsletter_mail_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#delete_newsletter_mail_pop_up #yes", function (event) {
    event.preventDefault();
    var newsletterMailId = $(this).attr("data");
    $("#delete_newsletter_mail_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: "POST",
        url: "/Newsletters/DeleteNewsletterMail",
        data: JSON.stringify({ newsletterMailId: newsletterMailId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_newsletter_mails").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#delete_newsletter_mail_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Newsletters/GetNewsletterMails",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_newsletter_mails").html(msg);
                        $("#delete_newsletter_mail_input").html("");
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
