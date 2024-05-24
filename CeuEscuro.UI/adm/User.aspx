<%@ Page Title="" Language="C#" MasterPageFile="~/adm/ManagerUser.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="CeuEscuro.UI.adm.User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <asp:Label ID="lblSession" runat="server" Text=""></asp:Label>

    <%--formulario--%>
    <ul>
       <li>
        <asp:TextBox ID="txtId" placeholder="Id:" runat="server"></asp:TextBox>
    </li>
    <li>
        <asp:TextBox ID="txtNome" placeholder="Nome:" MaxLength="150" runat="server"></asp:TextBox>
        <asp:Label ID="lblNome" runat="server" Text=""></asp:Label>
    </li>
    <li>
        <asp:TextBox ID="txtEmail" placeholder="Email:" MaxLength="150" runat="server"></asp:TextBox>
        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
    </li>
    <li>
        <asp:TextBox ID="txtSenha" placeholder="Senha:" MaxLength="6" runat="server"></asp:TextBox>
        <asp:Label ID="lblSenha" runat="server" Text=""></asp:Label>
    </li>
    <li>
        <asp:TextBox ID="txtDataNascUsuario" placeholder="Data de nascimento:" onkeypress="$(this).mask('00/00/0000')" runat="server"></asp:TextBox>
        <asp:Label ID="lblDataNascUsuario" runat="server" Text=""></asp:Label>
    </li>
    <li>
         <asp:DropDownList 
             ID="ddl1"
             Width="160px"
             weight="27px" 
             AutoPostBack="false"
             DataValueField="Id"
             DataTextField="Descricao"
             runat="server"></asp:DropDownList>
        </li>
        <li>
            <asp:Button ID="btnRecord" runat="server" Text="Record" OnClick="btnRecord_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" OnClientClick="if(!confirm('Deseja realmente eliminar esse registro ?'))return false" />
        </li>
        <li>
            <asp:TextBox ID="txtSearch" placeholder="Seach by Name:" runat="server" ></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/>
            <asp:Label ID="lblSearch" runat="server" Text=""></asp:Label>
        </li>
    </ul>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

    <%--gridView--%>
    <asp:GridView ID="gv1" OnSelectedIndexChanged="gv1_SelectedIndexChanged" AutoGenerateColumns="false" runat="server">
    <Columns>
        <asp:CommandField ShowSelectButton="true" ButtonType="Button" HeaderText="Options" />
        <asp:BoundField DataField="Id" HeaderText="Código" />
        <asp:BoundField DataField="Nome" HeaderText="Nome" />
        <asp:BoundField DataField="Email" HeaderText="Email" />
        <asp:BoundField DataField="Senha" HeaderText="Senha" />
        <asp:BoundField DataField="DataNascUsuario" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}"/>
        <asp:BoundField DataField="TipoUsuario_Id" HeaderText="Permissão" />
    </Columns>
   </asp:GridView>


</asp:Content>
