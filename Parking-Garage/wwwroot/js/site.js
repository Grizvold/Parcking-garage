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
            document.write(xhr.responseText);
        }
        else if(xhr.readyState === 4 && xhr.status === 401){
            alert('check-in failed')
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
                document.write(xhr.responseText);
            }
            else if(xhr.readyState === 4 && xhr.status === 401){
                alert('check-in failed')
                return false
            }
        }
        xhr.send(JSON.stringify(data));
}