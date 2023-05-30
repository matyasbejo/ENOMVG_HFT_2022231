let teachers = [];
let connection = null;

let teacherIdtoUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:15398/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("TeacherCreated", (user, message) => { //
        getdata();
    });

    connection.on("TeacherDeleted", (user, message) => { //
        getdata();
    });

    connection.on("TeacherUpdated", (user, message) => { //
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
    await fetch('http://localhost:15398/teacher') //
        .then(x => x.json())
        .then(y => {
            teachers = y;
            console.log(y);
            display();
        });
}


function display() { //
    document.getElementById("TeacherGetArea").innerHTML = "";
    teachers.forEach(s => {
        document.getElementById("TeacherGetArea").innerHTML +=
            "<tr><td>" + s.name +
            "</td><td>" + s.schoolId +
            "</td><td>" + s.salary +
            "</td><td>" + s.mainSubject +
            "</td><td>" +
            `<button type="button" onclick="remove(${s.id})">Delete</button>` +
            `<button type="button" onclick="showupdate(${s.id})">Update</button>` +
            "</td></tr>";
    });
}

function showupdate(id) {
    document.getElementById("tch_u_name").value = teachers.find(s => s['id'] == id)['name'];
    document.getElementById("tch_u_mainsubject").value = teachers.find(s => s['id'] == id)['mainSubject'];
    document.getElementById("tch_u_salary").value = teachers.find(s => s['id'] == id)['salary'];
    document.getElementById("tch_u_schoolid").value = teachers.find(s => s['id'] == id)['schoolId'];
    document.getElementById("updateformdiv").style.display = 'flex';
    teacherIdtoUpdate = id;
}

function remove(id) {
    fetch('http://localhost:15398/teacher/' + id, { //
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
    let _name = document.getElementById('tchname').value;
    let _tchschoolid = document.getElementById('tchschoolid').value;
    let _salary = document.getElementById('tchsalary').value;
    let _tchmainsubj = document.getElementById('tchmainsubject').value;

    fetch('http://localhost:15398/teacher', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: _name, schoolId: _tchschoolid, salary: _salary, mainSubject: parseInt(_tchmainsubj)
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
    let _name = document.getElementById('tch_u_name').value;
    let _tchschoolid = document.getElementById('tch_u_schoolid').value;
    let _salary = document.getElementById('tch_u_salary').value;
    let _tchmainsubj = document.getElementById('tch_u_mainsubject').value;

    fetch('http://localhost:15398/teacher', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: _name, schoolId: _tchschoolid, salary: _salary, mainSubject: parseInt(_tchmainsubj),
                id: teacherIdtoUpdate
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error) });
}