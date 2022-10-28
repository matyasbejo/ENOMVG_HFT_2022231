using ENOMVG_HFT_2022231.Logic;
using ENOMVG_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace ENOMVG_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        ISchoolLogic logic;

        public SchoolController(ISchoolLogic _logic)
        {
            this.logic = _logic;
        }

        // GET: api/<SchoolController>
        [HttpGet]
        public IEnumerable<School> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<SchoolController>/5
        [HttpGet("{id}")]
        public School Read(int _id)
        {
            return logic.Read(_id);
        }

        // POST api/<SchoolController>
        [HttpPost]
        public void Create([FromBody] School _school)
        {
            this.logic.Create(_school);
        }

        // PUT api/<SchoolController>/5
        [HttpPut]
        public void Update([FromBody] School _school)
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
