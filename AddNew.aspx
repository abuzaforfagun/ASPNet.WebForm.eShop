<%@ Page Title="Add New Product" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddNew.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeHolderHeading" Runat="Server">
    Add New Product
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="placeHolderContent" Runat="Server">
    <div class="col-md-12">
        <asp:Label runat="server" ID="lblMessage" class="label-info label-success" /><br />
        <div class="form-group">
            <label>Title</label>
            <asp:TextBox runat="server" ID="txtTitle" class="form-control" />
        </div>

        <div class="form-group">
            <label>Description</label>
            <asp:TextBox TextMode="MultiLine" runat="server" ID="txtDescription" class="form-control" />
        </div>

        <div class="form-group">
            <label>Price</label>
            <asp:TextBox runat="server" ID="txtPrice" class="form-control" />
        </div>

        <div class="form-group">
            <label>Image</label>
            <asp:FileUpload runat="server" ID="fileImage" CssClass="form-control" />
        </div>


        <div class="form-group">
            <label>Last Date</label>
            <asp:TextBox runat="server" TextMode="Date" ID="txtLastDate" class="form-control" />
        </div>
        <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="Save" class="btn btn-primary" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="placeHolderFooter" Runat="Server">
</asp:Content>

