<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="FreakyGeekyCrafts.Secure.ProductEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
       <h1>Edit a product</h1>
    <div class="col-lg-12 p-5 bg-white rounded shadow-sm mb-5">
        <div class="form-group">
            <asp:Label ID="lblProduct" runat="server">Select a product to edit details</asp:Label>
            <asp:DropDownList ID="ddlProducts" class="form-control form-control-sm" Width="200px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <asp:Panel ID="Panel1" runat="server" style="margin-bottom: 133px" Visible="False">
        
            <br />
        
            <asp:Image ID="imgProduct" runat="server" Height="150px" Width="150px" />
            <asp:FileUpload ID="filProductImage" runat="server" />
            <asp:Button ID="btnUpload" class="btn btn-primary button-custom" runat="server" Text="Upload Image" OnClick="btnUpload_Click" />
            <asp:Label ID="lblWarning" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Current Details. Enter data into textboxes of fields you wish to edit. "></asp:Label>
       
            <br />
            <br />
       
            <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label>
            <asp:Label ID="lblName" runat="server"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" CssClass="auto-style1"></asp:TextBox>
        
      
            <br />
            <br />
        
      
            <asp:Label ID="Label2" runat="server" Text="Description: "></asp:Label>
            <asp:Label ID="lblDescription" runat="server"></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
        
            <br />
            <br />
        
            <asp:Label ID="Label3" runat="server" Text="Price: £"></asp:Label>
            <asp:Label ID="lblPrice" runat="server"></asp:Label>
            <asp:TextBox ID="txtPrice" runat="server" CssClass="auto-style2"></asp:TextBox>
       
        
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Edit confirms the changes. Clear empties the textboxs and Restock refills product stock to maximum."></asp:Label>
       
        
            <br />
            <br />
       
        
            <asp:Button ID="btnEdit" class="btn btn-primary button-custom" runat="server" OnClick="btnEdit_Click" Text="Edit" />
            <asp:Button ID="btnClear" class="btn btn-primary button-custom" runat="server" OnClick="btnClear_Click" Text="Clear" />
            <asp:Button ID="btnRestock" class="btn btn-primary button-custom" runat="server" Text="Restock" OnClick="btnRestock_Click1" />
            <br />
            <br />
            <asp:Button ID="btnDelete" class="btn btn-primary button-custom" runat="server" OnClick="btnDelete_Click" Text="Delete Product" />
       
            <asp:CheckBox ID="chkDelete" runat="server" Text="Confirm Deletion" />
            <br />
            <asp:Label ID="Label5" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
       
        </asp:Panel>
   </div>
    </asp:Content>
