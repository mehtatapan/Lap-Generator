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
                TempData["Message"] = "Lap Time added successfully!";
                return View();
            }
            else
            {
                int minute = lapTime.minute;
                int seconds = lapTime.second;
                int milliseconds = lapTime.millisecond;
                TempData["AlertMessage"] = GetError(minute, seconds, milliseconds);
                return View(lapTime);
            }

        }

        public string GetError(int min, int sec, int milli)
        {

            if (min >= 60)
                return "Minute value can't be more than 60";
            if (sec >= 60)
                return "Second value can't be more than 60";
            if (milli >= 100)
                return "Millisecond value can't be more than 60";
            else
                return "";
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
