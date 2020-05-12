$(function () {
    bsCustomFileInput.init();


    $('table[data-table="true"]').each(function (index) {

        var sortOrder = $(this).data("table-sort-order") || "asc";
        var sortColumn = $(this).data("table-sort-column") || 0;

        $(this).DataTable({
            "order": [[sortColumn, sortOrder]],
            "responsive": true,
            "autoWidth": false,
        });

    });

    $('textarea[data-snote="true"]').summernote({
        height: 200
    });
    // https://getbootstrap.com/docs/4.4/components/modal/#via-javascript
    $("body").on("click", "[data-delete-id]", function (event) {
        event.preventDefault();
        var button = $(this); // Button that triggered the modal
        var id = button.data('delete-id') // Extract info from data-* attributes
        var name = button.data('delete-name') // Extract info from data-* attributes
        var action = button.data('delete-action') // Extract info from data-* attributes
        $("#deleteModalForm").attr("action", action);
        $("#deleteModalItemName").text(name);
        $("#deleteModalItemId").val(id);
        $("#deleteModal").modal();
    });
});