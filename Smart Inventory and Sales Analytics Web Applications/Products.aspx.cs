using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient; // Using pure .NET SQL Client

namespace Smart_Inventory_and_Sales_Analytics_Web_Applications
{
    public partial class Products : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategoriesDropdown();
                LoadProducts();
            }
        }

        // Fills the dropdown with Categories from your database
        private void LoadCategoriesDropdown()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT CategoryId, Name FROM Categories";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                ddlCategory.DataSource = dt;
                ddlCategory.DataTextField = "Name";
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select Category --", "0"));
            }
        }

        protected void btnSaveProduct_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue == "0") return;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO Products (CategoryId, Name, SKUCode, CostPrice, SellingPrice, Quantity) VALUES (@cid, @name, @sku, @cp, @sp, @qty)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cid", ddlCategory.SelectedValue);
                    cmd.Parameters.AddWithValue("@name", txtProductName.Text.Trim());
                    cmd.Parameters.AddWithValue("@sku", txtSKU.Text.Trim());
                    cmd.Parameters.AddWithValue("@cp", txtCostPrice.Text);
                    cmd.Parameters.AddWithValue("@sp", txtSellingPrice.Text);
                    cmd.Parameters.AddWithValue("@qty", txtQuantity.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LoadProducts(); // Refresh the table
        }

        private void LoadProducts()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // We join with Categories to show the Name instead of just an ID number
                string query = "SELECT p.*, c.Name as CategoryName FROM Products p JOIN Categories c ON p.CategoryId = c.CategoryId";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                rptProducts.DataSource = dt;
                rptProducts.DataBind();
            }
        }
    }
}