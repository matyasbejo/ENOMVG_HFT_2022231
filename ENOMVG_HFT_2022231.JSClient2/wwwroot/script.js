let students = [];

fetch('http://localhost:15398/student')
    .then(x => x.json())
    .then(y => {
        students = y;
        console.log(y);
        display();
    });

function display() {
    students.forEach(s => {
        document.getElementById("StudentGetArea").innerHTML +=
            "<tr><th>" + s.name +
            "</th><th>" + s.schoolId +
            "</th><th>" + s.age +
            "</th><th>" + s.gradesAVG + "</th></tr>";
    });
}