function SuccessPaging() {
    $("html, body").animate({ scrollTop: 0 }, "slow");
}

$(document).ready(function () {
    $("#holder").jPages({
        containerID: "publications_items",
        callback: function () {
            SuccessPaging();
        },
        perPage: 4,
        previous: "span#previous",
        first: "span#first",
        next: "span#next",
        last: "span#last"
    });
});



$(document).on("submit", "#filter-form", function (e) {
    e.preventDefault();

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            $("#pulications-list").html(msg);
            $("#holder").jPages({
                containerID: "publications_items",
                callback: function () {
                    SuccessPaging();
                },
                perPage: 4,
                previous: "span#previous",
                first: "span#first",
                next: "span#next",
                last: "span#last"
            });
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});