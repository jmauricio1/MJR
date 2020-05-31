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