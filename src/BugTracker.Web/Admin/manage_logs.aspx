<%@ Page Language="C#" CodeBehind="manage_logs.aspx.cs" Inherits="btnet.Admin.ManageLogs" ValidateRequest="false" EnableEventValidation="false" AutoEventWireup="true" %>

<!--
Copyright 2002-2011 Corey Trager
Distributed under the terms of the GNU General Public License
-->
<html>
<head>
    <title id="titl" runat="server">btnet backup db</title>
    <link rel="StyleSheet" href="../btnet.css" type="text/css">
</head>
<body>
    <% Security.write_menu(Response, "admin"); %>

    <div class="align">
        <table border="0">
            <tr>
                <td>

                    <form runat="server">

                        <asp:DataGrid ID="MyDataGrid" runat="server" BorderColor="black" CssClass="datat"
                            CellPadding="3" AutoGenerateColumns="false" OnItemCommand="my_button_click">
                            <HeaderStyle CssClass="datah"></HeaderStyle>
                            <ItemStyle CssClass="datad"></ItemStyle>
                            <Columns>
                                <asp:BoundColumn HeaderText="File" DataField="file" />
                                <asp:HyperLinkColumn HeaderText="Download" Text="Download" DataNavigateUrlField="url"
                                    Target="_blank" />
                                <asp:ButtonColumn HeaderText="Delete" ButtonType="LinkButton" Text="Delete" CommandName="dlt" />
                            </Columns>
                        </asp:DataGrid>
                        <div class="err" id="msg" runat="server">&nbsp;</div>

                    </form>
        </table>
    </div>
    <% Response.Write(Application["custom_footer"]); %></body>
</html>
