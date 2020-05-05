var selectedCell = null;
var win = null;
var div = null;
var control = null;
function openWin(divId, controlId) {
    div = divId;
    control = controlId;
    //win = window.GetRadWindowManager().GetWindowById(winID);
    //if (win) {
    //    win.show();
    //    win.maximize();  
    //}             
    //setTimeout(function () {
    //    window.GetRadWindowManager().GetActiveWindow().show();
    //    window.GetRadWindowManager().GetActiveWindow().maximize()
    //}, 0);
    return false;
}
function cell_Click(td) {
    var text = $(td).text();
    var cls = td.className;
    if (control === "__Page") {
        selectedCell = $('#' + div);
        $(selectedCell).removeClass();
        $(selectedCell).addClass(cls + " rank");

        $('#' + 'lbl' + div).text(text);
        $('#' + 'hid' + div).val(text);
        $('#' + 'hidClass' + div).val(cls);
    }
    else {
        selectedCell = $('#' + control + '_' + div);
        $(selectedCell).removeClass();
        $(selectedCell).addClass(cls + " rank");

        $('#' + control + '_lbl' + div).text(text);
        $('#' + control + '_hid' + div).val(text);
        $('#' + control + '_hidClass' + div).val(cls);
    }
    window.GetRadWindowManager().closeActiveWindow();
    return false;
}

(function () {
    var $;
    var demo = window.demo = window.demo || {};

    demo.initialize = function () {
        $ = $telerik.$;

        if (!Telerik.Web.UI.RadAsyncUpload.Modules.FileApi.isAvailable()) {
           // $(".qsf-demo-canvas").html("<strong>Your browser does not support Drag and Drop. Please take a look at the info box for additional information.</strong>");
        }
        else {
            $(document).bind({ "drop": function (e) { e.preventDefault(); } });

            var dropZone1 = $(document).find(".DropZone1");
            dropZone1.bind({ "dragenter": function (e) { dragEnterHandler(e, dropZone1); } })
                .bind({ "dragleave": function (e) { dragLeaveHandler(e, dropZone1); } })
                .bind({ "drop": function (e) { dropHandler(e, dropZone1); } });

            //var dropZone2 = $(document).find("#DropZone2");
            //dropZone2.bind({ "dragenter": function (e) { dragEnterHandler(e, dropZone2); } })
            //    .bind({ "dragleave": function (e) { dragLeaveHandler(e, dropZone2); } })
            //    .bind({ "drop": function (e) { dropHandler(e, dropZone2); } });
        }
    };

    function dropHandler(e, dropZone) {
        dropZone[0].style.backgroundColor = "#357A2B";
    }

    function dragEnterHandler(e, dropZone) {
        var dt = e.originalEvent.dataTransfer;
        var isFile = (dt.types != null && (dt.types.indexOf ? dt.types.indexOf('Files') != -1 : dt.types.contains('application/x-moz-file')));
        if (isFile || $telerik.isSafari5 || $telerik.isIE10Mode || $telerik.isOpera)
            dropZone[0].style.backgroundColor = "#000000";
    }

    function dragLeaveHandler(e, dropZone) {
        if (!$telerik.isMouseOverElement(dropZone[0], e.originalEvent))
            dropZone[0].style.backgroundColor = "#357A2B";
    }


})();