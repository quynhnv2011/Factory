function SuccessSearch() {
    $('#btnSearch').click();
}


function SubmitForm() {
    var result = $('#addForm').valid();

    var ngaybatdau = $('#from').val();
    var d = new Date(ngaybatdau.split("/").reverse().join("-"));
    var dd = d.getDate();
    var mm = d.getMonth() + 1;
    var yy = d.getFullYear();
    var newdate = mm + "/" + dd + "/" + yy;
    $('#ngaybatdau').val(newdate);
    var a = $('#ngaybatdau').val();


    var ngayketthuc = $('#to').val();
    var d = new Date(ngayketthuc.split("/").reverse().join("-"));
    var dd = d.getDate();
    var mm = d.getMonth() + 1;
    var yy = d.getFullYear();
    var newdate = mm + "/" + dd + "/" + yy;
    $('#ngayketthuc').val(newdate);
    var b = $('#ngayketthuc').val();
    console.log(result);


    var fromDate = new Date(parseInt(ngaybatdau.split("/")[2]), parseInt(ngaybatdau.split("/")[1]), parseInt(ngaybatdau.split("/")[0]));
    var ngayss = $('#NgaySS').val();

    var toDate = new Date(parseInt(ngayss.split("/")[2]), parseInt(ngayss.split("/")[1]), parseInt(ngayss.split("/")[0]));

    //if ($('#ngayketthuckytruoc').val() == ngaybatdau) {
    //    alert("Ngày bắt đầu đã tồn tại trong kỳ trước");
    //    return false;
    //}
    //if ($('#ngaybatdaukysau').val() == ngayketthuc) {
    //    alert("Ngày kết thúc đã tồn tại");
    //    return false;
    //}
    if ($('#checktrung').val()==ngaybatdau) {
        alert("1 ngày ko được thuộc 2 kỳ khác nhau");
        return false;
    }
    if (ngaybatdau == "") {
        alert("Bạn chưa nhập ngày bắt đầu");
        return false;
    }
    if (ngayketthuc== "") {
        alert("Bạn chưa nhập ngày kết thúc");
        return false;
    }
    if (ngaybatdau===ngayketthuc) {
        alert("Ngày kết thúc không thể trùng với ngày bắt đầu");
        return false;
    }
    if (fromDate < toDate) {
        alert("Ngày bắt đầu không được nhỏ hơn ngày kết thúc của kỳ trước");
        return false;
    } else {
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
}

function SubmitFormDongKy() {
    var result = $('#addForm').valid();
    $('#Trangthaidongky').val("2")
    $('#Trangthaimoky').val("0")

    var ngaybatdau = $('#from').val();
    var d = new Date(ngaybatdau.split("/").reverse().join("-"));
    var dd = d.getDate();
    var mm = d.getMonth() + 1;
    var yy = d.getFullYear();
    var newdate = mm + "/" + dd + "/" + yy;
    $('#ngaybatdau').val(newdate);


    var ngayketthuc = $('#to').val();
    var d = new Date(ngayketthuc.split("/").reverse().join("-"));
    var dd = d.getDate();
    var mm = d.getMonth() + 1;
    var yy = d.getFullYear();
    var newdate = mm + "/" + dd + "/" + yy;
    $('#ngayketthuc').val(newdate);
    var b = $('#ngayketthuc').val();
    if (ngaybatdau === ngayketthuc) {
        alert("Ngày kết thúc không thể trùng với ngày bắt đầu");
        return false;
    }
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
        url: '/KyKiemTra/CheckExistsName',
        type: 'GET',
        data: { "name": $('#TEN').val(), "Id": $('#ID').val() },
        success: function (data) {
            if (data == 1) {
                $('#txtCheckName').val("1");
                toastr["error"]("Tên kỳ đã đã tồn tại. Bạn vui lòng thao tác lại trong giây lát", "Thông báo");
                return false;
            }
            else {
                $('#txtCheckName').val("0");
                return true;
            }
        }
    });
}


