<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home_management.aspx.cs" Inherits="Project3.WebForm1" %>
<%@ Register TagPrefix="uc" TagName="Navigation" Src="navigation.ascx" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <title>Homes</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc:Navigation runat="server" />
        <div id="main">
            <div id="buttons">
                <asp:Button ID="btnCreate" runat="server" Text="Create Home" onClick="btnCreate_Click" CssClass="Button"/>
                <asp:Button ID="btnSearch" runat="server" Text="Search Homes" OnClick="btnSearch_Click" CssClass="Button"/>
            </div>
            <div id="errorField" runat="server" visible="false">
                <asp:Label ID="lblErrors" runat="server" />
            </div>
            <div id="home_fields" runat="server" visible="false">
                <asp:Label ID="lblHomeID" runat="server" Text="Home ID#" CssClass="Label"/><asp:TextBox ID="txtHomeID" runat="server" CssClass="Control"/><br />
                <asp:Label ID="lblAddress" runat="server" Text="Address:"  CssClass="Label"/><asp:TextBox ID="txtAddress" runat="server"  CssClass="Control"/><br />
                <asp:Label ID="lblCity" runat="server" Text="City:"  CssClass="Label"/><asp:TextBox ID="txtCity" runat="server"  CssClass="Control"/><br />
                <asp:Label ID="lblState" runat="server" Text="State:"  CssClass="Label"/><br />
                <asp:DropDownList ID="ddlState" runat="server" CssClass="Control">
                    <asp:ListItem Selected="True" Value="" />
                    <asp:ListItem Text="Alabama" Value="AL" />
                    <asp:ListItem Text="Alaska" Value="AK" />
                    <asp:ListItem Text="Arizona" Value="AZ" />
                    <asp:ListItem Text="Arkansas" Value="AR" />
                    <asp:ListItem Text="California" Value="CA" />
                    <asp:ListItem Text="Colorado" Value="CO" />
                    <asp:ListItem Text="Connecticut" Value="CT" />
                    <asp:ListItem Text="Delaware" Value="DE" />
                    <asp:ListItem Text="District of Columbia" Value="DC" />
                    <asp:ListItem Text="Florida" Value="FL" />
                    <asp:ListItem Text="Georgia" Value="GA" />
                    <asp:ListItem Text="Hawaii" Value="HI" />
                    <asp:ListItem Text="Idaho" Value="ID" />
                    <asp:ListItem Text="Illinois" Value="IL" />
                    <asp:ListItem Text="Indiana" Value="IN" />
                    <asp:ListItem Text="Iowa" Value="IA" />
                    <asp:ListItem Text="Kansas" Value="KS" />
                    <asp:ListItem Text="Kentucky" Value="KY" />
                    <asp:ListItem Text="Louisiana" Value="LA" />
                    <asp:ListItem Text="Maine" Value="ME" />
                    <asp:ListItem Text="Maryland" Value="MD" />
                    <asp:ListItem Text="Massachusetts" Value="MA" />
                    <asp:ListItem Text="Michigan" Value="MI" />
                    <asp:ListItem Text="Minnesota" Value="MN" />
                    <asp:ListItem Text="Mississippi" Value="MS" />
                    <asp:ListItem Text="Missouri" Value="MO" />
                    <asp:ListItem Text="Montana" Value="MT" />
                    <asp:ListItem Text="Nebraska" Value="NE" />
                    <asp:ListItem Text="Nevada" Value="NV" />
                    <asp:ListItem Text="New Hampshire" Value="NH" />
                    <asp:ListItem Text="New Jersey" Value="NJ" />
                    <asp:ListItem Text="New Mexico" Value="NM" />
                    <asp:ListItem Text="New York" Value="NY" />
                    <asp:ListItem Text="North Carolina" Value="NC" />
                    <asp:ListItem Text="North Dakota" Value="ND" />
                    <asp:ListItem Text="Ohio" Value="OH" />
                    <asp:ListItem Text="Oklahoma" Value="OK" />
                    <asp:ListItem Text="Oregon" Value="OR" />
                    <asp:ListItem Text="Pennsylvania" Value="PA" />
                    <asp:ListItem Text="Rhode Island" Value="RI" />
                    <asp:ListItem Text="South Carolina" Value="SC" />
                    <asp:ListItem Text="South Dakota" Value="SD" />
                    <asp:ListItem Text="Tennessee" Value="TN" />
                    <asp:ListItem Text="Texas" Value="TX" />
                    <asp:ListItem Text="Utah" Value="UT" />
                    <asp:ListItem Text="Vermont" Value="VT" />
                    <asp:ListItem Text="Virginia" Value="VA" />
                    <asp:ListItem Text="Washington" Value="WA" />
                    <asp:ListItem Text="West Virginia" Value="WV" />
                    <asp:ListItem Text="Wisconsin" Value="WI" />
                    <asp:ListItem Text="Wyoming" Value="WY" />
                </asp:DropDownList><br />
                <asp:Label ID="lblListPrice" runat="server" Text="List Price:"  CssClass="Label"/><asp:TextBox ID="txtListPrice" runat="server"  CssClass="Control"/><br />
                <asp:Label ID="lblSqft" runat="server" Text="sq/ft:"  CssClass="Label"/><asp:TextBox ID="txtSqft" runat="server"  CssClass="Control"/><br />
                <asp:Label ID="lblAvailability" runat="server" Text="Availability:"  CssClass="Label"/>
                <asp:DropDownList ID="ddlAvailabilty" runat="server" CssClass="Control">
                    <asp:ListItem Selected="True" Value="" />
                    <asp:ListItem Text="Sold" Value="Sold" />
                    <asp:ListItem Text="For Sale" Value="For Sale" />
                    <asp:ListItem Text="Forclosure" Value="Forclosure" />                    
                </asp:DropDownList><br />
                <asp:Label ID="lblBedrooms" runat="server" Text="Bedrooms:"  CssClass="Label"/><asp:TextBox ID="txtBedrooms" runat="server"  CssClass="Control"/><br />
                <asp:Label ID="lblBathrooms" runat="server" Text="Bathrooms:"  CssClass="Label"/><asp:TextBox ID="txtBathrooms" runat="server"  CssClass="Control"/><br />
                <asp:Label ID="lblType" runat="server" Text="Home Type:"  CssClass="Label"/>
                <asp:DropDownList ID="ddlHomeType" runat="server"  CssClass="Control">
                    <asp:ListItem Selected="True" Value="" />
                    <asp:ListItem Text="Townhouse" Value="TH" />
                    <asp:ListItem Text="Single Family Home" Value="SFH" />
                    <asp:ListItem Text="Multi Family Home" Value="MFH" />
                    <asp:ListItem Text="Condominium" Value="CD" />
                </asp:DropDownList><br />
                <asp:Label ID="lblRealtor" runat="server" Text="Realtor:"  CssClass="Label"/><asp:DropDownList ID="ddlRealtors" runat="server"  CssClass="Control"/><br />
            </div>
            <div id="createModify" runat="server" visible="false">
                <asp:Label ID="lblCreateModify" runat="server" />
                <asp:Button ID="btnCreateNewListing" Text="Create New Listing" runat="server" OnClick="btnCreateNewListing_Click" CssClass="Button"/>
            </div>
            <div id="modify" runat="server" visible="false">
                <asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes" OnClick="btnSaveChanges_Click" CssClass="Button"/>
            </div>
            <div id="search" runat="server" visible="false">
                <asp:Button ID="btnStartSearch" runat="server" Text="Search" OnClick="btnStartSearch_Click" CssClass="Button"/>
            </div>
            <div id="searchResults" runat="server" visible="false">
                <asp:Label Text="Client: " runat="server" /><asp:DropDownList ID="ddlClients" runat="server" CssClass="Control"/>
                <asp:GridView ID="gvSearchResults" runat="server" AutoGenerateColumns="false" OnRowCommand="gvSearchResults_RowCommand">
                    <Columns>
                        <asp:ButtonField ButtonType="Button" CommandName="deleteListing" Text="Delete" ControlStyle-CssClass="Button"/>
                        <asp:ButtonField ButtonType="Button" CommandName="editListing" Text="Modify" ControlStyle-CssClass="Button"/>
                        <asp:BoundField DataField="homeID" HeaderText="HomeID" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="City" HeaderText="City" />
                        <asp:BoundField DataField="State" HeaderText="State" />
                        <asp:BoundField DataField="ListPrice" HeaderText="Price" />
                        <asp:BoundField DataField="sqft" HeaderText="Square Feet" />
                        <asp:BoundField DataField="Availability" HeaderText="Availability" />
                        <asp:BoundField DataField="Bedrooms" HeaderText="Bedrooms" />
                        <asp:BoundField DataField="Bathrooms" HeaderText="Bathrooms" />
                        <asp:BoundField DataField="Type" HeaderText="Type" />
                        <asp:BoundField DataField="RealtorID" HeaderText="Realtor ID" />
                        <asp:BoundField DataField="Name" HeaderText="Realtor" />
                        <asp:TemplateField HeaderText="Viewing">
                            <ItemTemplate>
                                <asp:CheckBox id="chkScheduleViewing" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date and Time">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlHour" runat="server">
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
                                <asp:DropDownList ID="ddlMinute" runat="server">
                                    <asp:ListItem Text="00" Value="00" />
                                    <asp:ListItem Text="15" Value="15" />
                                    <asp:ListItem Text="30" Value="30" />
                                    <asp:ListItem Text="45" Value="45" />
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlAMPM" runat="server">
                                    <asp:ListItem Text="AM" Value="0" />
                                    <asp:ListItem Text="PM" Value="12" />
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlMonth" runat="server">
                                    <asp:ListItem Text="Jan" Value="1" />
                                    <asp:ListItem Text="Feb" Value="2" />
                                    <asp:ListItem Text="Mar" Value="3" />
                                    <asp:ListItem Text="Apr" Value="4" />
                                    <asp:ListItem Text="May" Value="5" />
                                    <asp:ListItem Text="Jun" Value="6" />
                                    <asp:ListItem Text="Jul" Value="7" />
                                    <asp:ListItem Text="Aug" Value="8" />
                                    <asp:ListItem Text="Sep" Value="9" />
                                    <asp:ListItem Text="Oct" Value="10" />
                                    <asp:ListItem Text="Nov" Value="11" />
                                    <asp:ListItem Text="Dec" Value="12" />
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlDay" runat="server">
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
                                    <asp:ListItem Text="13" Value="13" />
                                    <asp:ListItem Text="14" Value="14" />
                                    <asp:ListItem Text="15" Value="15" />
                                    <asp:ListItem Text="16" Value="16" />
                                    <asp:ListItem Text="17" Value="17" />
                                    <asp:ListItem Text="18" Value="18" />
                                    <asp:ListItem Text="19" Value="19" />
                                    <asp:ListItem Text="20" Value="20" />
                                    <asp:ListItem Text="21" Value="21" />
                                    <asp:ListItem Text="22" Value="22" />
                                    <asp:ListItem Text="23" Value="23" />
                                    <asp:ListItem Text="24" Value="24" />
                                    <asp:ListItem Text="25" Value="25" />
                                    <asp:ListItem Text="26" Value="26" />
                                    <asp:ListItem Text="27" Value="27" />
                                    <asp:ListItem Text="28" Value="28" />
                                    <asp:ListItem Text="29" Value="29" />
                                    <asp:ListItem Text="30" Value="30" />
                                    <asp:ListItem Text="31" Value="31" />
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlYear" runat="server">
                                    <asp:ListItem Text="2014" Value="2014" />
                                    <asp:ListItem Text="2015" Value="2015" />
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Button ID="btnSchedule" Text="Schedule Viewings" runat="server" OnClick="btnSchedule_Click" CssClass="Button"/>
            </div>
        </div>
    </form>
</body>
</html>
