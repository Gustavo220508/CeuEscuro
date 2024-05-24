<%@ Page Title="" Language="C#" MasterPageFile="~/user/ConsultaUser.Master" AutoEventWireup="true" CodeBehind="ConsultaFilm.aspx.cs" Inherits="CeuEscuro.UI.user.ConsultaFilm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--gridView--%>
 <asp:GridView ID="gv2" OnSelectedIndexChanged="gv2_SelectedIndexChanged" AutoGenerateColumns="false" runat="server">
     <Columns>
         <asp:CommandField ShowSelectButton="true" ButtonType="Button" HeaderText="Options" />
         <asp:BoundField DataField="Id" HeaderText="Código" />
         <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
         <asp:BoundField DataField="Produtora" HeaderText="Produtora" />
         <asp:BoundField DataField="Classificacao_Id" HeaderText="Classificação" />
         <asp:BoundField DataField="Genero_Id" HeaderText="Genero" />
         <asp:ImageField DataImageUrlField="UrlImg" HeaderText="Imagem" ControlStyle-Width="100" />
     </Columns>
 </asp:GridView>

</asp:Content>
