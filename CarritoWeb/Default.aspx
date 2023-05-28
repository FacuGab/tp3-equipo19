<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarritoWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="row" aria-labelledby="aspnetTitle">
        <h1 id="aspnetTitle">Nuestros productos</h1>
        <p class="lead">Tecnologia</p>
        <%
            foreach (Dominio.Articulo articulo in listaArticulos) //cambiar a repeater despues x si se rompe en las exepciones
            {
        %>
        <div class="card m-3" style="width: 18rem;">
            <img src="<%:articulo.UrlImagen %>" height="330" onerror="this.src='./Recursos/image-not-found.png'" alt="Imagen del articulo" />
            <div class="card-body">
                <h5 class="card-title"><%:articulo.descripicion %></h5>
                <p class="card-text"><%:articulo.marca %></p>
                <asp:Button Text="Agregar" ID="btnAgregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" runat="server" />
            </div>
        </div>
        <%  }   %>
    </section>

</asp:Content>
