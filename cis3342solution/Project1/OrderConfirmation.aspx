<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderConfirmation.aspx.cs" Inherits="Project1.OrderConfirmation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="orderInfo">
            <div id="custInfo">
                <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lblPhone" runat="server" Text="Label"></asp:Label>
            </div><br />
           <div id="order">
                <asp:GridView ID="gvOutput" runat="server" AutoGenerateColumns="false" ShowFooter="true">
                    <Columns>
                        <asp:BoundField DataField="PizzaType" HeaderText="PizzaType" />
                        <asp:BoundField DataField="PizzaSize" HeaderText="Size" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="Price" HeaderText="Price" />
                        <asp:BoundField DataField="Total" HeaderText="Total Cost" />
                    </Columns>
                </asp:GridView><br />
            </div>
        </div>
    </form>
</body>
</html>
