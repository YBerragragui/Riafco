function SuccessPaging() {
    $("html, body").animate({ scrollTop: 0 }, "slow");
}

function closeme() {
    $("#countryIfcl").html("");
}

$(document).ready(function () {

    $("#holder").jPages({
        containerID: "news_items",
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

$.ajax({
    type: "POST",
    url: "/Home/GetCountriesMap",
    success: function (msg) {
        var mydata = msg;
        window.Highcharts.mapChart("container", {
            legend: {enabled: false},
            tooltip: { enabled: false },
            exporting: {enabled: false},
            credits: {enabled: false},
            chart: {backgroundColor: "#E6E6E6",marginTop: 0,marginRight: 0,marginBottom: 0,marginLeft: 0},
            title: {text: ""},
            plotOptions: {
                series: {
                    events: {
                        click: function (e) {
                            var key = e.point["hc-key"];

                            $.ajax({
                                type: "POST",
                                url: "/Home/GetCountry",
                                data: JSON.stringify({ countryCode: key }),
                                contentType: "application/json; charset=utf-8",
                                success: function (msg) {
                                    $("#countryIfcl").html(msg);
                                },
                                error: function (jqXhr) {
                                    alert(jqXhr.responseText);
                                }
                            });
                        }
                    }
                }
            },
            series: [{nullColor: "#D2D2D2",data: mydata,borderColor: "#D2D2D2",mapData: window.Highcharts.maps["custom/africa"],states: {hover: {color: "#619BBD"}}}]
        });
    }
});