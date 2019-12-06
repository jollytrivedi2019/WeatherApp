using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GlobalWeatherApp.Models
{
    public class Weather
    {
        public Object getWeatherForcast()
        {
            List<WeatherDetails> lstWeather = new List<WeatherDetails>();
            string appid = "aa69195559bd4f88d79f9aadeb77a8f6";
            string url = "http://api.openweathermap.org/data/2.5/weather?q=Cleveland&APPID=" + appid + "&units=imperial";
            var client = new WebClient();
            var content = client.DownloadString(url);
            string strTemp, strHumidity;
            //loop to populate city name
            foreach (CityInfo city in Enum.GetValues(typeof(CityInfo))) {

                string url1 = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&APPID=" + appid + "&units=imperial";                
                client = new WebClient();
                content = client.DownloadString(url1);
                strTemp = content.ToString().Substring(content.ToString().IndexOf("temp") + 6, 5);
                strHumidity = content.ToString().Substring(content.ToString().IndexOf("humidity") + 10, 2);
                lstWeather.Add(new WeatherDetails(city.ToString(), strTemp, strHumidity));

            }

            //var jsonContent = JsonConvert.DeserializeObject(content);
            
            using(StreamWriter sw = File.CreateText("list.csv"))
{
                for (int i = 0; i < lstWeather.Count; i++)
                {
                    sw.WriteLine("City : " + lstWeather[i].City);
                    sw.WriteLine("Humidity : " + lstWeather[i].Humidity);
                    sw.WriteLine("Temperature : " + lstWeather[i].Temperature);
                }
            }
            //return class as list
            return lstWeather;
        }
        enum CityInfo
        {            
            Paris,
            Dublin,
            Washington,            
            Delhi,
            Mumbai,
            Rome,
            Berlin,
            Dubai,
            London
        }
        public class WeatherDetails
        {
            public string City { get; set; }
            public string Temperature{ get; set; }

            public string Humidity { get; set; }

            public WeatherDetails(string city, string temp, string hum)
            {
                City = city;
                Temperature = temp;
                Humidity = hum;

            }
        }
    }
}
