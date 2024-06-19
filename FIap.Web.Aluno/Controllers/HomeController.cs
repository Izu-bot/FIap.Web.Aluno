using FIap.Web.Aluno.Logging;
using FIap.Web.Aluno.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FIap.Web.Aluno.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomLogger _logger;

        public HomeController(ICustomLogger logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.Log("Acessando a página inicial"); // Uso do log
            return View();
        }

        public IActionResult Privacy()
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
