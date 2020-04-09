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

    for (var i = 1; i < data.length + 1; i++) {
        var module = document.createElement('div');
        module.className = "col-lg-4 col-md-6 col-sm-12 col-xs-12 launch-module text-center";

        var missname = document.createElement('h3');
        var missnameText = document.createTextNode(data[i-1]["missionName"]);
        missname.className = "text-center";
        missname.append(missnameText);

        var missdate = document.createElement('h4');
        missdateText = document.createTextNode(data[i-1]["missionDate"]);
        missdate.className = "text-center";
        missdate.append(missdateText);

        var success = document.createElement('h4');
        if (data[i-1]["launchSuccess"] == "True") {
            success.append("Successful");
            success.className = "text-center success-text";
        }
        else if (data[i-1]["launchSuccess"] == null) {
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
        button.href = '/SpaceCompanies/LaunchDetails?id=' + data[i-1]["flightNum"];

        var sameLine = document.createElement('div');
        sameLine.className = "clearfix"

        module.appendChild(missname);
        module.appendChild(missdate);
        module.appendChild(success);
        module.appendChild(button);
        
        $('#launch-list').append(module);
        if (((i % 3) == 0)) {
            $('#launch-list').append(sameLine);
        }
    }
}