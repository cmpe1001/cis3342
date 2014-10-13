<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_course.aspx.cs" Inherits="Project2.edit_course" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Course</title>
    <link href="css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="lblCRN" runat="server" Text="CRN:" />
                <asp:TextBox ID="txtCRN" runat="server" ReadOnly="true" /><br />
                <asp:Label ID="lblCourseTitle" runat="server" Text="Course Title:" />
                <asp:TextBox ID="txtCourseTitle" runat="server" /><br />
                <asp:Label ID="lblDeptIDCourse" runat="server" Text="Department ID:" />
                <asp:DropDownList ID="drpDeptID" runat="server" /><br />
                <asp:Label ID="lblSection" runat="server" Text="Section:" />
                <asp:TextBox ID="txtSection" runat="server" /><br />
                <asp:Label ID="lblProf" runat="server" Text="Professor Name:" />
                <asp:TextBox ID="txtProf" runat="server" /><br />
                <asp:Label ID="lblDayCode" runat="server" Text="Days:" />
                <asp:CheckBoxList ID="chkDayCode" runat="server">
                    <asp:ListItem Value="M">Monday</asp:ListItem>
                    <asp:ListItem Value="T">Tuesday</asp:ListItem>
                    <asp:ListItem Value="W">Wednesday</asp:ListItem>
                    <asp:ListItem Value="Th">Thursday</asp:ListItem>
                    <asp:ListItem Value="F">Friday</asp:ListItem>
                </asp:CheckBoxList>
                <asp:Label ID="lblTime" runat="server" Text="Start Time:" />
                <asp:DropDownList ID="drpStartHours" runat="server">
                    <asp:ListItem Text="1" Value="1" />
                    <asp:ListItem Text="2" Value="2" />
                    <asp:ListItem Text="3" Value="3" />
                    <asp:ListItem Text="4" Value="4" />
                    <asp:ListItem Text="5" Value="5" />
                    <asp:ListItem Text="6" Value="6" />
                    <asp:ListItem Text="7" Value="7" />
                    <asp:ListItem Text="8" Value="8" />
                    <asp:ListItem Text="9" Value="9" />
                    <asp:ListItem Text="10" Value="10" />
                    <asp:ListItem Text="11" Value="11" />
                    <asp:ListItem Text="12" Value="12" />
                </asp:DropDownList>
                <asp:DropDownList ID="drpStartMinutes" runat="server">
                    <asp:ListItem Text="00" Value="00" />
                    <asp:ListItem Text="15" Value="15" />
                    <asp:ListItem Text="30" Value="30" />
                    <asp:ListItem Text="45" Value="45" />
                </asp:DropDownList>
                <asp:DropDownList ID="drpStartAMPM" runat="server">
                    <asp:ListItem Text="AM" Value="0" />
                    <asp:ListItem Text="PM" Value="12" />
                </asp:DropDownList><br />
                <asp:Label ID="lblTimeEnd" runat="server" Text="End Time:" />
                <asp:DropDownList ID="drpEndHours" runat="server">
                    <asp:ListItem Text="1" Value="1" />
                    <asp:ListItem Text="2" Value="2" />
                    <asp:ListItem Text="3" Value="3" />
                    <asp:ListItem Text="4" Value="4" />
                    <asp:ListItem Text="5" Value="5" />
                    <asp:ListItem Text="6" Value="6" />
                    <asp:ListItem Text="7" Value="7" />
                    <asp:ListItem Text="8" Value="8" />
                    <asp:ListItem Text="9" Value="9" />
                    <asp:ListItem Text="10" Value="10" />
                    <asp:ListItem Text="11" Value="11" />
                    <asp:ListItem Text="12" Value="12" />
                </asp:DropDownList>
                <asp:DropDownList ID="drpEndMinutes" runat="server">
                    <asp:ListItem Text="00" Value="00" />
                    <asp:ListItem Text="15" Value="15" />
                    <asp:ListItem Text="30" Value="30" />
                    <asp:ListItem Text="45" Value="45" />
                </asp:DropDownList>
                <asp:DropDownList ID="drpEndAMPM" runat="server">
                    <asp:ListItem Text="AM" Value="0" />
                    <asp:ListItem Text="PM" Value="12" />
                </asp:DropDownList><br />
                <asp:Label ID="lblCredits" runat="server" Text="Credit Hours:" />
                <asp:TextBox ID="txtCredits" runat="server" /><br />
                <asp:Label ID="lblMaxSeats" runat="server" Text="Seats In Class:" />
                <asp:TextBox ID="txtMaxSeats" runat="server" /><br />
                <asp:Button ID="btnCreateCourse" runat="server" Text="Create/Update Course" OnClick="btnEditCourse_Click" /><br />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
        </div>
    </form>
</body>
</html>
