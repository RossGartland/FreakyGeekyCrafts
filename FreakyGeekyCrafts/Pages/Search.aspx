<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="FreakyGeekyCrafts.Pages.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Search</h1>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Enter a search term: "></asp:Label>
    <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="True" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Search" />
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Click on a product in the box then click the button to see more."></asp:Label>
    <br />
    <br />
    <asp:ListBox ID="lstResults" runat="server" Height="185px" Width="235px"></asp:ListBox>
    <asp:Button ID="btnSelect" class="btn btn-primary button-custom" runat="server" OnClick="btnSelect_Click" Text="Select Product" />
    <br />
    <br />
    <asp:Label ID="lblResults" runat="server"></asp:Label>
</asp:Content>
