<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="CarritoWeb.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />

    <div class="row mt-3">
        <asp:Repeater runat="server" ID="repEjemplo">
            <ItemTemplate>
                <div class="card m-3 pt-2 bg-warning text-dark" style="width: 18rem;">
                    <div class="card-header text-center">
                        <%#DataBinder.Eval( Container.DataItem, "nombre") %>
                    </div>
                    <!-- cards -->
                    <img src="<%#DataBinder.Eval( Container.DataItem, "UrlImagen") %>" class="card-img-top img-fluid imgCard" onerror="this.src='./Recursos/image-not-found.png'" alt="Imagen del articulo" />
                    <div class="row flex-wrap">
                        <h3>Seccion en desarrollo....</h3>
                        <div id="<%#Eval("id")%>" class="carousel slide carousel-fade">
                            <div class="carousel-inner">
                                    
                                    <%for (int i = 0; i < lista.Count; i++){
                                      %><div class="carousel-item active">
                                            <img src="<%#DataBinder.Eval( Container.DataItem, "imagenes[0]") %>" onerror="this.src='./Recursos/image-not-found.png'" class="d-block w-100" alt="...">
                                        </div>

                                    <%} %>
                                <%--<div class="carousel-item">
                                    <img src="Recursos/hellfish.png" class="d-block w-100" alt="...">
                                </div>
                                <div class="carousel-item">
                                    <img src="Recursos/the-simpsons-beatles.jpg" class="d-block w-100" alt="...">
                                </div>--%>
                            </div>
                            <button class="carousel-control-prev" type="button" data-bs-target="#<%#Eval("id")%>" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#<%#Eval("id")%>" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                            </button>
                        </div>
                    </div>
                    <!-- cards -->
                    <div class="card-body">
                        <h5 class="card-title card-header text-center"><%#DataBinder.Eval( Container.DataItem, "marca")%></h5>
                        <p class="card-text"><%#DataBinder.Eval( Container.DataItem, "descripicion")%></p>
                    </div>
                    <asp:Button Text="🛒 Agregar al carrito" ID="btnAgregar" CssClass="btn btn-outline-secondary mb-4 " CommandArgument='<%#Eval("id")%>' CommandName="Id_articulo" runat="server" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
