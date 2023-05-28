<%@ Page Title="About" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="CarritoComprasLopta.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main aria-labelledby="title" >
        <h2 id="title"><%: Title %></h2>
        <h3 > Acerca de nosotros </h3>
        <p>Empresa familiar</p>
        <asp:GridView runat="server" ID="dgvArticulos" CssClass="table table-bordered table-dark"></asp:GridView>
        <asp:Button Text="Listar Con SP" ID="btnListarSP" OnClick="btnListarSP_Click" runat="server" />
    </main>
</asp:Content>
