$(document).ready(function () {
    $('#example').dataTable({
        "language": {
            "sProcessing": "Đang xử lý...",
            "sLengthMenu": "Hiển thị _MENU_",
            "sZeroRecords": "Không tìm thấy yêu cầu nào phù hợp",
            "sInfo": "Hiển thị từ _START_ đến _END_ của _TOTAL_ đối tượng",
            "sInfoEmpty": "",
            "sInfoFiltered": "",
            "sInfoPostFix": "",
            "sSearch": "Tìm kiếm",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Đầu",
                "sPrevious": "Trước",
                "sNext": "Tiếp",
                "sLast": "Cuối"
            }
        },
    });
}); 