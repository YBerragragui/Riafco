/******************************
 * SECTION.
 ******************************/

/*CREATE SECTION TABS.*/
$(document).on("click", "#CreateSectionForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    if (panelToClose === 0) {
        var sectionFormData = {
            SectionImage: $("#SectionImage").val()
        };

        $.ajax({
            type: "POST",
            url: "/About/ValidateSectionFormData",
            data: JSON.stringify(sectionFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //sectionlinks : 
                    $("#CreateSectionForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#CreateSectionForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //sectionpanels
                    $("#CreateSectionForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#CreateSectionForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#CreateSectionForm").submit();
                }
            },
            error: function (jqXhr) {
                alert(jqXhr.responseText);
            }
        });

    } else {
        var sectionTranslationFormData = {
            SectionTitle: $("#Title_" + panelToClose + "").val(),
            LanguageId: $("#Language_" + panelToClose + "").val(),
            SectionDesciption: $("#Description_" + panelToClose + "").val()
        };

        $.ajax({
            type: "POST",
            url: "/About/ValidateSectionTranslationFormData",
            data: JSON.stringify(sectionTranslationFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //sectionlinks : 
                    $("#CreateSectionForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#CreateSectionForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //sectionpanels
                    $("#CreateSectionForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#CreateSectionForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                }
                else {
                    $("#CreateSectionForm").submit();
                }
            },
            error: function (jqXhr) {
                alert(jqXhr.responseText);
            }
        });
    }
});

$(document).on("click", "#CreateSectionForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //sectionlinks : 
    $("#CreateSectionForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#CreateSectionForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //sectionpanels
    $("#CreateSectionForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#CreateSectionForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

/* CREATE SECTION.*/
$(document).on("click", "#add_section_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#add_section_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#add_section_btn", function (e) {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: "/About/GetCreateSection",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_section_input").html(msg);
            $("#add_section_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#CreateSectionForm", function (e) {
    e.preventDefault();

    $("#add_section_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_sections").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#add_section_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/About/GetSections",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_sections").html(msg);
                        $("#add_section_input").html("");
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

/* UPDATE SECTION TABS.*/
$(document).on("click", "#UpdateSectionForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    if (panelToClose === 0) {
        var sectionFormData = {
            SectionImage: $("#SectionImage").val()
        };

        $.ajax({
            type: "POST",
            url: "/About/ValidateSectionFormData",
            data: JSON.stringify(sectionFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //sectionlinks : 
                    $("#UpdateSectionForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#UpdateSectionForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //sectionpanels
                    $("#UpdateSectionForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#UpdateSectionForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#UpdateSectionForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#update_section_input").html(jqXhr.responseText);
            }
        });

    } else {
        var sectionTranslationFormData = {
            SectionDesciption: $("#Description_" + panelToClose + "").val(),
            TranslationId: $("#Translation_" + panelToClose + "").val(),
            SectionTitle: $("#Title_" + panelToClose + "").val(),
            LanguageId: $("#Language_" + panelToClose + "").val()
        };

        $.ajax({
            type: "POST",
            url: "/About/ValidateSectionTranslationFormData",
            data: JSON.stringify(sectionTranslationFormData),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg === "True") {
                    //sectionlinks : 
                    $("#UpdateSectionForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                    $("#UpdateSectionForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                    //sectionpanels
                    $("#UpdateSectionForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                    $("#UpdateSectionForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
                } else {
                    $("#UpdateSectionForm").submit();
                }
            },
            error: function (jqXhr) {
                $("#update_section_input").html(jqXhr.responseText);
            }
        });
    }
});

$(document).on("click", "#UpdateSectionForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //sectionlinks : 
    $("#UpdateSectionForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#UpdateSectionForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //sectionpanels
    $("#UpdateSectionForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#UpdateSectionForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

/* UPDATE SECTION.*/
$(document).on("click", "#update_section_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#update_section_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#update_section_btn", function (e) {
    e.preventDefault();

    var sectionId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/About/GetUpdateSection",
        data: JSON.stringify({ sectionId: sectionId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_section_input").html(msg);
            $("#update_section_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#update_section_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#UpdateSectionForm", function (e) {
    e.preventDefault();

    $("#update_section_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $("#content_sections").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#update_section_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/About/GetSections",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_sections").html(msg);
                        $("#update_section_input").html("");
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
            $("#update_section_input").html(jqXhr.responseText);
        }
    });
});


/* DELETE SECTION.*/
$(document).on("click", "#delete_section_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#delete_section_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_section_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_section_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_section_btn", function (event) {
    event.preventDefault();

    var sectionId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/About/GetDeleteSection",
        data: JSON.stringify({ sectionId: sectionId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#delete_section_input").html(msg);
            $("#delete_section_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#delete_section_pop_up #yes", function (event) {
    event.preventDefault();
    var sectionId = $(this).attr("data");
    $("#delete_section_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: "POST",
        url: "/About/DeleteSection",
        data: JSON.stringify({ sectionId: sectionId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#content_sections").html("<img alt='loading'  src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#delete_section_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/About/GetSections",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#content_sections").html(msg);
                        $("#delete_section_input").html("");
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
 * PARAGRAPH SECTION.
 ******************************/

/* CREATE SECTION PARAGRAPH TABS.*/
$(document).on("click", "#CreateSectionParagraphForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);


    var sectionParagraphTranslationFormData = {
        ParagraphDescription: $("#Desc_" + panelToClose + "").val(),
        ParagraphTitle: $("#Title_" + panelToClose + "").val(),
        LanguageId: $("#Language_" + panelToClose + "").val()
    };

    $.ajax({
        type: "POST",
        url: "/About/ValidateSectionParagraphTranslation",
        data: JSON.stringify(sectionParagraphTranslationFormData),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg === "True") {
                //sectionlinks : 
                $("#CreateSectionParagraphForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                $("#CreateSectionParagraphForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                //paragraphpanels :
                $("#CreateSectionParagraphForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                $("#CreateSectionParagraphForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
            } else {
                $("#CreateSectionParagraphForm").submit();
            }
        },
        error: function (jqXhr) {
            $("#add_paragraph_input").html(jqXhr.responseText);
        }
    });

});

$(document).on("click", "#CreateSectionParagraphForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //sectionlinks : 
    $("#CreateSectionParagraphForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#CreateSectionParagraphForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //paragraphpanels
    $("#CreateSectionParagraphForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#CreateSectionParagraphForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

$(document).on("click", "#paragraph_section_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#paragraph_section_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#paragraph_section_btn", function (event) {
    event.preventDefault();

    var sectionId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/About/GetManageParagraphs",
        data: JSON.stringify({ sectionId: sectionId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#paragraph_section_input").html(msg);
            $("#paragraph_section_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#update_paragraph_input").html(jqXhr.responseText);
        }
    });
});

/* CREATE PARAGRAPH SECTION.*/
$(document).on("click", "#add_paragraph_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#add_paragraph_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#add_paragraph_btn", function (event) {
    event.preventDefault();

    var sectionId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/About/GetCreateSectionParagraph",
        data: JSON.stringify({ sectionId: sectionId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_paragraph_input").html(msg);
            $("#add_paragraph_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#add_paragraph_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#CreateSectionParagraphForm", function (e) {
    e.preventDefault();

    var sectionId = $("#CreateSectionParagraphForm #SectionId").val();
    $("#add_paragraph_input").html("<img alt='loading' src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $("#paragraph_section_input").html("<img alt='loading' src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });

                $("#add_paragraph_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/About/GetManageParagraphs",
                    data: JSON.stringify({ sectionId: sectionId }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#paragraph_section_input").html(msg);
                        $("#add_paragraph_input").html("");
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

/* UPDATE PARAGRAPH SECTION.*/
$(document).on("click", "#UpdateSectionParagraphForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    var sectionParagraphTranslationFormData = {
        ParagraphDescription: $("#Desc_" + panelToClose + "").val(),
        ParagraphTitle: $("#Title_" + panelToClose + "").val(),
        LanguageId: $("#Language_" + panelToClose + "").val()
    };

    $.ajax({
        type: "POST",
        url: "/About/ValidateSectionParagraphTranslation",
        data: JSON.stringify(sectionParagraphTranslationFormData),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg === "True") {
                //sectionlinks : 
                $("#UpdateSectionParagraphForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                $("#UpdateSectionParagraphForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                //paragraphpanels :
                $("#UpdateSectionParagraphForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                $("#UpdateSectionParagraphForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
            } else {
                $("#UpdateSectionParagraphForm").submit();
            }
        },
        error: function (jqXhr) {
            $("#update_paragraph_input").html(jqXhr.responseText);
        }
    });

});

$(document).on("click", "#UpdateSectionParagraphForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //sectionlinks : 
    $("#UpdateSectionParagraphForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#UpdateSectionParagraphForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //paragraphpanels
    $("#UpdateSectionParagraphForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#UpdateSectionParagraphForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

$(document).on("click", "#update_paragraph_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#update_paragraph_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#update_section_paragraph_btn", function (event) {
    event.preventDefault();

    var paragraphId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/About/GetUpdateSectionParagraph",
        data: JSON.stringify({ paragraphId: paragraphId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_paragraph_input").html(msg);
            $("#update_paragraph_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#update_paragraph_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#UpdateSectionParagraphForm", function (e) {
    e.preventDefault();

    var sectionId = $("#UpdateSectionParagraphForm #SectionId").val();
    $("#update_paragraph_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $.toast(msg.SuccessMessage, { 'width': 800 });

                $("#paragraph_section_input").html("<img alt='loading'  src='/Images/loading.gif' />");
                $("#update_paragraph_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/About/GetManageParagraphs",
                    data: JSON.stringify({ sectionId: sectionId }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#paragraph_section_input").html(msg);
                        $("#update_paragraph_input").html("");
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

/* DELETE SECTION PARAGRAPH.*/
$(document).on("click", "#delete_paragraph_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#delete_paragraph_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_paragraph_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_paragraph_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_section_paragraph_btn", function (event) {
    event.preventDefault();

    var sectionId = $(this).attr("data-section");
    var paragraphId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/About/GetDeleteSectionParagraph",
        data: JSON.stringify({ sectionId: sectionId, paragraphId: paragraphId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#delete_paragraph_input").html(msg);
            $("#delete_paragraph_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#delete_paragraph_pop_up #yes", function (event) {
    event.preventDefault();

    var sectionId = $(this).attr("data-section");
    var paragraphId = $(this).attr("data");

    $("#delete_paragraph_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: "POST",
        url: "/About/DeleteSectionParagraph",
        data: JSON.stringify({ paragraphId: paragraphId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#paragraph_section_input").html("<img alt='loading'  src='/Images/loading.gif' />");

                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#delete_paragraph_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/About/GetManageParagraphs",
                    data: JSON.stringify({ sectionId: sectionId }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#paragraph_section_input").html(msg);
                        $("#delete_paragraph_input").html("");
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
 * FILE SECTION.
 ******************************/

/* CREATE SECTION FILE TABS.*/
$(document).on("click", "#CreateSectionFileForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    var sectionFileTranslationFormData = {
        SectionFileSourceValue: $("#File_" + panelToClose + "").val(),
        SectionFileText: $("#Title_" + panelToClose + "").val(),
        LanguageId: $("#Language_" + panelToClose + "").val()
    };

    $.ajax({
        type: "POST",
        url: "/About/ValidateCreateSectionFileTranslation",
        data: JSON.stringify(sectionFileTranslationFormData),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg === "True") {
                //sectionlinks : 
                $("#CreateSectionFileForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                $("#CreateSectionFileForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                //Filepanels :
                $("#CreateSectionFileForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                $("#CreateSectionFileForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
            } else {
                $("#CreateSectionFileForm").submit();
            }
        },
        error: function (jqXhr) {
            $("#add_file_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#CreateSectionFileForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //sectionlinks : 
    $("#CreateSectionFileForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#CreateSectionFileForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //Filepanels
    $("#CreateSectionFileForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#CreateSectionFileForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

$(document).on("click", "#file_section_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#file_section_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#file_section_btn", function (event) {
    event.preventDefault();

    var sectionId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/About/GetManageFiles",
        data: JSON.stringify({ sectionId: sectionId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#file_section_input").html(msg);
            $("#file_section_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#update_file_input").html(jqXhr.responseText);
        }
    });
});

/* CREATE FILE SECTION.*/
$(document).on("click", "#add_file_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#add_file_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#add_file_btn", function (event) {
    event.preventDefault();

    var sectionId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/About/GetCreateSectionFile",
        data: JSON.stringify({ sectionId: sectionId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#add_file_input").html(msg);
            $("#add_file_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#CreateSectionFileForm", function (e) {
    e.preventDefault();

    var sectionId = $("#CreateSectionFileForm #SectionId").val();
    $("#add_file_input").html("<img alt='loading' src='/Images/loading.gif' />");
     
    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $("#file_section_input").html("<img alt='loading' src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });
                $("#add_file_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/About/GetManageFiles",
                    data: JSON.stringify({ sectionId: sectionId }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#file_section_input").html(msg);
                        $("#add_file_input").html("");
                    },
                    error: function (jqXhr) {
                        alert(jqXhr.responseText);
                    }
                });
            }
            else {
                $.toast(msg.ErrorMessage, { 'width': 800 });
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

/* UPDATE File SECTION.*/
$(document).on("click", "#UpdateSectionFileForm .next", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) - 1;
    var panelToOpen = parseInt(data);

    var sectionFileSourceValue = $("#File_" + panelToClose + "").val();
    var sectionFileTranslationFormData = {
        SectionFileText: $("#Title_" + panelToClose + "").val(),
        LanguageId: $("#Language_" + panelToClose + "").val(),
        SectionFileSourceValue: sectionFileSourceValue
    };

    $.ajax({
        type: "POST",
        url: "/About/ValidateUpdateSectionFileTranslation",
        data: JSON.stringify(sectionFileTranslationFormData),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg === "True") {
                //sectionlinks : 
                $("#UpdateSectionFileForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
                $("#UpdateSectionFileForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

                //Filepanels :
                $("#UpdateSectionFileForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
                $("#UpdateSectionFileForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
            } else {
                $("#UpdateSectionFileForm").submit();
            }
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#UpdateSectionFileForm .prev", function (event) {
    event.preventDefault();

    var data = $(this).attr("data-navigation");
    var panelToClose = parseInt(data) + 1;
    var panelToOpen = parseInt(data);

    //sectionlinks : 
    $("#UpdateSectionFileForm").find("li[data-navigation = '" + panelToClose + "']").removeClass("active");
    $("#UpdateSectionFileForm").find("li[data-navigation = '" + panelToOpen + "']").addClass("active");

    //Filepanels
    $("#UpdateSectionFileForm").find(".tab-pane[data-navigation = '" + panelToClose + "']").removeClass("active in");
    $("#UpdateSectionFileForm").find(".tab-pane[data-navigation = '" + panelToOpen + "']").addClass("active in");
});

$(document).on("click", "#update_file_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#update_file_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#update_file_btn", function (event) {
    event.preventDefault();

    var fileId = $(this).attr("data");
    $.ajax({
        type: "POST",
        url: "/About/GetUpdateSectionFile",
        data: JSON.stringify({ fileId: fileId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#update_file_input").html(msg);
            $("#update_file_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            $("#update_file_input").html(jqXhr.responseText);
        }
    });
});

$(document).on("submit", "#UpdateSectionFileForm", function (e) {
    e.preventDefault();

    var sectionId = $("#UpdateSectionFileForm #SectionId").val();
    $("#update_file_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: this.method,
        url: this.action,
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (msg) {
            if (msg.OperationSuccess === true) {

                $("#file_section_input").html("<img alt='loading' src='/Images/loading.gif' />");
                $.toast(msg.SuccessMessage, { 'width': 800 });

                $("#update_file_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/About/GetManageFiles",
                    data: JSON.stringify({ sectionId: sectionId }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#file_section_input").html(msg);
                        $("#update_file_input").html("");
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

/* DELETE SECTION File.*/
$(document).on("click", "#delete_file_pop_up .cd-popup-close", function (event) {
    event.preventDefault();
    $("#delete_file_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_file_pop_up #no", function (event) {
    event.preventDefault();
    $("#delete_file_pop_up").removeClass("is-visible");
    $("body").removeClass("hidden_body");
});

$(document).on("click", "#delete_file_btn", function (event) {
    event.preventDefault();

    var sectionId = $(this).attr("data-section");
    var fileId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/About/GetDeleteSectionFile",
        data: JSON.stringify({ sectionId: sectionId, fileId: fileId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $("#delete_file_input").html(msg);
            $("#delete_file_pop_up").addClass("is-visible");
            $("body").addClass("hidden_body");
        },
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});

$(document).on("click", "#delete_file_pop_up #yes", function (event) {
    event.preventDefault();

    var sectionId = $(this).attr("data-section");
    var fileId = $(this).attr("data");

    $("#delete_file_input").html("<img alt='loading'  src='/Images/loading.gif' />");

    $.ajax({
        type: "POST",
        url: "/About/DeleteSectionFile",
        data: JSON.stringify({ fileId: fileId }),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.OperationSuccess === true) {
                $.toast(msg.SuccessMessage, { 'width': 800 });

                $("#file_section_input").html("<img alt='loading'  src='/Images/loading.gif' />");
                $("#delete_file_pop_up").removeClass("is-visible");
                $("body").removeClass("hidden_body");

                $.ajax({
                    type: "POST",
                    url: "/About/GetManageFiles",
                    data: JSON.stringify({ sectionId: sectionId }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $("#file_section_input").html(msg);
                        $("#delete_file_input").html("");
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

/* DOWNLOAD SECTION FILE*/
$(document).on("click", "#dowload_file_btn", function (event) {
    event.preventDefault();

    var sectionFileTranslationId = $(this).attr("data");

    $.ajax({
        type: "POST",
        url: "/About/DownloadSectionFile",
        data: JSON.stringify({ sectionFileTranslationId: sectionFileTranslationId }),
        contentType: "application/json; charset=utf-8",
        error: function (jqXhr) {
            alert(jqXhr.responseText);
        }
    });
});
