$(document).ready(function () {
    $('#createContact').click(function (e) {
        e.preventDefault();

        var url = $(this).attr('href');
        $('#ContactPartial').load(url);
        $('.dialog').dialog({
            modal: true,
            resizable: false
        });
    })
    $('.popupForm').submit(function (e) {
        e.preventDefault();

    });
});