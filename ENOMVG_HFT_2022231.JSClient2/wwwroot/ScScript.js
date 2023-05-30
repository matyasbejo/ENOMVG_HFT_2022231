let schools = [];
let connection = null;

let schoolIdtoUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:15398/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("SchoolCreated", (user, message) => { //
        getdata();
    });

    connection.on("SchoolDeleted", (user, message) => { //
        getdata();
    });

    connection.on("SchoolUpdated", (user, message) => { //
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:15398/school') //
        .then(x => x.json())
        .then(y => {
            schools = y;
            console.log(y);
            display();
        });
}


function display() { //
    document.getElementById("SchoolGetArea").innerHTML = "";
    schools.forEach(s => {
        document.getElementById("SchoolGetArea").innerHTML +=
            "<tr><td>" + s.name +
            "</td><td>" + s.age +
            "</td><td>" + s.type +
            "</td><td>" +
            `<button type="button" onclick="remove(${s.id})">Delete</button>` +
            `<button type="button" onclick="showupdate(${s.id})">Update</button>` +
            "</td></tr>";
    });
}

function showupdate(id) {
    document.getElementById("sc_u_name").value = schools.find(s => s['id'] == id)['name'];
    document.getElementById("sc_u_type").value = schools.find(s => s['id'] == id)['type'];
    document.getElementById("sc_u_age").value = schools.find(s => s['id'] == id)['age'];
    document.getElementById("updateformdiv").style.display = 'flex';
    schoolIdtoUpdate = id;
}

function remove(id) {
    fetch('http://localhost:15398/school/' + id, { //
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() { //
    let _name = document.getElementById('scname').value;
    let _age = document.getElementById('scage').value;
    let _type = document.getElementById('sctype').value;

    fetch('http://localhost:15398/school', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: _name, age: parseInt(_age), type: parseInt(_type)
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error) });
}

function update() { //
    document.getElementById('updateformdiv').style.display = 'none';
    let _name = document.getElementById('sc_u_name').value;
    let _type= document.getElementById('sc_u_type').value;
    let _age = document.getElementById('sc_u_age').value;

    fetch('http://localhost:15398/school', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: _name, age: parseInt(_age), type: parseInt(_type),
                id: schoolIdtoUpdate
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error) });
}