<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarritoWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />

    <div class="row">
        <asp:Button Text="Cargar Carrito" CssClass="btn-primary" OnClick="btnCargarCarrito_Click" runat="server" />
    </div>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <h1 id="nuestrosProd" class="text-center text-light mt-5 mb-5 p-2">Nuestros productos</h1>
                <h2 class="text-center text-light mt-5 mb-5 p-2">Cantidad de Articulos: <span class="badge text-bg-primary"><%: countArticulos %></span></h2>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <!--FILTROS LISTA PRINCIPAL -->
    <section class="row">
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
    </section>

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
                                <p class="card-text"><%#DataBinder.Eval( Container.DataItem, "id")%></p>
                            </div>
                            <asp:Button Text="🛒 Agregar al carrito" ID="btnAgregar" CssClass="btn btn-outline-secondary mb-4 " CommandArgument='<%#Eval("id")%>' CommandName="Id_articulo" OnClick="btnAgregar_Click" runat="server" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </section>
        </ContentTemplate>
    </asp:UpdatePanel>

    <!-- CARRITO -->
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <section class="row">
                <!--Canvas carrito de compras -->
                <div class="offcanvas offcanvas-end bg-black text-light w-25" tabindex="-1" id="offcanvasRight" aria-labelledby="offcanvasRightLabel">
                    <div class="offcanvas-header">
                        <h5 id="offcanvasRightLabel">Carrito de compras</h5>
                        <asp:Button Text="Eliminar Lista" ID="btnEliminarLsCarrito" CssClass="btn" OnClick="btnEliminarLsCarrito_Click" runat="server" />
                        <button type="button" class="btn-link text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                    </div>
                    <div class="offcanvas-body">
                        <!-- ACA IRIA LA LISTA DE ARTICULOS EN EL CARRITO (ESTO TENDRIA QUE IR EN UNA REP, FOREACH O DGV PARA CARGAR DE UNA LISTA FILTRADA) -->
                        <p>
                            <label>Cantidad de Articulos</label>
                            <asp:Label Text="0" ID="lblCantArtCarrito" runat="server" />
                        </p>
                        <p>
                            <label>Total:</label>
                            <asp:Label Text="0$" ID="lblTotalCarrito" runat="server" />
                        </p>
                        <p>
                            <asp:GridView runat="server" ID="dgvCarrito">
                                <%--<label>Articulo XXX</label>
                            <label>Cantidad: XXX</label>
                            <label>Precio: XXX</label>
                            <button class="btn btn-success">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-check" viewBox="0 0 16 16">
                                    <path d="M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425a.267.267 0 0 1 .02-.022z" />
                                </svg>
                            </button>
                            <button class="btn btn-danger">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-check" viewBox="0 0 16 16">
                                    <path d="M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425a.267.267 0 0 1 .02-.022z" />
                                </svg>
                            </button>--%>
                            </asp:GridView>
                        </p>
                    </div>
                </div>
                <!-- Fin Canvas -->
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- Fin Default.aspx -->
</asp:Content>
