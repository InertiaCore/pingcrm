using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InertiaCore;

namespace PingCRM.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        [HttpGet]
        [Route("/")]
        [Route("dashboard")]
        public IActionResult Index()
        {
            return Inertia.Render("Dashboard/Index");
        }
    }
}