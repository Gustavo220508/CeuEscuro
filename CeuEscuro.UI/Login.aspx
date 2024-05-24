<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CeuEscuro.UI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="resource/style.css" rel="stylesheet" />
    <title>CeuEscuro</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="geral">
            <h1>CEu  Escuro</h1>
            <ul>
                <li>
                    <asp:TextBox ID="txtNome" runat="server" placeholder="Nome:" MaxLength="150"></asp:TextBox>
                </li>
                <li>
                    <asp:TextBox ID="txtSenha" runat="server" placeholder="Senha:" MaxLength="6" TextMode="Password"></asp:TextBox>
                </li>
                <li>
                    <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click"/>
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"/>
                </li>
                <li>
                    <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
                </li>
            </ul>

        </div>
    </form>
</body>
</html>
