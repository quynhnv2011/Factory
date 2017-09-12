$(document).on('click', '#btnLuu', function () {
    $.ajax({
        url: '/NhapPhieuExcel/LuuExcel',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            console.log(data);
            if (data.toString() === "") {
                $('#list-items').html("<span class='mess'>Lưu thành công.</span>");
            }
            else if (data.toString() === "1") {
                $('#list-items').html("<span class='mess'>Chưa có file excel nào được chọn.</span>");
            } else {
                $('#list-items').html("<span class='mess'>" + data + "</span>");
            }
        }
    });

});