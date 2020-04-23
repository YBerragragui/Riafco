/*GENERATE CODE*/
$(document).on("submit", "#generate_code_form", function (e) {
    e.preventDefault();
    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg === "True") {
                $.toast("OPÉRATION VALIDE.", { 'width': 1000 });
            }
            else {
                $.toast("CLASSE EST INTROUVABLE.", { 'width': 1000 });
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});