using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
                    numOfLikes.Text = posts["LikedAmount"].ToString();
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
    }
}