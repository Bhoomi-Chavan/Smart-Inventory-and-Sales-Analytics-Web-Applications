using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Smart_Inventory_and_Sales_Analytics_Web_Applications
{
    public partial class Register : System.Web.UI.Page
    {
        // MANUAL FORCE FIX
        protected global::System.Web.UI.WebControls.TextBox txtUser;
        protected global::System.Web.UI.WebControls.TextBox txtPass;
        protected global::System.Web.UI.WebControls.Label lblMsg;

        protected void btnReg_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, Password) VALUES (@u, @p)", conn);
                cmd.Parameters.AddWithValue("@u", txtUser.Text);
                cmd.Parameters.AddWithValue("@p", txtPass.Text);
                cmd.ExecuteNonQuery();
                Response.Redirect("Login.aspx");
            }
        }
    }
}