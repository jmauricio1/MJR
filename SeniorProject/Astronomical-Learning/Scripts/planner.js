

function ShowHideAllDiv() {
    document.getElementById('stopOneDiv').style.display = 'none';
    document.getElementById('stopTwoDiv').style.display = 'none';
    document.getElementById('stopThreeDiv').style.display = 'none';
    document.getElementById('stopFourDiv').style.display = 'none';
    $('#startPlanet').val('default');
    $('#stopOne').empty();
    $('#stopTwo').empty();
    $('#stopThree').empty();
    $('#stopFour').empty();
    $('#endPlanet').empty();
    getDestinationPlanet();
}

function ShowHideStopOneDiv() {
    document.getElementById('stopOneDiv').style.display = 'block';
    document.getElementById('stopTwoDiv').style.display = 'none';
    document.getElementById('stopThreeDiv').style.display = 'none';
    document.getElementById('stopFourDiv').style.display = 'none';
    $('#startPlanet').val('default');
    $('#stopOne').empty();
    $('#stopTwo').empty();
    $('#stopThree').empty();
    $('#stopFour').empty();
    $('#endPlanet').empty();
    getDestinationPlanet();
}

function ShowHideStopTwoDiv() {
    document.getElementById('stopOneDiv').style.display = 'block';
    document.getElementById('stopTwoDiv').style.display = 'block';
    document.getElementById('stopThreeDiv').style.display = 'none';
    document.getElementById('stopFourDiv').style.display = 'none';
    $('#startPlanet').val('default');
    $('#stopOne').empty();
    $('#stopTwo').empty();
    $('#stopThree').empty();
    $('#stopFour').empty();
    $('#endPlanet').empty();
    getDestinationPlanet();
}

function ShowHideStopThreeDiv() {
    document.getElementById('stopOneDiv').style.display = 'block';
    document.getElementById('stopTwoDiv').style.display = 'block';
    document.getElementById('stopThreeDiv').style.display = 'block';
    document.getElementById('stopFourDiv').style.display = 'none';
    $('#startPlanet').val('default');
    $('#stopOne').empty();
    $('#stopTwo').empty();
    $('#stopThree').empty();
    $('#stopFour').empty();
    $('#endPlanet').empty();
    getDestinationPlanet();
}

function ShowHideStopFourDiv() {
    document.getElementById('stopOneDiv').style.display = 'block';
    document.getElementById('stopTwoDiv').style.display = 'block';
    document.getElementById('stopThreeDiv').style.display = 'block';
    document.getElementById('stopFourDiv').style.display = 'block';
    $('#startPlanet').val('default');
    $('#stopOne').empty();
    $('#stopTwo').empty();
    $('#stopThree').empty();
    $('#stopFour').empty();
    $('#endPlanet').empty();
    getDestinationPlanet();
}

$("#startPlanet").change(function () {
    $("#stopOne").prop("disabled", true);
    if ($("#startPlanet").val() != "Choose here") {
        var LocationOptions = {};
        LocationOptions.url = "/TripPlanner/GetNewLocations";
        LocationOptions.type = "POST";
        LocationOptions.data = JSON.stringify({
            Location: $("#startPlanet").val()
        });
        LocationOptions.datatype = "json";
        LocationOptions.contentType = "application/json";
        LocationOptions.success = function (LocationsList) {
            $("#stopOne").empty();
            $("#stopOne").append("<option selected disabled hidden value='default'>Choose here</option>");
            for (var i = 0; i < LocationsList.length; i++) {
                $("#stopOne").append("<option>" + LocationsList[i] + "</option>");
            }
            $("#stopOne").prop("disabled", false);
        };
        LocationOptions.error = function () {
            alert("Error retreiving new locations!");
        };
        $.ajax(LocationOptions);
    } else {
        $("#stopOne").empty();
        $("#stopOne").prop("disabled", true);
    }
});

$("#stopOne").change(function () {
    $("#stopTwo").prop("disabled", true);
    if ($("#stopOne").val() != "Choose here") {
        var LocationOptions = {};
        LocationOptions.url = "/TripPlanner/GetNewLocations";
        LocationOptions.type = "POST";
        LocationOptions.data = JSON.stringify({
            Location: $("#stopOne").val()
        });
        LocationOptions.datatype = "json";
        LocationOptions.contentType = "application/json";
        LocationOptions.success = function (LocationsList) {
            $("#stopTwo").empty();
            $("#stopTwo").append("<option selected disabled hidden value='default'>Choose here</option>");
            for (var i = 0; i < LocationsList.length; i++) {
                $("#stopTwo").append("<option>" + LocationsList[i] + "</option>");
            }
            $("#stopTwo").prop("disabled", false);
        };
        LocationOptions.error = function () {
            alert("Error retreiving new locations!");
        };
        $.ajax(LocationOptions);
    } else {
        $("#stopTwo").empty();
        $("#stopTwo").prop("disabled", true);
    }
});

$("#stopTwo").change(function () {
    $("#stopThree").prop("disabled", true);
    if ($("#stopTwo").val() != "Choose here") {
        var LocationOptions = {};
        LocationOptions.url = "/TripPlanner/GetNewLocations";
        LocationOptions.type = "POST";
        LocationOptions.data = JSON.stringify({
            Location: $("#stopTwo").val()
        });
        LocationOptions.datatype = "json";
        LocationOptions.contentType = "application/json";
        LocationOptions.success = function (LocationsList) {
            $("#stopThree").empty();
            $("#stopThree").append("<option selected disabled hidden value='default'>Choose here</option>");
            for (var i = 0; i < LocationsList.length; i++) {
                $("#stopThree").append("<option>" + LocationsList[i] + "</option>");
            }
            $("#stopThree").prop("disabled", false);
        };
        LocationOptions.error = function () {
            alert("Error retreiving new locations!");
        };
        $.ajax(LocationOptions);
    } else {
        $("#stopThree").empty();
        $("#stopThree").prop("disabled", true);
    }
});

$("#stopThree").change(function () {
    $("#stopFour").prop("disabled", true);
    if ($("#stopThree").val() != "Choose here") {
        var LocationOptions = {};
        LocationOptions.url = "/TripPlanner/GetNewLocations";
        LocationOptions.type = "POST";
        LocationOptions.data = JSON.stringify({
            Location: $("#stopThree").val()
        });
        LocationOptions.datatype = "json";
        LocationOptions.contentType = "application/json";
        LocationOptions.success = function (LocationsList) {
            $("#stopFour").empty();
            $("#stopFour").append("<option selected disabled hidden value='default'>Choose here</option>");
            for (var i = 0; i < LocationsList.length; i++) {
                $("#stopFour").append("<option>" + LocationsList[i] + "</option>");
            }
            $("#stopFour").prop("disabled", false);
        };
        LocationOptions.error = function () {
            alert("Error retreiving new locations!");
        };
        $.ajax(LocationOptions);
    } else {
        $("#stopFour").empty();
        $("#stopFour").prop("disabled", true);
    }
});

function getDestinationPlanet() {
    if (document.getElementById('zeroStops').checked) {
        $("#startPlanet").change(function () {
            $("#endPlanet").prop("disabled", true);
            if ($("#startPlanet").val() != "Choose here") {
                var LocationOptions = {};
                LocationOptions.url = "/TripPlanner/GetNewLocations";
                LocationOptions.type = "POST";
                LocationOptions.data = JSON.stringify({
                    Location: $("#startPlanet").val()
                });
                LocationOptions.datatype = "json";
                LocationOptions.contentType = "application/json";
                LocationOptions.success = function (LocationsList) {
                    $("#endPlanet").empty();
                    $("#endPlanet").append("<option selected disabled hidden value='default'>Choose here</option>");
                    for (var i = 0; i < LocationsList.length; i++) {
                        $("#endPlanet").append("<option>" + LocationsList[i] + "</option>");
                    }
                    $("#endPlanet").prop("disabled", false);
                };
                LocationOptions.error = function () {
                    alert("Error retreiving new locations!");
                };
                $.ajax(LocationOptions);
            } else {
                $("#endPlanet").empty();
                $("#endPlanet").prop("disabled", true);
            }
        });
    }

    else if (document.getElementById('oneStops').checked) {
        $("#stopOne").change(function () {
            $("#endPlanet").prop("disabled", true);
            if ($("#stopOne").val() != "Choose here") {
                var LocationOptions = {};
                LocationOptions.url = "/TripPlanner/GetNewLocations";
                LocationOptions.type = "POST";
                LocationOptions.data = JSON.stringify({
                    Location: $("#stopOne").val()
                });
                LocationOptions.datatype = "json";
                LocationOptions.contentType = "application/json";
                LocationOptions.success = function (LocationsList) {
                    $("#endPlanet").empty();
                    $("#endPlanet").append("<option selected disabled hidden value='default'>Choose here</option>");
                    for (var i = 0; i < LocationsList.length; i++) {
                        $("#endPlanet").append("<option>" + LocationsList[i] + "</option>");
                    }
                    $("#endPlanet").prop("disabled", false);
                };
                LocationOptions.error = function () {
                    alert("Error retreiving new locations!");
                };
                $.ajax(LocationOptions);
            } else {
                $("#endPlanet").empty();
                $("#endPlanet").prop("disabled", true);
            }
        });
    }

    else if (document.getElementById('twoStops').checked) {
        $("#stopTwo").change(function () {
            $("#endPlanet").prop("disabled", true);
            if ($("#stopTwo").val() != "Choose here") {
                var LocationOptions = {};
                LocationOptions.url = "/TripPlanner/GetNewLocations";
                LocationOptions.type = "POST";
                LocationOptions.data = JSON.stringify({
                    Location: $("#stopTwo").val()
                });
                LocationOptions.datatype = "json";
                LocationOptions.contentType = "application/json";
                LocationOptions.success = function (LocationsList) {
                    $("#endPlanet").empty();
                    $("#endPlanet").append("<option selected disabled hidden value='default'>Choose here</option>");
                    for (var i = 0; i < LocationsList.length; i++) {
                        $("#endPlanet").append("<option>" + LocationsList[i] + "</option>");
                    }
                    $("#endPlanet").prop("disabled", false);
                };
                LocationOptions.error = function () {
                    alert("Error retreiving new locations!");
                };
                $.ajax(LocationOptions);
            } else {
                $("#endPlanet").empty();
                $("#endPlanet").prop("disabled", true);
            }
        });
    }

    else if (document.getElementById('threeStops').checked) {
        $("#stopThree").change(function () {
            $("#endPlanet").prop("disabled", true);
            if ($("#stopThree").val() != "Choose here") {
                var LocationOptions = {};
                LocationOptions.url = "/TripPlanner/GetNewLocations";
                LocationOptions.type = "POST";
                LocationOptions.data = JSON.stringify({
                    Location: $("#stopThree").val()
                });
                LocationOptions.datatype = "json";
                LocationOptions.contentType = "application/json";
                LocationOptions.success = function (LocationsList) {
                    $("#endPlanet").empty();
                    $("#endPlanet").append("<option selected disabled hidden value='default'>Choose here</option>");
                    for (var i = 0; i < LocationsList.length; i++) {
                        $("#endPlanet").append("<option>" + LocationsList[i] + "</option>");
                    }
                    $("#endPlanet").prop("disabled", false);
                };
                LocationOptions.error = function () {
                    alert("Error retreiving new locations!");
                };
                $.ajax(LocationOptions);
            } else {
                $("#endPlanet").empty();
                $("#endPlanet").prop("disabled", true);
            }
        });
    }

    else {
        $("#stopFour").change(function () {
            $("#endPlanet").prop("disabled", true);
            if ($("#stopFour").val() != "Choose here") {
                var LocationOptions = {};
                LocationOptions.url = "/TripPlanner/GetNewLocations";
                LocationOptions.type = "POST";
                LocationOptions.data = JSON.stringify({
                    Location: $("#stopFour").val()
                });
                LocationOptions.datatype = "json";
                LocationOptions.contentType = "application/json";
                LocationOptions.success = function (LocationsList) {
                    $("#endPlanet").empty();
                    $("#endPlanet").append("<option selected disabled hidden value='default'>Choose here</option>");
                    for (var i = 0; i < LocationsList.length; i++) {
                        $("#endPlanet").append("<option>" + LocationsList[i] + "</option>");
                    }
                    $("#endPlanet").prop("disabled", false);
                };
                LocationOptions.error = function () {
                    alert("Error retreiving new locations!");
                };
                $.ajax(LocationOptions);
            } else {
                $("#endPlanet").empty();
                $("#endPlanet").prop("disabled", true);
            }
        });
    }
}

function confirmRoute() {
    var start = $('#startPlanet').val();
    var stopOne = $('#stopOne').val();
    var stopTwo = $('#stopTwo').val();
    var stopThree = $('#stopThree').val();
    var stopFour = $('#stopFour').val();
    var destination = $('#endPlanet').val();

    if ($('#zeroStops').is(':checked') == true && (start == null || destination == null)) {
        alert("Please enter a valid route where all locations are selected.")
    }
    else if ($('#oneStops').is(':checked') == true && (start == null || stopOne == null || destination == null)) {
        alert("Please enter a valid route where all locations are selected.")
    }
    else if ($('#twoStops').is(':checked') == true && (start == null || stopOne == null || stopTwo == null || destination == null)) {
        alert("Please enter a valid route where all locations are selected.")
    }
    else if ($('#threeStops').is(':checked') == true && (start == null || stopOne == null || stopTwo == null || stopThree == null || destination == null)) {
        alert("Please enter a valid route where all locations are selected.")
    }
    else if ($('#fourStops').is(':checked') == true && (start == null || stopOne == null || stopTwo == null || stopThree == null || stopFour == null || destination == null)) {
        alert("Please enter a valid route where all locations are selected.")
    }
    else {
        document.getElementById('calculateButton').style.backgroundColor = 'lightgreen';
        document.getElementById('calculateButton').disabled = false;

        var inputs = document.getElementsByName('numOfStops');
        for (var i = 0; i < inputs.length; i++) {
            inputs[i].disabled = true;
        }

        document.getElementById('startPlanet').disabled = true;
        document.getElementById('stopOne').disabled = true;
        document.getElementById('stopTwo').disabled = true;
        document.getElementById('stopThree').disabled = true;
        document.getElementById('stopFour').disabled = true;
        document.getElementById('endPlanet').disabled = true;

    }
}
function calculateTrip() {

    document.getElementById('tripResultsTable').innerHTML =
        '<tr>' +
        '<th>Location From</th>' +
        '<th>Location To</th>' +
        '<th>Distance Travelled</th>' +
        '</tr>';
    document.getElementById('tripResults').style.display = 'block';
    var LocationsData = {};
    LocationsData.url = "/TripPlanner/CalculateDistances";
    LocationsData.type = "POST";
    LocationsData.data = JSON.stringify({
        Start: $("#startPlanet").val(),
        StopOne: $("#stopOne").val(),
        StopTwo: $("#stopTwo").val(),
        StopThree: $("#stopThree").val(),
        StopFour: $("#stopFour").val(),
        Destination: $("#endPlanet").val()
    });
    LocationsData.datatype = "json";
    LocationsData.contentType = "application/json";
    LocationsData.success = function (Distances) {
        var totalDistance = 0;
        for (i = 0; i < Distances.length; i++) {
            $('#tripResultsTable').find('tbody').append(
                '<tr>' +
                '<td>' + Distances[i].Start + '</td>' +
                '<td>' + Distances[i].Destination + '</td>' +
                '<td>' + Number(Distances[i].Distance).toLocaleString() + ' miles' + '</td>' +
                '</tr>'
            );
            totalDistance += Distances[i].Distance;
        };

        if (Distances.length > 1) {
            $('#tripResultsTable').find('tbody').append(
                '<tr style="border-top: 2px solid cornflowerblue">' +
                '<td>' + 'Total Distance: ' + totalDistance.toLocaleString() + ' miles' + '</td>' +
                '</tr>'
            );
        };
    };
    LocationsData.error = function () {
        alert("Error calculating distances!")
    };
    $.ajax(LocationsData);
}





function resetTripPlan() {
    document.getElementById('tripResults').style.display = 'none';
    ShowHideAllDiv();
    document.getElementById('zeroStops').checked = true;
    document.getElementById('calculateButton').style.backgroundColor = 'lightcoral';
    document.getElementById('calculateButton').disabled = true;

    var inputs = document.getElementsByName('numOfStops');
    for (var i = 0; i < inputs.length; i++) {
        inputs[i].disabled = false;
    }

    document.getElementById('startPlanet').disabled = false;
    document.getElementById('stopOne').disabled = false;
    document.getElementById('stopTwo').disabled = false;
    document.getElementById('stopThree').disabled = false;
    document.getElementById('stopFour').disabled = false;
    document.getElementById('endPlanet').disabled = false;

    document.getElementById('tripResultsTable').innerHTML =
        '<tr>' +
        '<th>Location From</th>' +
        '<th>Location To</th>' +
        '<th>Distance Travelled</th>' +
        '</tr>'
}

var filterOneClass = "";
var filterTwoClass = "";
var filterThreeClass = "";

function filterFirst() {
    if (filterOneClass != "") {
        $('#secondFilter .' + filterOneClass).prop('disabled', false);
        $('#secondFilter .' + filterOneClass).css('background-color', 'white');

        $('#thirdFilter .' + filterOneClass).prop('disabled', false);
        $('#thirdFilter .' + filterOneClass).css('background-color', 'white');
    }

    filterOneClass = $('#firstFilter :selected').attr('class');

    $('#secondFilter .' + filterOneClass).attr('disabled', true);
    $('#secondFilter .' + filterOneClass).css('background-color', 'lightcoral');

    $('#thirdFilter .' + filterOneClass).attr('disabled', true);
    $('#thirdFilter .' + filterOneClass).css('background-color', 'lightcoral');

    filterDataFetch();
}

function filterSecond() {
    if (filterTwoClass != "") {
        $('#firstFilter .' + filterTwoClass).prop('disabled', false);
        $('#firstFilter .' + filterTwoClass).css('background-color', 'white');

        $('#thirdFilter .' + filterTwoClass).prop('disabled', false);
        $('#thirdFilter .' + filterTwoClass).css('background-color', 'white');
    }

    filterTwoClass = $('#secondFilter :selected').attr('class');

    $('#firstFilter .' + filterTwoClass).attr('disabled', true);
    $('#firstFilter .' + filterTwoClass).css('background-color', 'lightgreen');

    $('#thirdFilter .' + filterTwoClass).attr('disabled', true);
    $('#thirdFilter .' + filterTwoClass).css('background-color', 'lightgreen');

    filterDataFetch()
}

function filterThird() {
    if (filterThreeClass != "") {
        $('#secondFilter .' + filterThreeClass).prop('disabled', false);
        $('#secondFilter .' + filterThreeClass).css('background-color', 'white');

        $('#thirdFilter .' + filterThreeClass).prop('disabled', false);
        $('#thirdFilter .' + filterThreeClass).css('background-color', 'white');
    }

    filterThreeClass = $('#thirdFilter :selected').attr('class');

    $('#firstFilter .' + filterThreeClass).attr('disabled', true);
    $('#firstFilter .' + filterThreeClass).css('background-color', 'lightyellow');

    $('#secondFilter .' + filterThreeClass).attr('disabled', true);
    $('#secondFilter .' + filterThreeClass).css('background-color', 'lightyellow');

    filterDataFetch()
}

function filterDataFetch() {
    var FilterOptions = {};
    FilterOptions.url = "/TripPlanner/GetFilterData";
    FilterOptions.type = "POST";
    FilterOptions.data = JSON.stringify({
        FilterOne: $('#firstFilter').val(),
        FilterTwo: $('#secondFilter').val(),
        FilterThree: $('#thirdFilter').val(),
    });
    FilterOptions.datatype = "json";
    FilterOptions.contentType = "application/json";
    FilterOptions.success = function (FilteredPlanets) {
        document.getElementById('filterPar').innerHTML = '';

        for (var i = 0; i < FilteredPlanets.length; i++) {
            if (i == (FilteredPlanets.length - 1)) {
                document.getElementById('filterPar').innerHTML += FilteredPlanets[i];
            }
            else {
                document.getElementById('filterPar').innerHTML += FilteredPlanets[i] + ', ';
            }
        }
    };
    FilterOptions.error = function () {
        alert("Error fetching filter data!");
    };
    $.ajax(FilterOptions);
}