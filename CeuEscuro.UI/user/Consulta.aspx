<%@ Page Title="" Language="C#" MasterPageFile="~/user/ConsultaUser.Master" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="CeuEscuro.UI.user.Consulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%--gridView--%>
 <asp:GridView ID="gv1" AutoGenerateColumns="false" runat="server">
 <Columns>
     <asp:BoundField DataField="Id" HeaderText="Código" />
     <asp:BoundField DataField="Nome" HeaderText="Nome" />
     <asp:BoundField DataField="Email" HeaderText="Email" />
     <asp:BoundField DataField="DataNascUsuario" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}"/>
     <asp:BoundField DataField="TipoUsuario_Id" HeaderText="Permissão" />
 </Columns>
</asp:GridView>
</asp:Content>
