function acceptComment(commentId) {
    var accept = confirm("Are you sure you want to accept this comment? All users will be able to see this comment after it is acccepted.");

    if (accept == true) {
        $.post("/AdminAbilities/AcceptComment?commentId=" + commentId, commentId, acceptCommentSuccess(), 'int');
    }
}

function acceptCommentSuccess() {
    alert("This comment has been accepted.");

    setTimeout(function () {
        location.reload();
    }, 350);
}



function acceptProject(projectId) {
    var accept = confirm("Are you sure you want to accept this project? All users will be able to see this project after it is acccepted.");

    if (accept == true) {
        $.post("/AdminAbilities/AcceptProject?projectId=" + projectId, projectId, acceptProjectSuccess(), 'int');
    }
}

function acceptProjectSuccess() {
    alert("This project has been accepted.");

    setTimeout(function () {
        location.reload();
    }, 350);
}
