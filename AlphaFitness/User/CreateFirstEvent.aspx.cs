using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaFitness.User
{
    public partial class CreateFirstEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string dayIDD = Request.QueryString["dayID"];
                int userID = Convert.ToInt32(Session["UserID"]);
                //int userID = 1; //For Testing Purpose.



                using (SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                {
                    con2.Open();

                    string cmdInsert1 = "INSERT INTO Mission (MissionType, MissionComplete, DayID, UserID) VALUES (@mt, @mc, @dayID, @userID)";
                    SqlCommand c1 = new SqlCommand(cmdInsert1, con2);
                    c1.Parameters.AddWithValue("@mt", "run");
                    c1.Parameters.AddWithValue("@mc", 0);
                    c1.Parameters.AddWithValue("@dayID", dayIDD);
                    c1.Parameters.AddWithValue("@userID", userID);
                    c1.ExecuteNonQuery();

                    string cmdInsert2 = "INSERT INTO Mission (MissionType, MissionComplete, DayID, UserID) VALUES (@mt, @mc, @dayID, @userID)";
                    SqlCommand c2 = new SqlCommand(cmdInsert2, con2);
                    c2.Parameters.AddWithValue("@mt", "medi");
                    c2.Parameters.AddWithValue("@mc", 0);
                    c2.Parameters.AddWithValue("@dayID", dayIDD);
                    c2.Parameters.AddWithValue("@userID", userID);
                    c2.ExecuteNonQuery();

                    string cmdInsert3 = "INSERT INTO Mission (MissionType, MissionComplete, DayID, UserID) VALUES (@mt, @mc, @dayID, @userID)";
                    SqlCommand c3 = new SqlCommand(cmdInsert3, con2);
                    c3.Parameters.AddWithValue("@mt", "water");
                    c3.Parameters.AddWithValue("@mc", 0);
                    c3.Parameters.AddWithValue("@dayID", dayIDD);
                    c3.Parameters.AddWithValue("@userID", userID);
                    c3.ExecuteNonQuery();

                    string cmdInsert4 = "INSERT INTO Mission (MissionType, MissionComplete, DayID, UserID) VALUES (@mt, @mc, @dayID, @userID)";
                    SqlCommand c4 = new SqlCommand(cmdInsert4, con2);
                    c4.Parameters.AddWithValue("@mt", "all");
                    c4.Parameters.AddWithValue("@mc", 0);
                    c4.Parameters.AddWithValue("@dayID", dayIDD);
                    c4.Parameters.AddWithValue("@userID", userID);

                    c4.ExecuteNonQuery();

                    con2.Close();

                }
            }
        }

        protected void done_Click(object sender, EventArgs e)
        {

            string userID = Session["UserID"].ToString();

            int height = Convert.ToInt32(txtHeight.Text);
            double weight = Convert.ToDouble(txtWeight.Text);
            string activity = ddlActive.SelectedValue.ToString();
            int age = Convert.ToInt32(txtAge.Text);
            string gender = ddlGender.SelectedValue.ToString();

            using (SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
            {
                con2.Open();

                string query = "UPDATE [User] SET Weight = @weight, Height = @height, Activity = @active, Age =  @age, Gender = @gender WHERE UserID = @userID";
                SqlCommand cmd = new SqlCommand(query, con2);

                cmd.Parameters.AddWithValue("@weight", weight);
                cmd.Parameters.AddWithValue("@height", height);
                cmd.Parameters.AddWithValue("@active", activity);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@userID", userID);


                int n = cmd.ExecuteNonQuery();

                if (n > 0)
                {
                    Response.Redirect("~/Dashboard/Dashboard.aspx");
                }
            }
        }
    }
}
