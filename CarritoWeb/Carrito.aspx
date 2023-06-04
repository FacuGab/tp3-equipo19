<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="CarritoWeb.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />

    <!-- CARRITO -->
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
             <h1 id="nuestrosProd" class="text-center mt-5 mb-5 p-2">Mi Carrito de Compras</h1>
            <table style="width: 88%" class="table table-dark table-striped">
<%--        <tr>
            <td style="width: 77px">
                &nbsp;</td>
            <td style="width: 397px">
                <asp:TextBox ID="txtCodigo" runat="server" Visible="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>--%>
        <tr>
            <td style="width: 77px">
                <strong>Fecha :</strong></td>
            <td style="width: 397px">
                <asp:Label ID="lblFecha" runat="server" Text="Label"></asp:Label>
            </td>

        </tr>
<%--        <tr>
            <td style="width: 77px">
                Cliente :</td>
            <td style="width: 397px">
                <asp:TextBox ID="txtCliente" runat="server" Width="332px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>--%>
        <tr>
<%--            <td style="width: 77px">
                &nbsp;</td>
            <td colspan="2">--%>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" cssClass="table table-dark table-striped"
                    Width="505px" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="Quitar">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="19px" 
                                    ImageUrl="~/Recursos/Cerrar ventana.png" Width="20px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="nombre" HeaderText="Codigo" />
                        <asp:BoundField DataField="urlImagen" HeaderText="URL" />
                        <asp:BoundField DataField="marca" HeaderText="Marca" />
                        <asp:BoundField DataField="descripicion" HeaderText="Descripcion" />
                        <asp:TemplateField HeaderText="Cantidad">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Height="19px" Width="73px">1</asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 77px">
                &nbsp;</td>
            <td style="width: 397px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 77px">
                &nbsp;</td>
            <td style="width: 397px; text-align: right">
                SubTotal S/ :&nbsp; 
                <asp:Label ID="lblSubTotal" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 77px">
                &nbsp;</td>
            <td style="width: 397px; text-align: right">
                IGV S/ :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblIGV" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 77px">
                &nbsp;</td>
            <td style="width: 397px; text-align: right">
                Total S/ :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 77px">
                &nbsp;</td>
            <td style="width: 397px">
                <asp:Button ID="Button1" runat="server" Text="Actualizar" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
