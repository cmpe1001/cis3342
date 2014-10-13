<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="Project2.create_student" StyleSheetTheme="" %>
<%@ Register TagPrefix="uc" TagName="Navigation" Src="navigation.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create/Search/Register Classes</title>
    <link href="css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="navigation"><uc:Navigation runat="server" /></div>
        <div id="content">
            <div id="page_name">Create, Search, and Register Classes</div>
            <div id="main">
                <asp:Label ID="lblStudentID" Text="Student ID:" runat="server"  />
                <asp:TextBox ID="txtStudentID" runat="server" />
                <asp:DropDownList ID="drpDepartment" runat="server" />
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/>
                <asp:CheckBoxList ID="chkDayCode" runat="server">
                    <asp:ListItem Value="M">Monday</asp:ListItem>
                    <asp:ListItem Value="T">Tuesday</asp:ListItem>
                    <asp:ListItem Value="W">Wednesday</asp:ListItem>
                    <asp:ListItem Value="Th">Thursday</asp:ListItem>
                    <asp:ListItem Value="F">Friday</asp:ListItem>
                </asp:CheckBoxList>
                <asp:Label ID="lblName" runat="server" Visible="false"/><asp:Label ID="lblDept" runat="server" Visible="false" />
                <asp:GridView ID="gvRegistration" runat="server" AutoGenerateColumns="False" OnRowCommand="gvRegistration_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Register">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkRegister" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CRN" HeaderText="CRN"/>
                        <asp:BoundField DataField="CourseTitle" HeaderText="Course Title"/>
                        <asp:BoundField DataField="Section" HeaderText="Section" />
                        <asp:BoundField DataField="MaxSeats" HeaderText="Max Seats"/>
                        <asp:BoundField DataField="Credits" HeaderText="Credit Hours"/>
                        <asp:BoundField DataField="DayCode" HeaderText="Days"/>
                        <asp:BoundField DataField="TimeCode" HeaderText="Start Time"/>
                        <asp:BoundField DataField="TimeCodeEnd" HeaderText="End Time"/>
                        <asp:BoundField DataField="Professor" HeaderText="Professor"/>
                        <asp:TemplateField HeaderText="Seats Open">
                            <ItemTemplate>
                                <asp:label ID="lblSeats" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Button ID="btnRegister" Visible="false" runat="server" Text="Register Selected" OnClick="btnRegister_Click" />
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
        </div>
    </form>
</body>
</html>
