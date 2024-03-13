using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaFitness.Dashboard
{
    public partial class CoinShop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Display the item
            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();

            string retrieve = "SELECT ItemID, ItemName, ItemUrl, RequireCoin, Category\r\nFROM dbo.Item\r\nWHERE Category = 'Title'\r\nORDER BY\r\n    CASE\r\n        WHEN ItemID NOT IN (SELECT ItemID FROM dbo.PurchasedItem) THEN 0\r\n        ELSE 1\r\n    END,\r\n    ItemID;";
            SqlCommand cmd = new SqlCommand(retrieve, conn);

            SqlDataReader item = cmd.ExecuteReader(); //More than 1 value

            if (item.HasRows)
            {
                itemRepeater.DataSource = item;
                itemRepeater.DataBind();
            }

            conn.Close();
        }


        protected void btnTitle_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "title();", true);

            //Display the item
            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();

            string retrieve = "SELECT ItemID, ItemName, ItemUrl, RequireCoin, Category\r\nFROM dbo.Item\r\nWHERE Category = 'Title'\r\nORDER BY\r\n    CASE\r\n        WHEN ItemID NOT IN (SELECT ItemID FROM dbo.PurchasedItem) THEN 0\r\n        ELSE 1\r\n    END,\r\n    ItemID;";
            SqlCommand cmd = new SqlCommand(retrieve, conn);

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

            //Connection Establish
            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();

            //Command & Execution 
            string retrieve = "SELECT * FROM Item WHERE Category = 'PDF'";
            SqlCommand cmd = new SqlCommand(retrieve, conn);

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

            //int userID = Convert.ToInt32(Session["UserID"]);
            int userID = 1; //For Testing Purpose.

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

            Debug.WriteLine("COIN : " + coin);
            Debug.WriteLine("REQUIRE COIN : " + requireCoin);


            //Purchase
            if (coin >= requireCoin)
            {
                //Buy the item
                SqlConnection conn;
                string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                conn = new SqlConnection(str);

                conn.Open();

                string query = "INSERT INTO PurchasedItem VALUES (@UserID, @ItemID, 0)";  //0 = not equipped
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@ItemID", itemID);

                int n1 = cmd.ExecuteNonQuery();

                //Deduct the coin
                int latestCoin = coin - requireCoin;

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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "purchased();", true);
                    Response.Redirect("~/Dashboard/CoinShop.aspx");
                }

                conn.Close();
                conn4.Close();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "coinInsufficient();", true);
            }

        }


        //TO BE CONTINUED -> MAKE THE PURCHASED ITEM GRAY OUT + MAKE THE PDF PURCHASABLE
        protected void itemRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //Have to compare the Item in DB -> PurchasedItem in DB
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

            }
        }

    }
}