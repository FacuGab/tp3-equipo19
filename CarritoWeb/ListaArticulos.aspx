<%@ Page Title="About" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="CarritoComprasLopta.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main aria-labelledby="title" >
        <h2 id="title"><%: Title %></h2>
        <h3 > Acerca de nosotros </h3>
        <p>Empresa familiar</p>
        <asp:GridView runat="server" ID="dgvArticulos" CssClass="table table-bordered table-dark" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="Id"/>
                <asp:BoundField HeaderText="Codigo" DataField="codigo"/>
                <asp:BoundField HeaderText="Nombre" DataField="nombre"/>
                <asp:BoundField HeaderText="Descripcion" DataField="descripicion"/>
                <asp:BoundField HeaderText="Marca" DataField="marca.marca"/>
                <asp:BoundField HeaderText="Categoria" DataField="categoria.categoria"/>
                <asp:BoundField HeaderText="Precio" DataField="precio"/>
                <asp:BoundField HeaderText="Imagen" DataField="UrlImagen"/>
            </Columns>
        </asp:GridView>
    </main>
</asp:Content>
