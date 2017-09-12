$('button.close').click(function (e) {
    e.preventDefault();
    $(this).closest(".alert").hide();
});
$('input').keydown(function (e) {
    if (e.keyCode === 13) {
        $('#login-form').submit();
    }
})