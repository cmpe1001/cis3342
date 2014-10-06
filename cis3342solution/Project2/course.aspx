<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="course.aspx.cs" Inherits="Project2.create_course" %>

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
        <asp:Label ID="lblCourseTitle" runat="server" Text="Course Title:"></asp:Label><br />
        <asp:TextBox ID="txtCourseTitle" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblDeptIDCourse" runat="server" Text="Department ID:"></asp:Label><br />
        <asp:TextBox ID="txtDeptIDCourse" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblSection" runat="server" Text="Section:"></asp:Label><br />
        <asp:TextBox ID="txtSection" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblProf" runat="server" Text="Professor Name:"></asp:Label><br />
        <asp:TextBox ID="txtProf" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblDayCode" runat="server" Text="Day Code:"></asp:Label><br />
        <asp:TextBox ID="txtDayCode" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblTime" runat="server" Text="Start Time:"></asp:Label><br />
        <asp:TextBox ID="txtTime" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblTimeEnd" runat="server" Text="End Time:"></asp:Label><br />
        <asp:TextBox ID="txtTimeEnd" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblCredits" runat="server" Text="Credit Hours:"></asp:Label><br />
        <asp:TextBox ID="txtCredits" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblMaxSeats" runat="server" Text="Seats In Class:"></asp:Label><br />
        <asp:TextBox ID="txtMaxSeats" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnCreateCourse" runat="server" Text="Create Course" OnClick="btnCreateCourse_Click" />
    </div>
    <div>
        <asp:Label ID="lblCourseCRNToDelete" runat="server" Text="Course CRN to delete:"></asp:Label><br />
        <asp:TextBox ID="txtCourseCRNtoDelete" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnDeleteCourse" runat="server" Text="Delete Course" OnClick="btnDeleteCourse_Click" />
    </div>
    <div>
        <asp:GridView ID="gvCourses" runat="server">
        </asp:GridView>
    </div>
    <div>
        <asp:Label ID="lblSearch" runat="server" Text="Search for a course by department:"></asp:Label><br />
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnCourseSearch_Click" />
    </div>
    <div>
        <asp:GridView ID="gvSearchResults" runat="server" AutoGenerateColumns="false"  OnSelectedIndexChanged="gvSearchResults_Click">
            <Columns>
                <asp:CommandField ButtonType="Button"  ShowSelectButton="True"></asp:CommandField>
                <asp:BoundField DataField="CRN" HeaderText="CRN" />
                <asp:BoundField DataField="CourseTitle" HeaderText="Course Title" />
                <asp:BoundField DataField="DeptID" HeaderText="Department ID" />
                <asp:BoundField DataField="Section" HeaderText="Section" />
            </Columns>
        </asp:GridView><br />
    </div>
    </form>
</body>
</html>
