<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarritoWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="row" aria-labelledby="aspnetTitle">

            <h1 id="aspnetTitle">Nuestros productos</h1>
            <p class="lead">Tecnologia</p>
            <%
                foreach (Dominio.Articulo articulo in listaArticulos)
                {
            %>
                    <div class="card m-3" style="width: 18rem;">
                        <img src="<%:articulo.UrlImagen %>" alt="Imagen del articulo" />
                        <div class="card-body">
                            <h5 class="card-title"><%:articulo.descripicion %></h5>
                            <p class="card-text"><%:articulo.marca %></p>
                            <a href="#" class="btn btn-primary">Go somewhere</a>
                        </div>
                    </div>
            <%  }   %>
        </section>

</asp:Content>
