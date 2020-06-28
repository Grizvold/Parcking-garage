// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function openWindow(url){
    location.href = url;
}

function getData(){
    let vehicle = {
        name: document.getElementById("name").value,
        plateId: document.getElementById("plateId").value,
        phone: document.getElementById("phone").value,
        ticketType: document.getElementById("ticketType").value,
        vehicleType: document.getElementById("vehicleType").value,
        vehicleHeight: document.getElementById("vehicleHeight").value,
        vehicleWidth: document.getElementById("vehicleWidth").value,
        vehicleLength: document.getElementById("vehicleLength").value
    };
    
    return vehicle;
}

function sendPostToServer(url){
    let data = getData();
    
    if(!validate(data)){
        alert('fill all requirements correctly');
        return false
    }
    
    var xhr = new XMLHttpRequest();
    xhr.open("POST", url, true);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
            /*document.write(xhr.responseText);*/
            document.getElementById("createVersionForm").reset();
            alert('Checked-in successfully');
        }
        else if(xhr.readyState === 4 && xhr.status === 400){
            alert(`check-in failed - wrong ticket, add ${JSON.parse(xhr.responseText)[0]}$`)
            return false
        }
    }
    xhr.send(JSON.stringify(data));
}

function validate(data){
    isValidversion = false;

    for(let [key, value] of Object.entries(data)){
        isValidversion = true;
        
        if(value == null || value == "" || value == "0"){
            return false;
        }
    }
    return data != null && data != "" && isValidversion
}


function sendDeleteToServer(url){
let data = {
            plateId: document.getElementById("plateId").value
        }
        
        var xhr = new XMLHttpRequest();
        xhr.open("DELETE", url, true);
        xhr.setRequestHeader("Content-Type", "application/json");
        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4 && xhr.status === 200) {
                document.getElementById("createVersionForm").reset();
                alert('Checked-out successfully');
            }
            else if(xhr.readyState === 4 && xhr.status === 400){
                alert('vehicle not exists')
                return false
            }
        }
        xhr.send(JSON.stringify(data));
}