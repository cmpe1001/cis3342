<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_student.aspx.cs" Inherits="Project2.edit_student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Student</title>
    <link href="css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblStudentID" runat="server" Text="Student ID: " /><asp:TextBox ID="txtStudentID" runat="server" ReadOnly="true" /><br />
            <asp:Label ID="lblName" runat="server" Text="Student Name: "/><asp:TextBox ID="txtName" runat="server" /><br />
            <asp:Button ID="btnEditStudent" runat="server" Text="Save Changes" OnClick="btnEditStudent_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </div>
        <div>
            <asp:Label ID="lblRegistered" Visible="false" runat="server" />
            <asp:GridView ID="gvRegistered" runat="server" AutoGenerateColumns="false" OnRowCommand="gvRegistered_RowCommand">
                <Columns>
                    <asp:BoundField DataField="CRN" HeaderText="CRN" />
                    <asp:BoundField DataField="CourseTitle" HeaderText="Course Title" />
                    <asp:BoundField DataField="DeptID" HeaderText="Department" />
                    <asp:BoundField DataField="Section" HeaderText="Section" />
                    <asp:BoundField DataField="Professor" HeaderText="Professor" />
                    <asp:BoundField DataField="DayCode" HeaderText="Days" />
                    <asp:BoundField DataField="TimeCode" HeaderText="Start Time" />
                    <asp:BoundField DataField="TimeCodeEnd" HeaderText="End Time" />
                    <asp:BoundField DataField="Credits" HeaderText="Credits" />
                    <asp:ButtonField ButtonType="Button" CommandName="dropClass" Text="Drop" />
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <asp:Label ID="lblTuitionOwed" runat="server" />
        </div>
    </form>
</body>
</html>
