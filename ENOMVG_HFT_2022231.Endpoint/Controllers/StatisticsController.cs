using ENOMVG_HFT_2022231.Logic;
using ENOMVG_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ENOMVG_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        ISchoolLogic SchoolLogic;
        IStudentLogic StudentLogic;
        ITeacherLogic TeacherLogic;

        public StatisticsController(ISchoolLogic _schl, IStudentLogic _stl, ITeacherLogic _tcl)
        {
            this.SchoolLogic = _schl;
            this.StudentLogic = _stl;
            this.TeacherLogic = _tcl;
        }

        [HttpGet("{id}")]
        public double School_GradesAvg(int id)
        {
            return this.SchoolLogic.SchoolGradesAVG(id);
        }

        [HttpGet("{id}")]
        public double School_SalaryAVG(int id)
        {
            return this.SchoolLogic.SchoolSalaryAVG(id);
        }

        [HttpGet("{name}")]
        public School School_ReadName(string name)
        {
            return SchoolLogic.ReadName(name);
        }

        [HttpGet("{id}")]
        public int School_CountAll(int id)
        {
            return SchoolLogic.CountAll(id);
        }

        [HttpGet("{id}")]
        public IEnumerable<Teacher> School_TeachersOfSchool(int id)
        {
            return SchoolLogic.TeachersOfSchool(id);
        }

        [HttpGet("{id}")]
        public IEnumerable<Student> School_StudentsOfSchool(int id)
        {
            return SchoolLogic.StudentsOfSchool(id);
        }
        ///////////////////////////
        [HttpGet("{name}")]
        public Student Student_ReadName(string name)
        {
            return StudentLogic.ReadName(name);
        }

        [HttpGet("")]
        public Student Student_BestStudent()
        {
            return StudentLogic.BestStudent();
        }

        [HttpGet("")]
        public double Student_AvarageAge()
        {
            return StudentLogic.AvarageAge();
        }

        [HttpGet("")]
        public IEnumerable<Student> School_YoungStudents()
        {
            return StudentLogic.YoungStudents();
        }

        ///////////////////
        [HttpGet("{name}")]
        public Teacher Teacher_Readname(string name)
        {
            return TeacherLogic.ReadName(name);
        }

        [HttpGet("")]
        public Teacher Teacher_MostPaidTeacher()
        {
            return TeacherLogic.MostPaidTeacher();
        }

        [HttpGet("")]
        public Teacher Teacher_LeastPaidTeacher()
        {
            return TeacherLogic.LeastPaidTeacher();
        }
    }
}
