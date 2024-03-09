using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

            //Connection Establish
            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();

            //Command & Execution 
            string retrieve = "SELECT * FROM Item WHERE Category = 'Title'";
            SqlCommand cmd = new SqlCommand(retrieve, conn);

            SqlDataReader item = cmd.ExecuteReader(); //More than 1 value

            if (item.HasRows)
            {
                itemRepeater.DataSource = item;
                itemRepeater.DataBind();
            }

        }
        protected void btnTitle_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "title();", true);

            //Connection Establish
            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();

            //Command & Execution 
            string retrieve = "SELECT * FROM Item WHERE Category = 'Title'";
            SqlCommand cmd = new SqlCommand(retrieve, conn);

            SqlDataReader item = cmd.ExecuteReader(); //More than 1 value

            if (item.HasRows)
            {
                itemRepeater.DataSource = item;
                itemRepeater.DataBind();
            }
        }
        protected void btnContent_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(),"script","content();",true);

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
        }
    }
}