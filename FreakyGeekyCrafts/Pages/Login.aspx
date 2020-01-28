<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FreakyGeekyCrafts.Pages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   
    
   <section id="login">
        <h1>Login</h1>
            <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUsername" class="form-control" runat="server" Width="200px"></asp:TextBox>
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPassword" TextMode="Password" class="form-control" runat="server" Width="200px"></asp:TextBox>
            <asp:CheckBox ID="chkPersist" runat="server" Visible="False" />
            <asp:Label ID="lblWarning" runat="server" ForeColor="Red"></asp:Label>
        <div>
            <br />
            <asp:Button ID="btnLogin" class="btn btn-primary button-custom" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <asp:Button ID="btnRegister" class="btn btn-primary button-custom" runat="server" OnClick="Button2_Click" Text="Register" />
        </div>
    </section>
    
</asp:Content>
