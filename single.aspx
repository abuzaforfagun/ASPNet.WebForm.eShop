<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="single.aspx.cs" Inherits="Single" %>

<script runat="server">

    protected void btnSaveAmount_Click(object sender, EventArgs e)
    {

    }
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeHolderHeading" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="placeHolderContent" Runat="Server">
    <div>
        <h3><asp:Label runat="server" ID="lblTitle" /></h3>
        <label>Host: <asp:Label runat="server" ID="lblHost" /></label><br />
        <label>Posted Date: <asp:Label runat="server" ID="lblPostDate" ></asp:Label></label> | <label>Last Date: <asp:Label runat="server" ID="lblLastDate" /></label> <br />
        <hr />
        <label>Min Price: <asp:Label runat="server" ID="lblPrice" /></label><br />

    </div>
    <div>
        <p><asp:Label runat="server" ID="lblDescription" /></p>
    </div>

    <div runat ="server" id="divBidNow">
        
        <div class="form-group  col-md-4">
            <label>Amount</label>
            <asp:TextBox runat="server" ID="txtAmount" CssClass="form-control"></asp:TextBox>
            <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" />
        </div>
    </div>
    <div runat="server" id="divBidAmount" visible="false">
        <label>Your Bid: <b><asp:Label runat="server" ID="lblYourBid" /></b></label>
    </div>

    <div runat="server" id="divWinning" visible="false">
        <hr />
        <label>Winning Price: <asp:Label runat="server" ID="lblWiningPrice" /></label><br />
        <label>Winner: <asp:Label runat="server" ID="lblWinner" /></label>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="placeHolderFooter" Runat="Server">
</asp:Content>

