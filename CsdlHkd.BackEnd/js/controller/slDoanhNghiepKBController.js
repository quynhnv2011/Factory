function SubmitForm() {
    var result = $('#addForm').valid();
    if ($('#donvi').val() == "-1") {
        alert("Bạn chưa chọn đơn vị");
        return false;
    }
    if ($('#cuhang').val() == "-1") {
        alert("Bạn chưa chọn cửa hàng");
        return false;
    }
    if ($('#loaixd').val() == "-1") {
        alert("Bạn chưa chọn loại xăng dầu");
        return false;
    }
    if ($('#donvitinh').val() == "-1") {
        alert("Bạn chưa chọn đơn vị tính");
        return false;
    }
    if ($('#kykt').val() == "-1") {
        alert("Bạn chưa chọn kỳ kiểm tra");
        return false;
    }
    console.log(result);
    $('#addForm').submit();

}