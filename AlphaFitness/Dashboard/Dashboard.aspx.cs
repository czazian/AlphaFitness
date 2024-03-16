using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Formatting;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaFitness.Dashboard
{
    public partial class Dashboard : System.Web.UI.Page
    {

        int completedMisionCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                //Default day style
                one.BackColor = Color.LightGray;
                one.ForeColor = Color.DimGray;

                two.BackColor = Color.LightGray;
                two.ForeColor = Color.DimGray;

                three.BackColor = Color.LightGray;
                three.ForeColor = Color.DimGray;

                four.BackColor = Color.LightGray;
                four.ForeColor = Color.DimGray;

                five.BackColor = Color.LightGray;
                five.ForeColor = Color.DimGray;

                six.BackColor = Color.LightGray;
                six.ForeColor = Color.DimGray;

                seven.BackColor = Color.LightGray;
                seven.ForeColor = Color.DimGray;

                int userID = Convert.ToInt32(Session["UserID"]);
                //int userID = 1; //For Testing Purpose.

                ///Day Management
                //Get Today's date
                DateTime today = DateTime.Now;


                //Need to check if the user's date now is same as today date -> If no, means a new day is came
                //Get date of joining
                DateTime dateOfJoin;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT DateOfJoin FROM [User] WHERE UserID = @userID", conn))
                    {
                        cmd.Parameters.AddWithValue("@userID", userID);
                        dateOfJoin = Convert.ToDateTime(cmd.ExecuteScalar());
                    }
                    conn.Close();
                }



                //Get user date now
                DateTime userdateNow;


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT DateNow FROM [User] WHERE UserID = @userID", conn))
                    {
                        cmd.Parameters.AddWithValue("@userID", userID);
                        userdateNow = Convert.ToDateTime(cmd.ExecuteScalar());
                    }
                    conn.Close();
                }
                userdateNow = userdateNow.Date;



                TimeSpan difference = today - dateOfJoin;
                int dayInTheWeek = Convert.ToInt32(difference.TotalDays + 1) % 7;
                if (Convert.ToInt32(difference.TotalDays + 1) == 7)
                {
                    dayInTheWeek = 7;
                }


                int weekNum = (Convert.ToInt32(difference.TotalDays) / 7) + 1;

                Debug.WriteLine("Day in week " + dayInTheWeek);
                Debug.WriteLine("Ween no. " + weekNum);
                Debug.WriteLine("DIFFERENCE : " + difference);

                //Update Day of Login
                lblNumberOfDays.Text = Math.Round(difference.TotalDays + 1).ToString();



                //Update Week
                weekNo.Text = weekNum.ToString();

                //Update Day
                Color active = Color.FromArgb(252, 186, 3);
                if (dayInTheWeek == 1)
                {
                    one.BackColor = active;
                    one.ForeColor = Color.White;
                }
                else if (dayInTheWeek == 2)
                {
                    two.BackColor = active;
                    two.ForeColor = Color.White;
                }
                else if (dayInTheWeek == 3)
                {
                    three.BackColor = active;
                    three.ForeColor = Color.White;
                }
                else if (dayInTheWeek == 4)
                {
                    four.BackColor = active;
                    four.ForeColor = Color.White;
                }
                else if (dayInTheWeek == 5)
                {
                    five.BackColor = active;
                    five.ForeColor = Color.White;
                }
                else if (dayInTheWeek == 6)
                {
                    six.BackColor = active;
                    six.ForeColor = Color.White;
                }
                else if (dayInTheWeek == 7)
                {
                    seven.BackColor = active;
                    seven.ForeColor = Color.White;
                }



                //Create first mission if the user is first time user
                using (SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                {

                    // Get today's date & date to check
                    DateTime td = DateTime.Now;
                    td = td.Date;

                    //If a day is passed, create a new day -> With 4 Missions 
                    Debug.WriteLine("TD = " + td);
                    Debug.WriteLine("User's NOW = " + userdateNow);

                    if (td > userdateNow)
                    {

                        //Update User datenow
                        resetADay(td, userID);

                        //Day
                        SqlConnection conn4;
                        string str4 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                        conn4 = new SqlConnection(str4);

                        conn4.Open();

                        string insertNewDay = "INSERT INTO Day (DayNo, UserID) VALUES (@dayNo, @userID)";
                        SqlCommand cmdDay = new SqlCommand(insertNewDay, conn4);
                        cmdDay.Parameters.AddWithValue("@dayNo", Math.Round(difference.TotalDays + 1));
                        cmdDay.Parameters.AddWithValue("@userID", userID);

                        int successful = cmdDay.ExecuteNonQuery();

                        conn4.Close();

                        if (successful > 0)
                        {


                            //Get Day ID
                            //Get today's dayID
                            SqlConnection conn5;
                            string str5 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                            conn5 = new SqlConnection(str5);

                            conn5.Open();

                            string cmdFindDayQuery = "SELECT DayID FROM Day WHERE DayNo = @dayNo AND UserID = @userID";
                            SqlCommand cmdFindDay = new SqlCommand(cmdFindDayQuery, conn5);
                            cmdFindDay.Parameters.AddWithValue("@dayNo", Math.Round(difference.TotalDays + 1));
                            cmdFindDay.Parameters.AddWithValue("@userID", userID);

                            int dayID = Convert.ToInt32(cmdFindDay.ExecuteScalar());

                            conn5.Close();

                            //Missions
                            using (SqlConnection conn3 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                            {
                                conn3.Open();

                                string cmdInsert1 = "INSERT INTO Mission (MissionType, MissionComplete, DayID, UserID) VALUES (@mt, @mc, @dayID, @userID)";
                                SqlCommand c1 = new SqlCommand(cmdInsert1, conn3);
                                c1.Parameters.AddWithValue("@mt", "run");
                                c1.Parameters.AddWithValue("@mc", 0);
                                c1.Parameters.AddWithValue("@dayID", dayID);
                                c1.Parameters.AddWithValue("@userID", userID);

                                string cmdInsert2 = "INSERT INTO Mission (MissionType, MissionComplete, DayID, UserID) VALUES (@mt, @mc, @dayID, @userID)";
                                SqlCommand c2 = new SqlCommand(cmdInsert2, conn3);
                                c2.Parameters.AddWithValue("@mt", "medi");
                                c2.Parameters.AddWithValue("@mc", 0);
                                c2.Parameters.AddWithValue("@dayID", dayID);
                                c2.Parameters.AddWithValue("@userID", userID);

                                string cmdInsert3 = "INSERT INTO Mission (MissionType, MissionComplete, DayID, UserID) VALUES (@mt, @mc, @dayID, @userID)";
                                SqlCommand c3 = new SqlCommand(cmdInsert3, conn3);
                                c3.Parameters.AddWithValue("@mt", "water");
                                c3.Parameters.AddWithValue("@mc", 0);
                                c3.Parameters.AddWithValue("@dayID", dayID);
                                c3.Parameters.AddWithValue("@userID", userID);

                                string cmdInsert4 = "INSERT INTO Mission (MissionType, MissionComplete, DayID, UserID) VALUES (@mt, @mc, @dayID, @userID)";
                                SqlCommand c4 = new SqlCommand(cmdInsert4, conn3);
                                c4.Parameters.AddWithValue("@mt", "all");
                                c4.Parameters.AddWithValue("@mc", 0);
                                c4.Parameters.AddWithValue("@dayID", dayID);
                                c4.Parameters.AddWithValue("@userID", userID);

                                c1.ExecuteNonQuery();
                                c2.ExecuteNonQuery();
                                c3.ExecuteNonQuery();
                                c4.ExecuteNonQuery();

                                conn3.Close();
                            }
                        }



                    }
                }


                //Missions Style Update
                //RUN
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                {

                    //Get Day ID
                    //Get today's dayID
                    SqlConnection conn5;
                    string str5 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                    conn5 = new SqlConnection(str5);

                    conn5.Open();

                    string cmdFindDayQuery = "SELECT DayID FROM Day WHERE DayNo = @dayNo AND UserID = @userID";
                    SqlCommand cmdFindDay = new SqlCommand(cmdFindDayQuery, conn5);
                    cmdFindDay.Parameters.AddWithValue("@dayNo", Math.Round(difference.TotalDays + 1));
                    cmdFindDay.Parameters.AddWithValue("@userID", userID);

                    int dayD = Convert.ToInt32(cmdFindDay.ExecuteScalar());

                    conn5.Close();

                    con.Open();

                    string query = "SELECT * FROM Mission WHERE DayID = @dayID AND UserID = @userID AND MissionType = 'run'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@dayID", dayD);
                    cmd.Parameters.AddWithValue("@userID", userID);

                    SqlDataReader re = cmd.ExecuteReader();

                    while (re.Read())
                    {
                        if (Convert.ToBoolean(re["MissionComplete"]) == true)
                        {
                            completedMisionCount++;
                            Debug.WriteLine("RUN COMPLETED");
                            m1.Style.Add("opacity", "0.2");
                            runDone.Enabled = false;
                            runDone.OnClientClick = "return false;";
                            runDone.Style.Add("cursor", "default");
                        }
                        else
                        {
                            m1.Style.Add("opacity", "1.0");
                            runDone.Enabled = true;
                            runDone.OnClientClick = "return confirm('Are you sure you have done?');";
                            runDone.Style.Add("cursor", "pointer");
                        }
                    }

                    con.Close();
                }

                //MEDI
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                {
                    //Get Day ID
                    //Get today's dayID
                    SqlConnection conn5;
                    string str5 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                    conn5 = new SqlConnection(str5);

                    conn5.Open();

                    string cmdFindDayQuery = "SELECT DayID FROM Day WHERE DayNo = @dayNo AND UserID = @userID";
                    SqlCommand cmdFindDay = new SqlCommand(cmdFindDayQuery, conn5);
                    cmdFindDay.Parameters.AddWithValue("@dayNo", Math.Round(difference.TotalDays + 1));
                    cmdFindDay.Parameters.AddWithValue("@userID", userID);

                    int dayD = Convert.ToInt32(cmdFindDay.ExecuteScalar());

                    conn5.Close();

                    con.Open();

                    string query = "SELECT * FROM Mission WHERE DayID = @dayID AND UserID = @userID AND MissionType = 'medi'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@dayID", dayD);
                    cmd.Parameters.AddWithValue("@userID", userID);

                    SqlDataReader re = cmd.ExecuteReader();

                    while (re.Read())
                    {
                        if (Convert.ToBoolean(re["MissionComplete"]) == true)
                        {
                            completedMisionCount++;
                            Debug.WriteLine("MEDI COMPLETED");
                            m3.Style.Add("opacity", "0.2");
                            mediDone.Enabled = false;
                            mediDone.OnClientClick = "return false;";
                            mediDone.Style.Add("cursor", "default");
                        }
                        else
                        {
                            m3.Style.Add("opacity", "1.0");
                            mediDone.Enabled = true;
                            mediDone.OnClientClick = "return confirm('Are you sure you have done?');";
                            mediDone.Style.Add("cursor", "pointer");
                        }
                    }

                    con.Close();
                }


                //Water 
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                {
                    //Get Day ID
                    //Get today's dayID
                    SqlConnection conn5;
                    string str5 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                    conn5 = new SqlConnection(str5);

                    conn5.Open();

                    string cmdFindDayQuery = "SELECT DayID FROM Day WHERE DayNo = @dayNo AND UserID = @userID";
                    SqlCommand cmdFindDay = new SqlCommand(cmdFindDayQuery, conn5);
                    cmdFindDay.Parameters.AddWithValue("@dayNo", Math.Round(difference.TotalDays + 1));
                    cmdFindDay.Parameters.AddWithValue("@userID", userID);

                    int dayD = Convert.ToInt32(cmdFindDay.ExecuteScalar());

                    conn5.Close();

                    con.Open();

                    string query = "SELECT * FROM Mission WHERE DayID = @dayID AND UserID = @userID AND MissionType = 'water'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@dayID", dayD);
                    cmd.Parameters.AddWithValue("@userID", userID);

                    SqlDataReader re = cmd.ExecuteReader();

                    while (re.Read())
                    {
                        if (Convert.ToBoolean(re["MissionComplete"]) == true)
                        {
                            completedMisionCount++;
                            Debug.WriteLine("WATER COMPLETED");
                            m2.Style.Add("opacity", "0.2");
                        }
                        else
                        {
                            m2.Style.Add("opacity", "1.0");
                        }
                    }

                    con.Close();
                }


                //All Mission Complete
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                {
                    //Get Day ID
                    //Get today's dayID
                    SqlConnection conn5;
                    string str5 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                    conn5 = new SqlConnection(str5);

                    conn5.Open();

                    string cmdFindDayQuery = "SELECT DayID FROM Day WHERE DayNo = @dayNo AND UserID = @userID";
                    SqlCommand cmdFindDay = new SqlCommand(cmdFindDayQuery, conn5);
                    cmdFindDay.Parameters.AddWithValue("@dayNo", Math.Round(difference.TotalDays + 1));
                    cmdFindDay.Parameters.AddWithValue("@userID", userID);

                    int dayD = Convert.ToInt32(cmdFindDay.ExecuteScalar());

                    conn5.Close();

                    con.Open();

                    string query = "SELECT * FROM Mission WHERE DayID = @dayID AND UserID = @userID AND MissionType = 'all'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@dayID", dayD);
                    cmd.Parameters.AddWithValue("@userID", userID);

                    SqlDataReader re = cmd.ExecuteReader();

                    while (re.Read())
                    {
                        if (Convert.ToBoolean(re["MissionComplete"]) == true)
                        {
                            Debug.WriteLine("ALL COMPLETED");
                            m4.Style.Add("opacity", "0.2");

                        }
                        else
                        {
                            m4.Style.Add("opacity", "1.0");
                        }
                    }

                    con.Close();
                }




                //Calories Display -> Need to calculate BMI for suggested calories consumption
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                {
                    //Get Day ID
                    //Get today's dayID
                    SqlConnection conn5;
                    string str5 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                    conn5 = new SqlConnection(str5);

                    conn5.Open();

                    string cmdFindDayQuery = "SELECT DayID FROM Day WHERE DayNo = @dayNo AND UserID = @userID";
                    SqlCommand cmdFindDay = new SqlCommand(cmdFindDayQuery, conn5);
                    cmdFindDay.Parameters.AddWithValue("@dayNo", Math.Round(difference.TotalDays + 1));
                    cmdFindDay.Parameters.AddWithValue("@userID", userID);

                    int dayD = Convert.ToInt32(cmdFindDay.ExecuteScalar());

                    conn5.Close();


                    con.Open();

                    string query = "SELECT SUM(Calories) FROM BodyMetric b, Day d WHERE b.DayID = d.DayID AND b.DayID = @dayID AND d.UserID = @userID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@dayID", dayD);
                    cmd.Parameters.AddWithValue("@userID", userID);

                    double calories;
                    if (string.IsNullOrEmpty(cmd.ExecuteScalar().ToString()))
                    {
                        calories = 0;
                    }
                    else
                    {
                        calories = Convert.ToDouble(cmd.ExecuteScalar());
                    }
                    caloriesValue.Text = calories.ToString();

                    con.Close();


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
                        } else if(gender == "F")
                        {
                            bmr = 10 * weight + 6.25 * height - 5 * age - 161;
                        }


                        //Type Value - Activity
                        double typeValue = 0;
                        Debug.WriteLine("Activity = " + activity);
                        if (activity == "Sedentary")
                        {
                            typeValue = 1.2;
                        } else if (activity == "Lightly")
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

                        if (calories > suggestedCalories)
                        {
                            caloriesValue.ForeColor = Color.Red;
                        } else if (calories > warning && calories <= suggestedCalories)
                        {
                            caloriesValue.ForeColor = Color.Gold;
                        } else
                        {
                            caloriesValue.ForeColor = Color.LightGreen;
                        }

                        con2.Close();
                    }
                }



            }

            //Display how many mission completed currenly
            completedMission.Text = completedMisionCount.ToString();
        }


        protected void runDone_Click(object sender, EventArgs e)
        {

            int userID = Convert.ToInt32(Session["UserID"]);
            // userID = 1; //For Testing Purpose.


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

            SqlConnection conn5;
            string str5 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn5 = new SqlConnection(str5);

            conn5.Open();

            string cmdFindDayQuery = "SELECT DayID FROM Day WHERE DayNo = @dayNo AND UserID = @userID";
            SqlCommand cmdFindDay = new SqlCommand(cmdFindDayQuery, conn5);
            cmdFindDay.Parameters.AddWithValue("@dayNo", Math.Round(difference.TotalDays + 1));
            cmdFindDay.Parameters.AddWithValue("@userID", userID);


            int dayID = Convert.ToInt32(cmdFindDay.ExecuteScalar());

            conn5.Close();


            //Update to complete
            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();

            string retrieve = "UPDATE Mission SET MissionComplete = 1 WHERE DayID = @dayID AND UserID = @userID AND MissionType = 'run'";

            SqlCommand cmd = new SqlCommand(retrieve, conn);
            cmd.Parameters.AddWithValue("@dayID", dayID);
            cmd.Parameters.AddWithValue("@userID", userID);

            cmd.ExecuteNonQuery();



            //Then we need to award user coin ->
            //STEP1 : GET User Current Coin Amount
            //Get coin amount owned
            int coin;

            SqlConnection conn2;
            string str2 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn2 = new SqlConnection(str2);

            conn2.Open();

            string query2 = "SELECT CoinOwned FROM [User] WHERE UserID = @uid";  //0 = not equipped
            SqlCommand cmd2 = new SqlCommand(query2, conn2);
            cmd2.Parameters.AddWithValue("@uid", userID);

            coin = Convert.ToInt32(cmd2.ExecuteScalar());

            conn2.Close();


            //Step 2 : Calculate new coin amount
            int newCoin = coin + 100; //<- run gain 100 Coin


            //Step 3 : Update Coin Amount
            SqlConnection conn3;
            string str3 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn3 = new SqlConnection(str3);

            conn3.Open();

            string retrieve3 = "UPDATE [User] SET CoinOwned = @coinAmt WHERE UserID = @userID";
            SqlCommand cmd3 = new SqlCommand(retrieve3, conn3);
            cmd3.Parameters.AddWithValue("@coinAmt", newCoin);
            cmd3.Parameters.AddWithValue("@userID", userID);

            cmd3.ExecuteNonQuery();


            conn3.Close();









            //Here we need to check for other mission, whether is completed or not -> FOR ALL MISSION COMPLETE COUNTING
            using (SqlConnection conn8 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
            {
                conn8.Open();
                using (SqlCommand cmd8 = new SqlCommand("SELECT MissionComplete FROM Mission WHERE DayID = @dayID AND UserID = @userID AND (MissionType = 'run' OR MissionType = 'medi' OR MissionType = 'water')", conn8))
                {
                    Debug.WriteLine("Entered READER FOR ALL CMPLTE => DAY ID = " + dayID);
                    Debug.WriteLine("Entered READER FOR ALL CMPLTE => DAY ID = " + userID);
                    cmd8.Parameters.AddWithValue("@dayID", dayID);
                    cmd8.Parameters.AddWithValue("@userID", userID);

                    SqlDataReader rdrAll = cmd8.ExecuteReader();

                    bool allComplete = true;


                    while (rdrAll.Read())
                    {
                        Debug.WriteLine("Entered READER FOR ALL CMPLTE");
                        Debug.WriteLine("ALL COMPLETE SIGNAL  = " + allComplete + " / " + rdrAll["MissionComplete"].ToString());
                        if (Convert.ToBoolean(rdrAll["MissionComplete"]) == false)
                        {
                            allComplete = false;
                            break;
                        }
                    }

                    if (allComplete == true)
                    {
                        //Update to complete
                        SqlConnection conn9;
                        string str9 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                        conn9 = new SqlConnection(str9);

                        conn9.Open();

                        string retrieve9 = "UPDATE Mission SET MissionComplete = 1 WHERE DayID = @dayID AND UserID = @userID AND MissionType = 'all'";

                        SqlCommand cmd9 = new SqlCommand(retrieve9, conn9);
                        cmd9.Parameters.AddWithValue("@dayID", dayID);
                        cmd9.Parameters.AddWithValue("@userID", userID);

                        cmd9.ExecuteNonQuery();

                        conn9.Close();




                        //Then we need to award user coin ->
                        //STEP1 : GET User Current Coin Amount
                        //Get coin amount owned
                        int coinAll;

                        SqlConnection conn11;
                        string str11 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                        conn11 = new SqlConnection(str11);

                        conn11.Open();

                        string query11 = "SELECT CoinOwned FROM [User] WHERE UserID = @uid";  //0 = not equipped
                        SqlCommand cmd11 = new SqlCommand(query11, conn11);
                        cmd11.Parameters.AddWithValue("@uid", userID);

                        coinAll = Convert.ToInt32(cmd11.ExecuteScalar());

                        conn11.Close();


                        //Step 2 : Calculate new coin amount
                        int newCoinAll = coinAll + 200; //<- run gain 100 Coin


                        //Step 3 : Update Coin Amount
                        SqlConnection conn12;
                        string str12 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                        conn12 = new SqlConnection(str12);

                        conn12.Open();

                        string retrieve12 = "UPDATE [User] SET CoinOwned = @coinAmt WHERE UserID = @userID";
                        SqlCommand cmd12 = new SqlCommand(retrieve12, conn12);
                        cmd12.Parameters.AddWithValue("@coinAmt", newCoinAll);
                        cmd12.Parameters.AddWithValue("@userID", userID);

                        cmd12.ExecuteNonQuery();

                        conn12.Close();



                    }
                }
                conn8.Close();
            }











            Response.Redirect("~/Dashboard/Dashboard.aspx");
        }



        protected void mediDone_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(Session["UserID"]);
            //int userID = 1; //For Testing Purpose.


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

            SqlConnection conn5;
            string str5 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn5 = new SqlConnection(str5);

            conn5.Open();

            string cmdFindDayQuery = "SELECT DayID FROM Day WHERE DayNo = @dayNo AND UserID = @userID";
            SqlCommand cmdFindDay = new SqlCommand(cmdFindDayQuery, conn5);
            cmdFindDay.Parameters.AddWithValue("@dayNo", Math.Round(difference.TotalDays + 1));
            cmdFindDay.Parameters.AddWithValue("@userID", userID);

            int dayID = Convert.ToInt32(cmdFindDay.ExecuteScalar());

            conn5.Close();


            //Update to complete
            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();

            string retrieve = "UPDATE Mission SET MissionComplete = 1 WHERE DayID = @dayID AND UserID = @userID AND MissionType = 'medi'";

            SqlCommand cmd = new SqlCommand(retrieve, conn);
            cmd.Parameters.AddWithValue("@dayID", dayID);
            cmd.Parameters.AddWithValue("@userID", userID);

            cmd.ExecuteNonQuery();



            //Then we need to award user coin ->
            //STEP1 : GET User Current Coin Amount
            //Get coin amount owned
            int coin;

            SqlConnection conn2;
            string str2 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn2 = new SqlConnection(str2);

            conn2.Open();

            string query2 = "SELECT CoinOwned FROM [User] WHERE UserID = @uid";  //0 = not equipped
            SqlCommand cmd2 = new SqlCommand(query2, conn2);
            cmd2.Parameters.AddWithValue("@uid", userID);

            coin = Convert.ToInt32(cmd2.ExecuteScalar());

            conn2.Close();


            //Step 2 : Calculate new coin amount
            int newCoin = coin + 50; //<- run gain 100 Coin


            //Step 3 : Update Coin Amount
            SqlConnection conn3;
            string str3 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn3 = new SqlConnection(str3);

            conn3.Open();

            string retrieve3 = "UPDATE [User] SET CoinOwned = @coinAmt WHERE UserID = @userID";
            SqlCommand cmd3 = new SqlCommand(retrieve3, conn3);
            cmd3.Parameters.AddWithValue("@coinAmt", newCoin);
            cmd3.Parameters.AddWithValue("@userID", userID);

            cmd3.ExecuteNonQuery();

            conn3.Close();






            //Here we need to check for other mission, whether is completed or not -> FOR ALL MISSION COMPLETE COUNTING
            using (SqlConnection conn8 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
            {
                conn8.Open();
                using (SqlCommand cmd8 = new SqlCommand("SELECT MissionComplete FROM Mission WHERE DayID = @dayID AND UserID = @userID AND (MissionType = 'run' OR MissionType = 'medi' OR MissionType = 'water')", conn8))
                {

                    cmd8.Parameters.AddWithValue("@dayID", dayID);
                    cmd8.Parameters.AddWithValue("@userID", userID);

                    SqlDataReader reader = cmd8.ExecuteReader();


                    bool allComplete = true;


                    while (reader.Read())
                    {
                        if (Convert.ToBoolean(reader["MissionComplete"]) == false)
                        {
                            allComplete = false;
                            break;
                        }
                        Debug.WriteLine("ALL COMPLETE SIGNAL  = " + allComplete);
                    }

                    if (allComplete == true)
                    {
                        //Update to complete
                        SqlConnection conn9;
                        string str9 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                        conn9 = new SqlConnection(str9);

                        conn9.Open();

                        string retrieve9 = "UPDATE Mission SET MissionComplete = 1 WHERE DayID = @dayID AND UserID = @userID AND MissionType = 'all'";

                        SqlCommand cmd9 = new SqlCommand(retrieve9, conn9);
                        cmd9.Parameters.AddWithValue("@dayID", dayID);
                        cmd9.Parameters.AddWithValue("@userID", userID);

                        cmd9.ExecuteNonQuery();

                        conn9.Close();





                        //Then we need to award user coin ->
                        //STEP1 : GET User Current Coin Amount
                        //Get coin amount owned
                        int coinAll;

                        SqlConnection conn11;
                        string str11 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                        conn11 = new SqlConnection(str11);

                        conn11.Open();

                        string query11 = "SELECT CoinOwned FROM [User] WHERE UserID = @uid";  //0 = not equipped
                        SqlCommand cmd11 = new SqlCommand(query11, conn11);
                        cmd11.Parameters.AddWithValue("@uid", userID);

                        coinAll = Convert.ToInt32(cmd11.ExecuteScalar());

                        conn11.Close();


                        //Step 2 : Calculate new coin amount
                        int newCoinAll = coinAll + 200; //<- run gain 100 Coin


                        //Step 3 : Update Coin Amount
                        SqlConnection conn12;
                        string str12 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                        conn12 = new SqlConnection(str12);

                        conn12.Open();

                        string retrieve12 = "UPDATE [User] SET CoinOwned = @coinAmt WHERE UserID = @userID";
                        SqlCommand cmd12 = new SqlCommand(retrieve12, conn12);
                        cmd12.Parameters.AddWithValue("@coinAmt", newCoinAll);
                        cmd12.Parameters.AddWithValue("@userID", userID);

                        cmd12.ExecuteNonQuery();

                        conn12.Close();




                    }
                }
                conn8.Close();
            }






            Response.Redirect("~/Dashboard/Dashboard.aspx");
        }


        protected void resetADay(DateTime td, int userID)
        {
            SqlConnection conn6;
            string str6 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn6 = new SqlConnection(str6);

            conn6.Open();

            string q = "UPDATE [User] SET DateNow = @newDateNow WHERE UserID = @userID";
            SqlCommand qc = new SqlCommand(q, conn6);
            qc.Parameters.AddWithValue("@newDateNow", td);
            qc.Parameters.AddWithValue("@userID", userID);

            qc.ExecuteNonQuery();

            conn6.Close();
        }

        protected void lbnClear_Click(object sender, EventArgs e)
        {
            txtHeight.Text = "";
            txtWeight.Text = "";
            txtCarbo.Text = "";
            txtHeartRate.Text = "";
            txtWater.Text = "";
            txtExercise.Text = "";
        }

        protected void lbnSubmit_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(Session["UserID"]);
            //int userID = 1; //For Testing Purpose.




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

            SqlConnection conn5;
            string str5 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn5 = new SqlConnection(str5);

            conn5.Open();

            string cmdFindDayQuery = "SELECT DayID FROM Day WHERE DayNo = @dayNo AND UserID = @userID";
            SqlCommand cmdFindDay = new SqlCommand(cmdFindDayQuery, conn5);
            cmdFindDay.Parameters.AddWithValue("@dayNo", Math.Round(difference.TotalDays + 1));
            cmdFindDay.Parameters.AddWithValue("@userID", userID);

            int dayID = Convert.ToInt32(cmdFindDay.ExecuteScalar());

            conn5.Close();



            //Get metrics
            double weight;
            int height;
            double carbo;
            double heart;
            int water;
            int exercise;


            //Default Values
            if (string.IsNullOrEmpty(txtWeight.Text))
            {
                weight = 0;
            }
            else
            {
                weight = Convert.ToDouble(txtWeight.Text);
            }

            if (string.IsNullOrEmpty(txtHeight.Text))
            {
                height = 0;
            }
            else
            {
                height = Convert.ToInt32(txtHeight.Text);
            }

            if (string.IsNullOrEmpty(txtCarbo.Text))
            {
                carbo = 0;
            }
            else
            {
                carbo = Convert.ToDouble(txtCarbo.Text);
            }

            if (string.IsNullOrEmpty(txtHeartRate.Text))
            {
                heart = 0;
            }
            else
            {
                heart = Convert.ToDouble(txtHeartRate.Text);
            }

            if (string.IsNullOrEmpty(txtWater.Text))
            {
                water = 0;
            }
            else
            {
                water = Convert.ToInt32(txtWater.Text);
            }

            if (string.IsNullOrEmpty(txtExercise.Text))
            {
                exercise = 0;
            }
            else
            {
                exercise = Convert.ToInt32(txtExercise.Text);
            }


            if (height == 0 && weight == 0 && carbo == 0 && heart == 0 && water == 0 && exercise == 0)
            {
                atleastOne.Visible = true;
                atleastOne.Text = "Warning: Please enter at least one input field.";
            }
            else
            {
                atleastOne.Visible = false;
                //Insert Queries
                using (SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                {
                    conn2.Open();
                    using (SqlCommand cmd2 = new SqlCommand("INSERT INTO BodyMetric (Weight, Height, Carbo, HeartRate, Water, Exercised, DayID) VALUES (@weight, @height, @carbo, @heart, @water, @exercised, @dayID)", conn2))
                    {
                        cmd2.Parameters.AddWithValue("@weight", weight);
                        cmd2.Parameters.AddWithValue("@height", height);
                        cmd2.Parameters.AddWithValue("@carbo", carbo);
                        cmd2.Parameters.AddWithValue("@heart", heart);
                        cmd2.Parameters.AddWithValue("@water", water);
                        cmd2.Parameters.AddWithValue("@exercised", exercise);
                        cmd2.Parameters.AddWithValue("@dayID", dayID);

                        int n = cmd2.ExecuteNonQuery();

                        if (n > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "insertSuccessful();", true);
                            txtHeight.Text = "";
                            txtWeight.Text = "";
                            txtCarbo.Text = "";
                            txtHeartRate.Text = "";
                            txtWater.Text = "";
                            txtExercise.Text = "";
                        }
                    }
                    conn2.Close();
                }


                //Update weight and height
                //weight
                if (weight != 0)
                {
                    using (SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                    {
                        con1.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE [User] SET Weight = @newWeight WHERE UserID = @uid", con1))
                        {
                            cmd.Parameters.AddWithValue("@newWeight", weight);
                            cmd.Parameters.AddWithValue("@uid", userID);

                            cmd.ExecuteNonQuery();
                        }
                        con1.Close();
                    }
                }


                //height
                if (height != 0)
                {
                    using (SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                    {
                        con2.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE [User] SET Height = @newHeight WHERE UserID = @uid", con2))
                        {
                            cmd.Parameters.AddWithValue("@newHeight", height);
                            cmd.Parameters.AddWithValue("@uid", userID);

                            cmd.ExecuteNonQuery();
                        }
                        con2.Close();
                    }
                }




                //Here is section for water detection
                if (water != 0)
                {

                    //We need to do checking if the water is done or not
                    using (SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                    {
                        con2.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT MissionComplete FROM Mission WHERE DayID = @dayID AND UserID = @userID AND MissionType = 'water'", con2))
                        {
                            cmd.Parameters.AddWithValue("@dayID", dayID);
                            cmd.Parameters.AddWithValue("@userID", userID);

                            bool complete = Convert.ToBoolean(cmd.ExecuteScalar());

                            con2.Close();

                            if (complete == false)
                            {
                                using (SqlConnection waterCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                                {

                                    //Actual Processing
                                    waterCon.Open();
                                    using (SqlCommand waterCmd = new SqlCommand("SELECT SUM(Water) FROM BodyMetric b, Day d WHERE b.DayID = d.DayID AND b.DayID = @dayID AND d.UserID = @userID", waterCon))
                                    {
                                        waterCmd.Parameters.AddWithValue("@dayID", dayID);
                                        waterCmd.Parameters.AddWithValue("@userID", userID);
                                        double waterConsumed;
                                        if (string.IsNullOrEmpty(waterCmd.ExecuteScalar().ToString()))
                                        {
                                            waterConsumed = 0;
                                        }
                                        else
                                        {
                                            waterConsumed = Convert.ToDouble(waterCmd.ExecuteScalar());
                                        }
                                        waterCon.Close();

                                        if (waterConsumed >= 2000)
                                        {


                                            //Update Coin
                                            //STEP1 : GET User Current Coin Amount
                                            //Get coin amount owned
                                            int coin;

                                            SqlConnection conn2;
                                            string str2 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                                            conn2 = new SqlConnection(str2);

                                            conn2.Open();

                                            string query2 = "SELECT CoinOwned FROM [User] WHERE UserID = @uid";  //0 = not equipped
                                            SqlCommand cmd2 = new SqlCommand(query2, conn2);
                                            cmd2.Parameters.AddWithValue("@uid", userID);

                                            coin = Convert.ToInt32(cmd2.ExecuteScalar());

                                            conn2.Close();


                                            //Step 2 : Calculate new coin amount
                                            int newCoin = coin + 150; //<- run gain 100 Coin


                                            //Step 3 : Update Coin Amount
                                            SqlConnection conn3;
                                            string str3 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                                            conn3 = new SqlConnection(str3);

                                            conn3.Open();

                                            string retrieve3 = "UPDATE [User] SET CoinOwned = @coinAmt WHERE UserID = @userID";
                                            SqlCommand cmd3 = new SqlCommand(retrieve3, conn3);
                                            cmd3.Parameters.AddWithValue("@coinAmt", newCoin);
                                            cmd3.Parameters.AddWithValue("@userID", userID);

                                            int n = cmd3.ExecuteNonQuery();

                                            conn3.Close();



                                            //Next, update the status of complete to true
                                            SqlConnection conn8;
                                            string str8 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                                            conn8 = new SqlConnection(str8);

                                            conn8.Open();

                                            string retrieve8 = "UPDATE Mission SET MissionComplete = 1 WHERE DayID = @dayID AND UserID = @userID AND MissionType = 'water'";

                                            SqlCommand cmd8 = new SqlCommand(retrieve8, conn8);
                                            cmd8.Parameters.AddWithValue("@dayID", dayID);
                                            cmd8.Parameters.AddWithValue("@userID", userID);

                                            cmd8.ExecuteNonQuery();

                                            conn8.Close();






                                            //Here we need to check for other mission, whether is completed or not -> FOR ALL MISSION COMPLETE COUNTING
                                            using (SqlConnection conn10 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                                            {
                                                conn10.Open();
                                                using (SqlCommand cmd10 = new SqlCommand("SELECT MissionComplete FROM Mission WHERE DayID = @dayID AND UserID = @userID AND (MissionType = 'run' OR MissionType = 'medi' OR MissionType = 'water')", conn10))
                                                {

                                                    cmd10.Parameters.AddWithValue("@dayID", dayID);
                                                    cmd10.Parameters.AddWithValue("@userID", userID);

                                                    SqlDataReader reader = cmd10.ExecuteReader();

                                                    bool allComplete = true;


                                                    while (reader.Read())
                                                    {
                                                        if (Convert.ToBoolean(reader["MissionComplete"]) == false)
                                                        {
                                                            allComplete = false;
                                                            break;
                                                        }
                                                        Debug.WriteLine("ALL COMPLETE SIGNAL  = " + allComplete);
                                                    }

                                                    if (allComplete == true)
                                                    {
                                                        //Update to complete
                                                        SqlConnection conn9;
                                                        string str9 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                                                        conn9 = new SqlConnection(str9);

                                                        conn9.Open();

                                                        string retrieve9 = "UPDATE Mission SET MissionComplete = 1 WHERE DayID = @dayID AND UserID = @userID AND MissionType = 'all'";

                                                        SqlCommand cmd9 = new SqlCommand(retrieve9, conn9);
                                                        cmd9.Parameters.AddWithValue("@dayID", dayID);
                                                        cmd9.Parameters.AddWithValue("@userID", userID);

                                                        cmd9.ExecuteNonQuery();

                                                        conn9.Close();



                                                        //Then we need to award user coin ->
                                                        //STEP1 : GET User Current Coin Amount
                                                        //Get coin amount owned
                                                        int coinAll;

                                                        SqlConnection conn11;
                                                        string str11 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                                                        conn11 = new SqlConnection(str11);

                                                        conn11.Open();

                                                        string query11 = "SELECT CoinOwned FROM [User] WHERE UserID = @uid";  //0 = not equipped
                                                        SqlCommand cmd11 = new SqlCommand(query11, conn11);
                                                        cmd11.Parameters.AddWithValue("@uid", userID);

                                                        coinAll = Convert.ToInt32(cmd11.ExecuteScalar());

                                                        conn11.Close();


                                                        //Step 2 : Calculate new coin amount
                                                        int newCoinAll = coinAll + 200; //<- run gain 100 Coin


                                                        //Step 3 : Update Coin Amount
                                                        SqlConnection conn12;
                                                        string str12 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                                                        conn12 = new SqlConnection(str12);

                                                        conn12.Open();

                                                        string retrieve12 = "UPDATE [User] SET CoinOwned = @coinAmt WHERE UserID = @userID";
                                                        SqlCommand cmd12 = new SqlCommand(retrieve12, conn12);
                                                        cmd12.Parameters.AddWithValue("@coinAmt", newCoinAll);
                                                        cmd12.Parameters.AddWithValue("@userID", userID);

                                                        cmd12.ExecuteNonQuery();

                                                        conn12.Close();



                                                    }
                                                }
                                                conn10.Close();

                                            }





                                        }
                                    }


                                }

                            }

                        }
                    }

                }


                Response.Redirect("~/Dashboard/Dashboard.aspx");
            }
        }
    }
}