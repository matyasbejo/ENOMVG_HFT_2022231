using ENOMVG_HFT_2022231.Logic;
using ENOMVG_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;

namespace ENOMVG_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        ISchoolLogic SchoolLogic;
        IStudentLogic StudentLogic;
        ITeacherLogic TeacherLogic;

        public StatisticsController(ISchoolLogic _schoollogic)
        {
            this.SchoolLogic = _schoollogic;
        }
    }
}
