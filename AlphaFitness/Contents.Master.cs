using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaFitness
{
    public partial class Contents : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "$(function () {initialStates(); });", true);

            ////Weather API
            string uri = "http://api.weatherbit.io/v2.0/current?lat=3.1412&lon=101.68653&country=MY&key=20fb41c9e8af48d9bf83e46cfe98a47f";
            WebRequest request = WebRequest.Create(uri);
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Get the Whole JSON for Kuala Lumpur
            string result = null;
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                result = sr.ReadToEnd();
                sr.Close();
            }

            string weathername = checkWhetherCode(result);
            //string weathername = "Thunder";
            wname.Text = weathername;

            if (weathername == "Sunny")
            {
                winfo.Text = "It's great to conduct outdoor activities.";
                wimg.ImageUrl = "~/Image/Element/sunny.gif";
            }
            else if (weathername == "Rainy")
            {
                winfo.Text = "It's ideal to stay at home.";
                wimg.ImageUrl = "~/Image/Element/rainy.gif";
            }
            else if (weathername == "Cloudy")
            {
                winfo.Text = "It's great to conduct outdoor activities, has possibility of precipitation.";
                wimg.ImageUrl = "~/Image/Element/cloudy.gif";
            }
            else if (weathername == "Thunder")
            {
                winfo.Text = "It's ideal to stay at home.";
                wimg.ImageUrl = "~/Image/Element/thunder.gif";
            } else
            {
                winfo.Text = "Undefined";
            }
        }


        //REFERENCES -> 
        ////Sunny
        //700 -> 751, 800 -> 802
        ////Rainy
        //300 -> 610, 621 -> 623, 900
        ////Cloudy
        //612, 803, 804
        ////Thunder
        //200 -> 233
        protected string checkWhetherCode(string json)
        {
            WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(json);

            // Access weather information
            int code = weatherData.data[0].weather.code;
            System.Diagnostics.Debug.WriteLine("THE WHETHER CODE : " + code);
            //Sunny
            if (code >= 700 && code <= 751 || code >= 800 && code <= 802)
            {
                return "Sunny";
            }
            else if (code >= 300 && code <= 610 || code >= 621 && code <= 623 || code == 900) //Rainy
            {
                return "Rainy";
            }
            else if (code == 612 || code == 803 || code == 804) //Cloudy
            {
                return "Cloudy";
            }
            else if (code >= 200 && code <= 233) //Thunder
            {
                return "Thunder";
            }
            else
            {
                return "Undefined";
            }
        }

    }


    //Class for receiving JSON Data
    public class WeatherData
    {
        public int count { get; set; }
        public List<WeatherInfo> data { get; set; }
    }

    public class WeatherInfo
    {
        public float app_temp { get; set; }
        public int aqi { get; set; }
        public string city_name { get; set; }
        public int clouds { get; set; }
        public string country_code { get; set; }
        public string datetime { get; set; }
        public float dewpt { get; set; }
        public int dhi { get; set; }
        public int dni { get; set; }
        public double elev_angle { get; set; }
        public int ghi { get; set; }
        //public double gust { get; set; }
        public double h_angle { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string ob_time { get; set; }
        public string pod { get; set; }
        public long precip { get; set; }
        public float pres { get; set; }
        public int rh { get; set; }
        public float slp { get; set; }
        public int snow { get; set; }
        public int solar_rad { get; set; }
        public List<string> sources { get; set; }
        public string state_code { get; set; }
        public string station { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public float temp { get; set; }
        public string timezone { get; set; }
        public long ts { get; set; }
        public int uv { get; set; }
        public int vis { get; set; }
        public WeatherDetails weather { get; set; }
        public WindInfo wind { get; set; }
    }

    public class WeatherDetails
    {
        public string icon { get; set; }
        public string description { get; set; }
        public int code { get; set; }
    }

    public class WindInfo
    {
        public string wind_cdir { get; set; }
        public string wind_cdir_full { get; set; }
        public int wind_dir { get; set; }
        public float wind_spd { get; set; }
    }
}