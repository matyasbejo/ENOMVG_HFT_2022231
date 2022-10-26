﻿using ENOMVG_HFT_2022231.Logic;
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

        public SchoolController(ISchoolLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<SchoolController>
        [HttpGet]
        public IEnumerable<School> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<SchoolController>/5
        [HttpGet("{id}")]
        public School Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<SchoolController>
        [HttpPost]
        public void Create([FromBody] School school)
        {
            this.logic.Create(school);
        }

        // PUT api/<SchoolController>/5
        [HttpPut]
        public void Update([FromBody] School school)
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
