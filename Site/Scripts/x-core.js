function pageLoad() {
    $("select")
        .not(".DDPager select")
        .chosen();
}

$(document).ready(function () {
    if (!Modernizr.inputtypes.date) {
        $('.date').datepicker();
    }
}); 

function intializeGridViewSelectAllCheckbox() {
    $(".select_all input").change(function () {
        if (this.checked) {
            $(".select :checkbox").attr('checked', 'checked');
        } else {
            $(".select :checkbox").removeAttr('checked');
        }
    });
}