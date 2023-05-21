using Microsoft.AspNetCore.Mvc;

namespace Boleteria_JacoboOsorioZapata.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
