<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_course.aspx.cs" Inherits="Project2.edit_course" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
        <asp:Label ID="lblCRN" runat="server" Text="Course Registration Number:"></asp:Label><br />
        <asp:TextBox ID="txtCRN" runat="server" ReadOnly="true"></asp:TextBox><br />
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
        <asp:Button ID="btnEditCourse" runat="server" Text="Save Changes" OnClick="btnEditCourse_Click" />
    </div>
    </div>
    </form>
</body>
</html>
