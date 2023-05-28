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

        <!-- Button trigger modal -->
        <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
            Launch demo modal
        </button>
        <%--<asp:Button Text="text" class="btn btn-primary"  runat="server" />--%>
        <!-- Modal -->
        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="exampleModalLabel">Modal title</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        ...
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary">Save changes</button>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
