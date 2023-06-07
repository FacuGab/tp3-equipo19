<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="CarritoWeb.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <style>
        #filaCardCarrito {
            margin-top: 350px;
            margin-bottom: 350px;
        }
    </style>
    <section class="container" id="section_carrito">
        <div class="row" >
            <div class="card text-center  bg-warning" id="filaCardCarrito">
                <div class="card-header">
                    <h3>Resumen Carrito</h3>
                </div>
                <div class="card-body ">
                    <div class="row">

                        <div class="col-2"></div>
                        <div class="col">
                            <!-- CARRITO -->
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="dgvCarrito" runat="server" AutoGenerateColumns="False" CssClass="table table-warning table-striped table-hover " Width="800px">
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:Image runat="server" Height="60px" ImageUrl='<%#Eval("urlImagen") %>' onerror="this.src='./Recursos/image-not-found.png'" Width="60px" CssClass="ml-2"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Quitar">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ibtEliminar" CssClass="mt-3" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="eliminar_btn" OnClick="ibtEliminar_Click" Height="29px" ImageUrl="~/Recursos/Eliminar.png" Width="29px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Nombre">
                                                <ItemTemplate>
                                                    
                                                    <asp:Label runat="server" Text='<%# Eval("nombre") %>' cssClass="mt-3" ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Precio">
                                                <ItemTemplate>
                                                    
                                                    <asp:Label runat="server" Text='<%# Eval("roundPrecio") %>' cssClass="mt-3" ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Cantidad">
                                                <ItemTemplate>
                                                    
                                                    <asp:Label runat="server" Text='<%# Eval("cantidad") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Ir">
                                                <ItemTemplate>
                                                    <asp:LinkButton Text="Detalle" ID="linkDetalle" OnClick="linkDetalle_Click" CommandArgument='<%#Eval("Id") %>' CommandName="linkDetalle" runat="server"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="" >
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnAgregar" ImageUrl="~/Recursos/agregar.png" Height="19" Width="20" runat="server" OnClick="btnAgregar_Click"
                                                        CommandArgument='<%#Eval("Id") %>' CommandName="btnAgregar" cssClass="mt-3"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnQuitar" ImageUrl="~/Recursos/minimizar.png" Height="19" Width="20" runat="server" OnClick="btnQuitar_Click"
                                                        CommandArgument='<%#Eval("Id") %>' CommandName="btnRestar" cssClass="mt-3" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate >

                                    <h5 class="card-title">Total</h5>
                                    <p class="card-text"><%:totalFinal %> $ </p>
                                    <h5 class="card-title">Total de Unidades</h5>
                                    <p class="card-text"><%: countItemCarrito %> unidades </p>
                                    <a href="Default.aspx" class="btn btn-primary mt-3 btn-sm">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-backspace-fill mb-1" viewBox="0 0 16 16">
                                            <path d="M15.683 3a2 2 0 0 0-2-2h-7.08a2 2 0 0 0-1.519.698L.241 7.35a1 1 0 0 0 0 1.302l4.843 5.65A2 2 0 0 0 6.603 15h7.08a2 2 0 0 0 2-2V3zM5.829 5.854a.5.5 0 1 1 .707-.708l2.147 2.147 2.146-2.147a.5.5 0 1 1 .707.708L9.39 8l2.146 2.146a.5.5 0 0 1-.707.708L8.683 8.707l-2.147 2.147a.5.5 0 0 1-.707-.708L7.976 8 5.829 5.854z" />
                                        </svg> Catalogo</a>

                                    <asp:Button Text="❌ Eliminar" ID="btnEliminar" CssClass="btn btn-danger mt-3 btn-sm" OnClick="btnEliminar_Click" runat="server" />

                                </ContentTemplate>
                            </asp:UpdatePanel>
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
