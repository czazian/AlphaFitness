using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
            cmdFindDay.Parameters.AddWithValue("@dayNo", Math.Round(difference.TotalDays + 1));
            cmdFindDay.Parameters.AddWithValue("@userID", userID);


            int dayID = Convert.ToInt32(cmdFindDay.ExecuteScalar());

            conn2.Close();

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
                        if (string.IsNullOrEmpty(calories.Text))
                        {
                            calories.Text = defaultValue.ToString();
                        }

                        if (string.IsNullOrEmpty(carbo.Text))
                        {
                            carbo.Text = defaultValue.ToString();
                        }

                        if (string.IsNullOrEmpty(heart.Text))
                        {
                            heart.Text = defaultValue.ToString();
                        }

                        if (string.IsNullOrEmpty(water.Text))
                        {
                            water.Text = defaultValue.ToString();
                        }

                        if (string.IsNullOrEmpty(exercise.Text))
                        {
                            exercise.Text = defaultValue.ToString();
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
        }
    }
}