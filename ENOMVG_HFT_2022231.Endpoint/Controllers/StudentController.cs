using ENOMVG_HFT_2022231.Logic;
using ENOMVG_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ENOMVG_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentLogic logic;

        public StudentController(IStudentLogic _logic)
        {
            this.logic = _logic;
        }

        // GET: api/<SchoolController>
        [HttpGet]
        public IEnumerable<Student> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<SchoolController>/5
        [HttpGet("{id}")]
        public Student Read(int _id)
        {
            return logic.Read(_id);
        }

        // POST api/<SchoolController>
        [HttpPost]
        public void Create([FromBody] Student _student)
        {
            this.logic.Create(_student);
        }

        // PUT api/<SchoolController>/5
        [HttpPut]
        public void Update([FromBody] Student _student)
        {
            logic.Update(_student);
        }

        // DELETE api/<SchoolController>/5
        [HttpDelete("{id}")]
        public void Delete(int _id)
        {
            logic.Delete(_id);
        }
    }
}
