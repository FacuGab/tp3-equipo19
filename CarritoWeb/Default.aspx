<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarritoWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <style>
        #filaTituloContador {
            padding-top: 50px; /* Manu!, si ves esto y pensas que se puede hacer mejor de otra forma, mandale */
        }
    </style>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row" id="filaTituloContador">
                <h1 id="nuestrosProd" class="text-center text-light mt-5 mb-5 p-2">Nuestros productos</h1>
                <h2 class="text-center text-light mt-5 mb-5 p-2">Cantidad de Articulos Seleccionados: <span class="badge text-bg-primary"><%: countArticulos %></span></h2>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <!--FILTROS LISTA PRINCIPAL -->
    <section class="row justify-content-center" style="margin-left: 100px">
        <div class="col-lg-2">
            <div class="form-floating">
                <asp:TextBox runat="server" ID="tbFiltroRapido" value="" CssClass="form-control  " placeholder="Filtro Rápido" AutoPostBack="true" OnTextChanged="tbFiltroRapido_TextChanged" />
                <label for="tbFiltroRapido">Filtro rápido</label>
            </div>
        </div>
        <div class="col-lg-2">
            <div class="form-floating">
                <asp:DropDownList ID="ddlFiltroCategoria" CssClass="form-select h-1" runat="server" AutoPostBack="false"></asp:DropDownList>
                <label for="ddlFiltroCategoria">Categoría</label>
            </div>
        </div>
        <div class="col-lg-2">
            <div class="form-floating">
                <asp:DropDownList ID="ddlFiltroMarca" CssClass="form-select" runat="server" AutoPostBack="false"></asp:DropDownList>
                <label for="ddlFiltroMarca">Marca</label>
            </div>
        </div>
        <div class="col-lg-2">
            <div class="form-floating">
                <asp:DropDownList ID="ddlCriterio" CssClass="form-select" runat="server" AutoPostBack="false"></asp:DropDownList>
                <label for="ddlFiltroMarca">Criterio</label>
            </div>
        </div>
        <div class="col-lg-2 ">
            <asp:Button ID="btnAgregarFiltro" runat="server" Text="Aplicar" OnClick="btnAgregarFiltro_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btnEliminarFiltro1" runat="server" Text="Eliminar" href="~/" OnClick="btnEliminarFiltro_Click" CssClass="btn btn-danger" />
        </div>
        <div class="col-lg-2"></div>
    </section>

    <!-- LISTA PRINCIPAL -->
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <section class="row mt-3" aria-labelledby="aspnetTitle">
                <!-- DATA LIST -->
                <asp:DataList ID="DataList1" runat="server" DataKeyField="Id" RepeatColumns="3" OnItemCommand="DataList1_ItemCommand">
                    <ItemTemplate>

                        <div class="card m-3 pt-2 bg-warning text-dark" style="width: 22rem;">
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
                                    <asp:Label ID="precioProdLabel" runat="server" Text='<%# Eval("roundPrecio") %>' CssClass="card-text" />
                                </p>
                            </div>
                            <asp:Button Text="🛒 Agregar" ID="btnAgregar" CssClass="btn btn-secondary mb-3 fs-5" CommandArgument='<%#Eval("id")%>' CommandName="Id_articulo" OnClick="btnAgregar_Click" runat="server" />
                            <asp:Label ID="lblAgregado" Text="" runat="server" CssClass="card-text" />
                        </div>

                    </ItemTemplate>
                </asp:DataList>
            </section>

        </ContentTemplate>
    </asp:UpdatePanel>

    <!-- Fin Default.aspx -->
</asp:Content>
