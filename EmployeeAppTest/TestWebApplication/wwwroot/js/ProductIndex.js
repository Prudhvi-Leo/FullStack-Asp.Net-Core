document.addEventListener("DOMContentLoaded", function () {
    const tableBody = document.querySelector("#tblProducts tbody");
    tableBody.innerHTML = ''; // Clear table rows

    fetch("/Products/ProductDetails/", {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        }
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            data.forEach(item => {
                const row = `
                <tr>
                    <td class='prtoducttd'>${item.ProductID}</td>
                    <td class='prtoducttd'>${item.Name}</td>
                    <td class='prtoducttd'>${item.Description}</td>
                </tr>`;
                tableBody.innerHTML += row;
            });
        })
        .catch(error => {
            console.error('There was a problem with your fetch operation:', error);
            // Handle error as needed
        });
});
