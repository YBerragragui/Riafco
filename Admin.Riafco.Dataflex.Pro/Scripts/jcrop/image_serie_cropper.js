$(document).ready(function () {
    var image = document.getElementById('origin-image');
    var cropper = new Cropper(image, {
        zoomable: true,
        autoCropArea: 1,
        aspectRatio: 300 / 300,
        crop: function (e) {
            $('#ImageHeight').val(e.detail.height);
            $('#ImageWidth').val(e.detail.width);
            $('#PointY').val(e.detail.y);
            $('#PointX').val(e.detail.x);
        }
    });
});