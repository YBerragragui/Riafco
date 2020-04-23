/******************************
 * COUNTRY.
 ******************************/

/* set hidden inputs from countrises dropdownlist*/
$(document).on("change", "#countrises", function (event) {
    event.preventDefault();

    var value = $("#countrises option:selected").attr("value");
    var text = $("#countrises option:selected").text();
    $("#CountryShortName").val(text);
    $("#CountryCode").val(value);
});


/*CREATE COUNTRY TABS.*/
$(document).on("click", "#CreateCountryForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    if (panelToClose === 0) {
        var countryFormData = {
            CountryShortName: $("#CountryShortName").val(),
            CountryImageValue: $("#CountryImage").val(),
            CountryCode: $("#CountryCode").val()
        };

        $.ajax({
            type: "POST",
            url: "/Offices/ValidateCreateCountryFormData",
            data: JSON.stringify(countryFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //countrylinks : 
                    $("#CreateCountryForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#CreateCountryForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //countrypanels
                    $("#CreateCountryForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#CreateCountryForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#CreateCountryForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#add_country_input").html(jqXhr.responseText);
            }
        });

    } else {
        var countryTranslationFormData = {
            CountrySummary: $("#Sum_" + panelToClose + "").val(),
            CountryDescription: $("#Desc_" + panelToClose + "").val(),
            CountryTitle: $("#Title_" + panelToClose + "").val(),
            CountryName: $("#Name_" + panelToClose + "").val(),
            LanguageId: $("#Language_" + panelToClose + "").val()
        };

        $.ajax({
            type: "POST",
            url: "/Offices/ValidateCountryTranslationFormData",
            data: JSON.stringify(countryTranslationFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //countrylinks : 
                    $("#CreateCountryForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#CreateCountryForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //countrypanels
                    $("#CreateCountryForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#CreateCountryForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                }
                else {
                    $("#CreateCountryForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#add_country_input").html(jqXhr.responseText);
            }
        });
    }
});

$(document).on("click", "#CreateCountryForm .prev", function (event) {
    event.preventDefault();
    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //countrylinks : 
    $("#CreateCountryForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#CreateCountryForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //countrypanels
    $("#CreateCountryForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#CreateCountryForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

/* CREATE COUNTRY.*/
$(document).on("click", "#add_country_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#add_country_btn", function (e) {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: "/Offices/GetCreateCountry",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_country_input").html(msg);
            $("#add_country_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#add_country_input").text(jqXhr.responseText);
        }
    });
});
$(document).on("submit", "#CreateCountryForm", function (e) {
    e.preventDefault();

    $("#add_country_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_countries").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#add_country_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Offices/GetCountries",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_countries").html(msg);
                        $("#add_country_input").html("");
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

/* UPDATE COUNTRY TABS.*/
$(document).on("click", "#UpdateCountryForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    if (panelToClose === 0) {
        var countryFormData = {
            CountryShortName: $("#CountryShortName").val(),
            CountryImageValue: $("#CountryImage").val(),
            CountryCode: $("#CountryCode").val(),
            CountryId: $("#CountryId").val()
        };

        $.ajax({
            type: "POST",
            url: "/Offices/ValidateUpdateCountryFormData",
            data: JSON.stringify(countryFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //countrylinks : 
                    $("#UpdateCountryForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#UpdateCountryForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //countrypanels
                    $("#UpdateCountryForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#UpdateCountryForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#UpdateCountryForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#update_country_input").html(jqXhr.responseText);
            }
        });

    } else {
        var countryTranslationFormData = {
            CountrySummary: $("#Sum_" + panelToClose + "").val(),
            TranslationId: $("#Translation_" + panelToClose + "").val(),
            CountryDescription: $("#Desc_" + panelToClose + "").val(),
            CountryTitle: $("#Title_" + panelToClose + "").val(),
            CountryName: $("#Name_" + panelToClose + "").val(),
            LanguageId: $("#Language_" + panelToClose + "").val()
        };

        $.ajax({
            type: "POST",
            url: "/Offices/ValidateCountryTranslationFormData",
            data: JSON.stringify(countryTranslationFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //countrylinks : 
                    $("#UpdateCountryForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#UpdateCountryForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //countrypanels
                    $("#UpdateCountryForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#UpdateCountryForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#UpdateCountryForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#update_country_input").html(jqXhr.responseText);
            }
        });
    }
});

$(document).on("click", "#UpdateCountryForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //countrylinks : 
    $("#UpdateCountryForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#UpdateCountryForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //countrypanels
    $("#UpdateCountryForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#UpdateCountryForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

/* UPDATE COUNTRY.*/
$(document).on("click", "#update_country_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();

        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#update_country_btn", function (e) {
    e.preventDefault();

    var countryId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Offices/GetUpdateCountry",
        data: JSON.stringify({ countryId: countryId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_country_input").html(msg);
            var value = $("#CountryCode").val();
            $("#countrises").val(value);

            $("#update_country_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#update_country_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#UpdateCountryForm", function (e) {
    e.preventDefault();

    $("#update_country_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $("#content_countries").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#update_country_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Offices/GetCountries",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_countries").html(msg);
                        $("#update_country_input").html("");
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
            $("#update_country_input").html(jqXhr.responseText);
        }
    });
});

/* DELETE COUNTRY.*/
$(document).on("click", "#delete_country_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#delete_country_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_country_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_country_btn", function (event) {
    event.preventDefault();
    var countryId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Offices/GetDeleteCountry",
        data: JSON.stringify({ countryId: countryId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#delete_country_input").html(msg);
            $("#delete_country_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#delete_country_pop_up #yes", function (event) {
    event.preventDefault();
    var countryId = $(this).attr("data");
    $("#delete_country_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: "POST",
        url: "/Offices/DeleteCountry",
        data: JSON.stringify({ countryId: countryId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_countries").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#delete_country_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Offices/GetCountries",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_countries").html(msg);
                        $("#delete_country_input").html("");
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
 * SHEETS.
 ******************************/

/* CREATE SHEET TABS.*/
$(document).on("click", "#CreateSheetForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    var sheetTranslationFormData = {
        SheetValue: $("#Value_" + panelToClose + "").val(),
        SheetTitle: $("#Title_" + panelToClose + "").val(),
        LanguageId: $("#Language_" + panelToClose + "").val()
    };

    $.ajax({
        type: "POST",
        url: "/Offices/ValidateSheetTranslation",
        data: JSON.stringify(sheetTranslationFormData),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg === "True") {
                //countrylinks : 
                $("#CreateSheetForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                $("#CreateSheetForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                //sheetpanels :
                $("#CreateSheetForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                $("#CreateSheetForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
            } else {
                $("#CreateSheetForm").submit();
            }
        },
        error: function (jqXhr) {
            $("#add_sheet_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#CreateSheetForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //countrylinks : 
    $("#CreateSheetForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#CreateSheetForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //sheetpanels
    $("#CreateSheetForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#CreateSheetForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

$(document).on("click", "#sheet_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#sheet_btn", function (event) {
    event.preventDefault();

    var countryId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Offices/GetManageSheets",
        data: JSON.stringify({ countryId: countryId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#sheet_input").html(msg);
            $("#sheet_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#update_sheet_input").html(jqXhr.responseText);
        }
    });
});

/* CREATE SHEET.*/
$(document).on("click", "#add_sheet_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#add_sheet_btn", function (event) {
    event.preventDefault();

    var countryId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Offices/GetCreateSheet",
        data: JSON.stringify({ countryId: countryId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_sheet_input").html(msg);
            $("#add_sheet_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#add_sheet_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#CreateSheetForm", function (e) {
    e.preventDefault();

    var countryId = $("#CreateSheetForm #CountryId").val();
    $("#add_sheet_input").html("<img alt='loading' src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $("#sheet_input").html("<img alt='loading' src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });

                $("#add_sheet_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Offices/GetManageSheets",
                    data: JSON.stringify({ countryId: countryId }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#sheet_input").html(msg);
                        $("#add_sheet_input").html("");
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
/* UPDATE SHEET.*/
$(document).on("click", "#UpdateSheetForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    var sheetTranslationFormData = {
        SheetValue: $("#Value_" + panelToClose + "").val(),
        SheetTitle: $("#Title_" + panelToClose + "").val(),
        LanguageId: $("#Language_" + panelToClose + "").val()
    };

    $.ajax({
        type: "POST",
        url: "/Offices/ValidateSheetTranslation",
        data: JSON.stringify(sheetTranslationFormData),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg === "True") {
                //countrylinks : 
                $("#UpdateSheetForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                $("#UpdateSheetForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                //sheetpanels :
                $("#UpdateSheetForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                $("#UpdateSheetForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
            } else {
                $("#UpdateSheetForm").submit();
            }
        },
        error: function (jqXhr) {
            $("#update_sheet_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#UpdateSheetForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //countrylinks : 
    $("#UpdateSheetForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#UpdateSheetForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //sheetpanels
    $("#UpdateSheetForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#UpdateSheetForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

$(document).on("click", "#update_sheet_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#update_sheet_btn", function (event) {
    event.preventDefault();

    var sheetId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/Offices/GetUpdateSheet",
        data: JSON.stringify({ sheetId: sheetId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_sheet_input").html(msg);
            $("#update_sheet_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#update_sheet_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#UpdateSheetForm", function (e) {
    e.preventDefault();

    var countryId = $("#UpdateSheetForm #CountryId").val();
    $("#update_sheet_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $.toast(msg.SuccessMessage, { 'width': 800 });

                $("#sheet_input").html("<img alt='loading'  src='/Images/loading.gif' />");
                $("#update_sheet_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Offices/GetManageSheets",
                    data: JSON.stringify({ countryId: countryId }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#sheet_input").html(msg);
                        $("#update_sheet_input").html("");
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

/* DELETE SHEET.*/
$(document).on("click", "#delete_sheet_pop_up", function (event) {
    if ($(event.target).is(".cd-popup-close")) {
        event.preventDefault();
        $(this).removeClass("is-visible");
        $("body").removeClass("hidden_body");
    }
});

$(document).on("click", "#delete_sheet_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_sheet_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_sheet_btn", function (event) {
    event.preventDefault();

    var countryId = $(this).attr("data-section");
    var sheetId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/Offices/GetDeleteSheet",
        data: JSON.stringify({ countryId: countryId, sheetId: sheetId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#delete_sheet_input").html(msg);
            $("#delete_sheet_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#delete_sheet_pop_up #yes", function (event) {
    event.preventDefault();

    var countryId = $(this).attr("data-section");
    var sheetId = $(this).attr("data");

    $("#delete_sheet_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: "POST",
        url: "/Offices/DeleteSheet",
        data: JSON.stringify({ sheetId: sheetId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#sheet_input").html("<img alt='loading'  src='/Images/loading.gif' />");

                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#delete_sheet_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/Offices/GetManageSheets",
                    data: JSON.stringify({ countryId: countryId }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#sheet_input").html(msg);
                        $("#delete_sheet_input").html("");
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

