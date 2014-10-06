<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="department.aspx.cs" Inherits="Project2.department" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="navigation">
    	<div class="button" onclick="location.href='./department.aspx';" style="cursor:pointer;">Departments</div>
		<div class="button_spacer"></div>
		<div class="button" onclick="location.href='./course.aspx';" style="cursor:pointer;">Courses</div>
		<div class="button_spacer"></div>
		<div class="button" onclick="location.href='./student.aspx';" style="cursor:pointer;">Students</div>
		<div class="button_spacer"></div>
		<div class="button" onclick="location.href='./register.aspx';" style="cursor:pointer;">Register</div>
	</div>
    <div>
        <asp:Label ID="lblDeptName" runat="server" Text="Department Name:"></asp:Label><br />
        <asp:TextBox ID="txtDeptName" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblDeptIDDept" runat="server" Text="Department ID:"></asp:Label><br />
        <asp:TextBox ID="txtDeptIDDept" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblLocation" runat="server" Text="Department Location:"></asp:Label><br />
        <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnCreateDept" runat="server" Text="Create Department" OnClick="btnCreateDepartment_Click" />
    </div>
    <div>
        <asp:GridView ID="gvDepartments" runat="server"></asp:GridView><br />
    </div>
    </form>
</body>
</html>
