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
    public class StudentController : ControllerBase
    {
        IStudentLogic logic;
        IHubContext<SignalRHub> hub;

        public StudentController(IStudentLogic _logic, IHubContext<SignalRHub> _hub)
        {
            this.logic = _logic;
            this.hub = _hub;
        }

        // GET: api/<SchoolController>
        [HttpGet]
        public IEnumerable<Student> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<SchoolController>/5
        [HttpGet("{id}")]
        public Student Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<SchoolController>
        [HttpPost]
        public void Create([FromBody] Student _student)
        {
            this.logic.Create(_student);
            this.hub.Clients.All.SendAsync("StudentCreated", _student);
        }

        // PUT api/<SchoolController>/5
        [HttpPut]
        public void Update([FromBody] Student _student)
        {
            logic.Update(_student);
            this.hub.Clients.All.SendAsync("StudentUpdated", _student);
        }

        // DELETE api/<SchoolController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Student studentToDelete = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("StudentCreated", studentToDelete);
        }
    }
}
