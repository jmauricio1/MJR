$(document).ready(function () {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/api/spacex-launchlist",
        success: displaySpaceXList,
        error: errorOnAjax
    });
});

function errorOnAjax() {
    console.log("ERROR on ajax request.");
}

function displaySpaceXList(data) {
    //console.log(data);

    for (var i = 0; i < data.length; i++) {
        var module = document.createElement('div');
        module.className = "col-lg-4 col-md-6 col-sm-12 col-xs-12 dark-bkr";

        var missname = document.createElement('h3');
        var missnameText = document.createTextNode(data[i]["missionName"]);
        missname.className = "text-center";
        missname.append(missnameText);

        var missdate = document.createElement('h4');
        missdateText = document.createTextNode(data[i]["missionDate"]);
        missdate.className = "text-center";
        missdate.append(missdateText);

        module.appendChild(missname);
        module.appendChild(missdate);

        $('#launch-list').append(module);
    }
}