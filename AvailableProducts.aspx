<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AvailableProducts.aspx.cs" Inherits="AvailableTenders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/datatables/dataTables.bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeHolderHeading" Runat="Server">
    Available Products
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="placeHolderContent" Runat="Server">
    <div class="col-md-4">
        <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="col-md-4">
        <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" Text="Search"/>
    </div>
    <div class="clearfix"></div>
<table id="tblList" class="table table-hover table-condensed table-responsive">
    <thead>
        <tr>
            <th>SL</th>
            <th>Title</th>
            <th>Buyer</th>
            <th>Description</th>
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
    <script src="js/AdminLte/plugins/datatables/jquery.dataTables.js" ></script>
    <script>
        $(document).ready(function () {
            $('#tblList').DataTables();
        });
    </script>
</asp:Content>

