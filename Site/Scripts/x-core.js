function pageLoad() {
    $("select")
        .not(".DDPager select")
        .not(".ajax__html_editor_extender_buttoncontainer select")
        .chosen();
}

$(document).ready(function () {
    positionFooter();
    $(window).scroll(positionFooter);
    $(window).resize(positionFooter);
    $(window).load(positionFooter);

    if (!Modernizr.inputtypes.date) {
        $('.date').datepicker();
    }
});

function positionFooter() {
    var mFoo = $("footer");

    if ((($(document.body).height() + mFoo.height()) < $(window).height() && mFoo.css("position") == "fixed") || ($(document.body).height() < $(window).height() && mFoo.css("position") != "fixed")) {
        mFoo.css({ position: "fixed", bottom: "0px" });
    } else {
        mFoo.css({ position: "static" });
    }

    mFoo.css({ display: "block" });
}

function intializeGridViewSelectAllCheckbox() {
    $(".select_all input").change(function () {
        if (this.checked) {
            $(".select :checkbox").attr('checked', 'checked');
        } else {
            $(".select :checkbox").removeAttr('checked');
        }
    });
}