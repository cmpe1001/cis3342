<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientManagement.aspx.cs" Inherits="Project3.clientManagement" %>
<%@ Register TagPrefix="uc" TagName="Navigation" Src="navigation.ascx" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <title>Clients</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc:Navigation runat="server" />
        <div id="main">
            <div id="buttons">
                <asp:Button ID="btnNewClient" runat="server" Text="New Client" OnClick="btnNewClient_Click" CssClass="Button" />
                <asp:Button ID="btnShowClients" runat="server" Text="Show Clients" OnClick="btnShowClients_Click" CssClass="Button" />
            </div>
            <div id="errorField" runat="server" visible="false">
                <asp:Label ID="lblErrors" runat="server" />
            </div>
            <div id="clientFields" runat="server" visible="false">
                <asp:Label ID="lblClientName" runat="server" Text="Client Name:" CssClass="Label" /><asp:TextBox ID="txtClientName" runat="server" CssClass="Control" /><br />
                <asp:Label ID="lblClientPhone" runat="server" Text="Client Phone:" CssClass="Label" /><asp:TextBox ID="txtClientPhone" runat="server" CssClass="Control" /><br />
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="Button" />
            </div>
            <div id="clientTable" runat="server" visible="false">
                <asp:GridView ID="gvClients" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
