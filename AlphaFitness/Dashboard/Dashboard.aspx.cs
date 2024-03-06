using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaFitness.Dashboard
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Color active = Color.FromArgb(252, 186, 3);

            one.BackColor = active;
            one.ForeColor = Color.White;

            two.BackColor = Color.LightGray;
            two.ForeColor = Color.DimGray;

            three.BackColor = Color.LightGray;
            three.ForeColor = Color.DimGray;

            four.BackColor = Color.LightGray; 
            four.ForeColor = Color.DimGray;

            five.BackColor = Color.LightGray;
            five.ForeColor = Color.DimGray;

            six.BackColor = Color.LightGray;
            six.ForeColor = Color.DimGray;

            seven.BackColor = Color.LightGray;
            seven.ForeColor = Color.DimGray;

        }
    }
}