<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="SelectedProduct.aspx.cs" Inherits="FreakyGeekyCrafts.Pages.SelectedProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
 <h1 runat="server" id="productTitle">Products</h1>
    <div class="card mt-4">
        <div class="card-body">
            <h3 runat="server" id="productName" class="card-title jimjojin"></h3>
            <h4 runat="server" id="productPrice">
                <asp:Label ID="lblTitle" runat="server" Font-Size="1.6em"></asp:Label>
                </h4>
            <p runat="server" id="productDesc" class="card-text">
                <asp:Image ID="imgProduct" runat="server" Height="200px" Width="200px" />
            </p>
            <p runat="server" class="card-text">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="1.1em" Text="Description: "></asp:Label>
<asp:Label ID="lblDescription" runat="server" Font-Bold="True" Font-Size="1.1em"></asp:Label>
            </p>
            <p runat="server" class="card-text">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="1.1em" Text="Price: £"></asp:Label>
                <asp:Label ID="lblPrice" runat="server" Font-Bold="True" Font-Size="1.1em"></asp:Label>
            </p>
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="1.1em" Text="Quantity"></asp:Label>
            <div>              
                <h4 runat="server" id="productID">
                <asp:Label ID="lblWarning" runat="server" Font-Bold="True" Font-Size="1.1em"></asp:Label>
                    <asp:DropDownList ID="ddlStock" runat="server" OnSelectedIndexChanged="ddlStock_SelectedIndexChanged" AutoPostBack="True" Visible="False">
                </asp:DropDownList>
                </h4>
                <p runat="server">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="1.1em" Text="Total Price:" Visible="False"></asp:Label>
                    <asp:Label ID="lblTotalPrice" runat="server" Font-Bold="True" Font-Size="1.1em" Visible="False"></asp:Label>
                </p>
            </div>

            <div class="btn-group cart">
                <asp:Button ID="btnAdd" runat="server" Text="Add to bag" Class="btn btn-primary button-custom" OnClick="btnAdd_Click" Visible="False" />
            </div>
        </div>
    </div>

    <div class="card card-outline-secondary my-4">
        <div class="card-header">
            Product Reviews
         
        </div>
        <div class="card-body">
            <asp:Panel ID="pnlReviews" runat="server">
            </asp:Panel>
            <br />
            <asp:Label ID="lblReview" runat="server" Text="Enter a review for this product."></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Height="78px" TextMode="MultiLine" ToolTip="Enter review text here" Width="444px"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="btnReview" runat="server" Text="Add a review" Class="btn btn-primary button-custom" OnClick="btnReview_Click" />
            <asp:Label ID="lblReviewWarning" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
