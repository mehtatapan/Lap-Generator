using Lap_Generator_UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lap_Generator_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            client.BaseAddress = new Uri("http://localhost:60677/");
        }

        // GET: Drivers
        public ActionResult Index()
        {
            IEnumerable<Driver> Drivers = null;

            //HTTP GET
            var responseTask = client.GetAsync("api/Drivers");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadFromJsonAsync<IList<Driver>>();
                readTask.Wait();

                Drivers = readTask.Result;
            }
            else //web api sent error response 
            {
                Drivers = Enumerable.Empty<Driver>();

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(Drivers);
        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}