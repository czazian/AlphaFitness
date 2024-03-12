using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

            string retrieve = "SELECT \r\n    P.*, \r\n    U.*,\r\n    ISNULL(CommentCount.Count, 0) AS CommentCount\r\nFROM \r\n    [dbo].[Post] P\r\nJOIN \r\n    [dbo].[User] U ON P.UserID = U.UserID\r\nLEFT JOIN \r\n    (SELECT \r\n         [PostID], \r\n         COUNT(*) AS Count\r\n     FROM \r\n         [dbo].[Comment]\r\n     GROUP BY \r\n         [PostID]) AS CommentCount ON P.[PostID] = CommentCount.[PostID] ORDER BY P.PostTime DESC;";

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

            string query = "INSERT INTO Post Values (@title, @content, 0, @dateTime, @userID)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@content", content);
            cmd.Parameters.AddWithValue("@dateTime", dateTime);
            cmd.Parameters.AddWithValue("@userID", userID);

            int i = cmd.ExecuteNonQuery();

            if(i > 0)
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

    }
}