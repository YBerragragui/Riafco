//add ou update user:
$(document).on('click', '#manage_rule_pop_up', function (event) {
    if ($(event.target).is('.cd-popup-close') || $(event.target).is('.cd-popup')) {
        event.preventDefault();
        $('#manage_rule_input').html('');
        $(this).removeClass('is-visible');
        $('body').removeClass('hidden_body');
    }
});

$(document).on("click", "#add_rule_btn", function (e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: "/Users/GetRules",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $('#manage_rule_input').html(msg);
            $('#manage_rule_pop_up').addClass('is-visible');
            $('body').addClass('hidden_body');
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR.responseText);
        }
    });
});

$(document).on("click", "#update_rule", function (e) {
    e.preventDefault();

    var ruleId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Users/GetUpdateUser",
        data: JSON.stringify({ ruleId: ruleId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $('#manage_rule_input').html(msg);
            $('#manage_rule_pop_up').addClass('is-visible');
            $('body').addClass('hidden_body');
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR.responseText);
        }
    });
});