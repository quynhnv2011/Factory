function SubmitForm() {
    var result = $('#addForm').valid();
    if (result) {
        CheckName();
        var err = 0;
        if ($('#DonViId').val() == "0") {
            toastr["error"]("Bạn vui lòng chọn đơn vị", "Thông báo");
            err = 1;
        }
        if ($('#Status').val() == "0") {
            toastr["error"]("Bạn vui lòng chọn trạng thái", "Thông báo");
            err = 1;
        }
        if ($('#txtCheckName').val() == "1") {
            if ($('#hfTmpErrorMsg').val().length > 0) {
                toastr["error"]($('#hfTmpErrorMsg').val(), "Thông báo");
            }
            err = 1;
        }
        if(err == 0){
            $('#addForm').submit();
        }
    }
}

function CheckName() {
    $.ajax({
        url: '/Account/CheckExistsName',
        type: 'GET',
        data: { "name": $('#Email').val(), "Id": $('#Id').val() },
        success: function (data) {
            console.log(data);
            if (data == 1) {
                $('#txtCheckName').val("1");
                toastr["error"]("Email đã tồn tại. Bạn vui lòng thao tác lại trong giây lát", "Thông báo");
            }
            else {
                $('#txtCheckName').val("0");
            }
        }
    });
}
