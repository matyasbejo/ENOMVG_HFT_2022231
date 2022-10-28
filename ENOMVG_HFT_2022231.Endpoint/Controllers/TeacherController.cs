using ENOMVG_HFT_2022231.Logic;
using ENOMVG_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ENOMVG_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        ITeacherLogic logic;

        public TeacherController(ITeacherLogic _logic)
        {
            this.logic = _logic;
        }

        // GET: api/<SchoolController>
        [HttpGet]
        public IEnumerable<Teacher> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<SchoolController>/5
        [HttpGet("{id}")]
        public Teacher Read(int _id)
        {
            return logic.Read(_id);
        }

        // POST api/<SchoolController>
        [HttpPost]
        public void Create([FromBody] Teacher _teacher)
        {
            this.logic.Create(_teacher);
        }

        // PUT api/<SchoolController>/5
        [HttpPut]
        public void Update([FromBody] Teacher _school)
        {
            logic.Update(_school);
        }

        // DELETE api/<SchoolController>/5
        [HttpDelete("{id}")]
        public void Delete(int _id)
        {
            logic.Delete(_id);
        }
    }
}
