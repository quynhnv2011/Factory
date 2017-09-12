function ExportExcel() {
    $('#hfExport').val(1);
    $('#frmSearch').submit();
    $('#hfExport').val(0);
}
function deleteTB(id) {
    var thisUrl = window.location.href;
    if (confirm("Bạn có thực sự muốn xóa!") == true) {
        location.href = thisUrl + "/Delete/" + id;
    } else {
        
    }
}