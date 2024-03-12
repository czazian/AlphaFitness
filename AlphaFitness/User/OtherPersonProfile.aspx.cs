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