
document.addEventListener("DOMContentLoaded", function () {
    var rawdata = { 'IDValue': '10' };

    fetch("/Home/AjaxTest/?IDValue=10", {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        },
    }).then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.text();
        }).then(response => {
            document.getElementById("someDiv").innerHTML = response;
        }).catch(error => {
            console.error('There was a problem with your fetch operation:', error);
        });
});