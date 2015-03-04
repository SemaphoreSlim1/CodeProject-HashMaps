/// <reference path="../../jquery-1.9.0.js" />
/// <reference path="../../bootstrap.js" />
/// <reference path="../../Knockout-3.1.0.js" />

$(function () {
    $("#logIn").click(function () {        
        var redirect = encodeURIComponent(constants.host + "/Home/Display");
        window.location = "https://www.yammer.com/dialog/oauth?client_id=" + constants.yammerClientID + "&redirect_uri=" + redirect;
    });
});