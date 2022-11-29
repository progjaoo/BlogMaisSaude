using Microsoft.AspNetCore.Mvc;
using ProjetoBlog.Filters;
using ProjetoBlog.Models;
using System.Diagnostics;

namespace BlogProjetoInt.Controllers
{

    public class ChatController : Controller
    {
        private readonly ILogger<ChatController> _logger;

        public ChatController(ILogger<ChatController> logger)
        {
            _logger = logger;
        }
        public IActionResult Chat()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}