using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Smart_Inventory_and_Sales_Analytics_Web_Applications
{
    public partial class Login : System.Web.UI.Page
    {
        // Add these declarations if they are missing and not auto-generated
        protected TextBox txtUser;
        protected TextBox txtPass;
        protected Label lblMsg;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Simple check for Viva presentation
            if (txtUser.Text == "admin" && txtPass.Text == "12345")
            {
                Session["User"] = "admin"; // Remember the user
                Response.Redirect("Default.aspx"); // Go to Dashboard
            }
            else
            {
                lblMsg.Text = "Invalid Username or Password";
            }
        }
    }
}