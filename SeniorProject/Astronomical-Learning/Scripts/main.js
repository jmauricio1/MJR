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

    document.getElementById("moonFactText").innerHTML = "The Moon's gravity is about 1/5 of the Earth's. [<a href='#ref9'>9</a>]<br> The above image shows a map of The Moon's surface were red is places of higher gravity and blue is places of lower gravity.";

}

function changeFactInfoTemp() {

    document.getElementById("moonFactImage").src = "https://www.jpl.nasa.gov/edu/images/news/lro20101021-full.jpg";

    document.getElementById("moonFactSource").innerHTML = "<a href='https://www.jpl.nasa.gov/edu/news/2019/7/25/science-points-the-way-to-stellar-career-path-for-nasa-jpl-intern/'>Source</a>";

    document.getElementById("moonFactText").innerHTML = "The Moon's temperature can vary wildly from 107 degrees Celsius (225 F) during the day to -153 degrees Celsius (-174 F) at night.[<a href='#ref9'>9</a>] <br>  The above image has cold areas as blue and warm areas as red.";

}

