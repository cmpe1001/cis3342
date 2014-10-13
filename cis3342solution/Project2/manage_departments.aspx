<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manage_departments.aspx.cs" Inherits="Project2.manage_departments" %>
<%@ Register TagPrefix="uc" TagName="Navigation" Src="navigation.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Departments</title>
    <link href="css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:Navigation runat="server" />
        <div id="page_name">Manage Departments</div>
        <div>
            <asp:label ID="lblName" runat="server" Text="Department Name:" />
            <asp:TextBox ID="txtName" runat="server" /><br />
            <asp:Label ID="lblDeptID" runat="server" Text="Department ID:" />
            <asp:TextBox ID="txtDeptID" runat="server" /><br />
            <asp:Label ID="lblLocation" runat="server" Text="Location:" />
            <asp:TextBox ID="txtLocation" runat="server" /><br />
            <asp:Label ID="lblErrorOutput" runat="server" Visible="false" /><br />
            <asp:Button ID="btnCreateDept" runat="server" Text="Create Department" OnClick="btnCreateDept_Click" />
        </div>
        <div>
            <p>Current Departments:</p>
            <asp:GridView ID="gvDepts" runat="server" />
       </div>
    </form>
</body>
</html>