using Microsoft.AspNetCore.Mvc;
using SerilogDemo.Models;
using System.Diagnostics;

namespace SerilogDemo.Controllers
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
            _logger.LogInformation("Home Controller Index Method");

            _logger.LogInformation("Starting Count Method");
            Count();
            return View();
        }

        private void Count()
        {
            try
            {
                for(int i = 0; i < 100; i++)
                {
                    if (i == 50) throw new Exception();
                    _logger.LogInformation("The number is : {i}", i);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("Error, The number is 50");
            }
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