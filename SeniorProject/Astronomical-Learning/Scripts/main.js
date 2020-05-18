
function sunShowImageSources() {

    var x = document.getElementById("sunSources");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}




function changeFactInfoCenter() {

    document.getElementById("sunFactImage").src = "https://upload.wikimedia.org/wikipedia/commons/2/28/Copernican_heliocentrism_diagram-2.jpg";

    document.getElementById("sunFactSource").innerHTML = "<a href='https://commons.wikimedia.org/wiki/File:Copernican_heliocentrism_diagram-2.jpg'>Source</a>";

    document.getElementById("sunFactText").innerHTML = "For a long time up until the 16th century it was widely regarded that Earth was the center of the Solar System until the Polish astronomer Nicolai Copernicus wrote a model that described why the Sun must be the center of our Solar System. [<a href='https://www.britannica.com/topic/sun-worship'>REF</a>]<br>";

}

function changeFactInfoDial() {

    document.getElementById("sunFactImage").src = "https://upload.wikimedia.org/wikipedia/commons/3/3a/Sundial_2r.jpg";

    document.getElementById("sunFactSource").innerHTML = "<a href='https://commons.wikimedia.org/wiki/File:Sundial_2r.jpg'>Source</a>";

    document.getElementById("sunFactText").innerHTML = " People used to tell times using an object called a sun dial which used the Sun's light to cast a shadow on the dial's face which would look similar to modern day clocks.<br>";

}

function changeFactInfoReligion() {

    document.getElementById("sunFactImage").src = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e7/Maler_der_Grabkammer_der_Nefertari_001.jpg/499px-Maler_der_Grabkammer_der_Nefertari_001.jpg";

    document.getElementById("sunFactSource").innerHTML = "<a href='https://commons.wikimedia.org/wiki/File:Maler_der_Grabkammer_der_Nefertari_001.jpg'>Source</a>";

    document.getElementById("sunFactText").innerHTML = "The Sun is also an important part of some religions including Egyptian, Indo-European, and Meso-American. [<a href='https://www.britannica.com/topic/sun-worship'>REF</a>]";

}



function moonShowImageSources() {
    var x = document.getElementById("moonSources");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}




function changeFactInfoGravity() {

    document.getElementById("moonFactImage").src = "https://www.jpl.nasa.gov/spaceimages/images/largesize/PIA16587_hires.jpg";

    document.getElementById("moonFactSource").innerHTML = "<a href='https://www.jpl.nasa.gov/spaceimages/details.php?id=PIA16587'>Source</a>";

    document.getElementById("moonFactText").innerHTML = "The Moon's gravity is about 1/5 of the Earth's. [<a href='http://www.sciencekids.co.nz/sciencefacts/space/moon.html'>REF</a>]<br> The above image shows a map of The Moon's surface were red is places of higher gravity and blue is places of lower gravity.";

}

function changeFactInfoTemp() {

    document.getElementById("moonFactImage").src = "https://www.jpl.nasa.gov/edu/images/news/lro20101021-full.jpg";

    document.getElementById("moonFactSource").innerHTML = "<a href='https://www.jpl.nasa.gov/edu/news/2019/7/25/science-points-the-way-to-stellar-career-path-for-nasa-jpl-intern/'>Source</a>";

    document.getElementById("moonFactText").innerHTML = "The Moon's temperature can vary wildly from 107 degrees Celsius (225 F) during the day to -153 degrees Celsius (-174 F) at night.[<a href='http://www.sciencekids.co.nz/sciencefacts/space/moon.html'>REF</a>] <br>  The above image has cold areas as blue and warm areas as red.";

}





function homeShowPictureInfo() {

    var x = document.getElementById("pictureInfo");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}


function starsChangeInfo(image, source, info) {
    document.getElementById("starsTypesImage").src = image;

    document.getElementById("starsTypesSource").href = source;

    document.getElementById("starsTypesInfo").innerHTML = info;

}

function showDiv(name) {

    var x = document.getElementById(name);
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}



function changeFactInfoDesert() {
    document.getElementById("cometImage").src = "https://i.pinimg.com/originals/66/ef/a2/66efa2297100fff8b1f69b31f9221caa.jpg";

    document.getElementById("cometImageDescription").innerHTML = "A picture of the Libyan Desert where the comet is believed to have impacted. Note the yellow glass strewn across the desert.";
}

function changeFactInfoYellowGlass() {
    document.getElementById("cometImage").src = "https://upload.wikimedia.org/wikipedia/commons/5/59/Libyan_Desert_Glass.jpg";

    document.getElementById("cometImageDescription").innerHTML = "A single piece of yellow silicate glass obtained from the Libyan Desert.";
}

function changeFactInfoScarab() {
    document.getElementById("cometImage").src = "https://assets.catawiki.nl/assets/2016/12/8/0/2/f/02f0496a-bd2c-11e6-9e69-ee7b79227db6.jpg";

    document.getElementById("cometImageDescription").innerHTML = "Pharaoh Tutankhamen's scarab crafted from the yellow silicate glass of the Libyan Desert";
}






function submitComment(url) {
    if ($('#commentBox').val().length >= 10) {
        // Build the comment
        var comment = { "Username": "Placeholder", "PageFrom": window.location.pathname, "Comment": $('#commentBox').val() };

        // Send the information
        $.post(url, { comment: comment }, showSuccess, 'json');
    }
    else {
        alert("Please enter a minimum of 10 characters to comment.")
    }
}

function showSuccess() {
    alert("Your comment was submitted successfully! It will appear on this page as soon as an admin has reviewed and approved it.");
    document.getElementById("commentBox").value = "";
}

function deleteComment(commentId) {
    var del = confirm("Are you sure you want to delete this comment?");

    if (del == true) {
        $.post("/Profile/DeleteComment?commentId=" + commentId, commentId, deleteSuccess(), 'int');
    }
}

function deleteSuccess() {
    alert("You've deleted the comment.");

    setTimeout(function () {
        location.reload();
    }, 350);
}







function siteSearch() {

    var query = document.getElementById("siteSearchBar").value;

    location.href = '/Search/searchPage' + '?searchQuery=' + query;
}






function calculateQuiz1Score() {
    var totalScore = 0;

    if (document.querySelector('input[name="q1"]:checked').value == 2) {
        totalScore = totalScore + 1;
        document.getElementById("a1").innerHTML = "Correct";
    }
    else {
        document.getElementById("a1").innerHTML = "Incorrect";
    }
    if (document.querySelector('input[name="q2"]:checked').value == 1) {
        totalScore = totalScore + 1;
        document.getElementById("a2").innerHTML = "Correct";
    }
    else {
        document.getElementById("a2").innerHTML = "Incorrect";
    }
    if (document.querySelector('input[name="q3"]:checked').value == 4) {
        totalScore = totalScore + 1;
        document.getElementById("a3").innerHTML = "Correct";
    }
    else {
        document.getElementById("a3").innerHTML = "Incorrect";
    }
    if (document.querySelector('input[name="q4"]:checked').value == 3) {
        totalScore = totalScore + 1;
        document.getElementById("a4").innerHTML = "Correct";
    }
    else {
        document.getElementById("a4").innerHTML = "Incorrect";
    }

    if (document.querySelector('input[name="q5"]:checked').value == 2) {
        totalScore = totalScore + 1;
        document.getElementById("a5").innerHTML = "Correct";
    }
    else {
        document.getElementById("a5").innerHTML = "Incorrect";
    }

    if (document.querySelector('input[name="q6"]:checked').value == 1) {
        totalScore = totalScore + 1;
        document.getElementById("a6").innerHTML = "Correct";
    }
    else {
        document.getElementById("a6").innerHTML = "Incorrect";
    }

    if (document.querySelector('input[name="q7"]:checked').value == 1) {
        totalScore = totalScore + 1;
        document.getElementById("a7").innerHTML = "Correct";
    }
    else {
        document.getElementById("a7").innerHTML = "Incorrect";
    }

    if (document.querySelector('input[name="q8"]:checked').value == 2) {
        totalScore = totalScore + 1;
        document.getElementById("a8").innerHTML = "Correct";
    }
    else {
        document.getElementById("a8").innerHTML = "Incorrect";
    }

    if (document.querySelector('input[name="q9"]:checked').value == 2) {
        totalScore = totalScore + 1;
        document.getElementById("a9").innerHTML = "Correct";
    }
    else {
        document.getElementById("a9").innerHTML = "Incorrect";
    }

    if (document.querySelector('input[name="q10"]:checked').value == 3) {
        totalScore = totalScore + 1;
        document.getElementById("a10").innerHTML = "Correct";
    }
    else {
        document.getElementById("a10").innerHTML = "Incorrect";
    }
    document.getElementById("total").innerHTML = totalScore + "/10";
}

/*
$(function () {
    $('.button').on("click", function () {
        $.post('@Url.Action("PostActionToUpdatePoints", "Home")').always(function () {
            $('.target').load('/Home/UpdatePoints');
        })
    });
}); 
*/

function singleQuestionWrong(aDiv, bDiv) {

    var x = document.getElementById(aDiv);

    x.innerHTML = "Incorrect";

    var y = document.getElementById(bDiv);

    y.style.display = "none";
}


function singleQuestionRight(aDiv, bDiv) {

    var x = document.getElementById(aDiv);

    x.innerHTML = "Correct";

    var y = document.getElementById(bDiv);

    y.style.display = "none";
}








function acceptComment(commentId) {
    var accept = confirm("Are you sure you want to accept this comment? All users will be able to see this comment after it is acccepted.");

    if (accept == true) {
        $.post("/AdminAbilities/AcceptComment?commentId=" + commentId, commentId, acceptSuccess(), 'int');
    }
}

function acceptSuccess() {
    alert("This comment has been accepted.");

    setTimeout(function () {
        location.reload();
    }, 350);
}




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