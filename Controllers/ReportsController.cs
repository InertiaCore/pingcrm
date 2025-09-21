using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InertiaCore;

namespace PingCRM.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        [HttpGet]
        [Route("reports")]
        public IActionResult Index()
        {
            return Inertia.Render("Reports/Index");
        }
    }
}