﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace WebAppWeather.Models
{
    public class WeatherHelper
    {
        
        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        [Display(Name = "Enter the name of the city")]
        //Свойство для хранения данных о введенном городе.
        public string InputCity { get; set; }

        //AppId выданный OpenWeatherApi.
        private static string appId = "ec9a70d26efefb2f50b06809908b582d";

        /// <summary>
        /// Метод для получения данных с openweatherapi в формате json и отправки ответа на основе сформированной Url с названием города, и AppId.
        /// </summary>
        /// <returns>Object</returns>
        public Object GetWeatherList()
        {
            Object jsonContent;
            StringBuilder builder = new StringBuilder();
            //Формирование строки.
            builder.Append("https://api.openweathermap.org/data/2.5/forecast?q=");
            builder.Append(InputCity);
            builder.Append("&APPID=");
            builder.Append(appId);
            builder.Append("&units=metric");
            string url = builder.ToString();
            //string url = $"https://api.openweathermap.org/data/2.5/forecast?q={InputCity}&APPID={appId}&units=metric";

            try
            {
                using (WebClient client = new WebClient())
                {
                    var content = client.DownloadString(url);
                    jsonContent = JsonConvert.DeserializeObject<RootObject>(content);
                }
            }
            catch (Exception ex)
            {
                return "not found";
            }
            return jsonContent;
        }
    }
    /// <summary>
    /// Классы помощники для десериализации полученного ответа с Openweatherapi
    /// </summary>
    public class Main
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
        public int humidity { get; set; }
        public double temp_kf { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
    }

    public class Sys
    {
        public string pod { get; set; }
    }

    public class Rain
    {
        public double __invalid_name__3h { get; set; }
    }

    public class List
    {
        public int dt { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public Sys sys { get; set; }
        public string dt_txt { get; set; }
        public Rain rain { get; set; }
    }

    public class Coord
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
        public int timezone { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class RootObject
    {
        public string cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        public List<List> list { get; set; }
        public City city { get; set; }
    }
}