<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pizzaShop.aspx.cs" Inherits="Project1.pizzaShop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gvMenu" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Select Pizza">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbBox" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PizzaType" HeaderText="PizzaType" />
                <asp:BoundField DataField="BasePrice" HeaderText="Price" />
                <asp:TemplateField HeaderText="Order Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gvOutput" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
