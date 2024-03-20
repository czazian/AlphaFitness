using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;

namespace AlphaFitness.Food
{
    public partial class FoodTracking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Populate the DropDownList only on the initial page load
                PopulateFoodList();
            }

        }

        protected void PopulateFoodList()
        {
            string mainconn = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select * from[dbo].[Food]";
            SqlDataAdapter sda = new SqlDataAdapter(sqlquery, sqlconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            FoodList.DataSource = dt;
            FoodList.DataValueField = "FoodID";
            FoodList.DataTextField = "FoodName";
            FoodList.DataBind();
        }

        protected void FoodAdd_Click(object sender, EventArgs e)
        {

            // Retrieve the entered food details from the textboxes
            string foodName = AddFood.Text;
            int quantity = Convert.ToInt32(TextBox2.Text);
            decimal calories = Convert.ToDecimal(AddCalory.Text);

            // Perform any validation if required

            // Get the current user ID from the session or any other source
            string userID = Session["UserID"].ToString();

            // Get the current DayID using the GetDayID method or any other method to obtain it
            int dayID = GetDayID(userID);

            // Add the food details to the Intake table in the database
            string mainconn = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            using (SqlConnection sqlconn = new SqlConnection(mainconn))
            {
                sqlconn.Open();
                using (SqlCommand cmdAddIntake = sqlconn.CreateCommand())
                {
                    cmdAddIntake.CommandType = CommandType.Text;
                    cmdAddIntake.CommandText = "INSERT INTO dbo.Intake (UserID, FoodName, Quantity, Calories, DayID) " +
                                               "VALUES (@UserID, @FoodName, @Quantity, @Calories, @DayID)";
                    cmdAddIntake.Parameters.AddWithValue("@UserID", userID);
                    cmdAddIntake.Parameters.AddWithValue("@FoodName", foodName);
                    cmdAddIntake.Parameters.AddWithValue("@Quantity", quantity);
                    cmdAddIntake.Parameters.AddWithValue("@Calories", calories);
                    cmdAddIntake.Parameters.AddWithValue("@DayID", dayID);

                    cmdAddIntake.ExecuteNonQuery();
                }
            }
        }

        protected void FoodSelect_Click(object sender, EventArgs e)
        {
            string userID = Session["UserID"].ToString();

            // Get the selected food ID and quantity
            string foodName = FoodList.SelectedItem.Text;
            int quantity = Convert.ToInt32(FoodQuantity.SelectedValue);

            int dayID = GetDayID(userID); // Retrieve the DayID

            // Retrieve the calorie value for the selected food item from the Food table
            int calorie = GetFoodCalorie(foodName);

            // Add the food intake to the Intake table
            string mainconn = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            using (SqlConnection sqlconn = new SqlConnection(mainconn))
            {
                sqlconn.Open();
                using (SqlCommand cmdAddIntake = sqlconn.CreateCommand())
                {
                    cmdAddIntake.CommandType = CommandType.Text;
                    cmdAddIntake.CommandText = "INSERT INTO dbo.Intake (UserID, FoodName, Quantity, DayID, Calories) " +
                                               "VALUES (@UserID, @FoodName, @Quantity,@DayID,@Calories)";
                    cmdAddIntake.Parameters.AddWithValue("@UserID", userID);
                    cmdAddIntake.Parameters.AddWithValue("@FoodName", foodName);
                    cmdAddIntake.Parameters.AddWithValue("@Quantity", quantity);
                    cmdAddIntake.Parameters.AddWithValue("DayID", dayID);
                    cmdAddIntake.Parameters.AddWithValue("@Calories", calorie);

                    cmdAddIntake.ExecuteNonQuery();
                }
            }
        }

        // Function to retrieve the calorie value for a given food name from the Food table
        private int GetFoodCalorie(string foodName)
        {
            int calorie = 0;
            string mainconn = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            using (SqlConnection sqlconn = new SqlConnection(mainconn))
            {
                sqlconn.Open();
                string query = "SELECT FoodCalories FROM Food WHERE FoodName = @FoodName";
                using (SqlCommand cmd = new SqlCommand(query, sqlconn))
                {
                    cmd.Parameters.AddWithValue("@FoodName", foodName);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        calorie = Convert.ToInt32(result);
                    }
                }
            }
            return calorie;
        }

        private int GetDayID(string userID)
        {
            int dayID = -1; // Initialize to -1 to indicate failure

            string mainconn = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            using (SqlConnection sqlconn = new SqlConnection(mainconn))
            {
                sqlconn.Open();
                using (SqlCommand cmdGetDayID = new SqlCommand("SELECT TOP 1 DayID FROM Day WHERE UserID = @UserID ORDER BY DayNo DESC", sqlconn))
                {
                    cmdGetDayID.Parameters.AddWithValue("@UserID", userID);
                    object result = cmdGetDayID.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        dayID = Convert.ToInt32(result);
                    }
                }
            }

            return dayID;
        }

        protected void TotalCalory_Click(object sender, EventArgs e)
        {
            // Get the UserID from the session
            int userID = Convert.ToInt32(Session["UserID"]);

            // Get the latest DayID for the current user
            int latestDayID = GetLatestDayID(userID);

            // Calculate total calories for the latest DayID
            int totalCalories = CalculateTotalCaloriesForDayID(latestDayID);

            // Store the total calories for the latest DayID
            StoreTotalCalories(userID, latestDayID, totalCalories);

            // Insert the same total calories into the BodyMetric table
            InsertTotalCaloriesIntoBodyMetric(latestDayID, totalCalories);
        }

        // Function to calculate total calories for a given DayID
        private int CalculateTotalCaloriesForDayID(int dayID)
        {
            // Connection string
            string mainconn = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;

            using (SqlConnection sqlconn = new SqlConnection(mainconn))
            {
                // Open the connection
                sqlconn.Open();

                // Query to calculate total calories for the given DayID
                string query = "SELECT SUM(Calories * Quantity) FROM Intake WHERE DayID = @DayID";

                using (SqlCommand cmd = new SqlCommand(query, sqlconn))
                {
                    cmd.Parameters.AddWithValue("@DayID", dayID);

                    // Execute the query and return the total calories
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
        }

        // Function to get the latest DayID for the current user
        private int GetLatestDayID(int userID)
        {
            // Connection string
            string mainconn = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;

            using (SqlConnection sqlconn = new SqlConnection(mainconn))
            {
                // Open the connection
                sqlconn.Open();

                // Query to get the latest DayID for the current user
                string query = "SELECT TOP 1 DayID FROM Day WHERE UserID = @UserID ORDER BY DayID DESC";

                using (SqlCommand cmd = new SqlCommand(query, sqlconn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    // Execute the query and return the latest DayID
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }



        // Function to store the total calories in the TotalCalories table
        private void StoreTotalCalories(int userID, int dayID, int totalCalories)
        {
            // Connection string
            string mainconn = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;

            using (SqlConnection sqlconn = new SqlConnection(mainconn))
            {
                // Open the connection
                sqlconn.Open();

                // Check if there is already a record for the given UserID and DayID
                string checkQuery = "SELECT COUNT(*) FROM TotalCalories WHERE UserID = @UserID AND DayID = @DayID";

                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlconn))
                {
                    checkCmd.Parameters.AddWithValue("@UserID", userID);
                    checkCmd.Parameters.AddWithValue("@DayID", dayID);

                    int existingRecords = (int)checkCmd.ExecuteScalar();

                    // If a record already exists, update it; otherwise, insert a new record
                    if (existingRecords > 0)
                    {
                        string updateQuery = "UPDATE TotalCalories SET TotalCalories = @TotalCalories WHERE UserID = @UserID AND DayID = @DayID";

                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, sqlconn))
                        {
                            updateCmd.Parameters.AddWithValue("@UserID", userID);
                            updateCmd.Parameters.AddWithValue("@DayID", dayID);
                            updateCmd.Parameters.AddWithValue("@TotalCalories", totalCalories);

                            updateCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO TotalCalories (UserID, DayID, TotalCalories) VALUES (@UserID, @DayID, @TotalCalories)";

                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, sqlconn))
                        {
                            insertCmd.Parameters.AddWithValue("@UserID", userID);
                            insertCmd.Parameters.AddWithValue("@DayID", dayID);
                            insertCmd.Parameters.AddWithValue("@TotalCalories", totalCalories);

                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void InsertTotalCaloriesIntoBodyMetric(int dayID, int totalCalories)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["AlphaFitness"].ConnectionString;
            using (SqlConnection sqlconn = new SqlConnection(mainconn))
            {
                sqlconn.Open();
                using (SqlCommand cmdInsertCalories = sqlconn.CreateCommand())
                {
                    cmdInsertCalories.CommandType = CommandType.Text;
                    cmdInsertCalories.CommandText = "INSERT INTO dbo.BodyMetric (Calories, DayID) VALUES (@Calories, @DayID)";
                    cmdInsertCalories.Parameters.AddWithValue("@Calories", totalCalories);
                    cmdInsertCalories.Parameters.AddWithValue("@DayID", dayID);

                    // Execute the insert command
                    cmdInsertCalories.ExecuteNonQuery();
                }
            }
        }
    }
}