<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="navigation.ascx.cs" Inherits="Project2.navigation" %>

<div id="navigation">
	<div class="button" onclick="location.href='./manage_departments.aspx';" style="cursor:pointer;">Manage Departments</div>
	<div class="button_spacer"></div>
	<div class="button" onclick="location.href='./manage_courses.aspx';" style="cursor:pointer;">Manage Courses</div>
	<div class="button_spacer"></div>
	<div class="button" onclick="location.href='./manage_students.aspx';" style="cursor:pointer;">Create/Search/Modify Students</div>
	<div class="button_spacer"></div>
	<div class="button" onclick="location.href='./registration.aspx';" style="cursor:pointer;">Create/Search/Register Classes</div>
</div>