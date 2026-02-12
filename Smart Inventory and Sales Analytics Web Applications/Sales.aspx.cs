using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls; // Required

namespace Smart_Inventory_and_Sales_Analytics_Web_Applications
{
    public partial class Sales : System.Web.UI.Page
    {
        // MANUAL FORCE FIX: Declare controls so Visual Studio sees them
        protected global::System.Web.UI.WebControls.DropDownList ddlProducts;
        protected global::System.Web.UI.WebControls.TextBox txtQty;
        protected global::System.Web.UI.WebControls.Label lblStatus;
        protected global::System.Web.UI.WebControls.Button btnCompleteSale;

        string connString = ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Security Check: Kick them out if not logged in
                if (Session["User"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // Only show products with stock > 0
                string query = "SELECT ProductId, Name FROM Products WHERE Quantity > 0";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                ddlProducts.DataSource = dt;
                ddlProducts.DataTextField = "Name";
                ddlProducts.DataValueField = "ProductId";
                ddlProducts.DataBind();
                ddlProducts.Items.Insert(0, new ListItem("-- Select Product --", "0"));
            }
        }

        protected void btnCompleteSale_Click(object sender, EventArgs e)
        {
            if (ddlProducts.SelectedValue == "0" || string.IsNullOrEmpty(txtQty.Text)) return;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // Update Stock and Record Sale
                string sql = @"UPDATE Products SET Quantity = Quantity - @qty WHERE ProductId = @pid;
                               INSERT INTO Sales (ProductId, Quantity, TotalAmount) VALUES (@pid, @qty, 0)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@qty", txtQty.Text);
                    cmd.Parameters.AddWithValue("@pid", ddlProducts.SelectedValue);
                    cmd.ExecuteNonQuery();

                    lblStatus.Text = "Sale Recorded Successfully!";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                }
            }
            txtQty.Text = ""; // Clear input
            LoadProducts();   // Refresh list
        }
    }
}