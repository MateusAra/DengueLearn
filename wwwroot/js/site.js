
$('#close-alert').click(function () {
    $('#message-alert').hide('hide');
});

setTimeout(function () {
    $('#message-alert').hide('hide');
}, 3000);

$(document).ready(function () {
    $("#gotoconfirm").click(function () {
        $("#gotoconfirm").addClass('hideEl');
        $("#confirm").removeClass('hideEl');
        $("#quizcontent").addClass('hideEl');
    });

    $("#backquiz").click(function () {
        $("#gotoconfirm").removeClass('hideEl');
        $("#confirm").addClass('hideEl');
        $("#quizcontent").removeClass('hideEl');
    });

    $("#gotoconfirm").click(function () {
        $("html, body").animate({ scrollTop: 0 }, 200);
        $(this).focus();
    });
})

