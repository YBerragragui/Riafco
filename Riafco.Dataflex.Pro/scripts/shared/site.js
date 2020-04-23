$(document).ready(function () {
    var owl = $(".owl-carousel1").owlCarousel({
        loop: true,
        margin: 10,
        responsive:
            {
                0: { items: 3 },
                355: { items: 2 },
                600: { items: 3 },
                1000: { items: 4 }
            }
    });
    $(".next_carousel").click(function () {
        owl.trigger("next.owl.carousel");
    });
    $(".prev_carousel").click(function () {
        owl.trigger("prev.owl.carousel");
    });

    $(".owl-carousel2").owlCarousel({
        loop: true,
        margin: 10,
        responsive:
        {
            0: { items: 1 },
            600: { items: 2 },
            1000: { items: 3 }
        }
    });
    $("#resourceDate").datetimepicker();
});

$(document).on("submit", "#CreateSubscribeForm", function (e) {
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
                $("#CreateSubscribeForm")[0].reset();
            } else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});


