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

        public TeacherController(ITeacherLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<SchoolController>
        [HttpGet]
        public IEnumerable<Teacher> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<SchoolController>/5
        [HttpGet("{id}")]
        public Teacher Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<SchoolController>
        [HttpPost]
        public void Create([FromBody] Teacher teacher)
        {
            this.logic.Create(teacher);
        }

        // PUT api/<SchoolController>/5
        [HttpPut]
        public void Update([FromBody] Teacher school)
        {
            logic.Update(school);
        }

        // DELETE api/<SchoolController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
