<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Project2.register" %>

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
        <asp:Label ID="lblStudentIDReg" runat="server" Text="Student ID:"></asp:Label><br />
        <asp:TextBox ID="txtStudentIDReg" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblCRNReg" runat="server" Text="CRN:"></asp:Label><br />
        <asp:TextBox ID="txtCRNReg" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnRegCourse" runat="server" Text="Register for Course" OnClick="btnRegCourse_Click" />
    </div>
    <div>
        <asp:GridView ID="gvRegistrations" runat="server"></asp:GridView><br />
    </div>
    <div>
        <asp:GridView ID="gvPrettyRegs" runat="server"></asp:GridView><br />
    </div>
    </form>
</body>
</html>
