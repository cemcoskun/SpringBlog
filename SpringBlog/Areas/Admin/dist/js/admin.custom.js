$(function() {
    $('#table[data-table="true"]').DataTable({
        "responsive": true,
        "autoWidth": false,
    });
    $('textarea[data-snote="true"]').summernote({
    height: 200});
});