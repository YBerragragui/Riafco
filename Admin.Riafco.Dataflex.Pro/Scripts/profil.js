$(document).on("submit", "#update_Profile", function (e) {
    e.preventDefault();
    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        dataType: "json",
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $.toast(msg.SuccessMessage, { 'width': 1000 });
            }
            else {
                $.toast(msg.ErrorMessage, { 'width': 1000 });
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});
