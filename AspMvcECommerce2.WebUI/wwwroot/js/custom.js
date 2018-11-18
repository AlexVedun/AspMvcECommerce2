var $modal = $('#modal');
var $cart = $('.cart');

var setModalOk = function () {

    var hash = location.hash || "#!home";
    var re = /#!([-0-9A-Za-z]+)(\:(.+))?/;
    var match = re.exec(hash);
    hash = match[1];
    $modal.find('.modal-footer > a').attr('href', "#!" + hash);
};

var preloaderHide = function () {
    $('.preloader-wrapper').css('display', 'none');
}

var preloaderShow = function () {
    $('.preloader-wrapper').css('display', 'block');
}

//
var onSignIn = function (login) {

    $("a[href='#!home:out']").text('Signout (' + login + ')');
    $("a[href='#!home:out']").css('display', 'block');

    $("a[href='#!signin']").css('display', 'none');
    $("a[href='#!signup']").css('display', 'none');

    $(".cart").css('display', 'block');
}

var onSignOut = function () {

    $("a[href='#!home:out']").text('');
    $("a[href='#!home:out']").css('display', 'none');

    $("a[href='#!signin']").css('display', 'block');
    $("a[href='#!signup']").css('display', 'block');

    $(".cart").css('display', 'none');
    //TODO
    $("section#admin").html('');
}

$(document).ready(function () {

    $('.sidenav').sidenav();
    $('.modal').modal();
    $.get("/api/auth/checkauth")
        .done(function (resp) {

            if (resp != null) {

                onSignIn(resp);
            }
        })
        .fail(function () { alert("Fatal error"); });

    
    //$(".cart").click(setModalOk);
});