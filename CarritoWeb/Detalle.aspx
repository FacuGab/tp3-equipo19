<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="CarritoWeb.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #cardDetalle {
            margin-top: 15px;
        }
    </style>
    <section class="row">
        <div class="col-3"></div>
        <div class="col">
            <div class="card mb-3" id="cardDetalle" style="max-width: 540px;">
                <div class="row g-0">
                    <div class="col-md-4">
                        <img src="Recursos/image-not-found.png" class="img-fluid rounded-start" alt="...">
                    </div>
                    <div class="col-md-8">
                        <div class="card-body">
                            <h5 class="card-title">NOMBRE DE ARTICULO</h5>
                            <p class="card-text">Esta es una descripcion de un articulo</p>
                            <p class="card-text">Esto es mas informacion sobre el articulo</p>
                            <p class="card-text">Este es el precio de un articulo</p>
                            <p class="card-text"><small class="text-body-secondary">Ultimas 3 unidades!</small></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-2"></div>
    </section>
</asp:Content>
