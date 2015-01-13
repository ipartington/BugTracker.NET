<%@ Page Language="C#" CodeBehind="delete_category.aspx.cs" Inherits="btnet.Category.delete_category" AutoEventWireup="true" %>

<!--
Copyright 2002-2011 Corey Trager
Distributed under the terms of the GNU General Public License
-->

<html>
<head>
    <title id="titl" runat="server">btnet delete category</title>
    <link rel="StyleSheet" href="../btnet.css" type="text/css">
</head>
<body>
    <% security.write_menu(Response, "admin"); %>
    <p>
        <div class="align">
            <p>&nbsp</p>
            <a href="categories.aspx">back to categories</a>

            <p>
                or<p>

                    <script>
                        function submit_form() {
                            var frm = document.getElementById("frm");
                            frm.submit();
                            return true;
                        }

                    </script>
                    <form runat="server" id="frm">
                        <a id="confirm_href" runat="server" href="javascript: submit_form()"></a>
                        <input type="hidden" id="row_id" runat="server"/>>
                    </form>

        </div>
        <% Response.Write(Application["custom_footer"]); %>
</body>
</html>


