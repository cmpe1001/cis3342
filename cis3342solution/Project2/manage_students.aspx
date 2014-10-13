<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manage_students.aspx.cs" Inherits="Project2.manage_students" %>
<%@ Register TagPrefix="uc" TagName="Navigation" Src="navigation.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create/Search/Modify Students</title>
    <link href="css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:Navigation runat="server" />
        <div>
            <div id="page_name">Create, Search, and Modify Students</div>
            <div id="createStudent">
                <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:Button ID="btnCreateStudent" runat="server" Text="Create Student" OnClick="btnCreateStudent_Click" /><br />
                <asp:label ID="lblCreateStudentOutput" runat="server" Visible="false" /><br />
                <asp:Label ID="lblNewStudentName" runat="server" Text="" Visible="false"></asp:Label><br />
                <asp:Label ID="lblNewStudentID" runat="server" Visible="false"></asp:Label><br />
            </div>
            <div id="searchStudent">
                <asp:Label ID="lblStudentName" runat="server" Text="Search Students:"></asp:Label><br />
                <asp:TextBox ID="txtStudentName" runat="server"></asp:TextBox><br />
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearchStudents_Click" /><br />
                <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" OnRowCommand="gvStudents_RowCommand" OnSelectedIndexChanged="gvStudents_Click">
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True"/>
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
                        <asp:ButtonField CommandName="deleteStudent" Text="Delete" ButtonType="Button" />
                    </Columns>
                </asp:GridView><br />
            </div>
            <asp:Label ID="lblTest" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>