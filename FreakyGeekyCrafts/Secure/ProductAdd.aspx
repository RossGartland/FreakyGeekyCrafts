<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="ProductAdd.aspx.cs" Inherits="FreakyGeekyCrafts.Secure.ProductAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Add A Product</h1>
        <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Name textbox can't be blank" ForeColor="Red" ValidationGroup="grpRequired"></asp:RequiredFieldValidator>
        <asp:TextBox ID="txtName" class="form-control" width="200px" runat="server"></asp:TextBox>
    
    <asp:Label ID="lblDesc" runat="server" Text="Description:"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDesc" ErrorMessage="Description textbox can't be blank" ForeColor="Red" ValidationGroup="grpRequired"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtDesc" class="form-control" width="200px" runat="server"></asp:TextBox>
    <asp:Label ID="lblType" runat="server" Text="Product Type:"></asp:Label>
    <asp:DropDownList ID="ddlType" class="dropdown" runat="server">
        <asp:ListItem>Earring</asp:ListItem>
        <asp:ListItem>Ring</asp:ListItem>
        <asp:ListItem>Bracelets</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblPrice" runat="server" Text="Price:"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPrice" ErrorMessage="Price textbox can't be blank" ForeColor="Red" ValidationGroup="grpRequired"></asp:RequiredFieldValidator>
  
    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPrice" ErrorMessage="Price must be greater than 0" ForeColor="Red" MaximumValue="5000" MinimumValue="0.01" ValidationGroup="grpRange"></asp:RangeValidator>
    <asp:TextBox ID="txtPrice" class="form-control" width="200px" runat="server"></asp:TextBox>
     
    <asp:Label ID="lblStock" runat="server" Text="Max Stock Level:"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtStock" ErrorMessage="Stock textbox can't be blank" ForeColor="Red" ValidationGroup="grpRequired"></asp:RequiredFieldValidator>
  
    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtPrice" ErrorMessage="Max stock must be greater than 0" ForeColor="Red" MaximumValue="5000" MinimumValue="0.01" ValidationGroup="grpRange"></asp:RangeValidator>
    <asp:TextBox ID="txtStock" class="form-control" width="200px" runat="server"></asp:TextBox>
    
    <asp:Label ID="lblFile" runat="server" Text="Image File"></asp:Label>
    <asp:FileUpload ID="filImage" runat="server" />
    <br>
    <br />
    <asp:Button ID="btnAdd" class="btn btn-primary button-custom" runat="server" OnClick="btnAdd_Click" Text="Add Product" />
    <asp:Label ID="lblWarning" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>
