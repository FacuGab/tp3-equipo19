<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarritoWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />

    <div class="row">
        <asp:Button Text="Cargar Carrito" CssClass="btn-primary" ID="btnCargarCarrito" OnClick="btnCargarCarrito_Click1" runat="server" />
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
            <asp:Button ID="btnFiltro" runat="server" Text="Aplicar" OnClick="btnFiltro_Click" CssClass="btn btn-primary" />
        </div>
        <div class="col-lg-2"></div>
    </section>

    <!-- LISTA PRINCIPAL -->
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <section class="row mt-3" aria-labelledby="aspnetTitle">
                <asp:Label ID="lblAgregado" runat="server" Text="Label"></asp:Label>
                <asp:DataList ID="DataList1" runat="server" DataKeyField="Id" RepeatColumns="3" OnItemCommand="DataList1_ItemCommand">
                    <ItemTemplate>

                        <div class="card m-3 pt-2 bg-warning text-dark" style="width: 18rem;">
                            <div class="card-header text-center">
                                <asp:Label ID="nomProdLabel" runat="server" Text='<%# Eval("nombre") %>' CssClass="fs-5" />
                                <asp:Image ID="ImageCard" runat="server" ImageUrl='<%# Eval("urlImagen") %>'
                                    class="card-img-top img-fluid imgCard" onerror="this.src='./Recursos/image-not-found.png'" />
                            </div>
                            <asp:Label ID="urlLabel" Visible="false" runat="server" Text='<%# Eval("urlImagen") %>' CssClass="fs-5" />
                            <div class="card-body">
                                <h5>
                                    <asp:Label ID="marcaProdLabel" runat="server" Text='<%# Eval("marca") %>' CssClass="card-title card-header text-center" /></h5>
                                <p>
                                    <asp:Label ID="descripProdLabel" runat="server" Text='<%# Eval("descripicion") %>' CssClass="card-text" />
                                </p>
                                <p>
                                    <asp:Label ID="precioProdLabel" runat="server" Text='<%# Eval("precio") %>' CssClass="card-text" />
                                </p>
                            </div>
                            <asp:Button Text="🛒 Agregar al carrito" ID="btnAgregar" CssClass="btn btn-outline-secondary mb-3 " CommandArgument='<%#Eval("id")%>' CommandName="Id_articulo" OnClick="btnAgregar_Click" runat="server" />
                        </div>

                    </ItemTemplate>
                </asp:DataList>
                <div>
                    <asp:Button Text="Cargar Carrito (solo por ahora)" runat="server" />
                </div>
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
