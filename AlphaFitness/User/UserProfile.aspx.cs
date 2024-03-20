using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
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




            //Display the equipped title
            using (SqlConnection conn3 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
            {
                conn3.Open();
                using (SqlCommand cmd3 = new SqlCommand("SELECT i.ItemUrl FROM PurchasedItem p, Item i WHERE p.ItemID = i.ItemID AND p.UserID = @userID AND i.Category = 'Title' AND p.Equipped = 1", conn3))
                {
                    cmd3.Parameters.AddWithValue("@userID", userID);
                    object url = cmd3.ExecuteScalar();

                    if(url != null)
                    {
                        string urlDes = url.ToString();
                        if(!string.IsNullOrEmpty(urlDes))
                        {
                            titltImg.ImageUrl = urlDes;
  
                        } else
                        {
                            titltImg.ImageUrl = "~/Image/Title/transparent.png";
                        }
                    }
                }
                conn3.Close();





                SqlConnection conn4;
                string str4 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                conn4 = new SqlConnection(str4);

                conn4.Open();

                string query4 = "SELECT COUNT(*) FROM Item i, PurchasedItem p WHERE i.ItemID = p.ItemID AND i.Category = 'Title' AND p.Equipped = 1 AND UserID = @userID";
                SqlCommand cmd4 = new SqlCommand(query4, conn4);
                cmd4.Parameters.AddWithValue("@userID", userID);

                int num = Convert.ToInt32(cmd4.ExecuteScalar());


                if (num == 0)
                {
                    titltImg.Visible = false;
                }
                else
                {
                    titltImg.Visible = true;
                }

            }
        }
    }
}