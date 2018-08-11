<%@ Page Title="" Language="C#" MasterPageFile="~/Login.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form-box" id="login-box">
        <div class="header">Sign In</div>
            
            <div class="body bg-gray">
                <div class="form-group">
                    <asp:Label runat="server" ID="lblMessage" />
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtUserId" class="form-control" placeholder="Email" />
                </div>
                <div class="form-group">
                    <asp:TextBox TextMode="Password" runat="server" ID="txtPassword" class="form-control" placeholder="Password"/>

                </div>

            </div>
            <div class="footer">                                                               
                <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" CssClass="btn bg-olive btn-block" Text ="Sing me in" />
                    <a href="RegisterBuyer.aspx">Register as Buyer</a><br />
                    <a href="RegisterSeller.aspx">Register as Seller</a>
            </div>

    </div>
</asp:Content>

