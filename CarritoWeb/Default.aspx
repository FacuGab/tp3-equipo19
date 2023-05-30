﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarritoWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">   
                <h1 id="nuestrosProd" class="text-center text-light mt-5 mb-5 p-2">Nuestros productos</h1>
                <h2 class="text-center text-light mt-5 mb-5 p-2">Cantidad de Articulos: <span class="badge text-bg-primary"><%: countArticulos %></span></h2>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <!--FILTROS LISTA PRINCIPAL -->
    <div class="row">
        <div class="col-lg-2"></div>
        <div class="col-lg-2">
            <div class="form-floating">
                <asp:TextBox runat="server" ID="tbFiltroRapido" value="" CssClass="form-control  " placeholder="Filtro Rápido" AutoPostBack="true" OnTextChanged="tbFiltroRapido_TextChanged" />
                <label for="tbFiltroRapido">Filtro rápido</label>
            </div>
        </div>
        <div class="col-lg-2">
            <div class="form-floating">
                <asp:DropDownList ID="ddlFiltroCategoria" CssClass="form-select h-1" runat="server"></asp:DropDownList>
                <label for="ddlFiltroCategoria">Categoría</label>
            </div>
        </div>
        <div class="col-lg-2">
            <div class="form-floating">
                <asp:DropDownList ID="ddlFiltroMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                <label for="ddlFiltroMarca">Marca</label>
            </div>
        </div>
        <div class="col-lg-2 ">
            <asp:Button ID="btnFiltro" runat="server" Text="Aplicar" CssClass="btn btn-primary" />
        </div>
        <div class="col-lg-2"></div>
    </div>

    <!-- LISTA PRINCIPAL -->
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <section class="row mt-3" aria-labelledby="aspnetTitle">

                <asp:Repeater ID="repListaPrincipal" runat="server">
                    <ItemTemplate>
                        <div class="card m-3 pt-2 bg-warning text-dark" style="width: 18rem;">
                            <div class="card-header text-center">
                                <%#DataBinder.Eval( Container.DataItem, "nombre") %>
                            </div>
                            <img src="<%#DataBinder.Eval( Container.DataItem, "UrlImagen") %>" class="card-img-top img-fluid imgCard" onerror="this.src='./Recursos/image-not-found.png'" alt="Imagen del articulo" />
                            <div class="card-body">
                                <h5 class="card-title card-header text-center"><%#DataBinder.Eval( Container.DataItem, "marca")%></h5>
                                <p class="card-text"><%#DataBinder.Eval( Container.DataItem, "descripicion")%></p>

                            </div>
                            <asp:Button Text="🛒 Agregar al carrito" ID="btnAgregar" CssClass="btn btn-outline-secondary mb-4 "  CommandArgument='<%#Eval("id")%>' CommandName="Id_articulo" OnClick="btnAgregar_Click" runat="server" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </section>
        </ContentTemplate>
    </asp:UpdatePanel>

    <!-- Fin Default.aspx -->
</asp:Content>

                <%--        <%
                    foreach (Dominio.Articulo articulo in listaArticulos) //cambiar a repeater despues x si se rompe en las exepciones
                    {
                %>
                        <div class="card m-3 pt-2 bg-warning text-dark" style="width: 18rem;">
                            <span style="display:none"><%:articulo.id %></span>
                            <div class="card-header text-center">
                                <%:articulo.nombre %>
                            </div>
                                <img src="<%:articulo.UrlImagen %>" class="card-img-top img-fluid imgCard" onerror="this.src='./Recursos/image-not-found.png'" alt="Imagen del articulo" />
                            <div class="card-body">
                                <h5 class="card-title card-header text-center"><%:articulo.marca %></h5>
                                <p class="card-text"><%:articulo.descripicion %></p>
 
                            </div>
                                <asp:Button Text="🛒 Agregar al carrito" ID="btnAgregar" CssClass="btn btn-outline-secondary mb-4 " OnClick="btnAgregar_Click" CommandArgument='<%:articulo.id %>' CommandName="Id_articulo" runat="server"/>
                        </div>
                <%  }   %>--%>