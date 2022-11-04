<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<!DOCTYPE html>

<html xmln s="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Academia Login</title>
        <link href="~/Login_Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-box">
            <img src="Stock/school (1).png" class="avatar" alt="Avatar Image" />
            <h1>¡Bienvenido al Sistema!</h1> 
            <form>
                <asp:Label for="username" Text="Usuario" runat="server" />
                <asp:TextBox ID="txtUsuario" type="text" placeholder="Ingresar Usuario" runat="server" />
                <asp:Label for="password" Text="Clave" runat="server" />
                <asp:TextBox ID="txtClave" type="password" placeholder="Ingresar Clave" runat="server" />
                <asp:Button ID="btnIngresar" Text="Ingresar" runat="server" OnClick="btnIngresar_Click"/>
                <a href="#">Olvidé mi clave</a> <br />
            </form>
        </div>
    </form>
</body>
</html>
