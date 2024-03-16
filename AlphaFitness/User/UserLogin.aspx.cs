using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaFitness.User
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string HashPassword(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }

        protected void register_Click(object sender, EventArgs e)
        {
            bool valid = false;
            SqlConnection conn2;
            string str2 = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn2 = new SqlConnection(str2);

            conn2.Open();

            string query2 = "SELECT COUNT(*) FROM [User] WHERE Email = @email";
            SqlCommand cmd2 = new SqlCommand(query2, conn2);
            cmd2.Parameters.AddWithValue("@email", regEmail.Text);

            int n = Convert.ToInt32(cmd2.ExecuteScalar());
            if (n >= 1)
            {
                valid = false;
            }
            else
            {
                valid = true;
            }

            //Getting values
            string name = regName.Text;
            string email = regEmail.Text;
            string password1 = pass1.Text;
            string password2 = pass2.Text;
            string defaultImagePath = "~/Image/Profile/default.jpg";


            //Hash Password
            string hashedPassword = HashPassword(password2);


            DateTime dateTime = DateTime.Now;
            dateTime.ToString("MMMM, dd yyyy");

            //Store into DB
            if (password1 == password2 && password1 != "" && password2 != "" && Page.IsValid && valid == true)
            {
                SqlConnection conn;
                string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                conn = new SqlConnection(str);

                conn.Open();

                string query = "INSERT INTO [User] (UserName, Email, Password, ProfileImage, DateOfJoin, DateNow) VALUES (@name, @email, @password, @image, @doj, @dn)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@image", defaultImagePath);
                cmd.Parameters.AddWithValue("@doj", dateTime);
                cmd.Parameters.AddWithValue("@dn", dateTime);

                int i = cmd.ExecuteNonQuery();

                if (i >= 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "registered()", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "error()", true);
                }
            }

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();

            string query = "SELECT COUNT(*) FROM [User] WHERE Email = @email";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@email", regEmail.Text);

            int n = Convert.ToInt32(cmd.ExecuteScalar());
            if (n >= 1)
            {
                CustomValidator1.IsValid = false;
                error1.Text = "*Email has been registered, please try to use another email to register.";
            }
            else
            {
                CustomValidator1.IsValid = true;
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {

            System.Diagnostics.Debug.WriteLine("Custom Validator is fired.");

            string password1 = pass1.Text;
            string password2 = pass2.Text;
            if (password1 == "" || password2 == "")
            {
                CustomValidator2.IsValid = false;
                error2.Text = "*Please do not leave your password 1 and password 2 empty.";
            }
            else if (password1 != password2)
            {
                CustomValidator2.IsValid = false;
                error2.Text = "*Please ensure your password 1 and password 2 is matched.";
            }
            else
            {
                CustomValidator2.IsValid = true;
            }
        }

        private int getCount()
        {
            //Getting user id with email 
            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["ApexOnlineShopDb"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();

            string query = "SELECT COUNT(*) FROM [User] WHERE Email = @email";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@email", txtRecoverEmail.Text);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            conn.Close();

            return count;
        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            //Operation
            if (txtRecoverEmail.Text == "")
            {
                message1.Text = "Please do not leave email empty and enter your email with correct format.";
                message1.ForeColor = Color.Red;
            }
            else if (getCount() == 0)
            {
                message1.Text = "Email does not exist, please try another one.";
                message1.ForeColor = Color.Red;
            }
            else if (txtRecoverEmail.Text != "")
            {
                //Avoid user click again while email is sending
                btnSendEmail.Enabled = false;
                recBtn.Enabled = true;
                resendbtn.Enabled = true;
                //Correct operation
                message1.ForeColor = Color.ForestGreen;
                string recipient = txtRecoverEmail.Text;
                string code = sendEmail(recipient);
                Session["code"] = code.ToString();

            }
        }

        private string sendEmail(string recipient)
        {
            //Generate 6 digits random numbers 
            Random generator = new Random();
            string code = generator.Next(0, 1000000).ToString("D6");

            //Mail Object
            MailMessage mailMessage = new MailMessage();
            string fromMail = "alphafitness.noreply@gmail.com";
            string fromPassword = "eixldscknbztbdwo";

            //Sender and Recipient
            mailMessage.From = new MailAddress(fromMail); //The sender
            mailMessage.To.Add(recipient); //The recipient
            mailMessage.Subject = "Verification Code"; //Email Subject

            //Mail Message
            mailMessage.Body = "Your Verification Code : " + code;
            mailMessage.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.Timeout = 20000;
            client.Credentials = new System.Net.NetworkCredential(fromMail, fromPassword);
            client.EnableSsl = true;

            //Send the email asynchronously - means send in background 
            ThreadPool.QueueUserWorkItem(delegate
            {
                client.Send(mailMessage);
            });

            message1.Text = "Verification code has been sent to your mainbox.";

            return code;
        }

        protected void login_Click(object sender, EventArgs e)
        {

            //Obtain data
            string loginEmail = email.Text;
            string loginPassword = password.Text;

            //Hash Password
            string hashPassword = HashPassword(loginPassword);

            //Processing
            SqlConnection conn;
            string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            conn = new SqlConnection(str);

            conn.Open();

            string query = "SELECT * FROM [User] WHERE Email = @email AND Password = @pass";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@email", loginEmail);
            cmd.Parameters.AddWithValue("@pass", hashPassword);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows) //mean match and yes
            {
                if (reader.Read())
                {
                    //Session
                    Session["UserID"] = reader["UserID"].ToString();



                    //Check if user does not have any day -> If yes, add the first day
                    using (SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                    {
                        conn2.Open();
                        using (SqlCommand cmd2 = new SqlCommand("SELECT Count(*) FROM [Day] WHERE UserID = @userID", conn2))
                        {
                            cmd2.Parameters.AddWithValue("@userID", Session["UserID"]);

                            int n = Convert.ToInt32(cmd2.ExecuteScalar());

                            conn2.Close();

                            if (n == 0) //Means the user is new to this app
                            {
                                using (SqlConnection conn3 = new SqlConnection(ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString))
                                {
                                    conn3.Open();
                                    using (SqlCommand ccmd = new SqlCommand("INSERT INTO Day (DayNo, UserID) VALUES (1, @userID)" + " SELECT SCOPE_IDENTITY()" , conn3))
                                    {
                                        ccmd.Parameters.AddWithValue("@userID", Session["UserID"]);

                                        string insertedDayID = Convert.ToString(ccmd.ExecuteScalar());

                                        Response.Redirect("~/User/CreateFirstEvent.aspx?dayID=" + insertedDayID);
                                    }
                                    conn3.Close();
                                }
                            }
                        }
                    }





                }

                //Redirect
                Response.Redirect("~/Dashboard/Dashboard.aspx");

            }
            else //mean error
            {
                loginerr.Text = "*Email or Password wrong, please try again.";
            }





        }

        //Verification Code Processing
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            string codeToCompare = "";
            string enteredCode = verificationCode.Text;
            if (Session["code"].ToString() != "")
            {
                codeToCompare = Session["code"].ToString();
                recBtn.Enabled = true;
            }

            if (enteredCode == codeToCompare.ToString())
            {
                //Obtain user id 
                SqlConnection conn;
                string str = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
                conn = new SqlConnection(str);

                conn.Open();

                string query = "SELECT UserID FROM [User] WHERE Email = @email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", txtRecoverEmail.Text);

                string id = cmd.ExecuteScalar().ToString();

                if (id != "")
                {
                    Response.Redirect("~/User/ChangePassword.aspx?id=" + id);
                }

            }
            else
            {
                message2.ForeColor = Color.Red;
                message2.Text = "Incorrect verification code, please enter again.";
            }
        }

        protected void resendbtn_Click(object sender, EventArgs e)
        {
            txtRecoverEmail.Text = "";
            verificationCode.Text = "";
            message1.Text = "";
            message2.Text = "";
            resendbtn.Enabled = false;
            btnSendEmail.Enabled = true;
            recBtn.Enabled = false;
            txtRecoverEmail.Focus();
        }
    }
}