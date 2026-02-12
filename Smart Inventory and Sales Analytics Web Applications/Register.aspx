<!DOCTYPE html>
<html>
<head runat="server">
    <title>Register</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light d-flex align-items-center justify-content-center" style="height: 100vh;">
    <form id="form1" runat="server">
        <div class="card shadow p-4" style="width: 350px;">
            <h3 class="text-center text-primary">Create Account</h3>
            <div class="mb-3">
                <label>Username</label>
                <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" placeholder="Choose a username"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label>Password</label>
                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" placeholder="Choose a password"></asp:TextBox>
            </div>
            <asp:Button ID="btnReg" runat="server" Text="Sign Up" CssClass="btn btn-success w-100" OnClick="btnReg_Click" />
            <a href="Login.aspx" class="d-block text-center mt-3">Already have an account? Login</a>
            <asp:Label ID="lblMsg" runat="server" CssClass="text-danger text-center d-block mt-2"></asp:Label>
        </div>
    </form>
</body>
</html>