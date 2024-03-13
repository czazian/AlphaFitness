using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace AlphaFitness.Community
{
    public partial class Community : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();

            string retrieve = "SELECT \r\n    P.*, \r\n    U.*, \r\n    ISNULL(CommentCount.Count, 0) AS CommentCount,\r\n    ISNULL(LikeCount.Count, 0) AS LikeCount,\r\n    ISNULL(LikedUsers.Users, '') AS LikedUsers\r\nFROM   \r\n    [dbo].[Post] P \r\nJOIN    \r\n    [dbo].[User] U ON P.UserID = U.UserID \r\nLEFT JOIN    \r\n    (SELECT         \r\n         [PostID],         \r\n         COUNT(*) AS Count    \r\n     FROM         \r\n         [dbo].[Comment]   \r\n     GROUP BY    \r\n         [PostID]) AS CommentCount ON P.[PostID] = CommentCount.[PostID]\r\nLEFT JOIN    \r\n    (SELECT         \r\n         [PostID],         \r\n         COUNT(*) AS Count    \r\n     FROM         \r\n         [dbo].[LikedPerson]   \r\n     GROUP BY    \r\n         [PostID]) AS LikeCount ON P.[PostID] = LikeCount.[PostID]\r\nLEFT JOIN    \r\n    (SELECT \r\n         [PostID],\r\n         STRING_AGG([UserID], ', ') AS Users\r\n     FROM\r\n         [dbo].[LikedPerson]\r\n     GROUP BY\r\n         [PostID]) AS LikedUsers ON P.[PostID] = LikedUsers.[PostID]\r\nORDER BY \r\n    P.PostTime DESC;\r\n";

            SqlCommand cmd = new SqlCommand(retrieve, conn);

            SqlDataReader posts = cmd.ExecuteReader(); //More than 1 value

            if (posts.HasRows)
            {
                postRepeater.DataSource = posts;
                postRepeater.DataBind();

                //Display values
                numOfPosts.Text = postRepeater.Items.Count.ToString();
                currentTime.Text = DateTime.Now.ToString("MMMM, dd yyyy");
            }

        }





        //Activate when the user submit a post
        protected void submit_Click(object sender, EventArgs e)
        {
            //User who submit the post
            //int userID = Convert.ToInt32(Session["UserID"]);
            int userID = 1; // For Testing Purpose


            //Obtain inputs
            string title = txtTopic.Text;
            string content = txtContent.Text;

            DateTime dateTime = DateTime.Now;
            dateTime.ToString("MMMM, dd yyyy - hh:mm tt");

            //Processing
            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();

            string query = "INSERT INTO Post (PostTitle, PostContent, PostTime, UserID) VALUES (@title, @content, @dateTime, @userID)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@content", content);
            cmd.Parameters.AddWithValue("@dateTime", dateTime);
            cmd.Parameters.AddWithValue("@userID", userID);

            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "title();", true);
                txtTopic.Text = "";
                txtContent.Text = "";
                Response.Redirect("~/Community/Community.aspx");
            }
        }

        protected void ibProfile_Command(object sender, CommandEventArgs e)
        {
            string uid = e.CommandArgument.ToString();
            Response.Redirect("~/User/OtherPersonProfile.aspx?userID=" + uid);
        }

        protected void LikeClick_Command(object sender, CommandEventArgs e)
        {
            //int userID = Convert.ToInt32(Session["UserID"]);
            int userID = 1; // For Testing Purpose
            string postID = e.CommandArgument.ToString();



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
                    Response.Redirect("~/Community/Community.aspx");
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
                    Response.Redirect("~/Community/Community.aspx");
                }
            }

        }


        //CHANGE STYLING FOR LIKE BUTTON
        protected void postRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                LinkButton likeBtn = e.Item.FindControl("LikeClick") as LinkButton; //The Like Button
                HiddenField Post = e.Item.FindControl("hdnID") as HiddenField;  //The PostID 
                string postID = Post.Value;

                //int userID = Convert.ToInt32(Session["UserID"]);
                int userID = 1; // For Testing Purpose


                //Check if the same user click the like button
                //Processing
                SqlConnection conn2;
                string str2 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                conn2 = new SqlConnection(str2);

                conn2.Open();

                string query2 = "SELECT COUNT(*) FROM [LikedPerson] l WHERE l.UserID = @userID AND l.PostID = @postID";
                SqlCommand cmd2 = new SqlCommand(query2, conn2);
                cmd2.Parameters.AddWithValue("@UserID", userID);
                cmd2.Parameters.AddWithValue("@postID", postID);

                int n = Convert.ToInt32(cmd2.ExecuteScalar());

                if (n > 0)
                {
                    Debug.WriteLine("N = "+ n);
                    likeBtn.Text = "<i style=\"color:palevioletred; opacity:1.0;\" class=\"fa-solid fa-heart\"></i>";
                } else
                {
                    Debug.WriteLine("N = " + n);
                    likeBtn.Text = "<i style=\"color:palevioletred; opacity:1.0;\" class=\"fa-regular fa-heart\"></i>";
                }



            }
        }
    }
}