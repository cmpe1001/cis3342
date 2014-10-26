<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="realtor_management.aspx.cs" Inherits="Project3.realtor_management" %>
<%@ Register TagPrefix="uc" TagName="Navigation" Src="navigation.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Realtors/Sheduled Viewings</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:Navigation ID="Navigation1" runat="server" />
        <div id="main">
            <div id="buttons"></div>
            <div id="errorField" runat="server" visible="false">
                <asp:Label ID="lblErrors" runat="server" />
            </div>
            <div id="realtorSelection" runat="server">
                <asp:Label ID="lblRealtor" runat="server" Text="Realtor:" /><asp:DropDownList ID="ddlRealtors" runat="server" CssClass="Control"/><br />
                <asp:Button ID="btnShowListings" runat="server" Text="Show Viewings" OnClick="btnShowListings_Click" CssClass="Button"/>
                <asp:GridView ID="gvListings" runat="server" AutoGenerateColumns="false" OnRowCommand="gvListings_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="homeID" HeaderText="Home ID" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="City" HeaderText="City" />
                        <asp:BoundField DataField="State" HeaderText="State" />
                        <asp:BoundField DataField="Date" HeaderText="Date" />
                        <asp:BoundField DataField="Name" HeaderText="Client Name" />
                        <asp:BoundField DataField="hsrID" HeaderText="Viewing ID" />
                        <asp:ButtonField ButtonType="Button" Text="Cancel Viewing" CommandName="cancelViewing" ControlStyle-CssClass="Button"/>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>