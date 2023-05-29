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
    public class TeacherController : ControllerBase
    {
        ITeacherLogic logic;
        IHubContext<SignalRHub> hub;

        public TeacherController(ITeacherLogic _logic, IHubContext<SignalRHub> _hub)
        {
            this.logic = _logic;
            this.hub = _hub;
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
        public void Create([FromBody] Teacher _teacher)
        {
            this.logic.Create(_teacher);
            this.hub.Clients.All.SendAsync("TeacherCreated", _teacher);
        }

        // PUT api/<SchoolController>/5
        [HttpPut]
        public void Update([FromBody] Teacher _teacher)
        {
            logic.Update(_teacher);
            this.hub.Clients.All.SendAsync("TeacherUpdated", _teacher);

        }

        // DELETE api/<SchoolController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Teacher teacherToDelete = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("TeacherDeleted", teacherToDelete);
        }
    }
}
