<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webform01.aspx.cs" Inherits="WebApplication1.webform01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:TextBox ID="txtInput1" runat="server"></asp:TextBox>
        <asp:DropDownList ID="dropFunction" runat="server">
            <asp:ListItem Value="add">+</asp:ListItem>
            <asp:ListItem Value="subtract">-</asp:ListItem>
            <asp:ListItem Value="multiply">*</asp:ListItem>
            <asp:ListItem Value="divide">/</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtInput2" runat="server"></asp:TextBox>=<asp:TextBox ID="txtOutput" runat="server"></asp:TextBox>
        
        <asp:Button ID="btnCalculate" runat="server" OnClick="Button1_Click" Text="Math it out" />
    
    </div>
    </form>
</body>
</html>
