using System.Web.Mvc;
using WebAppWeather.Models;

namespace WebAppWeather.Controllers
{
    public class HomeController : Controller
    {
       [HttpGet]
        public ActionResult Index()
        {
            return View(new WeatherHelper());
        }
        /// <summary>
        /// Метод для обработки входящего параметра и отправки ответа с Openweatherapi.
        /// </summary>
        /// <param name="InputCity"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetWeatherForecast(string InputCity)
        {
            WeatherHelper weather = new WeatherHelper();
            weather.InputCity = InputCity;
            return Json(weather.GetWeatherList(), JsonRequestBehavior.AllowGet);
        }
    }
}