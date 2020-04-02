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
        module.className = "col-lg-4 col-md-6 col-sm-12 col-xs-12 launch-module";

        var missname = document.createElement('h3');
        var missnameText = document.createTextNode(data[i]["missionName"]);
        missname.className = "text-center";
        missname.append(missnameText);

        var missdate = document.createElement('h4');
        missdateText = document.createTextNode(data[i]["missionDate"]);
        missdate.className = "text-center";
        missdate.append(missdateText);

        var success = document.createElement('h4');
        if (data[i]["launchSuccess"] == "True") {
            success.append("Successful");
            success.className = "text-center success-text";
        }
        else if (data[i]["launchSuccess"] == null) {
            success.append("Not Yet Launched");
            success.className = "text-center null-text";
        }
        else {
            success.append("Unsuccessful");
            success.className = "text-center unsuccessful-text";
        }

        var button = document.createElement('a');
        button.append("Details");
        button.className = "btn btn-primary";
        button.href = '/SpaceCompanies/LaunchDetails?id=' + data[i]["flightNum"];

        module.appendChild(missname);
        module.appendChild(missdate);
        module.appendChild(success);
        module.appendChild(button);

        $('#launch-list').append(module);
    }
}