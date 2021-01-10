// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


/*----file uploader-----*/
function loadFile(event) {
    var fileName = document.getElementById("file").value;
    var idxDot = fileName.lastIndexOf(".") + 1;
    var extFile = fileName.substr(idxDot, fileName.length).toLowerCase();

    if (extFile == "jpg" || extFile == "jpeg" || extFile == "png") {
        var output = document.getElementById('output');
        output.src = URL.createObjectURL(event.target.files[0]);
        output.onload = function () {
            URL.revokeObjectURL(output.src) // free memory
        }
    } else {
        alert("Only jpg/jpeg and png files are allowed!");
    }
}

function GetConfirmation() {
    var reply = confirm("Искате ли да изтриете обявата?");

    if (reply) {
        return true;
    }
    else {
        return false;
    }
}
 