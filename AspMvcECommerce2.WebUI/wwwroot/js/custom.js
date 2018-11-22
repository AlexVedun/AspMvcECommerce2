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

//Получение нового сообщения из WebSocket
if (!!window.EventSource) {
    var source = new EventSource('http://localhost:49741/api/subscribe');
    source.addEventListener('message', function (e) {
        console.log("message");
        console.log(e);
        $("a[href='#!home:out']").click();
    }, false);
    source.addEventListener('open', function (e) {
        console.log("open!");
    }, false);
    source.addEventListener('error', function (e) {
        if (e.readyState == EventSource.CLOSED) {
            console.log("error!");
        }
    }, false);
} else {
    // not supported!
    //fallback to something else
    console.log('!!window.EventSource is not supported. Fallback to something else');
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