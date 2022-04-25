using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CitiesWebsite_new.Services;
using CitiesWebsite_new.Models;

namespace CitiesWebsite_new.ViewComponents
{
    public class CityViewComponent : ViewComponent
    {
        private ICityProvider _cities;

        public CityViewComponent(ICityProvider cities)
        {
            _cities = cities;
        }
        public async Task<IViewComponentResult> InvokeAsync(string cityName)
        {
            ViewBag.CurrentCity = await GetCity(cityName);
            return View("SelectCity");
        }
        private Task<City> GetCity(string cityName)
        {
            return Task.FromResult<City>(_cities[cityName]);
        }
    }
}
