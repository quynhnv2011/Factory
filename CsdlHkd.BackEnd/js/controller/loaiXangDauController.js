function SuccessSearch() {
    $('#btnSearch').click();
}


function SubmitForm() {
    var result = $('#addForm').valid();
    console.log(result);
    if (result) {
        CheckName();
        if ($('#txtCheckName').val() === "1") {
            if ($('#hfTmpErrorMsg').val().length > 0) {
                toastr["error"]($('#hfTmpErrorMsg').val(), "Thông báo");
            }
            return false;
        } else {
            $('#addForm').submit();
        }
    }
}

function CheckName() {
    $.ajax({
        url: '/LoaiXangDau/CheckExistsName',
        type: 'GET',
        data: { "name": $('#Ten').val(), "Id": $('#Id').val() },
        success: function (data) {
            if (data == 1) {
                $('#txtCheckName').val("1");
                toastr["error"]("Tên loại xăng dầu đã tồn tại. Bạn vui lòng thao tác lại trong giây lát", "Thông báo");
                return false;
            }
            else {
                $('#txtCheckName').val("0");
                return true;
            }
        }
    });
}

