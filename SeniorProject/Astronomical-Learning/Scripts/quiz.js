$(document).ready(function () {
    $('#q1-submit').on("click", function () {
        var input1 = document.querySelector('input[name="q1"]:checked').value;
        var input2 = document.querySelector('input[name="q2"]:checked').value;
        var input3 = document.querySelector('input[name="q3"]:checked').value;
        var input4 = document.querySelector('input[name="q4"]:checked').value;
        var input5 = document.querySelector('input[name="q5"]:checked').value;
        var input6 = document.querySelector('input[name="q6"]:checked').value;
        var input7 = document.querySelector('input[name="q7"]:checked').value;
        var input8 = document.querySelector('input[name="q8"]:checked').value;
        var input9 = document.querySelector('input[name="q9"]:checked').value;
        var input10 = document.querySelector('input[name="q10"]:checked').value;

        $.ajax({
            type: "GET",
            dataType: "json",
            url: "/GamesAndQuizzes/Q1Score",
            data: {
                a1: input1,
                a2: input2,
                a3: input3,
                a4: input4,
                a5: input5,
                a6: input6,
                a7: input7,
                a8: input8,
                a9: input9,
                a10: input10
            },
            error: errorOnAjax
        });
    });
});

function errorOnAjax(data) {
    console.log(data.responseText);
}