$(document).on("submit", "#SendMessageForm", function (e) {
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
                $("#SendMessageForm")[0].reset();
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});