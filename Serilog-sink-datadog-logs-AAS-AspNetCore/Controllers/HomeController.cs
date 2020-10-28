using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog_sink_datadog_logs_AAS_AspNetCore.Models;

namespace Serilog_sink_datadog_logs_AAS_AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Entered the HomeController/Index(): ILogger");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Entered the HomeController/Privacy(): ILogger");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
