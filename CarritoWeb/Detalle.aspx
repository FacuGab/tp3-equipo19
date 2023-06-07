<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="CarritoWeb.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #cardDetalle {
            padding-top: 100px;
        }
    </style>
    <section class="row justify-content-md-center">

        <div class="col col-md-2">
        </div>
        <div class="col-6">
            <div class="card mb-3" id="cardDetalle" style="max-width: 540px;">
                <div class="row">
                    <div class="col-md-6" style="margin-left: 100px">
                        <%--<img src="<%:articulo.UrlImagen %>" onerror="this.src='./Recursos/image-not-found.png'" class="img-fluid rounded-start" alt="...">--%>
                        <div id="carouselExample" class="carousel slide">
                            <div class="carousel-inner">

                                <%
                                    if (imagenes_x_articulo == null) return;
                                    for(int i = 0; i < imagenes_x_articulo.Count;  i++)
                                    {
                                %>
                                <div class="carousel-item active">
                                    <img src="<%:imagenes_x_articulo[i] %>" onerror="this.src='./Recursos/image-not-found.png'" class="d-block w-100" alt="...">
                                </div>
                                <%
                                    } %>
                            </div>
                            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                            </button>
                        </div>
                    </div>
                    <div class="col-md-8">
                        <div class="card-body">
                            <h5 class="card-title">Nombre: <%:articulo.nombre %></h5>
                            <p class="card-text">Marca: <%:articulo.marca.marca %></p>
                            <p class="card-text">Categoria: <%:articulo.categoria.categoria%></p>
                            <p class="card-text">Descripcion: <%:articulo.descripicion %></p>
                            <p class="card-text">Esto es mas informacion sobre el articulo</p>
                            <p class="card-text">Precio: <%:articulo.precio %></p>
                            <p class="card-text"><small class="text-body-secondary">Ultimas 3 unidades!</small></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col col-md-2"></div>

    </section>
    <div class="row">
        <div class="col">
            <a href="Carrito.aspx" class="icon-link">Volver</a>
        </div>
    </div>

</asp:Content>
