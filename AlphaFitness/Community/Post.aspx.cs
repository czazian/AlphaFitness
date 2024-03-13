using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaFitness.Community
{
    public partial class Post : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string postID = Request.QueryString["postID"].ToString();

            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();

            string query = "SELECT * " +
                "FROM [User] u, Post p " +
                "WHERE u.UserID = p.UserID " +
                "AND p.PostID = @postID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@postID", postID);

            SqlDataReader posts = cmd.ExecuteReader();

            if (posts.HasRows)
            {
                while (posts.Read())
                {
                    lblTitle.Text = posts["PostTitle"].ToString();
                    postedDate.Text = posts["PostTime"].ToString();
                    postedUser.Text = posts["UserName"].ToString();
                    postedUserImage.ImageUrl = posts["ProfileImage"].ToString();
                    comment.Text = posts["PostContent"].ToString();
                }
            }

            conn.Close();






            SqlConnection conn2;
            string str2 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn2 = new SqlConnection(str2);

            conn2.Open();

            string query2 = "SELECT DISTINCT * " +
                "FROM Comment c, Post p, [User] u " +
                "WHERE c.PostID = p.PostID " +
                "AND c.UserID = u.UserID " +
                "AND p.PostID = @postID " +
                "ORDER BY c.CommentTime DESC";
            SqlCommand cmd2 = new SqlCommand(query2, conn2);
            cmd2.Parameters.AddWithValue("@postID", postID);

            SqlDataReader comments = cmd2.ExecuteReader();

            if (comments.HasRows)
            {
                commentRepeater.DataSource = comments;
                commentRepeater.DataBind();
            }

            numOfComments.Text = commentRepeater.Items.Count.ToString();






            //Detect the user who clicks the like button
            //int userID = Convert.ToInt32(Session["UserID"]);
            int userID = 1; //Testing Purpose

            //Check if the same user click the like button
            //Processing
            SqlConnection conn3;
            string str3 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn3 = new SqlConnection(str3);

            conn3.Open();

            string query3 = "SELECT COUNT(*) FROM [LikedPerson] l WHERE l.UserID = @userID AND l.PostID = @postID";
            SqlCommand cmd3 = new SqlCommand(query3, conn3);
            cmd3.Parameters.AddWithValue("@UserID", userID);
            cmd3.Parameters.AddWithValue("@postID", postID);

            int n = Convert.ToInt32(cmd3.ExecuteScalar());

            if (n > 0)
            {
                Debug.WriteLine("N = " + n);
                LikeClick.Text = "<i style=\"color:palevioletred; opacity:1.0;\" class=\"fa-solid fa-heart\"></i>";
            }
            else
            {
                Debug.WriteLine("N = " + n);
                LikeClick.Text = "<i style=\"color:palevioletred; opacity:1.0;\" class=\"fa-regular fa-heart\"></i>";
            }




            //Check if the same user click the like button
            //Processing
            SqlConnection conn4;
            string str4 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn4 = new SqlConnection(str4);

            conn4.Open();

            string query4 = "SELECT COUNT(*) FROM [LikedPerson] WHERE PostID = @postID";
            SqlCommand cmd4 = new SqlCommand(query4, conn4);
            cmd4.Parameters.AddWithValue("@postID", postID);

            int n2 = Convert.ToInt32(cmd4.ExecuteScalar());

            numOfLikes.Text = n2.ToString();

        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            //int userID = Convert.ToInt32(Session["UserID"]);
            int userID = 1; //Testing Purpose

            string postID = Request.QueryString["postID"].ToString();

            DateTime dateTime = DateTime.Now;
            dateTime.ToString("MMMM, dd yyyy - hh:mm tt");

            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();

            string query = "INSERT INTO Comment VALUES (@content, @time, @userID, @postID)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@content", txtWrite.Text);
            cmd.Parameters.AddWithValue("@time", dateTime);
            cmd.Parameters.AddWithValue("@userID", userID.ToString());
            cmd.Parameters.AddWithValue("@postID", postID);

            int i = cmd.ExecuteNonQuery();

            if (i > 0) {
                txtWrite.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "title();", true);
                Response.Redirect("~/Community/Post.aspx?postID=" + postID);
            }
        }





        protected void commenterImg_Command(object sender, CommandEventArgs e)
        {
            string userID = e.CommandArgument.ToString();
            string postID = Request.QueryString["postID"].ToString();
            Response.Redirect("~/User/OtherPersonProfile.aspx?userID=" + userID + "&page=post&postID=" + postID);
        }

        protected void LikeClick_Click(object sender, EventArgs e)
        {
            //Detect the user who clicks the like button
            //int userID = Convert.ToInt32(Session["UserID"]);
            int userID = 1; //Testing Purpose

            string postID = Request.QueryString["postID"].ToString();


            //Check if the same user click the like button
            //Processing
            SqlConnection conn2;
            string str2 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn2 = new SqlConnection(str2);

            conn2.Open();

            string query2 = "SELECT COUNT(*) \r\nFROM [LikedPerson] l\r\nWHERE l.UserID = @userID\r\nAND l.PostID = @postID";
            SqlCommand cmd2 = new SqlCommand(query2, conn2);
            cmd2.Parameters.AddWithValue("@UserID", userID);
            cmd2.Parameters.AddWithValue("@postID", postID);

            int n = Convert.ToInt32(cmd2.ExecuteScalar());

            if (n > 0)
            {
                //Remove Like
                SqlConnection conn;
                string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                conn = new SqlConnection(str);

                conn.Open();

                string query = "DELETE FROM LikedPerson WHERE UserID = @UserID AND PostID = @PostID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@PostID", postID);

                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    Response.Redirect("~/Community/Post.aspx?postID=" + postID);
                }
            }
            else
            {
                //Add Like
                SqlConnection conn;
                string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                conn = new SqlConnection(str);

                conn.Open();

                string query = "INSERT INTO LikedPerson Values (@UserID ,@PostID)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@PostID", postID);

                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    Response.Redirect("~/Community/Post.aspx?postID=" + postID);
                }
            }
        }
    }
}