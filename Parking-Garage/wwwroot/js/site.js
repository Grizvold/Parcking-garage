// open new url 
function openWindow(url){
    location.href = url;
}

//get vehicle data from form inputs
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

// send post request to server to check-in vehicle
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
            if(JSON.parse(xhr.responseText)[0] == -1){
                alert("parking in full");
            }
            else{
                alert(`check-in failed - wrong ticket, add ${JSON.parse(xhr.responseText)[0]}$`)
            }
            return false
        }
    }
    xhr.send(JSON.stringify(data));
}
//validate inputs
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

// send delete request to server to check out vehicle
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