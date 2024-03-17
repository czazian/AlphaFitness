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
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "run();", true);

            string userID = Session["UserID"].ToString();

            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();
            string query = "SELECT * FROM [User] WHERE UserID = @id";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@id", userID);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    profileimg.ImageUrl = reader["ProfileImage"].ToString();
                    txtUsername.Text = reader["UserName"].ToString();
                    txtWeight.Text = reader["Weight"].ToString();
                    txtHeight.Text = reader["Height"].ToString();
                    
                }
            }

        }

        protected void Delete_Click(object sender, EventArgs e)
        {

            string userID = Session["UserID"].ToString();

            //Update to db here
            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();
            string query = "UPDATE [User] SET ProfileImage = @img WHERE UserID = @id";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@img", "~/Image/Profile/default.jpg");
            command.Parameters.AddWithValue("@id", userID);

            int n = command.ExecuteNonQuery();

            if (n > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                        "alert",
                        "alert('Your profile photo has been successfully reset to default!');window.location ='EditProfile.aspx';",
                        true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                        "alert",
                        "alert('Something wrong when trying to update!');window.location ='EditProfile.aspx';",
                        true);
            }
        }

        protected void hideButton_Click(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile)
            {
                try
                {
                    string userID = Session["UserID"].ToString();
                    //Saving file to destination
                    string filename = FileUpload1.FileName;
                    string path = Server.MapPath("~/Image/Profile/");
                    path += filename;
                    FileUpload1.SaveAs(path);

                    System.Diagnostics.Debug.WriteLine("PATH : " + path);

                    //Update to db here
                    SqlConnection conn;
                    string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                    conn = new SqlConnection(str);

                    conn.Open();
                    string query = "UPDATE [User] SET ProfileImage = @img WHERE UserID = @id";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@img", "~/Image/Profile/" + filename);
                    command.Parameters.AddWithValue("@id", userID);

                    int n = command.ExecuteNonQuery();

                    if (n > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(),
                                "alert",
                                "alert('Your profile photo has been successfully updated!');window.location ='EditProfile.aspx';",
                                true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(),
                                "alert",
                                "alert('Something wrong when trying to update!');window.location ='EditProfile.aspx';",
                                true);
                    }

                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("error");
                }
            }
        }

        protected void goLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("UserID");
            Response.Redirect("~/User/UserLogin.aspx");
        }

        protected void Change_TextChanged(object sender, EventArgs e)
        {
            //Enable the edit button
            edit.Enabled = true;

            //Processing
            string userID = Session["UserID"].ToString();
            string oriName = "";
            string oriWeight = "";
            string oriHeight = "";

            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();
            string query = "SELECT * FROM [User] WHERE UserrID = @id";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@id", userID);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    oriName = reader["UserName"].ToString();
                    oriWeight = reader["Weight"].ToString();
                    oriHeight = reader["Height"].ToString();
                }

                if (oriName != txtUsername.Text)
                {
                    modified1.Text = " - Modified";
                }
                else
                {
                    modified1.Text = "";
                }

                if (oriWeight != txtWeight.Text)
                {
                    modified2.Text = " - Modified";
                }
                else
                {
                    modified2.Text = "";
                }

                if (oriHeight != txtHeight.Text)
                {
                    modified3.Text = " - Modified";
                }
                else
                {
                    modified3.Text = "";
                }
            }

        }

        protected void Change_IndexChanged(object sender, EventArgs e)
        {

        }

        protected void edit_Click(object sender, EventArgs e)
        {
            string userID = Session["UserID"].ToString();

            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();
            string query = "UPDATE [User] SET UserName = @name, Weight = @weight, Height = @height WHERE UserID = @id";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@name", txtUsername.Text);
            command.Parameters.AddWithValue("@weight", txtWeight.Text);
            command.Parameters.AddWithValue("@height", txtHeight.Text);
            command.Parameters.AddWithValue("@id", userID);
            int n = command.ExecuteNonQuery();


            if (n > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                        "alert",
                        "alert('Your profile information has been successfully updated!');",
                        true);
                modified1.Text = "";
                modified2.Text = "";
                modified3.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                        "alert",
                        "alert('Something wrong when trying to update!');",
                        true);
            }
        }
    }
}