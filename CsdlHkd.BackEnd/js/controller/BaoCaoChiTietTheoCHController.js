function loadCuaHang(el) {
    $.ajax({
        url: '/BaoCaoChiTietTheoCuaHang/ListCuaHangByDvPbId',
        type: "GET",
        data: { "IdDvPb": $(el).val() },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var obj = JSON.parse(data);            
            $('#ddCuaHang').html("");
            $('#ddCuaHang').append("<option value='0'>Chọn cửa hàng</option>");
            for (var i = 0; i < obj.length; i++) {
                $('#ddCuaHang').append("<option value='" + obj[i].Id + "'>" + obj[i].Ten + "</option>");
            }
        }
    });
}
function loadDDKyKT(el) {
    $.ajax({
        url: '/BaoCaoChiTietTheoCuaHang/GetDDKyKiemTraStart',
        type: "GET",
        data: { "IdCuaHang": $(el).val() },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var obj = JSON.parse(data);
            $('#KyKiemTraStart').html("");
            $('#KyKiemTraStart').append("<option value='0'>Chọn Kỳ Kiểm Tra</option>");
            for (var i = 0; i < obj.length; i++) {
                $('#KyKiemTraStart').append("<option value='" + obj[i].Id + "'>" + obj[i].Ten + "</option>");
            }
        }
    })
}