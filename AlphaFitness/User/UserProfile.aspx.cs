using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaFitness.User
{
    public partial class UserProfile : System.Web.UI.Page
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
                    profileimg.ImageUrl = reader["ProfileImage"].ToString();
                    username.Text = reader["UserName"].ToString();
                    email.Text = reader["Email"].ToString();
                    weight.Text = reader["Weight"].ToString();
                    height.Text = reader["Height"].ToString();

                    DateTime dt = Convert.ToDateTime(reader["DateOfJoin"]);
                    dateJoin.Text = dt.ToString("MMMM, dd yyyy");

                    //
                }
            }
            else
            {
                Response.Redirect("~/User/UserLogin.aspx");
            }
        }
    }
}