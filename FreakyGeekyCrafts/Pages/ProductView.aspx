<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="ProductView.aspx.cs" Inherits="FreakyGeekyCrafts.Pages.ProductView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     
<h1>Products</h1>
    <h2>Browse our beautiful handcrafted jewelry.</h2>
    
    
    <div class="col-lg-12 p-5 bg-white rounded shadow-sm mb-5">
        <asp:GridView ID="dvgProducts" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="dvgProducts_PageIndexChanging" OnSelectedIndexChanged="dvgProducts_SelectedIndexChanged" Font-Size="Medium">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="ProductID" HeaderText="Product ID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="RetailPrice" HeaderText="Price" />
                <asp:BoundField DataField="ImageFile" HeaderText="Image File" Visible="False" />
                <asp:ImageField DataImageUrlField="ImageFile" HeaderText="Product Image">
                    <ControlStyle Height="50px" Width="50px" />
                </asp:ImageField>
            </Columns>
            <FooterStyle Font-Size="Medium" />
        </asp:GridView>
    &nbsp;</div>
</asp:Content>
