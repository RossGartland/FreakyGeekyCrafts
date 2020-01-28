<%@ Page Title="" Language="C#" MasterPageFile="../Master/Main.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="FreakyGeekyCrafts.Pages.Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Account Page</h1>

    <div class="form-group">
        <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="ACCOUNT"></asp:Label>
    </div>


    <asp:Label ID="lblName" runat="server"></asp:Label>

    <br />

    <asp:Label ID="lblAccountStatus" runat="server"></asp:Label>

    <br />

    <asp:Label ID="lblAddress" runat="server"></asp:Label>

    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="All previous Invoices"></asp:Label>
    <br />

    <asp:ListBox ID="lstInvoices" runat="server" CssClass="auto-style1" Height="187px" Width="511px"></asp:ListBox>
    <br />
    <br />
    <div>


        <asp:Button ID="Button1" class="btn btn-primary button-custom" runat="server" Text="Edit/delete product details" OnClick="Button1_Click" Visible="False" />
        <asp:Label ID="lblWarning" runat="server"></asp:Label>
        <asp:Button ID="btnAdd" class="btn btn-primary button-custom" runat="server" Text="Add Product" OnClick="btnAdd_Click" />
    </div>
</asp:Content>