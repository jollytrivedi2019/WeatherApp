using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GlobalWeatherApp.Models;
using Newtonsoft.Json;

namespace GlobalWeatherApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Weather()
        {
            ViewData["Message"] = "";

            return View();
        }

        public JsonResult GetWeather()
        {
            Weather weatherinfo = new Weather();
            return Json(weatherinfo.getWeatherForcast());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
