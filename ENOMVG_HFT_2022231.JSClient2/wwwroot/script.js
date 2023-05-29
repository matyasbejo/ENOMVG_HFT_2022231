let students = [];
let connection = null;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:15398/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("StudentCreated", (user, message) => {
        getdata();
    });

    connection.on("StudentDeleted", (user, message) => {
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
    await fetch('http://localhost:15398/student')
        .then(x => x.json())
        .then(y => {
            students = y;
            console.log(y);
            display();
        });
}


function display() {
    document.getElementById("StudentGetArea").innerHTML = "";
    students.forEach(s => {
        document.getElementById("StudentGetArea").innerHTML +=
            "<tr><td>" + s.name +
            "</td><td>" + s.schoolId +
            "</td><td>" + s.age +
            "</td><td>" + s.gradesAVG +
        "</td><td>" + `<button type="button" onclick="remove(${s.id})">Delete</button>` + "</td></tr>";
    });
}

function remove(id){
    fetch('http://localhost:15398/student/' + id, {
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

function create() {
    let _name = document.getElementById('stname').value;
    let _stschoolid = document.getElementById('stschoolid').value;
    let _age = document.getElementById('stage').value;
    let _grades = document.getElementById('stgradesavg').value;

    fetch('http://localhost:15398/student', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: _name, schoolId: _stschoolid, age: _age, gradesAVG: _grades
            })
    })
        .then(response => response)
        .then(data =>
        {
            console.log('Success', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error) });
}