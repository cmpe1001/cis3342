<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pizzaShop.aspx.cs" Inherits="Project1.pizzaShop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pizza Ordering</title>
</head>
<body>
    <form id="form2" runat="server">
        <div id="ordering">
            <div id="customerInfo">
                <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label><br />
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
                <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label><br />
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox><br />
                <asp:Label ID="lblPhone" runat="server" Text="Phone Number:"></asp:Label><br />
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox><br />
                <asp:Label ID="lblTransfer" runat="server" Text="Pickup/Delivery:"></asp:Label><br />
                <asp:DropDownList ID="drpTransfer" runat="server">
                    <asp:ListItem Enabled="True" Value="delivery">Delivery</asp:ListItem>
                    <asp:ListItem Enabled="True" Value="pickup">Pick-Up</asp:ListItem>
                </asp:DropDownList><br />
            </div>
            <div id="menu">
                <asp:GridView ID="gvMenu" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="Select Pizza">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbBox" runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PizzaType" HeaderText="PizzaType" />
                        <asp:TemplateField HeaderText="Size">
                            <ItemTemplate>
                                <asp:DropDownList ID="drpSize" runat="server">
                                    <asp:ListItem Enabled="True" Value="1">Small</asp:ListItem>
                                    <asp:ListItem Enabled="True" Value="2">Medium</asp:ListItem>
                                    <asp:ListItem Enabled="True" Value="3">Large</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Order Quantity">
                            <ItemTemplate>
                                <asp:TextBox ID="txtQuantity" runat="server" Text="0"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView><br />
                <asp:Button ID="btnOrder" runat="server" Text="Place Order" OnClick="btnOrder_Click" /><br />
            </div>
        </div>
        <div id="orderInfo">
            <div id="custInfo">
                <asp:Label ID="lblOutputName" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblOutputAddress" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblOutputPhone" runat="server" Text=""></asp:Label><br />
            </div><br />
           <div id="order">
                <asp:GridView ID="gvOutput" runat="server" AutoGenerateColumns="false" ShowFooter="true">
                    <Columns>
                        <asp:BoundField DataField="PizzaType" HeaderText="PizzaType" />
                        <asp:BoundField DataField="PizzaSize" HeaderText="Size"  />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="Price" HeaderText="Price" />
                        <asp:BoundField DataField="Total" HeaderText="Total Cost" />
                    </Columns>
                </asp:GridView><br />
            </div>
        </div>
        <div id="managementReport">
            <asp:Button ID="btnReport" runat="server" Text="Management Report" OnClick="btnGenerateReport" /><br />
            <div id="reportGV">
                <asp:GridView ID="gvReport" runat="server"></asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
