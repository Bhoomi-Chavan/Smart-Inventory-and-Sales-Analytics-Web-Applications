using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient; // Pure Microsoft .NET SQL!

namespace Smart_Inventory_and_Sales_Analytics_Web_Applications
{
    public partial class Categories : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrEmpty(categoryName)) return;

            // Notice we changed MySqlConnection to SqlConnection
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO Categories (Name, Description) VALUES (@Name, @Description)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", categoryName);
                    cmd.Parameters.AddWithValue("@Description", description);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            txtCategoryName.Text = "";
            txtDescription.Text = "";
            LoadCategories();
        }

        private void LoadCategories()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM Categories ORDER BY CategoryId DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptCategories.DataSource = dt;
                        rptCategories.DataBind();
                    }
                }
            }
        }
    }
}