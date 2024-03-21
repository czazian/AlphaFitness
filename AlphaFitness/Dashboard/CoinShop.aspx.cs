using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaFitness.Dashboard
{
    public partial class CoinShop : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string cat = Request.QueryString["cat"];

                if (cat == null || cat == "Title")
                {
                    cat = "Title";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "title();", true);
                }
                else if (cat == "PDF")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "content();", true);
                }

                //Display the item
                SqlConnection conn;
                string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                conn = new SqlConnection(str);

                conn.Open();

                string retrieve = "SELECT \r\n    ItemID, \r\n    ItemName, \r\n    ItemUrl, \r\n    RequireCoin, \r\n    Category\r\nFROM \r\n    dbo.Item\r\nWHERE \r\n    Category = @cat\r\nORDER BY\r\n    CASE\r\n        WHEN ItemID NOT IN (SELECT ItemID FROM dbo.PurchasedItem WHERE UserID = @userID) THEN 0\r\n        ELSE 1\r\n    END,\r\n    ItemID;";
                SqlCommand cmd = new SqlCommand(retrieve, conn);
                cmd.Parameters.AddWithValue("@cat", cat);
                cmd.Parameters.AddWithValue("@userID", Session["UserID"].ToString());

                SqlDataReader item = cmd.ExecuteReader(); //More than 1 value

                if (item.HasRows)
                {
                    itemRepeater.DataSource = item;
                    itemRepeater.DataBind();
                }

                conn.Close();
            }
        }


        protected void btnTitle_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "title();", true);

            //Display the item
            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();

            string retrieve = "SELECT \r\n    ItemID, \r\n    ItemName, \r\n    ItemUrl, \r\n    RequireCoin, \r\n    Category\r\nFROM \r\n    dbo.Item\r\nWHERE \r\n    Category = 'Title'\r\nORDER BY\r\n    CASE\r\n        WHEN ItemID NOT IN (SELECT ItemID FROM dbo.PurchasedItem WHERE UserID = @userID) THEN 0\r\n        ELSE 1\r\n    END,\r\n    ItemID;";
            SqlCommand cmd = new SqlCommand(retrieve, conn);
            cmd.Parameters.AddWithValue("@userID", Session["UserID"].ToString());

            SqlDataReader item = cmd.ExecuteReader(); //More than 1 value

            if (item.HasRows)
            {
                itemRepeater.DataSource = item;
                itemRepeater.DataBind();
            }

            conn.Close();
        }


        protected void btnContent_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "content();", true);

            //Display the item
            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();

            string retrieve = "SELECT ItemID, ItemName, ItemUrl, RequireCoin, Category\r\nFROM dbo.Item\r\nWHERE Category = 'PDF' \r\nORDER BY\r\n    CASE\r\n        WHEN ItemID NOT IN (SELECT ItemID FROM dbo.PurchasedItem WHERE UserID = @userID) THEN 0\r\n        ELSE 1\r\n    END,\r\n    ItemID;";
            SqlCommand cmd = new SqlCommand(retrieve, conn);
            cmd.Parameters.AddWithValue("@userID", Session["UserID"].ToString());

            SqlDataReader item = cmd.ExecuteReader(); //More than 1 value

            if (item.HasRows)
            {
                itemRepeater.DataSource = item;
                itemRepeater.DataBind();
            }

            conn.Close();
        }




        protected void btnBuy_Command(object sender, CommandEventArgs e)
        {

            int userID = Convert.ToInt32(Session["UserID"]);
            //int userID = 1; //For Testing Purpose.


            string itemID = e.CommandArgument.ToString();

            Debug.WriteLine("ITEM ID : " + itemID);

            //Get coin amount owned
            int coin;

            SqlConnection conn2;
            string str2 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn2 = new SqlConnection(str2);

            conn2.Open();

            string query2 = "SELECT CoinOwned FROM [User] WHERE UserID = @uid";  //0 = not equipped
            SqlCommand cmd2 = new SqlCommand(query2, conn2);
            cmd2.Parameters.AddWithValue("@uid", userID);

            coin = Convert.ToInt32(cmd2.ExecuteScalar());

            conn2.Close();


            //Get Item Coin Require
            int requireCoin;

            SqlConnection conn3;
            string str3 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn3 = new SqlConnection(str3);

            conn3.Open();

            string query3 = "SELECT RequireCoin FROM Item WHERE ItemID = @itemID";  //0 = not equipped
            SqlCommand cmd3 = new SqlCommand(query3, conn3);
            cmd3.Parameters.AddWithValue("@itemID", itemID);

            requireCoin = Convert.ToInt32(cmd3.ExecuteScalar());

            conn3.Close();


            //Get Item Category
            string cate;

            SqlConnection conn8;
            string str8 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn8 = new SqlConnection(str8);

            conn8.Open();

            string query8 = "SELECT Category FROM Item WHERE ItemID = @itemID";  //0 = not equipped
            SqlCommand cmd8 = new SqlCommand(query8, conn8);
            cmd8.Parameters.AddWithValue("@itemID", itemID);

            cate = cmd8.ExecuteScalar().ToString();

            conn8.Close();


            //Get Item Equipped Status
            int equipped;

            SqlConnection conn9;
            string str9 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn9 = new SqlConnection(str9);

            conn9.Open();

            string query9 = "SELECT Equipped FROM PurchasedItem WHERE ItemID = @itemID AND UserID = @userID";  //0 = not equipped
            SqlCommand cmd9 = new SqlCommand(query9, conn9);
            cmd9.Parameters.AddWithValue("@itemID", itemID);
            cmd9.Parameters.AddWithValue("@userID", userID);

            equipped = Convert.ToInt32(cmd9.ExecuteScalar());

            conn9.Close();



            Debug.WriteLine("COIN : " + coin);
            Debug.WriteLine("REQUIRE COIN : " + requireCoin);
            Debug.WriteLine("Category : " + cate);
            Debug.WriteLine("Equipped for PDF? : " + equipped);

            //Purchase
            if (coin >= requireCoin)
            {
                //Buy the item
                SqlConnection conn;
                string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                conn = new SqlConnection(str);

                conn.Open();

                string query = "";
                if (cate == "Title")
                {
                    query = "INSERT INTO PurchasedItem VALUES (@UserID, @ItemID, 0)";  //0 = not equipped
                }
                else if (cate == "PDF")
                {
                    query = "INSERT INTO PurchasedItem VALUES (@UserID, @ItemID, 1)";  //1 = not equipped
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@ItemID", itemID);

                int n1 = cmd.ExecuteNonQuery();

                //Deduct the coin
                int latestCoin;
                if (cate == "PDF" && equipped == 1)
                {
                    latestCoin = coin;
                }
                else
                {
                    latestCoin = coin - requireCoin;
                }

                SqlConnection conn4;
                string str4 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                conn4 = new SqlConnection(str4);

                conn4.Open();
                string query4 = "UPDATE [User] SET CoinOwned = @coin WHERE UserID = @uid";  //0 = not equipped
                SqlCommand cmd4 = new SqlCommand(query4, conn4);
                cmd4.Parameters.AddWithValue("@coin", latestCoin);
                cmd4.Parameters.AddWithValue("@uid", userID);

                int n2 = cmd4.ExecuteNonQuery();

                if (n1 > 0 && n2 > 0)
                {
                    //Show purchased message
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "purchased();", true);

                    //Check to redirect to which page
                    SqlConnection conn6;
                    string str6 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                    conn6 = new SqlConnection(str6);

                    conn6.Open();

                    Debug.WriteLine("ItemID Buy Content = " + itemID);

                    string query6 = "SELECT Category, ItemUrl, ItemName FROM Item WHERE ItemID = @iid";
                    SqlCommand cmd6 = new SqlCommand(query6, conn6);
                    cmd6.Parameters.AddWithValue("@iid", itemID);

                    SqlDataReader rdr = cmd6.ExecuteReader();

                    string cat = "";
                    string url = "";
                    string itemName = "";
                    while (rdr.Read())
                    {
                        cat = rdr["Category"].ToString();
                        url = rdr["ItemUrl"].ToString();
                        itemName = rdr["ItemName"].ToString();
                    }

                    if (cat == "Title")
                    {
                        Response.Redirect("~/Dashboard/CoinShop.aspx?cat=Title");
                    }
                    else if (cat == "PDF")
                    {

                        string redirect = "<script>window.open('" + ResolveUrl(url) + "'); window.location.href='" + ResolveUrl("~/Dashboard/CoinShop.aspx?cat=PDF") + "'</script>";
                        Response.Write(redirect);

                    }
                    conn6.Close();
                }
                conn.Close();
                conn4.Close();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "coinInsufficient();", true);
            }

        }


        //protected void downloadFile(string url, string ItemName)
        //{
        //    if (!string.IsNullOrEmpty(url))
        //    {

        //        string filePath = Server.MapPath(url);

        //        // Check if the file exists
        //        if (File.Exists(filePath))
        //        {
        //            // Set the content type and header
        //            Response.ContentType = "application/pdf";
        //            Response.AppendHeader("Content-Disposition", "attachment; filename=" + ItemName + ".pdf");

        //            // Write the file content to the response stream
        //            Response.TransmitFile(filePath);
        //            Response.Flush();
        //        }
        //    }
        //}



        protected void itemRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int userID = Convert.ToInt32(Session["UserID"]);
            //int userID = 1; //For Testing Purpose.

            //Have to compare the Item in DB -> PurchasedItem in DB
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Panel panel = e.Item.FindControl("wrapper") as Panel;
                LinkButton btn = e.Item.FindControl("btnBuy") as LinkButton;
                HiddenField itemIDHiddenField = e.Item.FindControl("itemID") as HiddenField;
                Panel panelBuy = e.Item.FindControl("buyContainer") as Panel;
                Panel panelPurchased = e.Item.FindControl("purchasedPanel") as Panel;
                Panel panelDownload = e.Item.FindControl("PDFDownload") as Panel;
                LinkButton downloadBtn = e.Item.FindControl("downloadBtn") as LinkButton;

                string itemID = itemIDHiddenField.Value;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT p.ItemID, p.Equipped, i.Category FROM PurchasedItem p, Item i WHERE p.ItemID = i.ItemID AND UserID = @userID", conn))
                    {
                        cmd.Parameters.AddWithValue("@userID", userID);
                        SqlDataReader reader1 = cmd.ExecuteReader();

                        while (reader1.Read())
                        {
                            if (itemID == reader1["ItemID"].ToString() && reader1["Category"].ToString() == "Title")
                            {
                                panel.Style.Add("opacity", "0.3");
                                btn.Visible = false;
                                panelBuy.Visible = false;
                                panelPurchased.Visible = true;
                            }

                            if (itemID == reader1["ItemID"].ToString() && Convert.ToInt32(reader1["Equipped"]) == 1 && reader1["Category"].ToString() == "PDF")
                            {
                                downloadBtn.Enabled = true;
                                btn.Visible = false;
                                panelBuy.Visible = false;
                                panelDownload.Visible = true;
                            }
                        }

                    }
                    conn.Close();

                }
            }
        }

        protected void downloadBtn_Command(object sender, CommandEventArgs e)
        {
            string url = e.CommandArgument.ToString();

            string redirect = "<script>window.open('" + ResolveUrl(url) + "'); window.location.href='" + ResolveUrl("~/Dashboard/CoinShop.aspx?cat=PDF") + "'</script>";
            Response.Write(redirect);
        }
    }
}