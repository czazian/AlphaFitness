using AlphaFitness.Community;
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
    public partial class OtherPersonProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = Request.QueryString["userID"];

            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();

            string query = "SELECT * FROM [User] WHERE [UserID] = @userid";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userid", userid);

            SqlDataReader u = cmd.ExecuteReader();

            if (u.HasRows)
            {
                while (u.Read())
                {
                    profileimg.ImageUrl = u["ProfileImage"].ToString();
                    email.Text = u["Email"].ToString();
                    weight.Text = u["Weight"].ToString();
                    height.Text = u["Height"].ToString();
                    username.Text = u["UserName"].ToString();

                    DateTime dt = Convert.ToDateTime(u["DateOfJoin"]);
                    dateJoin.Text = dt.ToString("MMMM, dd yyyy");

                    //Image4.ImageUrl = user["Email"].ToString();
                }
            }



            //Display the equipped title
            using (SqlConnection conn3 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
            {
                conn3.Open();
                using (SqlCommand cmd3 = new SqlCommand("SELECT i.ItemUrl FROM PurchasedItem p, Item i WHERE p.ItemID = i.ItemID AND p.UserID = @userID AND i.Category = 'Title' AND p.Equipped = 1", conn3))
                {
                    cmd3.Parameters.AddWithValue("@userID", userid);
                    object url = cmd3.ExecuteScalar();

                    if (url != null)
                    {
                        string urlDes = url.ToString();
                        if (!string.IsNullOrEmpty(urlDes))
                        {
                            titltImg.ImageUrl = urlDes;

                        }
                        else
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
                cmd4.Parameters.AddWithValue("@userID", userid);

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

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            string page = Request.QueryString["page"];
            if (page == "post")
            {
                string userID = Request.QueryString["userID"].ToString();
                string postID = Request.QueryString["postID"].ToString();
                Response.Redirect("~/Community/Post.aspx?userID=" + userID + "&postID=" + postID);
            } else
            {
                Response.Redirect("~/Community/Community.aspx");
            }
        }
    }
}