<%@ Page Title="Applied Products" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="winningproduct.aspx.cs" Inherits="WinningProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeHolderHeading" Runat="Server">
    Applied Products
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="placeHolderContent" Runat="Server">
    <table class="table table-hover table-condensed table-responsive">
    <thead>
        <tr>
            <th>SL</th>
            <th>Title</th>
            <th>Buyer </th>
            <th>Description</th>
            <th>Bid</th>
            <th>Last Date</th>
            <th>Posted Date</th>
        </tr>
    </thead>
    <tbody>
        <asp:Label runat="server" ID="placeHolderTenderList"></asp:Label>
    </tbody>
        
</table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="placeHolderFooter" Runat="Server">
</asp:Content>

