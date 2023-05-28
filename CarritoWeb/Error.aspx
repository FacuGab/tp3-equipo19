<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="CarritoWeb.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="mb-3">
            <h3>Error:</h3>
            <h4>
                <asp:Label Text="" ID="lblMsj" runat="server" />
                <asp:Label Text="" ID="lblPath" runat="server" />
            </h4>
        </div>
    </div>
</asp:Content>
