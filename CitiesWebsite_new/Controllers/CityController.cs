using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitiesWebsite_new.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitiesWebsite_new.Controllers
{
    public class CityController : Controller
    {
        public ICityProvider _cities;

        public CityController(ICityProvider cities)
        {
            _cities = cities;
        }

        public IActionResult ShowCities()
        {
            ViewBag.Cities = _cities;
            return View();
        }

        public IActionResult ShowDataForCity(string cityName)
        {
            ViewBag.City = _cities[cityName];

            return View();
        }

        public IActionResult GetImage(string cityName)
        {
            return File($@"images\{cityName}.jpg", "image/jpeg");
        }
    }
}