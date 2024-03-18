using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaFitness.Analysis
{
    public partial class Analysis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "run();", true);

            //Obtain login session
            string userID = Session["UserID"].ToString();

            //Processing
            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();

            string query = "SELECT * FROM [User] WHERE UserID = @userID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userID", userID);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    username.Text = reader["UserName"].ToString();
                }
            }
            else
            {
                Response.Redirect("~/User/UserLogin.aspx");
            }

            conn.Close();

            //get userID and dateID

            //Get today's dayID
            DateTime today = DateTime.Now;
            DateTime dateOfJoin;

            using (SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
            {
                conn1.Open();
                using (SqlCommand cmd1 = new SqlCommand("SELECT DateOfJoin FROM [User] WHERE UserID = @userID", conn1))
                {
                    cmd1.Parameters.AddWithValue("@userID", userID);
                    dateOfJoin = Convert.ToDateTime(cmd1.ExecuteScalar());
                }
                conn1.Close();
            }

            TimeSpan difference = today - dateOfJoin;

            SqlConnection conn2;
            string str5 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn2 = new SqlConnection(str5);

            conn2.Open();

            string cmdFindDayQuery = "SELECT DayID FROM Day WHERE DayNo = @dayNo AND UserID = @userID";
            SqlCommand cmdFindDay = new SqlCommand(cmdFindDayQuery, conn2);
            cmdFindDay.Parameters.AddWithValue("@dayNo", Math.Round(difference.TotalDays));
            cmdFindDay.Parameters.AddWithValue("@userID", userID);


            int dayID = Convert.ToInt32(cmdFindDay.ExecuteScalar());

            conn2.Close();


            //RecommendFood Section
            //String showRecommendFood = "SELECT * FROM [RecommendFood]";

            //bind to a data source
            //SqlDataSource1.SelectCommand = showRecommendFood;
            //SqlDataSource1.DataBind();
            //Repeater1.DataBind();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
            {
                //get today body metric data

                con.Open();

                string query2 = "SELECT * FROM [BodyMetric] WHERE DayID = @dayID";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@dayID", dayID);

                SqlDataReader reader2 = cmd2.ExecuteReader();

                if (reader2.HasRows)
                {
                    while (reader2.Read())
                    {
                        int defaultValue = 0;

                        calories.Text = reader2["Calories"].ToString();
                        carbo.Text = reader2["Carbo"].ToString();
                        heart.Text = reader2["HeartRate"].ToString();
                        water.Text = reader2["Water"].ToString();
                        exercise.Text = reader2["Exercised"].ToString();

                        //Default Values
                        if (string.IsNullOrEmpty(carbo.Text))
                        {
                            carbo.Text = defaultValue.ToString();
                            carboData.Value = defaultValue.ToString();
                        }
                        else
                        {
                            carboData.Value = reader2["Carbo"].ToString();
                        }

                        if (string.IsNullOrEmpty(heart.Text))
                        {
                            heart.Text = defaultValue.ToString();
                            heartData.Value = defaultValue.ToString();
                        }
                        else
                        {
                            heartData.Value = reader2["HeartRate"].ToString();
                        }

                        if (string.IsNullOrEmpty(water.Text))
                        {
                            water.Text = defaultValue.ToString();
                            waterData.Value = defaultValue.ToString();
                        }
                        else
                        {
                            waterData.Value = reader2["Water"].ToString();
                        }

                        if (string.IsNullOrEmpty(exercise.Text))
                        {
                            exercise.Text = defaultValue.ToString();
                            exerciseData.Value = defaultValue.ToString();
                        }
                        else
                        {
                            exerciseData.Value = reader2["Exercised"].ToString();
                        }
                    }
                }
                else
                {
                    int defaultNum = 0;
                    calories.Text = defaultNum.ToString();
                    carbo.Text = defaultNum.ToString();
                    heart.Text = defaultNum.ToString();
                    water.Text = defaultNum.ToString();
                    exercise.Text = defaultNum.ToString();
                }

                con.Close();
            }









            ///For recommended foods operations///
            //Get the calories value
            SqlConnection connn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString);
            connn1.Open();

            string queryConn = "SELECT TotalCalories FROM TotalCalories WHERE DayID = @dayID AND UserID = @userID";
            SqlCommand cmdConn = new SqlCommand(queryConn, connn1);
            cmdConn.Parameters.AddWithValue("@dayID", dayID);
            cmdConn.Parameters.AddWithValue("@userID", Convert.ToInt32(userID));
            double totalCalories = Convert.ToDouble(cmdConn.ExecuteScalar());

            Debug.WriteLine("Calories = " + totalCalories);

            calories.Text = totalCalories.ToString();

            connn1.Close();

            //Get the calories calculation
            using (SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
            {
                con2.Open();

                string query2 = "SELECT Activity, Weight, Height, Age, Gender FROM [User] WHERE UserID = @userID";
                SqlCommand cmd2 = new SqlCommand(query2, con2);
                cmd2.Parameters.AddWithValue("@userID", userID);

                SqlDataReader rdr = cmd2.ExecuteReader();

                string activity = "";
                double weight = 0;
                double height = 0;
                int age = 0;
                string gender = "";

                while (rdr.Read())
                {
                    activity = rdr["Activity"].ToString();
                    weight = Convert.ToDouble(rdr["Weight"]);
                    height = Convert.ToDouble(rdr["Height"]);
                    age = Convert.ToInt32(rdr["Age"]);
                    gender = rdr["Gender"].ToString();
                }


                //BMR CALCULATION
                double bmr = 0;
                Debug.WriteLine("GENDER = " + gender);
                if (gender == "M")
                {
                    bmr = 10 * weight + 6.25 * height - 5 * age + 5;
                }
                else if (gender == "F")
                {
                    bmr = 10 * weight + 6.25 * height - 5 * age - 161;
                }


                //Type Value - Activity
                double typeValue = 0;
                Debug.WriteLine("Activity = " + activity);
                if (activity == "Sedentary")
                {
                    typeValue = 1.2;
                }
                else if (activity == "Lightly")
                {
                    typeValue = 1.375;
                }
                else if (activity == "Moderately")
                {
                    typeValue = 1.55;
                }
                else if (activity == "Very")
                {
                    typeValue = 1.725;
                }
                else if (activity == "Extra")
                {
                    typeValue = 1.9;
                }

                //Calculate Calories
                double suggestedCalories = bmr * typeValue;
                Debug.WriteLine("SUGGESTED CALORIES = " + suggestedCalories);

                //Changing the style of calories
                double warning = suggestedCalories - 500;
                Debug.WriteLine("WARNING CALORIES = " + warning);

                con2.Close();


                //Get Foods not which calories exceeding the warning value
                using (SqlConnection conn3 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                {
                    conn3.Open();
                    using (SqlCommand cmd3 = new SqlCommand("SELECT TOP 5 FoodName, FoodCalories, FoodImg FROM (SELECT TOP 20 FoodName, FoodCalories, FoodImg FROM FOOD WHERE (@totalCalories + FoodCalories) <= @warningCalories ORDER BY FoodID) AS SubQueryAlias;", conn3))
                    {
                        cmd3.Parameters.AddWithValue("@totalCalories", totalCalories);
                        cmd3.Parameters.AddWithValue("@warningCalories", suggestedCalories);
                        SqlDataReader recommendedFoods = cmd3.ExecuteReader();
                        Repeater1.DataSource = recommendedFoods;
                        Repeater1.DataBind();

                        if (Repeater1.Items.Count == 0)
                        {
                            ExceedCaloriesLimit.Visible = true;
                            ExceedCaloriesLimit.Text = "You have exceeded your total daily suggested calories.";
                        } else
                        {
                            ExceedCaloriesLimit.Visible = false;
                        }
                    }
                    conn3.Close();
                }


            }


        }
    }
}