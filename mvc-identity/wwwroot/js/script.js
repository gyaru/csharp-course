document.addEventListener('DOMContentLoaded', (event) => {
    reloadTable();
});

document.getElementById("lookUp").addEventListener('click', (e) => {
    const input = document.getElementById("searchId").value;
    console.log(input);
    showDetails(input);
})

document.getElementById("refresh").addEventListener('click', (e) => {
    reloadTable();
})

function reloadTable() {
    document.getElementById("peopleTableSpinner").style.display = "inline-block";
    document.getElementById("peopleTable").style.display = "none";
    fetch("/People/All",)
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error: ${response.status}`);
            }
            return response.text();
        })
        .then(text => {
            setTimeout(() => {
                document.getElementById("peopleTableSpinner").style.display = "none";
                document.getElementById("peopleTable").innerHTML = text;
                document.getElementById("peopleTable").style.display = "table";
            }, 500);
        })
        .catch(() => console.log("woops"));
}

function deleteByID(id) {
    fetch("/People/Delete/" + id, {method: 'POST'})
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error: ${response.status}`);
            }
            return response.text();
        })
        .then(text => {
            reloadTable(text);
        })
        .catch(() => console.log("woops"));
}

function showDetails(id) {
    fetch("/People/Details/" + id,)
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error: ${response.status}`);
            }
            return response.text();
        })
        .then(text => {
            document.getElementById("detailsModal").innerHTML = text;
            document.getElementById("detailsModal").style.zIndex = 2;
            document.getElementById("modalClose").addEventListener('click', (e) => {
                console.log('what')
                document.getElementById("detailsModal").style.display = "hidden";
                document.getElementById("detailsModal").style.opacity = 0;
                document.getElementById("detailsModal").style.zIndex = -9999;
            })
            document.getElementById("detailsModal").style.display = "block";
            document.getElementById("detailsModal").style.opacity = 100;
        })
        .catch(() => console.log("woops"));
}