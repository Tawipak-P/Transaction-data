// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(window).on('scroll', function () {
    var scrollHeight = $(document).height();
    var scrollPosition = $(window).height() + $(window).scrollTop();
    if ($(window).scrollTop() > 0) {
        $('nav').addClass('fixed-top');
    } else {
        $('nav').removeClass('fixed-top');
    }
});


//if ($(window).scrollTop(100)) {
    
//}
//else {
//    if ($(window).scrollTop(0)) {
//        $('nav').removeClass('fixed-top');
//    }
//}


