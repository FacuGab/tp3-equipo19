<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="CarritoWeb.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="row mt-5" >

        <div class="col mt-5 mb-5" >
            <div class="card mt-5" id="cardDetalle" >
                <div class="row g-0">
                    <div class="col-md-6">
                        
                        <div id="carouselExample" class="carousel slide w-100 h-auto">
                            <div class="carousel-inner img-fluid" data-bs-interval="10000">

                                <%
                                    if (imagenes_x_articulo == null) return;
                                    for(int i = 0; i < imagenes_x_articulo.Count;  i++)
                                    {
                                %>
                                    <div class="carousel-item active w-100 h-80">
                                        <img src="<%:imagenes_x_articulo[i] %>" class="d-block w-100" alt="..." id="img-carousel">
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
                    <div class="card col-md-6">
                        <h5 class="card-header text-center "><%:articulo.nombre %></h5>
                        <div class="card-body ">
                            <h5 class="card-title fs-5 "><%:articulo.marca.marca %></h5>
                            <p class="card-text"><%:articulo.categoria.categoria%></p>
                            <p class="card-text"><%:articulo.descripicion%></p>
                            <p class="card-text">Precio: <%:articulo.precio %></p>
                            <a href="Carrito.aspx" class="btn btn-warning mt-4">Regresar</a>
                            <p class="card-text mt-5"><small class="text-body-secondary">Ultimas 3 unidades!</small></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
