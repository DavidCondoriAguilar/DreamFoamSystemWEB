<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DreamWEB.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>DreamFoam - Login</title>
    <link rel="stylesheet" href="~/Content/bootstrap.css" />
    <link rel="stylesheet" href="~/CSS/LoginStyle.css" />
    <style type="text/css">
        .auto-style1 {
            width: 168px;
            height: 121px;
        }
    </style>
</head>
<body>
    <div class="container-fluid ps-md-0">
        <div class="row g-0">
            <div class="d-none d-md-flex col-md-4 col-lg-6 bg-image"></div>
            <div class="col-md-8 col-lg-6">
                <div class="login d-flex align-items-center py-5">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-9 col-lg-8 mx-auto">
                                <img class="img-fluid auto-style1 mx-auto d-block" src="/FotosTemp/dreamLogo3.png"/>
                                <h2 class="text-center" style="font-family: 'Copperplate Gothic'; position:relative; bottom:15px;">Dream Foam</h2>
                               
      
                                <h3 class="login-heading mb-4">Inicio de Sesion</h3>
                                <p class="small">Por favor inicie sesión para continuar</p>
                                <form id="form1" runat="server">
                                    <div class="form-floating mb-3">
                                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                                        <label for="txtNombre">Usuario:</label>
                                    </div>
                                    <div class="form-floating mb-3">
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                        <label for="txtPassword">Contraseña:</label>
                                    </div>
                                    <div class="d-grid">
                                        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-lg btn-primary btn-login text-uppercase fw-bold mb-2" OnClick="btnIngresar_Click"/>
                                        <div class="text-center">
                                            <p class="small">Usuario y contraseña de prueba "admin"</p>
                                        </div>
                                        <asp:Label ID="lblMensaje" runat="server" CssClass="text-center small text-danger"></asp:Label>
                                    </div>
                                </form>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="~/Scripts/bootstrap.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
</body>
</html>
