using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            //string userID = 25.ToString();

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



            //DropdownList Initialization
            using (SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
            {
                conn2.Open();
                using (SqlCommand cmd2 = new SqlCommand("SELECT * FROM PurchasedItem p, Item i WHERE p.ItemID = i.ItemID AND p.UserID = @userID AND i.Category = 'Title'", conn2))
                {
                    cmd2.Parameters.AddWithValue("@userID", userID);
                    SqlDataReader reader1 = cmd2.ExecuteReader();

                    ddlTitle.DataSource = reader1;
                    ddlTitle.DataTextField = "ItemName";
                    ddlTitle.DataValueField = "ItemID";
                    ddlTitle.DataBind();

                }
                conn2.Close();

                //Add blank item
                ddlTitle.Items.Insert(0, new ListItem("", "-1"));
            }


            //Point the selected title to currently selected title
            using (SqlConnection conn3 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
            {
                conn3.Open();
                using (SqlCommand cmd3 = new SqlCommand("SELECT p.ItemID FROM PurchasedItem p, Item i WHERE p.ItemID = i.ItemID AND p.UserID = @userID AND i.Category = 'Title' AND p.Equipped = 1", conn3))
                {
                    cmd3.Parameters.AddWithValue("@userID", userID);
                    int newID = Convert.ToInt32(cmd3.ExecuteScalar());

                    ddlTitle.SelectedIndex = checkIndex(newID);
                }
                conn3.Close();

                int checkIndex(int newID)
                {
                    for (int i = 0; i < ddlTitle.Items.Count; i++)
                    {
                        if (ddlTitle.Items[i].Value.Equals(newID.ToString()))
                        {
                            return i;
                        }
                    }
                    return 0;
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
            string query = "SELECT * FROM [User] WHERE UserID = @id";
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

        protected void edit_Click(object sender, EventArgs e)
        {

            //Update Name Weight Height
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
            int n1 = command.ExecuteNonQuery();

            conn.Close();


            //Update Title
            int selectedTitleID = Convert.ToInt32(ddlTitle.SelectedValue);

            if (selectedTitleID != 0)
            {
                SqlConnection conn2;
                string str2 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                conn2 = new SqlConnection(str2);

                conn2.Open();

                string query2 = "UPDATE [PurchasedItem] SET Equipped = 1 WHERE UserID = @userID AND ItemID = @itemID";
                SqlCommand command2 = new SqlCommand(query2, conn2);
                command2.Parameters.AddWithValue("@userID", userID);
                command2.Parameters.AddWithValue("@itemID", selectedTitleID);
                int n2 = command2.ExecuteNonQuery();

                conn2.Close();

                //Deselect equipped title, other than the currently selected one
                SqlConnection conn3;
                string str3 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                conn3 = new SqlConnection(str3);

                conn3.Open();

                string query3 = "UPDATE [PurchasedItem] SET Equipped = 0 FROM [PurchasedItem] INNER JOIN [Item] ON [PurchasedItem].[ItemID] = [Item].[ItemID] WHERE [PurchasedItem].[UserID] = @userID AND [Item].[Category] = 'Title' AND [PurchasedItem].[ItemID] <> @itemID;";
                SqlCommand command3 = new SqlCommand(query3, conn3);
                command3.Parameters.AddWithValue("@userID", userID);
                command3.Parameters.AddWithValue("@itemID", selectedTitleID);
                int n3 = command3.ExecuteNonQuery();

                conn3.Close();


                //Check if successful or not
                if (n1 > 0 && n2 > 0 && n3 > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "alert",
                            "alert('Your profile information has been successfully updated!');",
                            true);
                    modified1.Text = "";
                    modified2.Text = "";
                    modified3.Text = "";
                }
            }
            else if (selectedTitleID == -1)
            {
                //Deselect all
                SqlConnection conn4;
                string str4 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                conn4 = new SqlConnection(str4);

                conn4.Open();

                string query4 = "UPDATE [PurchasedItem] SET Equipped = 0 FROM [PurchasedItem] INNER JOIN [Item] ON [PurchasedItem].[ItemID] = [Item].[ItemID] WHERE [PurchasedItem].[UserID] = @userID AND [Item].[Category] = 'Title'";
                SqlCommand command4 = new SqlCommand(query4, conn4);
                command4.Parameters.AddWithValue("@userID", userID);
                command4.Parameters.AddWithValue("@itemID", selectedTitleID);
                int n5 = command4.ExecuteNonQuery();

                if (n5 > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                                                "alert",
                                                "alert('Your profile information has been successfully updated!');",
                                                true);
                }
            }
        }

        protected void ddlTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            edit.Enabled = true;
        }
    }
}