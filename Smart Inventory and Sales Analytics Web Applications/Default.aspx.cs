using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text; // Required for StringBuilder
using System.Web.UI.WebControls;

namespace Smart_Inventory_and_Sales_Analytics_Web_Applications
{
    public partial class _Default : System.Web.UI.Page
    {
        // --- MANUAL FORCE FIX: Declare controls explicitly ---
        protected global::System.Web.UI.WebControls.Label lblTotalProducts;
        protected global::System.Web.UI.WebControls.Label lblTotalCategories;
        protected global::System.Web.UI.WebControls.Label lblLowStock;
        protected global::System.Web.UI.WebControls.Label lblTotalRevenue;
        protected global::System.Web.UI.WebControls.GridView gvLowStock;
        protected global::System.Web.UI.WebControls.GridView gvTopSellers; // Existing table
        // ---------------------------------------------------

        string connString = ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadDashboardStats();
            }
        }

        private void LoadDashboardStats()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                // 1. Basic Counters
                lblTotalProducts.Text = new SqlCommand("SELECT COUNT(*) FROM Products", conn).ExecuteScalar()?.ToString() ?? "0";
                lblTotalCategories.Text = new SqlCommand("SELECT COUNT(*) FROM Categories", conn).ExecuteScalar()?.ToString() ?? "0";
                lblLowStock.Text = new SqlCommand("SELECT COUNT(*) FROM Products WHERE Quantity < 5", conn).ExecuteScalar()?.ToString() ?? "0";

                // 2. Revenue
                object revenue = new SqlCommand("SELECT ISNULL(SUM(TotalAmount), 0) FROM Sales", conn).ExecuteScalar();
                if (lblTotalRevenue != null) lblTotalRevenue.Text = "₹ " + Convert.ToDecimal(revenue).ToString("N2");

                // 3. Load Low Stock Table
                SqlDataAdapter sdaLow = new SqlDataAdapter("SELECT Name, Quantity FROM Products WHERE Quantity < 5", conn);
                DataTable dtLow = new DataTable();
                sdaLow.Fill(dtLow);
                gvLowStock.DataSource = dtLow;
                gvLowStock.DataBind();

                // 4. ANALYTICS: Top 5 Sellers (Table & Chart)
                string query = @"
                    SELECT TOP 5 P.Name, SUM(S.Quantity) AS TotalSold 
                    FROM Sales S 
                    INNER JOIN Products P ON S.ProductId = P.ProductId 
                    GROUP BY P.Name 
                    ORDER BY TotalSold DESC";

                SqlDataAdapter sdaTop = new SqlDataAdapter(query, conn);
                DataTable dtTop = new DataTable();
                sdaTop.Fill(dtTop);

                // Bind the Table
                if (gvTopSellers != null)
                {
                    gvTopSellers.DataSource = dtTop;
                    gvTopSellers.DataBind();
                }

                // Prepare Data for the Chart
                StringBuilder sbLabels = new StringBuilder();
                StringBuilder sbData = new StringBuilder();

                foreach (DataRow row in dtTop.Rows)
                {
                    sbLabels.Append(row["Name"] + ",");
                    sbData.Append(row["TotalSold"] + ",");
                }

                // Remove the last comma and send to HiddenFields
                if (hfChartLabels != null && sbLabels.Length > 0)
                {
                    hfChartLabels.Value = sbLabels.ToString().TrimEnd(',');
                    hfChartData.Value = sbData.ToString().TrimEnd(',');
                }
            }
        }
    }
}