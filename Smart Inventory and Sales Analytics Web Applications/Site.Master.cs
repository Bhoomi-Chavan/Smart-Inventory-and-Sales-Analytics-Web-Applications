using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Smart_Inventory_and_Sales_Analytics_Web_Applications
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                // User is Logged In -> Show the Logout Button in the Header
                if (lnkHeaderLogout != null) lnkHeaderLogout.Visible = true;
            }
            else
            {
                // User is NOT Logged In -> Hide the Logout Button
                if (lnkHeaderLogout != null) lnkHeaderLogout.Visible = false;

                // Security Check: Kick them to Login page if they try to access internal pages
                string path = Request.Url.AbsolutePath;
                if (!path.Contains("Login.aspx") && !path.Contains("Register.aspx"))
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        // This function works for BOTH buttons (Sidebar and Header)
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon(); // Clear the session
            Response.Redirect("Login.aspx"); // Go back to Login
        }
    }
}