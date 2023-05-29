using ENOMVG_HFT_2022231.Endpoint.Services;
using ENOMVG_HFT_2022231.Logic;
using ENOMVG_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;


namespace ENOMVG_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        ISchoolLogic logic;
        IHubContext<SignalRHub> hub;

        public SchoolController(ISchoolLogic _logic, IHubContext<SignalRHub> _hub)
        {
            this.logic = _logic;
            this.hub = _hub;
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
        public void Create([FromBody] School _school)
        {
            this.logic.Create(_school);
            this.hub.Clients.All.SendAsync("SchoolCreated", _school);
        }

        // PUT api/<SchoolController>/5
        [HttpPut]
        public void Update([FromBody] School _school)
        {
            logic.Update(_school);
            this.hub.Clients.All.SendAsync("SchoolUpdated", _school);
        }

        // DELETE api/<SchoolController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            School schoolToDelete = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("SchoolDeleted", schoolToDelete);
        }
    }
}
