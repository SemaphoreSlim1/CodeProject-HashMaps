/// <reference path="../../bootstrap.js" />
/// <reference path="../../Knockout-3.1.0.js" />
/// <reference path="../../jquery-1.9.0.js" />
/// <reference path="https://ecn.dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=7.0&s=1" />

$(function () {
    
    var map;
    var searchManager;

    var options = {
        credentials: constants.bingMapsKey,
        center: new Microsoft.Maps.Location(35.333333, 25.133333),
        zoom: 2
    };

    $("#mapDiv").text("");
    var map = new Microsoft.Maps.Map(document.getElementById("mapDiv"), options);
    
    Microsoft.Maps.loadModule('Microsoft.Maps.Search', { callback: searchModuleLoaded });

    function searchModuleLoaded() {
        searchManager = new Microsoft.Maps.Search.SearchManager(map);
    }
    
    //if (navigator.geolocation) {
    //    navigator.geolocation.getCurrentPosition(locationSuccess, locationError);
    //} else {
    //    error('not supported');
    //}

    //function locationError() {
      
    //}

    //function locationSuccess(position) {
    //    $("#mapDiv").text("");
    //    var latlng = new Microsoft.Maps.Location(position.coords.latitude, position.coords.longitude);
    //    map = new Microsoft.Maps.Map(document.getElementById("mapDiv"), options);
    //    Microsoft.Maps.loadModule('Microsoft.Maps.Search', { callback: searchModuleLoaded });
    //}

    var yams = [];
    var currentYamIndex = -1;
    var currentPin = null;
    var infobox = null;   

    refreshYams();

    window.setInterval(function () {
        refreshYams();
    }, 60 * 2 * 1000);

    function refreshYams()
    {
        $("#loading-placeholder").show();

        $.ajax({
            url: "/Api/YammerUpdates",
            success: function (data, textStatus, jqXHR) {
                $("#loading-placeholder").hide();
                if (data.length > 0)
                { yams = data; } //only refresh the yams if there's new ones.
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert("Error");
            }
        });
    }

    window.setInterval(function () {
        cycleYams();
    }, 5 * 1000);

    function cycleYams() {
        if (searchManager == undefined || searchManager == null)
        { return; }

        if (yams.length == 0)
        { return; }

        if (currentYamIndex + 1 > yams.length - 1)
        { currentYamIndex = 0; }
        else
        { currentYamIndex++; }

        PlotData(yams[currentYamIndex]);
    }

    function PlotData(item)
    {
        var geocodeRequest = { where: item.Composer.Location, count: 1, callback: geocodeCallback, errorCallback: errCallback, userData: item };
        searchManager.geocode(geocodeRequest);
    }

    function geocodeCallback(geocodeResult, userData) {

        if (currentPin != null)
        {
            map.entities.remove(currentPin);
        }

        if (geocodeResult.results.length > 0)
        {
            var location = geocodeResult.results[0].location;           

            currentPin = new Microsoft.Maps.Infobox(location, {
                visible: true,
                title: userData.Composer.FullName,
                description: userData.PlainBody.substr(0,140)
            });
            
            map.entities.push(currentPin);
        }
    }


    function errCallback(geocodeRequest) {
      //  alert("An error occurred.");
    }


});