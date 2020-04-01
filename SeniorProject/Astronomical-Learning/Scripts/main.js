
﻿function sunShowImageSources() {

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

    document.getElementById("sunFactText").innerHTML = "For a long time up until the 16th century it was widely regarded that Earth was the center of the Solar System until the Polish astronomer Nicolai Copernicus wrote a model that described why the Sun must be the center of our Solar System. [<a href='#ref11'>11</a>]<br>";

}

function changeFactInfoDial() {

    document.getElementById("sunFactImage").src = "https://upload.wikimedia.org/wikipedia/commons/3/3a/Sundial_2r.jpg";

    document.getElementById("sunFactSource").innerHTML = "<a href='https://commons.wikimedia.org/wiki/File:Sundial_2r.jpg'>Source</a>";

    document.getElementById("sunFactText").innerHTML = " People used to tell times using an object called a sun dial which used the Sun's light to cast a shadow on the dial's face which would look similar to modern day clocks.<br>";

}

function changeFactInfoReligion() {

    document.getElementById("sunFactImage").src = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e7/Maler_der_Grabkammer_der_Nefertari_001.jpg/499px-Maler_der_Grabkammer_der_Nefertari_001.jpg";

    document.getElementById("sunFactSource").innerHTML = "<a href='https://commons.wikimedia.org/wiki/File:Maler_der_Grabkammer_der_Nefertari_001.jpg'>Source</a>";

    document.getElementById("sunFactText").innerHTML = "The Sun is also an important part of some religions including Egyptian, Indo-European, and Meso-American. [<a href='#ref12'>12</a>]";

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

    document.getElementById("moonFactText").innerHTML = "The Moon's gravity is about 1/5 of the Earth's. [<a href='#ref9'>9</a>]<br> The above image shows a map of The Moon's surface were red is places of higher gravity and blue is places of lower gravity.";

}

function changeFactInfoTemp() {

    document.getElementById("moonFactImage").src = "https://www.jpl.nasa.gov/edu/images/news/lro20101021-full.jpg";

    document.getElementById("moonFactSource").innerHTML = "<a href='https://www.jpl.nasa.gov/edu/news/2019/7/25/science-points-the-way-to-stellar-career-path-for-nasa-jpl-intern/'>Source</a>";

    document.getElementById("moonFactText").innerHTML = "The Moon's temperature can vary wildly from 107 degrees Celsius (225 F) during the day to -153 degrees Celsius (-174 F) at night.[<a href='#ref9'>9</a>] <br>  The above image has cold areas as blue and warm areas as red.";

}





function homeShowPictureInfo() {

    var x = document.getElementById("pictureInfo");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}


function starsChangeInfo(image, source, info)
{
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

