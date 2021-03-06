<%@ Page language="C#" CodeBehind="delete_subscriber.aspx.cs" Inherits="btnet.delete_subscriber" AutoEventWireup="True" %>
<!--
Copyright 2002-2011 Corey Trager
Distributed under the terms of the GNU General Public License
-->
<!-- #include file = "inc.aspx" -->

<script language="C#" runat="server">


Security security;

///////////////////////////////////////////////////////////////////////
void Page_Load(Object sender, EventArgs e)
{

	Util.do_not_cache(Response);
	
	security = new Security();
	security.check_security( HttpContext.Current, Security.MUST_BE_ADMIN);

	if (Request.QueryString["ses"] != (string) Session["session_cookie"])
	{
		Response.Write ("session in URL doesn't match session cookie");
		Response.End();
	}

	var sql = new SQLString("delete from bug_subscriptions where bs_bug = @bg_id and bs_user = @us_id");
	sql = sql.AddParameterWithValue("$bg_id", Util.sanitize_integer(Request["bg_id"]));
	sql = sql.AddParameterWithValue("$us_id", Util.sanitize_integer(Request["us_id"]));
	btnet.DbUtil.execute_nonquery(sql);

    Response.Redirect("view_subscribers.aspx?id=" + Util.sanitize_integer(Request["bg_id"]));

}

</script>
