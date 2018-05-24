<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Proyecto.Web.Views.Registrar.Registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8"/>
  <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
  <meta name="description" content=""/>
  <meta name="author" content=""/>
  <title>SB Admin - Start Bootstrap Template</title>
  <!-- Bootstrap core CSS-->
  <link href="../../vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
  <!-- Custom fonts for this template-->
  <link href="../../vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
  <!-- Custom styles for this template-->
  <link href="../../css/sb-admin.css" rel="stylesheet"/>
      <!-- Bootstrap core JavaScript-->
  <script src="../../vendor/jquery/jquery.min.js"></script>
  <script src="../../vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
  <!-- Core plugin JavaScript-->
  <script src="../../vendor/jquery-easing/jquery.easing.min.js"></script>
</head>
    <body class="bg-dark">
  <div class="container">
    <div class="card card-register mx-auto mt-5">
      <div class="card-header">Register an Account</div>
      <div class="card-body">
          <form id="form1" runat="server">
          <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputName">First name</label>
                  <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server"></asp:TextBox>
              </div>
              <div class="col-md-6">
                <label for="exampleInputLastName">Last name</label>
                  <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server"></asp:TextBox>
              </div>
            </div>
          </div>
          <div class="form-group">
            <label for="exampleInputEmail1">Email address</label>
              <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ></asp:TextBox>
          </div>
          <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputPassword1">Password</label>
                  <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="col-md-6">
                <label for="exampleConfirmPassword">Confirm password</label>
                  <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
              </div>
            </div>
          </div>
          <a class="btn btn-primary btn-block" href="login.html">
              <asp:Button ID="btnRegister"  CssClass="btn btn-primary btn-block" runat="server" Text="Registrar" />
          </form>
        <div class="text-center">
          <a class="d-block small mt-3" href="login.aspx">Login Page</a>
          <a class="d-block small" href="#">Forgot Password?</a>
        </div>
      </div>
    </div>
  </div>

</body>
</html>
