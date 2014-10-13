<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manage_courses.aspx.cs" Inherits="Project2.manage_courses" %>
<%@ Register TagPrefix="uc" TagName="Navigation" Src="navigation.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Courses</title>
    <link href="css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:Navigation runat="server" />
        <div>
            <div id="page_name">Manage Courses</div>
            <div>
                <asp:Button ID="btnCreateNewCourse" runat="server" Text="Create a New Course" OnClick="btnCreateNewCourse_Click" />
            </div>
            <div>
                <asp:Label ID="lblSearch" runat="server" Text="List courses by department:"></asp:Label>
                <asp:DropDownList ID="drpSearchList" runat="server" /><br />
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnCourseSearch_Click" />
            </div>
            <div>
                <asp:GridView ID="gvSearchResults" runat="server" AutoGenerateColumns="false" OnRowCommand="gvSearchResults_RowCommand" OnSelectedIndexChanged="gvSearchResults_Click">
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True"></asp:CommandField>
                        <asp:BoundField DataField="CRN" HeaderText="CRN" />
                        <asp:BoundField DataField="CourseTitle" HeaderText="Course Title" />
                        <asp:BoundField DataField="DeptID" HeaderText="Department ID" />
                        <asp:BoundField DataField="Section" HeaderText="Section" />
                        <asp:ButtonField CommandName="deleteCourse" Text="Delete" ButtonType="Button" />
                    </Columns>
                </asp:GridView><br />
            </div>
        </div>
    </form>
</body>
</html>