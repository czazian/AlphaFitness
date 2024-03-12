using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

            string retrieve = "SELECT * " +
                "FROM Post p, User u, Comment c " +
                "WHERE u.UserID =  p.UserID" +
                "AND u.UserID = c.UserID";

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