<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="OrderConfirmation.aspx.cs" Inherits="FreakyGeekyCrafts.Pages.OrderConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
 <h1>Order Confirmation</h1>
        <asp:Label ID="lblTitle" runat="server" Text="ORDER COMPLETE" Font-Size="1.1em"></asp:Label>
        <br />
        <div>
            <asp:Label ID="lblInvoice" runat="server" Text="Invoice Number:" Font-Size="1.1em"></asp:Label>
            <asp:Label ID="lblInvoiceDisplay" runat="server" Font-Size="1.1em"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblPrice" runat="server" Text="Total Price:" Font-Size="1.1em"></asp:Label>
            <asp:Label ID="lblPriceDisplay" runat="server" Font-Size="1.1em"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblDate" runat="server" Text="Date:" Font-Size="1.1em"></asp:Label>
            <asp:Label ID="lblDateDisplay" runat="server" Font-Size="1.1em"></asp:Label>
            <br />
        </div>
    <div>
        <asp:Button ID="Button1" class="btn btn-primary button-custom" runat="server" OnClick="Button1_Click" Text="Previous Purchases" />
    </div>
</asp:Content>
