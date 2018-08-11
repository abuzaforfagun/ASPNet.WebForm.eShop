<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="archive.aspx.cs" Inherits="Archive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeHolderHeading" Runat="Server">
    Products
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="placeHolderContent" Runat="Server">
<table class="table table-hover table-condensed table-responsive">
    <thead>
        <tr>
            <th>SL</th>
            <th>Image</th>
            <th>Title</th>
            <th>Price</th>
            <th>Description</th>
            <th>Last Date</th>
            <th>Posted Date</th>
            <th>Winner</th>
            <th>Winning Price</th>
        </tr>
    </thead>
    <tbody>
        <asp:Label runat="server" ID="placeHolderTenderList"></asp:Label>
    </tbody>
        
</table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="placeHolderFooter" Runat="Server">
</asp:Content>

