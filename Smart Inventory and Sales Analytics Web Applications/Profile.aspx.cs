using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Web.UI.WebControls; // Required for TextBox, Label, etc.
using System.Security.Cryptography;
using System.Text;

namespace Smart_Inventory_and_Sales_Analytics_Web_Applications
{
    public partial class Profile : System.Web.UI.Page
    {   
        string connStr = ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Security: Kick user out if not logged in
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                // Show current username
                if (lblUsername != null)
                {
                    lblUsername.Text = Session["User"].ToString();
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Normalize and TRIM removes accidental spaces (Very important!)
            string newPass = txtNewPass?.Text?.Trim() ?? string.Empty;
            string confirmPass = txtConfirmPass?.Text?.Trim() ?? string.Empty;
            string oldPass = txtOldPass?.Text?.Trim() ?? string.Empty;

            // Basic validation
            if (string.IsNullOrEmpty(oldPass))
            {
                lblMsg.Text = "Please enter your current password.";
                lblMsg.ForeColor = Color.Red;
                return;
            }

            // 1. Check if New Passwords Match
            if (!string.Equals(newPass, confirmPass, StringComparison.Ordinal))
            {
                lblMsg.Text = "New passwords do not match!";
                lblMsg.ForeColor = Color.Red;
                return;
            }

            string username = Session["User"]?.ToString();
            if (string.IsNullOrEmpty(username))
            {
                // Session expired or invalid
                Response.Redirect("Login.aspx");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // Fetch stored password for the user (do not assume plain-text)
                    using (SqlCommand getCmd = new SqlCommand("SELECT Password FROM Users WHERE Username = @u", conn))
                    {
                        getCmd.Parameters.AddWithValue("@u", username);
                        object dbObj = getCmd.ExecuteScalar();

                        if (dbObj == null || dbObj == DBNull.Value)
                        {
                            lblMsg.Text = "User not found.";
                            lblMsg.ForeColor = Color.Red;
                            return;
                        }

                        string dbPass = dbObj.ToString();

                        // Determine if stored password looks like a SHA-256 hex string
                        bool storedIsSha256 = IsLikelySha256Hex(dbPass);

                        // Compute comparison value for entered old password
                        string oldPassCompare = storedIsSha256 ? ComputeSha256Hex(oldPass) : oldPass;

                        if (!string.Equals(oldPassCompare, dbPass, StringComparison.Ordinal))
                        {
                            lblMsg.Text = "Incorrect Current Password!";
                            lblMsg.ForeColor = Color.Red;
                            return;
                        }

                        // Prepare value to store (preserve hashing style)
                        string newPassToStore = storedIsSha256 ? ComputeSha256Hex(newPass) : newPass;

                        using (SqlCommand updateCmd = new SqlCommand("UPDATE Users SET Password = @p WHERE Username = @u", conn))
                        {
                            updateCmd.Parameters.AddWithValue("@p", newPassToStore);
                            updateCmd.Parameters.AddWithValue("@u", username);
                            updateCmd.ExecuteNonQuery();
                        }

                        lblMsg.Text = "Password updated successfully!";
                        lblMsg.ForeColor = Color.Green;
                    }
                }
            }
            catch (Exception)
            {
                lblMsg.Text = "An error occurred while updating the password.";
                lblMsg.ForeColor = Color.Red;
                // Log exception server-side in production
            }
        }

        private static bool IsLikelySha256Hex(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length != 64) return false;
            foreach (char c in s)
            {
                bool isHex = (c >= '0' && c <= '9') ||
                             (c >= 'a' && c <= 'f') ||
                             (c >= 'A' && c <= 'F');
                if (!isHex) return false;
            }
            return true;
        }

        private static string ComputeSha256Hex(string input)
        {
			using (var sha = SHA256.Create())
			{
				byte[] bytes = Encoding.UTF8.GetBytes(input ?? string.Empty);
				byte[] hash = sha.ComputeHash(bytes);
				var sb = new StringBuilder(hash.Length * 2);
				foreach (byte b in hash) sb.AppendFormat("{0:x2}", b);
				return sb.ToString();
			}
        }
    }
}