using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Http.Results;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaFitness
{
    public partial class Contents : System.Web.UI.MasterPage
    {

        protected int checkIndex(int cityID)
        {
            for (int i = 0; i < ddlWeather.Items.Count; i++)
            {
                if (ddlWeather.Items[i].Value.Equals(cityID.ToString()))
                {
                    return i;
                }
            }
            return 0;
        }


        protected void ddlWeather_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cityid = Convert.ToInt32(ddlWeather.SelectedValue);
            Session["CityID"] = cityid;
            ddlWeather.SelectedIndex = checkIndex(cityid);


            //Weather Process
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "$(function () {initialStates(); });", true);

            ////Weather API
            string uri = "http://api.weatherbit.io/v2.0/current?city_id=" + cityid + "&country=MY&key=20fb41c9e8af48d9bf83e46cfe98a47f";
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
            //wname.Text = weathername;

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
            }
            else
            {
                winfo.Text = "Undefined";
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            int cityid = 0;
            if (Session["CityID"] == null)
            {
                //Set default to Kuala Lumpur
                Session["CityID"] = "1735161";
                cityid = 1735161;
            }
            else
            {
                cityid = Convert.ToInt32(Session["CityID"]);
            }

            //Weather Selection
            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();

            //Command & Execution 
            string retrieve = "SELECT * FROM Weather";
            SqlDataAdapter adapter = new SqlDataAdapter(retrieve, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            ddlWeather.DataSource = dt;
            ddlWeather.DataBind();
            ddlWeather.DataTextField = "CityName";
            ddlWeather.DataValueField = "CityID";
            ddlWeather.DataBind();
            // ddlWeather.SelectedIndex = 57;


            //Weather Process
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "$(function () {initialStates(); });", true);
            ddlWeather.SelectedIndex = checkIndex(cityid);

            ////Weather API
            string uri = "http://api.weatherbit.io/v2.0/current?city_id=" + cityid + "&country=MY&key=20fb41c9e8af48d9bf83e46cfe98a47f";
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
            //wname.Text = weathername;

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
            }
            else
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
            double tempu = weatherData.data[0].temp;

            temp.Text = tempu.ToString()+ "°C";

            System.Diagnostics.Debug.WriteLine("LIST OF ITEM : " + json);
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

        protected void logoutLink_Click(object sender, EventArgs e)
        {
            Session.Remove("UserID");
            Response.Redirect("~/User/UserLogin.aspx");
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
        public double app_temp { get; set; }
        public double aqi { get; set; }
        public string city_name { get; set; }
        public double clouds { get; set; }
        public string country_code { get; set; }
        public string datetime { get; set; }
        public double dewpt { get; set; }
        public double dhi { get; set; }
        public double dni { get; set; }
        public double elev_angle { get; set; }
        public double ghi { get; set; }
        public double gust { get; }
        public double h_angle { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string ob_time { get; set; }
        public string pod { get; set; }
        public double precip { get; set; }
        public double pres { get; set; }
        public double rh { get; set; }
        public double slp { get; set; }
        public double snow { get; set; }
        public double solar_rad { get; set; }
        public List<string> sources { get; set; }
        public string state_code { get; set; }
        public string station { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public double temp { get; set; }
        public string timezone { get; set; }
        public double ts { get; set; }
        public double uv { get; set; }
        public double vis { get; set; }
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