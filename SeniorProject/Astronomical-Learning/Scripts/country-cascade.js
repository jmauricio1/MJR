$(document).ready(function () {

    /*
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Home/ListOfCountries",
        success: displayCountries,
        error: errorOnAjax
    });
    */

    $('#country-select').change(function () {
        var countryName = $('#country-select').val();
        console.log(countryName + " : from change in country select list");
        $.ajax({
            type: "GET",
            dataType: "json",
            url: '/Home/GetPlaces',
            data: { countryName: $('#country-select').val()},
            success: displayStatesProvinces,
            error: errorOnAjax
        });
    });

    $('#stateprovince-select').change(function () {
        console.log(('#stateprovince-select').val());
    });
});

function displayCountries(data) {
    //console.log(data);
    var countriesList = document.createElement('select');
    countriesList.id = "country-select";
    countriesList.className = "form-control";
    countriesList.setAttribute("data-val", "true");
    countriesList.setAttribute("data-val-required", "The Country field is required.");
    countriesList.name = "Country";

    for (var i = 0; i < data.length; i++) {
        var current = document.createElement('option');
        var text = document.createTextNode(data[i]);
        current.append(text);

        countriesList.appendChild(current);
    }
    $('#theCountries').append(countriesList);
}

function errorOnAjax() {
    console.log("ERROR on ajax request.");
}

function displayStatesProvinces(data) {
    //console.log(data);

    $('#theStateProvince').empty();

    var regionsList = document.createElement('select');
    regionsList.id = "stateprovince-select";
    regionsList.className = "form-control";
    regionsList.setAttribute("data-val", "true");
    regionsList.setAttribute("data-val-required", "The StateProvince field is required.");
    regionsList.name = "StateProvince";

    for (var i = 0; i < data.length; i++) {
        var current = document.createElement('option');
        var text = document.createTextNode(data[i]);
        current.append(text);

        regionsList.appendChild(current);
    }
    $('#theStateProvince').append(regionsList);
}

