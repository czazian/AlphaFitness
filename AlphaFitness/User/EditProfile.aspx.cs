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

            string customerID = Session["UserID"].ToString();

            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();
            string query = "SELECT * FROM [User] WHERE UserID = @id";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@id", customerID);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    profileimg.ImageUrl = reader["Image"].ToString();
                    txtUsername.Text = reader["Name"].ToString();
                    txtWeight.Text = reader["PhoneNo"].ToString();
                    txtHeight.Text = reader["Address"].ToString();
                }
            }

        }

        protected void Delete_Click(object sender, EventArgs e)
        {

            string customerID = Session["CustomerID"].ToString();

            //Update to db here
            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["ApexOnlineShopDb"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();
            string query = "UPDATE Customer SET Image = @img WHERE CustomerID = @id";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@img", "~/Image/Profile/default.jpg");
            command.Parameters.AddWithValue("@id", customerID);

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
                    string customerID = Session["CustomerID"].ToString();
                    //Saving file to destination
                    string filename = FileUpload1.FileName;
                    string path = Server.MapPath("~/Image/Profile/");
                    path += filename;
                    FileUpload1.SaveAs(path);

                    System.Diagnostics.Debug.WriteLine("PATH : " + path);

                    //Update to db here
                    SqlConnection conn;
                    string str = ConfigurationManager.ConnectionStrings["ApexOnlineShopDb"].ConnectionString;
                    conn = new SqlConnection(str);

                    conn.Open();
                    string query = "UPDATE Customer SET Image = @img WHERE CustomerID = @id";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@img", "~/Image/Profile/" + filename);
                    command.Parameters.AddWithValue("@id", customerID);

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
            Session.Remove("CustomerID");
            Response.Redirect("~/Customer/Home.aspx");
        }

        protected void Change_TextChanged(object sender, EventArgs e)
        {
            //Enable the edit button
            edit.Enabled = true;

            //Processing
            string customerID = Session["CustomerID"].ToString();
            string oriName = "";
            string oriPhone = "";
            string oriAddress = "";

            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["ApexOnlineShopDb"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();
            string query = "SELECT * FROM Customer WHERE CustomerID = @id";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@id", customerID);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    oriName = reader["Name"].ToString();
                    oriPhone = reader["PhoneNo"].ToString();
                    oriAddress = reader["Address"].ToString();
                }

                if (oriName != txtUsername.Text)
                {
                    modified1.Text = " - Modified";
                }
                else
                {
                    modified1.Text = "";
                }

                if (oriPhone != txtWeight.Text)
                {
                    modified2.Text = " - Modified";
                }
                else
                {
                    modified2.Text = "";
                }

                if (oriAddress != txtHeight.Text)
                {
                    modified3.Text = " - Modified";
                }
                else
                {
                    modified3.Text = "";
                }
            }

        }

        protected void edit_Click(object sender, EventArgs e)
        {
            string customerID = Session["CustomerID"].ToString();

            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["ApexOnlineShopDb"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();
            string query = "UPDATE Customer SET Name = @name, PhoneNo = @phone, Address = @address WHERE CustomerID = @id";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@name", txtUsername.Text);
            command.Parameters.AddWithValue("@phone", txtWeight.Text);
            command.Parameters.AddWithValue("@address", txtHeight.Text);
            command.Parameters.AddWithValue("@id", customerID);
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