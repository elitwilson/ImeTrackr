$(document).ready(function () {
    $('#createContact').click(function (e) {
        e.preventDefault();

        var url = $(this).attr('href');

        $('#ContactPartial').load(url);

        $('#ContactPartial').dialog({
            modal: true,
            resizable: false
        });
    })

});