<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="FreakyGeekyCrafts.Pages.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>My Bag</h1>

    <div class="pb-5">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 p-5 bg-white rounded shadow-sm mb-5">
                    <div class="table-responsive">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col" class="border-0 bg-light">
                                        <div class="p-2 px-3 text-uppercase">Product</div>
                                    </th>
                                    <th scope="col" class="border-0 bg-light">
                                        <div class="py-2 text-uppercase">Price</div>
                                    </th>
                                    <th scope="col" class="border-0 bg-light">
                                        <div class="py-2 text-uppercase">Quantity</div>
                                    </th>
                                    <th scope="col" class="border-0 bg-light">
                                        &nbsp;</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <th scope="row" class="border-0">
                                        <div class="p-2">
                                            <div class="ml-3 d-inline-block align-middle">
                                                <asp:ListBox ID="lstName" runat="server" Font-Size="Small" Height="141px" Width="182px"></asp:ListBox>
                                            </div>
                                        </div>
                                    </th>
                                    <td class="border-0 align-middle">
                                        <asp:ListBox ID="lstPrice" runat="server" Font-Size="Small" Height="144px" Width="143px"></asp:ListBox>
                                    </td>
                                    <td class="border-0 align-middle">
                                        <asp:ListBox ID="lstQuantity" runat="server" Font-Size="Small" Height="142px" Width="154px"></asp:ListBox>
        <asp:Button ID="btnRemove" class="btn btn-primary button-custom" runat="server" OnClick="btnRemove_Click" Text="Remove" />
        <asp:Button ID="btnEmpty" class="btn btn-primary button-custom" runat="server" OnClick="btnEmpty_Click" Text="Empty" />
                                    </td>
                                    <td class="border-0 align-middle"><a href="#" class="text-dark"><i class="fa fa-trash"></i></a></td>
                                </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row py-5 p-4 bg-white rounded shadow-sm">
        <div class="col-lg-6">
          <div class="bg-light rounded-pill px-4 py-3 text-uppercase font-weight-bold">Coupon code</div>
          <div class="p-4">
            <p class="font-italic mb-4">If you have a coupon code, please enter it in the box below</p>
            <div class="input-group mb-4 border rounded-pill p-2">
                <asp:TextBox ID="txtVoucherInput" runat="server" Width="339px"></asp:TextBox>
&nbsp;<div class="input-group-append border-0">
                  <asp:Button ID="Button1" runat="server" CssClass="btn btn-dark px-4 rounded-pill" OnClick="Button1_Click" Text="Apply Voucher" />
                    <asp:Label ID="lblVoucher" runat="server"></asp:Label>
              </div>
            </div>
          </div>
          <div class="bg-light rounded-pill px-4 py-3 text-uppercase font-weight-bold">Instructions for seller</div>
          <div class="p-4">
            <p class="font-italic mb-4">If you have some information for the seller you can leave them in the box below</p>
            <textarea name="" cols="30" rows="2" class="form-control"></textarea>
          </div>
        </div>
        <div class="col-lg-6">
          <div class="bg-light rounded-pill px-4 py-3 text-uppercase font-weight-bold">Order summary </div>
          <div class="p-4">
            <p class="font-italic mb-4">Shipping and additional costs are calculated based on values you have entered.</p>
            <ul class="list-unstyled mb-4">
              <li class="d-flex justify-content-between py-3 border-bottom"><strong class="text-muted">Order Subtotal: 
                  <asp:Label ID="lblPrice" runat="server" CssClass="font-weight-bold"></asp:Label>
                  </strong>
                   <strong  id="sub_total" runat="server"></strong>
              </li>
              <li class="d-flex justify-content-between py-3 border-bottom"><strong class="text-muted">Shipping and handling:</strong><strong>£2</strong></li>
                <li class="d-flex justify-content-between py-3 border-bottom"><strong class="text-muted">Total</strong>&nbsp;<h5 id="totalPrice" runat="server" class="font-weight-bold">£<strong class="text-muted"><asp:Label ID="lblTotal" runat="server"></asp:Label>
                    </strong></h5>
                </li>
            </ul>
              <asp:Label ID="lblWarning" runat="server" Font-Size="Large"></asp:Label>
              <asp:Button ID="btnPurchase" class="btn btn-dark rounded-pill py-2 btn-block" runat="server" OnClick="btnPurchase_Click" Text="Purchase" Visible="False" />
          </div>
        </div>
      </div>
        </div>
</div>
</asp:Content>
