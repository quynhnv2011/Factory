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
        url: '/CuaHangXd/CheckExistsName',
        type: 'GET',
        data: { "name": $('#Ten').val(), "Id": $('#Id').val() },
        success: function (data) {
            if (data === 1) {
                $('#txtCheckName').val("1");
                toastr["error"]("Tên cửa hàng xăng dầu đã tồn tại. Bạn vui lòng thao tác lại trong giây lát", "Thông báo");
                return false;
            }
            else {
                $('#txtCheckName').val("0");
                return true;
            }
        }
    });
}

function ClickCheckBoxRemove(id, isShowMsg) {
    var rs = false;
    $.ajax({
        url: '/CuaHangXd/CheckExistsRecord',
        type: 'POST',
        async: false,
        data: { "idCuaHang": id },
        success: function (data) {
            if (data === "1") {
                if (isShowMsg) {
                    toastr["error"]("Cửa hàng xăng dầu đã có vòi bơm nên không thể xóa", "Thông báo");
                }
                $('#chkItem_' + id).prop('checked', false);
                rs = true;
            } else {
                rs = false;
            }
        }
    });
    return rs;
}
$(function () {
    $(document).on('click', '#chkAll', function (e) {
        var check = $(this).is(":checked");
        if (!check) {
            $(this).closest("table").find("tbody input[type=checkbox]").prop("checked", false);
        }
        else {
            $(this).closest("table").find("tbody input[type=checkbox]").each(function () {
                var id = $(this).data("id");
                var rs = ClickCheckBoxRemove(id, false);
                if (!rs) {
                    $('#chkItem_' + id).prop('checked', true);
                }
            });
        }
        EnableDeleteAll('dt_basic');
    });

    $(document).on('click', '.chkId', function (e) {
        var id = $(this).data("id");
        ClickCheckBoxRemove(id, true);
        EnableDeleteAll('dt_basic');
    });
});