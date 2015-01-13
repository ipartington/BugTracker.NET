<%@ Page Language="C#" CodeBehind="categories.aspx.cs" Inherits="btnet.Category.categories" AutoEventWireup="true" %>
<%@ Import Namespace="btnet" %>

<html>
<head>
    <title id="titl" runat="server">btnet categories</title>
    <link rel="StyleSheet" href="../btnet.css" type="text/css">
    <script type="text/javascript" language="JavaScript" src="../sortable.js"></script>
</head>

<body>
    <% security.write_menu(Response, "admin"); %>


    <div class="align">
        <a href="edit_category.aspx">add new category</a>
        </p>
        <%

            if (DataSet.Tables[0].Rows.Count > 0)
            {
                SortableHtmlTable.create_from_dataset(Response, DataSet, "edit_category.aspx?id=", "delete_category.aspx?id=");
            }
            else
            {
                Response.Write("No categories in the database.");
            }

        %>
    </div>
    <% Response.Write(Application["custom_footer"]); %></body>
</html>
