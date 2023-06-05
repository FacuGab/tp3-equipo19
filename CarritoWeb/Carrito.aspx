<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="CarritoWeb.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <style>
        #section_carrito {
            margin-top: 200px
        }
    </style>
    <section class="container" id="section_carrito">
        <div class="row">
            <div class="card text-center">
                <div class="card-header">
                    <h3>Resumen Carrito</h3>
                </div>
                <div class="card-body">
                    <div class="row">

                        <div class="col-2"></div>
                        <div class="col">
                            <!-- CARRITO -->
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="dgvCarrito" runat="server" AutoGenerateColumns="False" CssClass="table table-dark table-striped" Width="505px">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Quitar">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="19px" ImageUrl="~/Recursos/Eliminar.png" Width="20px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="nombre" HeaderText="Codigo" />
                                            <asp:BoundField DataField="roundPrecio" HeaderText="Precio" />
                                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                            <asp:TemplateField HeaderText="Ir">
                                                <ItemTemplate>
                                                    <asp:LinkButton Text="Detalle" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="+/-">
                                                <ItemTemplate>
                                                    <asp:ImageButton id="btnAgregar" ImageUrl="~/Recursos/agregar.png" Height="19" Width="20" runat="server" />
                                                    <asp:ImageButton id="btnQuitar" ImageUrl="~/Recursos/minimizar.png" Height="19" Width="20" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col">
                            <h5 class="card-title">Total</h5>
                            <p class="card-text"><%:totalFinal %> $ </p>
                            <h5 class="card-title">Total de Unidades</h5>
                            <p class="card-text"><%: countItemCarrito %> unidades </p>
                            <a href="Default.aspx" class="btn btn-primary">Volver a Catalogo</a>
                            <a href="#" class="btn btn-primary">Eliminar</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <br />

        </div>
    </section>

</asp:Content>
