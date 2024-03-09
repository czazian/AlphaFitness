using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaFitness.Tutorial
{
    public partial class IndividualTutorial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Query String
            string id = Request.QueryString["id"];
            if (!IsPostBack)
            {
                //Connection Establish
                SqlConnection conn;
                string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                conn = new SqlConnection(str);

                conn.Open();

                //Command & Execution 
                string retrieve = "SELECT * FROM TUTORIAL WHERE TutID = @id";
                SqlCommand cmd = new SqlCommand(retrieve, conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader tutorial = cmd.ExecuteReader(); //More than 1 value

                if (tutorial.HasRows)
                {
                    while (tutorial.Read())
                    {
                        mainimg.ImageUrl = tutorial["TutImage"].ToString();
                        tutFilter.Text = tutorial["TutFilter"].ToString();
                        tutTitle.Text = tutorial["TutTitle"].ToString();
                        tutSubtitle.Text = tutorial["TutSubtitle"].ToString();
                        tutAuthor.Text = tutorial["TutAuthor"].ToString();
                        tutContent.Text = tutorial["TutContent"].ToString();
                    }
                }
                conn.Close();
            }
        }
    }
}