<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student_registration.aspx.cs" Inherits="Project2.student_registration" %>

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
            <asp:Label ID="lblStudentID" runat="server" Text="Student ID:"></asp:Label><br />
            <asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblDeptID" runat="server" Text="Department ID:"></asp:Label><br />
            <asp:TextBox ID="txtDeptID" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblDayCode" runat="server" Text="Day Code:"></asp:Label><br />
            <asp:TextBox ID="txtDayCode" runat="server"></asp:TextBox><br />
        </div>
        <div>
            <asp:GridView ID="gvRegistrations" runat="server"></asp:GridView><br />
        </div>
        <div>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /><br />
        </div>
        <div>
            <asp:GridView ID="gvResults" runat="server"></asp:GridView><br />
        </div>
    </form>
</body>
</html>
