using Microsoft.AspNetCore.Mvc;

namespace BlogProjetoInt.Controllers
{
	public class ContatoController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
