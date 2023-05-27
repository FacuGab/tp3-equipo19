<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarritoWeb.Vistas.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-3"></div>
        <div class="col-6">
            <!-- LISTA -->
            <asp:GridView ID="dgvListaPrincipal" CssClass="table table-bordered table-dark" runat="server">
            </asp:GridView>
        </div>
        <div class="col-3"></div>
    </div>

</asp:Content>
