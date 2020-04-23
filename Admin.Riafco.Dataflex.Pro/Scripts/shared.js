function activer_lien(id) {
    $(".link").removeClass("active");
    $("#" + id).addClass("active");
}

$(document).on("click", "#crop_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close") || $(event.target).is(".cd-popup")) {
        event.preventDefault();

        $("#crop_pop_up").removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});
