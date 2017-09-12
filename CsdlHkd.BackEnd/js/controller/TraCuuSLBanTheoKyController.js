$(function () {
    $('.treetable').treegrid({
        expanderExpandedClass: 'fa fa-caret-down',
        expanderCollapsedClass: 'fa fa-caret-right'
    });

    $('.treetable tr').each(function (e) {
        var paddingSize = 0;
        var cntIndents = $(this).find('span.treegrid-indent').length;
        paddingSize = cntIndents * 16;
        paddingSize += 8;
        $(this).find("span.treegrid-indent").remove();
        if (!($(this).find("i.treegrid-expander").hasClass("fa fa-caret-down") || $(this).find("treegrid-expander").hasClass("fa fa-caret-right"))) {
            $(this).find("i.treegrid-expander").remove();
            paddingSize += 16;
        }
        $(this).find("td:eq(0)").css("padding-left", paddingSize);
    });
});

