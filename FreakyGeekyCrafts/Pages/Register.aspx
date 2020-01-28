<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FreakyGeekyCrafts.Pages.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Register</h1>
        <asp:Label ID="lblForename" runat="server" Text="Forename:"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtForename" ErrorMessage="Forename required" ForeColor="Red" ValidationGroup="EntryRequired"></asp:RequiredFieldValidator>
        <asp:TextBox ID="txtForename" class="form-control" Width="200px" runat="server" AutoPostBack="True"></asp:TextBox>
        <asp:Label ID="lblSurname" runat="server" Text="Surname:"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSurname" ErrorMessage="Surname required" ForeColor="Red" ValidationGroup="EntryRequired"></asp:RequiredFieldValidator>
        <asp:TextBox ID="txtSurname" class="form-control" Width="200px" runat="server"></asp:TextBox>
        <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email required"  ontextchanged="txtEmail_TextChanged" ForeColor="Red" ValidationGroup="EntryRequired"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email not valid" ForeColor="Red"></asp:CustomValidator>
        <asp:TextBox ID="txtEmail" class="form-control" Width="200px" runat="server" AutoPostBack="True" CausesValidation="True" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
        <asp:Label ID="lblPassword" runat="server" Text="Select password:"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password required" ForeColor="Red" ValidationGroup="EntryRequired"></asp:RequiredFieldValidator>
        <asp:TextBox ID="txtPassword" class="form-control" Width="200px" runat="server" AutoPostBack="True"></asp:TextBox>
        <asp:Label ID="lblUserType" runat="server" Text="Customer or Staff:"></asp:Label>
        <asp:DropDownList ID="ddlStaff" class="form-control" Width="200px" runat="server">
            <asp:ListItem Value="Customer"></asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address required" ForeColor="Red" ValidationGroup="EntryRequired"></asp:RequiredFieldValidator>
        <asp:TextBox ID="txtAddress" class="form-control" Width="200px" runat="server" AutoPostBack="True" CausesValidation="True"></asp:TextBox>
        <asp:Label ID="lblCity" runat="server" Width="200px" Text="City:"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCity" ErrorMessage="City required" ForeColor="Red" ValidationGroup="EntryRequired"></asp:RequiredFieldValidator>
        <asp:TextBox ID="txtCity" class="form-control" Width="200px" runat="server"></asp:TextBox>
        <asp:Label ID="lblPostcode" runat="server" Text="Postcode:"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPostcode" ErrorMessage="Postcode required" ForeColor="Red" ValidationGroup="EntryRequired"></asp:RequiredFieldValidator>
        <asp:TextBox ID="txtPostcode" class="form-control" Width="200px" runat="server"></asp:TextBox>
        <asp:Label ID="lblPhone" runat="server" Text="Phone Number:"></asp:Label>
        <asp:TextBox ID="txtPhone" class="form-control" Width="200px" runat="server"></asp:TextBox>
    <div>
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" ValidationGroup ="EntryRequired" style="height: 28px" />
        <asp:Label ID="lblWarning" runat="server"></asp:Label>
    </div>
</asp:Content>
