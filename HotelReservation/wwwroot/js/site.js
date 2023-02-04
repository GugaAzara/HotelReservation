// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function () {
    

    $('button[data-toggle="modal"]').click(function () {
        $(".overlay, .popup").fadeIn();
    })

    $("#close-popup").click(function () {
        $("#fade-area").removeAttr("style");
        $("#customer-popup").removeAttr("style");
    })


})

