using Lap_Generator_UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lap_Generator_UI.Controllers
{
    public class LapTimesController : Controller
    {
        private readonly HttpClient client = new HttpClient();

        public LapTimesController()
        {
            client.BaseAddress = new Uri("http://localhost:60677/api/LapTimes");
        }

        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LapTime lapTime)
        {
            //HTTP POST
            var postTask = client.PostAsJsonAsync<LapTime>("LapTimes", lapTime);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Upload Successful.");
                return View();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return View(lapTime);
            }

        }

        //public async Task<List<Driver>> GetDrivers()
        //{
        //    var response = await client.GetAsync("");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        List<Driver> Drivers = await response.Content.ReadFromJsonAsync<List<Driver>>();
        //        return Drivers;
        //    }
        //    else
        //    {
        //        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
        //        return new List<Driver>();
        //    }
        //}
    }
}
