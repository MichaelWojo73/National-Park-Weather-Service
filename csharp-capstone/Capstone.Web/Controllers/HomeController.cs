using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;
using SessionCart.Web.Extensions;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {

        private IParkSqlDAL parkDAL;
        private IWeatherSqlDAL weatherSqlDAL;
        private ISurveySqlDAL surveyDAL;

        public HomeController(IParkSqlDAL parkDAL, IWeatherSqlDAL weatherSqlDAL, ISurveySqlDAL surveyDAL)
        {
            this.parkDAL = parkDAL;
            this.weatherSqlDAL = weatherSqlDAL;
            this.surveyDAL = surveyDAL;
        }

        public IActionResult Index()
        {
            var parks = parkDAL.GetParks();
            return View(parks);
        }

        [HttpGet]
        public IActionResult Detail(string Id)
        {
            var park = parkDAL.GetPark(Id);
            return View(park);
        }

        [HttpGet]
        public IActionResult Weather(string Id)
        {
            var currentWeather = weatherSqlDAL.GetWeather(Id);

            var degree = getCurrentDegree();

            if(degree == "C")
            {
                foreach(var weather in currentWeather)
                {
                    weather.Degree = "C";
                    weather.High = weather.ConvertToCelcius(weather.High);
                    weather.Low = weather.ConvertToCelcius(weather.Low);
                }
            }


            return View(currentWeather);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Weather(string Id, string degree)
        {
            SaveCurrentDegree(degree);

            // Redirect to action Forecast get with parkcode and degree in query string
            return RedirectToAction("Weather", new { Id });
        }

        private string getCurrentDegree()
        {
            string currentDegree = HttpContext.Session.Get<String>("Degree");
            if(currentDegree == null)
            {
                currentDegree = "F";
                HttpContext.Session.Set("Degree", currentDegree);
            }
            return currentDegree;
        }

        private void SaveCurrentDegree(string degree)
        {
            HttpContext.Session.Set<string>("Degree", degree);
        }
         

        [HttpGet]
        public IActionResult SaveNewSurvey()
        {
            Survey survey = new Survey();
            return View(survey);
        }

        [HttpGet]
        public IActionResult FavoriteParks()
        {
            var surveyList = surveyDAL.GetAllSurveys();
            return View(surveyList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNewSurvey(Survey survey)
        {
            surveyDAL.SaveNewSurvey(survey);
            return RedirectToAction("Favoriteparks");
        }

        
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

