using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.DynamicData;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using WeatherNote.API;
using WeatherNote.Models;


namespace WeatherNote.ApiImplementation
{
    public class TemperaturApi
    {
        private string apiKey = "95abfe80363cd1f33d210e682a72511c";
        private string city = "2686469";

        public RootObject TempRequest()
        {
            HttpWebRequest apiRequest =
                WebRequest.Create("http://api.openweathermap.org/data/2.5/forecast?id=" + city + "&APPID=" + apiKey +
                                  "&units=metric") as HttpWebRequest;

            string apiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }

            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(apiResponse);

            return rootObject;
        }

        public List<double> ReturningTemperatures()
        {
            List<double> temperatures = new List<double>();

            var rootObject = TempRequest();

            for (int i = 1; i <= 4; i++)
            {
                double maxTemp = -200;
                var currentday = DateTime.Today;
                currentday = currentday.AddDays(i);

                foreach (var item in rootObject.list)
                {
                    var currentTemp = item.main.temp_max;
                    var daytime = Convert.ToDateTime(item.dt_txt); 

                    TimeSpan differTimeSpan = daytime - currentday;

                    if (differTimeSpan.Days == 0)
                    {
                        if (currentTemp > maxTemp)
                        {
                            maxTemp = currentTemp;
                        }
                    }
                }

                double round = Math.Round(maxTemp);
                temperatures.Add(round);
            }
            return temperatures;
        }
    }
}