let students = [];
let ids = [];

getdata();

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
    ids = [];
    document.getElementById("StudentGetArea").innerHTML = "";
    students.forEach(s => {
        document.getElementById("StudentGetArea").innerHTML +=
            "<tr><th>" + s.name +
            "</th><th>" + s.schoolId +
            "</th><th>" + s.age +
            "</th><th>" + s.gradesAVG + "</th></tr>";
        ids.push(s.id);
    });
}

function create() {
    let _name = document.getElementById('stname').value;
    let _stschoolid = document.getElementById('stschoolid').value;
    let _age = document.getElementById('stage').value;
    let _grades = document.getElementById('stgradesavg').value;
    let _id = Math.max.apply(null, ids) + 1;

    fetch('http://localhost:15398/student', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: _name, schoolId: _stschoolid, age: _age, gradesAVG: _grades, id: _id
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