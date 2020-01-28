<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="FreakyGeekyCrafts.Pages.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Send us a message</h1>
        <label>Forename</label>
        <asp:TextBox ID="txtForename" class="form-control" placeholder="Enter forename" runat="server"></asp:TextBox>
        <label>Surname</label>
        <asp:TextBox ID="txtSurname" class="form-control" placeholder="Enter surname" runat="server"></asp:TextBox>
        <label>Email address</label>
        <asp:TextBox ID="txtEmail" class="form-control" aria-describedby="emailHelp" placeholder="Enter email" runat="server"></asp:TextBox>
        
        <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
        <label>Comment</label>
        <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
    <asp:Button ID="btnSubmit" type="submit" class="btn btn-primary button-custom" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
</asp:Content>