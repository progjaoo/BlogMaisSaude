using Microsoft.AspNetCore.Mvc;
using ProjetoBlog.Filters;

namespace ProjetoBlog.Controllers
{
    [PageUserLogin]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
