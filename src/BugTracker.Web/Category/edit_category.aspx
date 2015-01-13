<%@ Page Language="C#" CodeBehind="edit_category.aspx.cs" Inherits="btnet.Category.edit_category" AutoEventWireup="true" %>

<!--
Copyright 2002-2011 Corey Trager
Distributed under the terms of the GNU General Public License
-->

<html>
<head>
    <title id="titl" runat="server">btnet edit category</title>
    <link rel="StyleSheet" href="../btnet.css" type="text/css">
</head>
<body>
    <% security.write_menu(Response, "admin"); %>


    <div class="align">
        <table border="0">
            <tr>
                <td>
                    <a href="categories.aspx">back to categories</a>
                    <form class="frm" runat="server">
                        <table border="0">

                            <tr>
                                <td class="lbl">Description:</td>
                                <td>
                                    <input runat="server" type="text" class="txt" id="name" maxlength="30" size="30" /></td>
                                <td runat="server" class="err" id="name_err">&nbsp;</td>
                            </tr>

                            <tr>
                                <td colspan="3"><span class="smallnote">Sort Sequence controls the sort order in the dropdowns.</span></td>
                            </tr>

                            <tr>
                                <td class="lbl">Sort Sequence:</td>
                                <td>
                                    <input runat="server" type="text" class="txt" id="sort_seq" maxlength="2" size="2" /></td>
                                <td runat="server" class="err" id="sort_seq_err">&nbsp;</td>
                            </tr>

                            <tr>
                                <td class="lbl">Default Selection:</td>
                                <td>
                                    <asp:CheckBox runat="server" class="cb" ID="default_selection" /></td>
                                <td>&nbsp</td>
                            </tr>

                            <tr>
                                <td colspan="3" align="left"><span runat="server" class="err" id="msg">&nbsp;</span></td>
                            </tr>

                            <tr>
                                <td colspan="2" align="center">
                                    <input runat="server" class="btn" type="submit" id="sub" value="Create or Edit" /></td>
                                <td>&nbsp</td>
                            </tr>
                        </table>
                    </form>
                </td>
            </tr>

        </table>
    </div>
    <% Response.Write(Application["custom_footer"]); %></body>
</html>


