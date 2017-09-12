$(function () {
    $(document).ready(function () {
        $('.datepicker').datepicker({
            autoclose: true,
            dateFormat: "dd/mm/yy",
            todayHighlight: true,
        });
    });
    $("#tabs").tabs();

    
});

function addRow() {
    var rowId = $('#rowid').val();
    var objTable = document.getElementById('dt_basic').getElementsByTagName('tbody')[0];

    var objRow = objTable.insertRow(objTable.rows.length);

    var objCell1 = objRow.insertCell(0);

    var objInputButton = document.createElement("input");
    objInputButton.type = "button";
    objInputButton.onclick = function () {
        addRow();
    };

    var objdel = document.createElement("a");
    objdel.classList = "fa fa-trash-o padding-left white btn btn-xs btn-primary";
    objdel.href = "javascript: void(0);";
    objdel.title = "Xóa";
    objdel.text = " ";
    objdel.onclick = function () {
        deleteRow(this, 0);
    };

    //var objsave = document.createElement("a");
    //objsave.classList = "fa fa-floppy-o padding-left white btn btn-xs btn-primary";
    //objsave.href = "javascript: void(0);";
    //objsave.title = "Lưu";
    //objsave.text = " ";

    objCell1.appendChild(objdel);
    //objCell1.appendChild(objsave);
    objCell1.classList = "text-center";

    var objCell2 = objRow.insertCell(1);
    var objSoLuongTS = document.createElement("input");
    objSoLuongTS.id = objSoLuongTS.name = "row-sl-" + rowId;
    objSoLuongTS.type = "text";
    objCell2.appendChild(objSoLuongTS);

    var objCell3 = objRow.insertCell(2);
    var objTenLoaiTS = document.createElement("input");
    objTenLoaiTS.id = objTenLoaiTS.name = "row-ten-" + rowId;
    objTenLoaiTS.type = "text";
    objCell3.appendChild(objTenLoaiTS);

    var objCell4 = objRow.insertCell(3);
    var objTongGiaTriTS = document.createElement("input");
    objTongGiaTriTS.id = objTongGiaTriTS.name = "row-tong-" + rowId;
    objTongGiaTriTS.type = "number";
    objCell4.appendChild(objTongGiaTriTS);

    var objCell5 = objRow.insertCell(4);
    var objId = document.createElement("input");
    objId.id = objId.name = "row-id-" + rowId;
    objId.type = "number";
    objId.value = "0";
    objCell5.hidden = "hidden";
    objCell5.appendChild(objId);

    $('#rowid').val(parseInt(rowId) + 1);
}

function deleteRow(row, Id) {
    var i = row.parentNode.parentNode.rowIndex;
    document.getElementById('dt_basic').deleteRow(i);
    if(Id > 0) $('#lstDel').val($('#lstDel').val() + "|" + Id);
}

function getTaiSan() {
    var table = $('#dt_basic').DataTable();
    var data = table.$('input, select').serialize();
    $('#hdfDsTaiSan').val(data);
}

var $check15 = $('#TtCoKDoanhQMang15').click(function () {
    $('#DiaChiWebsite15').prop('disabled', !$check15.is(':checked'));
    if (!$check15.is(':checked')) $('#DiaChiWebsite15').val("");
});

$('#rbCoKhoHang').click(function () {
    $('#DienTich16').prop('disabled', false);
});

$('#rbKhongCoKhoHang').click(function () {
    $('#DienTich16').prop('disabled', true);
    $('#DienTich16').val("0");
});

$('#rbDiThue').click(function () {
    $('#GiaThue20').prop('disabled', false);
});

$('#rbCNKD').click(function () {
    $('#GiaThue20').prop('disabled', true);
    $('#GiaThue20').val("0");
});

$('#rbCaNhanTuKD').click(function () {
    NhanCong(false);
});

$('#rbNhanCongKhac').click(function () {
    NhanCong(true);
});

$('#tabs4').click(function () {
    $('#DoanhThuNhom130').prop('disabled', !$('#NnKDoanhNhom110').is(':checked'));
    if (!$('#NnKDoanhNhom110').is(':checked')) $('#DoanhThuNhom130').val("0");
    $('#DoanhThuNhom230').prop('disabled', !$('#NnKDoanhNhom210').is(':checked'));
    if (!$('#NnKDoanhNhom210').is(':checked')) $('#DoanhThuNhom230').val("0");
    $('#DoanhThuNhom330').prop('disabled', !$('#NnKDoanhNhom310').is(':checked'));
    if (!$('#NnKDoanhNhom310').is(':checked')) $('#DoanhThuNhom330').val("0");
    $('#DoanhThuNhom430').prop('disabled', !$('#NnKDoanhNhom410').is(':checked'));
    if (!$('#NnKDoanhNhom410').is(':checked')) $('#DoanhThuNhom430').val("0");
});

function NhanCong(bcheck) {
    $('#TtTgSang21').prop('disabled', bcheck);
    $('#TtTgTrua21').prop('disabled', bcheck);
    $('#TtTgChieu21').prop('disabled', bcheck);
    $('#TtTgCaNgay21').prop('disabled', bcheck);

    $('#rbLaoDongHon10').prop('disabled', !bcheck);
    $('#rbLaoDongDuoi10').prop('disabled', !bcheck);
    $('#SoLuongLdBtg22B').prop('disabled', !bcheck);
    $('#TongChiTraGio22B').prop('disabled', !bcheck);
    $('#SoLuongLdTtg22B').prop('disabled', !bcheck);
    $('#TongChiTraThang22B').prop('disabled', !bcheck);
    $('#SoLuongLdBtg22C').prop('disabled', !bcheck);
    $('#TongChiTraGio22C').prop('disabled', !bcheck);
    $('#SoLuongLdTtg22C').prop('disabled', !bcheck);
    $('#TongChiTraThang22C').prop('disabled', !bcheck);
    if (!bcheck) {
        $('#SoLuongLdBtg22B').val("0");
        $('#TongChiTraGio22B').val("0");
        $('#SoLuongLdTtg22B').val("0");
        $('#TongChiTraThang22B').val("0");
        $('#SoLuongLdBtg22C').val("0");
        $('#TongChiTraGio22C').val("0");
        $('#SoLuongLdTtg22C').val("0");
        $('#TongChiTraThang22C').val("0");
    }
    else {
        $('#TtTgSang21').prop('checked', !bcheck);
        $('#TtTgTrua21').prop('checked', !bcheck);
        $('#TtTgChieu21').prop('checked', !bcheck);
        $('#TtTgCaNgay21').prop('checked', !bcheck);
    }
}