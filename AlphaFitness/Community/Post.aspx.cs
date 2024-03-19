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

            int postOwnerUserID = 0;

            if (posts.HasRows)
            {
                while (posts.Read())
                {
                    lblTitle.Text = posts["PostTitle"].ToString();
                    postedDate.Text = posts["PostTime"].ToString();
                    postedUser.Text = posts["UserName"].ToString();
                    postedUserImage.ImageUrl = posts["ProfileImage"].ToString();
                    comment.Text = posts["PostContent"].ToString();
                    postOwnerUserID = Convert.ToInt32(posts["UserID"]);
                }
            }

            conn.Close();







            //Display the equipped title
            using (SqlConnection conn5 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
            {
                conn5.Open();
                using (SqlCommand cmd5 = new SqlCommand("SELECT i.ItemUrl FROM PurchasedItem p, Item i WHERE p.ItemID = i.ItemID AND p.UserID = @userID AND i.Category = 'Title' AND p.Equipped = 1", conn5))
                {
                    cmd5.Parameters.AddWithValue("@userID", postOwnerUserID);
                    object url = cmd5.ExecuteScalar();

                    if (url != null)
                    {
                        string urlDes = url.ToString();
                        if (!string.IsNullOrEmpty(urlDes))
                        {
                            img.ImageUrl = urlDes;

                        }
                        else
                        {
                            img.ImageUrl = "~/Image/Title/transparent.png";
                        }
                    }
                }
                conn5.Close();





                SqlConnection conn6;
                string str6 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                conn6 = new SqlConnection(str6);

                conn6.Open();

                string query6 = "SELECT COUNT(*) FROM Item i, PurchasedItem p WHERE i.ItemID = p.ItemID AND i.Category = 'Title' AND p.Equipped = 1 AND UserID = @userID";
                SqlCommand cmd6 = new SqlCommand(query6, conn6);
                cmd6.Parameters.AddWithValue("@userID", postOwnerUserID);

                int num = Convert.ToInt32(cmd6.ExecuteScalar());


                if (num == 0)
                {
                    img.Visible = false;
                }
                else
                {
                    img.Visible = true;
                }

            }





            //COMMENTS
            SqlConnection conn2;
            string str2 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn2 = new SqlConnection(str2);

            conn2.Open();

            string query2 = "WITH EquippedItems AS (\r\n    SELECT \r\n        u.UserID,\r\n        i.ItemID,\r\n        i.ItemUrl AS EquippedImageUrl,\r\n        ROW_NUMBER() OVER (PARTITION BY u.UserID ORDER BY pi.Equipped DESC) AS RowNum\r\n    FROM \r\n        [User] u\r\n    JOIN \r\n        PurchasedItem pi ON u.UserID = pi.UserID AND pi.Equipped = 1\r\n    JOIN \r\n        Item i ON pi.ItemID = i.ItemID\r\n)\r\nSELECT DISTINCT c.*, p.*, u.*, e.EquippedImageUrl\r\nFROM \r\n    Comment c\r\nJOIN \r\n    Post p ON c.PostID = p.PostID\r\nJOIN \r\n    [User] u ON c.UserID = u.UserID\r\nJOIN \r\n    EquippedItems e ON u.UserID = e.UserID AND e.RowNum = 1\r\nWHERE \r\n    p.PostID = @postID\r\nORDER BY \r\n    c.CommentTime DESC;";
            SqlCommand cmd2 = new SqlCommand(query2, conn2);
            cmd2.Parameters.AddWithValue("@postID", postID);

            SqlDataReader comments = cmd2.ExecuteReader();

            if (comments.HasRows)
            {
                commentRepeater.DataSource = comments;
                commentRepeater.DataBind();
            }

            numOfComments.Text = commentRepeater.Items.Count.ToString();

            conn2.Close();













            //Detect the user who clicks the like button
            int userID = Convert.ToInt32(Session["UserID"]);
            //int userID = 1; //Testing Purpose

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


            conn3.Close();

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

            conn4.Close();






            //Check if the post owner is same as the current login user
            SqlConnection conn1;
            string str1 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn1 = new SqlConnection(str1);

            conn1.Open();

            string query1 = "SELECT UserID FROM Post WHERE PostID = @pid";
            SqlCommand cmd1 = new SqlCommand(query1, conn1);
            cmd1.Parameters.AddWithValue("@pid", postID);

            string uid = cmd1.ExecuteScalar().ToString();

            if (uid == userID.ToString())
            {
                LikeClick.Enabled = false;
            }
            else
            {
                LikeClick.Enabled = true;
            }

            conn1.Close();
        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(Session["UserID"]);
            //int userID = 1; //Testing Purpose

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

            if (i > 0)
            {
                txtWrite.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "title();", true);


                //Then, add Notification to the Post Owner
                //STEP 1 : GET CURRENT USER INFO
                SqlConnection conn5;
                string str5 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                conn5 = new SqlConnection(str5);
                conn5.Open();

                string query5 = "SELECT UserName FROM [User] u WHERE UserID = @UserID";
                SqlCommand cmd5 = new SqlCommand(query5, conn5);
                cmd5.Parameters.AddWithValue("@UserID", userID);

                string cuName = cmd5.ExecuteScalar().ToString();



                //STEP 2 : GET POST OWNER INFO
                SqlConnection conn3;
                string str3 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                conn3 = new SqlConnection(str3);

                conn3.Open();
                string query3 = "SELECT * FROM [User] u, [Post] p WHERE p.UserID = u.UserID AND p.PostID = @PostID";
                SqlCommand cmd3 = new SqlCommand(query3, conn3);
                cmd3.Parameters.AddWithValue("@PostID", postID);

                SqlDataReader reader = cmd3.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string postOwnerID = reader["UserID"].ToString();
                        string postTitle = reader["PostTitle"].ToString();

                        if (postOwnerID != userID.ToString())
                        {

                            //STEP 3 : INSERT INTO THE POST OWNER NOTIFICATION TABLE
                            string message = cuName + " leave a comment to your post, with title \"" + postTitle + "\".";
                            Debug.WriteLine(message);

                            SqlConnection conn4;
                            string str4 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                            conn4 = new SqlConnection(str4);

                            conn4.Open();
                            string query4 = "INSERT INTO Notification (NotificationContent, UserID, PostURL) VALUES (@NotificationContent, @UserID, @PostURL)";
                            SqlCommand cmd4 = new SqlCommand(query4, conn4);
                            cmd4.Parameters.AddWithValue("@NotificationContent", message);
                            cmd4.Parameters.AddWithValue("@UserID", postOwnerID);
                            cmd4.Parameters.AddWithValue("@PostURL", postID);

                            int n2 = cmd4.ExecuteNonQuery();
                        }
                    }
                }
                conn3.Close();
                //END OF NOTIFICATION


                Response.Redirect("~/Community/Post.aspx?postID=" + postID);
            }
            conn.Close();
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
            int userID = Convert.ToInt32(Session["UserID"]);
            //int userID = 1; //Testing Purpose

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

                //Then, add Notification to the Post Owner
                //STEP 1 : GET POST OWNER INFO
                SqlConnection conn3;
                string str3 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                conn3 = new SqlConnection(str3);

                conn3.Open();
                string query3 = "SELECT * FROM [User] u, [Post] p WHERE p.UserID = u.UserID AND p.PostID = @PostID";
                SqlCommand cmd3 = new SqlCommand(query3, conn3);
                cmd3.Parameters.AddWithValue("@PostID", postID);

                SqlDataReader reader = cmd3.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string postOwnerName = reader["UserName"].ToString();
                        string postOwnerID = reader["UserID"].ToString();
                        string postTitle = reader["PostTitle"].ToString();

                        //STEP 2 : INSERT INTO THE POST OWNER NOTIFICATION TABLE
                        string message = postOwnerName + " liked your post, with title \"" + postTitle + "\".";
                        Debug.WriteLine(message);

                        SqlConnection conn4;
                        string str4 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                        conn4 = new SqlConnection(str4);

                        conn4.Open();
                        string query4 = "INSERT INTO Notification (NotificationContent, UserID, PostURL) VALUES (@NotificationContent, @UserID, @PostURL)";
                        SqlCommand cmd4 = new SqlCommand(query4, conn4);
                        cmd4.Parameters.AddWithValue("@NotificationContent", message);
                        cmd4.Parameters.AddWithValue("@UserID", postOwnerID);
                        cmd4.Parameters.AddWithValue("@PostURL", postID);

                        int n2 = cmd4.ExecuteNonQuery();

                        conn4.Close();
                    }
                }

                if (i > 0)
                {
                    Response.Redirect("~/Community/Post.aspx?postID=" + postID);
                }
                conn2.Close();
            }
            conn2.Close();
        }

        protected void commentRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            System.Web.UI.WebControls.Image img = e.Item.FindControl("img") as System.Web.UI.WebControls.Image;
            HiddenField User_ID = e.Item.FindControl("userID") as HiddenField;
            string userID = User_ID.Value;

            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();

            string query = "SELECT COUNT(*) FROM Item i, PurchasedItem p WHERE i.ItemID = p.ItemID AND i.Category = 'Title' AND p.Equipped = 1 AND UserID = @userID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userID", userID);

            int num = Convert.ToInt32(cmd.ExecuteScalar());


            if (num == 0)
            {
                img.Visible = false;
            }
            else
            {
                img.Visible = true;
            }
        }
    }
}