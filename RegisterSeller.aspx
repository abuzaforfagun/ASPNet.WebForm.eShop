<%@ Page Title="" Language="C#" MasterPageFile="~/Login.master" AutoEventWireup="true" CodeFile="RegisterSeller.aspx.cs" Inherits="RegisterSeller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form-box" id="login-box">
        <div class="header">Sign Up</div>
            
            <div class="body bg-gray">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtName" class="form-control" placeholder="Name" />
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtEmail" class="form-control" placeholder="Email" />
                </div>

                <div class="form-group">
                    <asp:TextBox TextMode="Password" runat="server" ID="txtPassword" class="form-control" placeholder="Password"/>
                </div>
            </div>
            <div class="footer">                                                               
                <asp:Button runat="server" ID="btnRegister" OnClick="btnRegister_Click" CssClass="btn bg-olive btn-block" Text ="Register" />
                    
            </div>

    </div>
</asp:Content>

