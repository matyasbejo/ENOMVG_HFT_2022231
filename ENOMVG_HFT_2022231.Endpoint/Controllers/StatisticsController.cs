using ENOMVG_HFT_2022231.Logic;
using Microsoft.AspNetCore.Mvc;

namespace ENOMVG_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        ISchoolLogic SchoolLogic;

        public StatisticsController(ISchoolLogic _schoollogic)
        {
            this.SchoolLogic = _schoollogic;
        }
    }
}
