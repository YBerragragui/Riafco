$(document).ready(function () {
    $("textarea").froalaEditor({
        enter: $.FroalaEditor.ENTER_BR,
        placeholderText: "votre description .....",
        fontSizeSelection: false,
        codeMirror: false,
        height: 200,
        colorsText: ["#ec3213", "#000000", "#ffffff", "#eeeeee"]
    });
});