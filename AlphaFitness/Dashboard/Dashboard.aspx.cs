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

namespace AlphaFitness.Dashboard
{
    public partial class Dashboard : System.Web.UI.Page
    {
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

                //int userID = Convert.ToInt32(Session["UserID"]);
                int userID = 1; //For Testing Purpose.

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
                int dayInTheWeek = Convert.ToInt32(difference.TotalDays) % 7;
                int weekNum = (Convert.ToInt32(difference.TotalDays) / 7) + 1;

                //Update Day of Login
                lblNumberOfDays.Text = Math.Round(difference.TotalDays).ToString();

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



                //Get Day ID
                //Get today's dayID
                SqlConnection conn5;
                string str5 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                conn5 = new SqlConnection(str5);

                conn5.Open();

                string cmdFindDayQuery = "SELECT DayID FROM Day WHERE DayNo = @dayNo AND UserID = @userID";
                SqlCommand cmdFindDay = new SqlCommand(cmdFindDayQuery, conn5);
                cmdFindDay.Parameters.AddWithValue("@dayNo", Math.Round(difference.TotalDays));
                cmdFindDay.Parameters.AddWithValue("@userID", userID);

                int dayID = Convert.ToInt32(cmdFindDay.ExecuteScalar());

                conn5.Close();



                //Check if user does not have any day -> If yes, add the first day
                using (SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                {
                    conn2.Open();
                    using (SqlCommand cmd2 = new SqlCommand("SELECT Count(*) FROM [Day] WHERE UserID = @userID", conn2))
                    {
                        cmd2.Parameters.AddWithValue("@userID", userID);

                        int n = Convert.ToInt32(cmd2.ExecuteScalar());

                        conn2.Close();

                        if (n == 0) //Means the user is new to this app
                        {
                            using (SqlConnection conn3 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                            {
                                conn3.Open();
                                using (SqlCommand cmd3 = new SqlCommand("INSERT INTO Day (DayNo, UserID) VALUES (1, @userID)", conn3))
                                {
                                    cmd3.Parameters.AddWithValue("@userID", userID);

                                    int inserted = cmd3.ExecuteNonQuery();
                                }
                                conn3.Close();
                            }
                        }
                    }



                    // Get today's date & date to check
                    DateTime td = DateTime.Now;
                    td =  td.Date;

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
                        cmdDay.Parameters.AddWithValue("@dayNo", Math.Round(difference.TotalDays));
                        cmdDay.Parameters.AddWithValue("@userID", userID);

                        int successful = cmdDay.ExecuteNonQuery();

                        conn4.Close();

                        if (successful > 0)
                        {
                            if (dayID != 0)
                            {
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
                }


                //Missions Style Update
                //RUN
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                {
                    con.Open();

                    string query = "SELECT * FROM Mission WHERE DayID = @dayID AND UserID = @userID AND MissionType = 'run'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@dayID", dayID);
                    cmd.Parameters.AddWithValue("@userID", userID);

                    SqlDataReader re = cmd.ExecuteReader();

                    while (re.Read())
                    {
                        if (Convert.ToBoolean(re["MissionComplete"]) == true)
                        {
                            m1.Style.Add("opacity", "0.2");
                            runDone.Enabled = false;
                            runDone.OnClientClick = "return false";
                            runDone.Style.Add("cursor", "default");
                        }
                    }

                    con.Close();
                }

                //MEDI
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                {
                    con.Open();

                    string query = "SELECT * FROM Mission WHERE DayID = @dayID AND UserID = @userID AND MissionType = 'medi'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@dayID", dayID);
                    cmd.Parameters.AddWithValue("@userID", userID);

                    SqlDataReader re = cmd.ExecuteReader();

                    while (re.Read())
                    {
                        if (Convert.ToBoolean(re["MissionComplete"]) == true)
                        {
                            m3.Style.Add("opacity", "0.2");
                            mediDone.Enabled = false;
                            mediDone.OnClientClick = "return false";
                            mediDone.Style.Add("cursor", "default");
                        }
                    }

                    con.Close();
                }



            }
        }


        protected void runDone_Click(object sender, EventArgs e)
        {

            //int userID = Convert.ToInt32(Session["UserID"]);
            int userID = 1; //For Testing Purpose.


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
            int dayInTheWeek = Convert.ToInt32(difference.TotalDays) % 7;
            int weekNum = (Convert.ToInt32(difference.TotalDays) / 7) + 1;

            SqlConnection conn5;
            string str5 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn5 = new SqlConnection(str5);

            conn5.Open();

            string cmdFindDayQuery = "SELECT DayID FROM Day WHERE DayNo = @dayNo AND UserID = @userID";
            SqlCommand cmdFindDay = new SqlCommand(cmdFindDayQuery, conn5);
            cmdFindDay.Parameters.AddWithValue("@dayNo", Math.Round(difference.TotalDays));
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
            Response.Redirect("~/Dashboard/Dashboard.aspx");

            conn3.Close();


            Response.Redirect("~/Dashboard/Dashboard.aspx");
        }



        protected void mediDone_Click(object sender, EventArgs e)
        {
            //int userID = Convert.ToInt32(Session["UserID"]);
            int userID = 1; //For Testing Purpose.


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
            int dayInTheWeek = Convert.ToInt32(difference.TotalDays) % 7;
            int weekNum = (Convert.ToInt32(difference.TotalDays) / 7) + 1;

            SqlConnection conn5;
            string str5 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn5 = new SqlConnection(str5);

            conn5.Open();

            string cmdFindDayQuery = "SELECT DayID FROM Day WHERE DayNo = @dayNo AND UserID = @userID";
            SqlCommand cmdFindDay = new SqlCommand(cmdFindDayQuery, conn5);
            cmdFindDay.Parameters.AddWithValue("@dayNo", Math.Round(difference.TotalDays));
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

    }
}