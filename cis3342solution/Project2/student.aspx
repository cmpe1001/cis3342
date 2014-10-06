<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="Project2.create_student" %>

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
    <div id="createStudent">
        <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label><br />
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnCreateStudent" runat="server" Text="Create Student" OnClick="btnCreateStudent_Click" /><br />
        <asp:Label ID="lblNewStudentName" runat="server" Text="" Visible="false"></asp:Label><br />
        <asp:Label ID="lblNewStudentID" runat="server" Visible="false"></asp:Label><br />
    </div>
    <div id="deleteStudent">
        <asp:Label ID="lblStudentIDtoDelete" runat="server" Text="Student ID to be deleted:"></asp:Label><br />
        <asp:TextBox ID="txtStudentIDtoDelete" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnDeleteStudent" runat="server" Text="Delete" OnClick="btnDeleteStudent_Click" /><br />
        <asp:Label ID="lblDeleteOutput" runat="server" Text="" Visible="false"></asp:Label><br />
    </div>
    <div id="searchStudent">

    </div>
    <div>
        <asp:GridView ID="gvStudents" runat="server"></asp:GridView><br />
    </div>
    </form>
</body>
</html>
