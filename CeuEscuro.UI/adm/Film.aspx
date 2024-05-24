<%@ Page Title="" Language="C#" MasterPageFile="~/adm/ManagerUser.Master" AutoEventWireup="true" CodeBehind="Film.aspx.cs" Inherits="CeuEscuro.UI.adm.Film" %>

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
            <asp:TextBox ID="txtTitulo" placeholder="Titulo:" MaxLength="150" runat="server"></asp:TextBox>
            <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:TextBox ID="txtProdutora" placeholder="Produtora:" MaxLength="150" runat="server"></asp:TextBox>
            <asp:Label ID="lblProdutora" runat="server" Text=""></asp:Label>
        </li>
        <%--<li>
            <asp:TextBox ID="txtSenha" placeholder="Senha:" MaxLength="6" runat="server"></asp:TextBox>
            <asp:Label ID="lblSenha" runat="server" Text=""></asp:Label>
        </li>--%>
        <%--<li>
            <asp:TextBox ID="txtDataNascUsuario" placeholder="Data de nascimento:" onkeypress="$(this).mask('00/00/0000')" runat="server"></asp:TextBox>
            <asp:Label ID="lblDataNascUsuario" runat="server" Text=""></asp:Label>
        </li>--%>
        <li>
            <span>Selecione a Classificacao</span>
        </li>
        <li>
            <asp:DropDownList
                ID="ddlClassif"
                Width="160px"
                weight="27px"
                AutoPostBack="false"
                DataValueField="Id"
                DataTextField="DescricaoClassif"
                runat="server">
            </asp:DropDownList>
        </li>
        <li>
            <span>Selecione o Genero</span>
        </li>
        <li>
            <asp:DropDownList
                ID="ddlGenero"
                Width="160px"
                weight="27px"
                AutoPostBack="false"
                DataValueField="Id"
                DataTextField="Descricao"
                runat="server">
            </asp:DropDownList>
        </li>
        <li>
            <asp:FileUpload ID="Fup" runat="server" />
            <asp:Label ID="lblFup" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:Button ID="btnRecord" runat="server" Text="Record" OnClick="btnRecord_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClientClick="if(!confirm('Deseja realmente eliminar esse registro ?'))return false" OnClick="btnDelete_Click" />
        </li>
        <li>
            <asp:TextBox ID="txtSearch" placeholder="Seach by Name:" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <asp:Label ID="lblSearch" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <%--filtro por genero--%>
            <asp:TextBox ID="txtFilters" placeholder="filter by genero:" runat="server"></asp:TextBox>
            <asp:Button ID="btnFilter" runat="server" OnClick="btnFilter_Click" Text="Filter" />
            <asp:Button ID="btnFilterClear" runat="server" OnClick="btnFilterClear_Click" Text="Clear Filter" />
            <asp:Label ID="lblFilter" runat="server" Text=""></asp:Label>
        </li>
    </ul>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

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
