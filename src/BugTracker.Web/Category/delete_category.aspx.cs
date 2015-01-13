using System;
using System.Data;
using System.Web;

namespace btnet.Category
{
    public partial class delete_category : BasePage
    {
        private SQLString _sql;

        protected Security security;

        void Page_Init(object sender, EventArgs e) { ViewStateUserKey = Session.SessionID; }

        
        void Page_Load(Object sender, EventArgs e)
        {

            Util.do_not_cache(Response);

            security = new Security();
            security.check_security(HttpContext.Current, Security.MUST_BE_ADMIN);

            if (IsPostBack)
            {
                _sql = new SQLString(@"delete categories where ct_id = @catid");
                _sql = _sql.AddParameterWithValue("catid", Util.sanitize_integer(row_id.Value));
                DbUtil.execute_nonquery(_sql);
                Server.Transfer("categories.aspx");
            }
            else
            {
                titl.InnerText = Util.get_setting("AppTitle", "BugTracker.NET") + " - " + "delete category";

                var id = Util.sanitize_integer(Request["id"]);

                _sql = new SQLString(@"declare @cnt int
			select @cnt = count(1) from bugs where bg_category = @ctid
			select ct_name, @cnt [cnt] from categories where ct_id = @ctid");
                _sql = _sql.AddParameterWithValue("ctid", id);

                DataRow dr = DbUtil.get_datarow(_sql);

                if ((int)dr["cnt"] > 0)
                {
                    Response.Write("You can't delete category \""
                        + Convert.ToString(dr["ct_name"])
                        + "\" because some bugs still reference it.");
                    Response.End();
                }
                else
                {
                    confirm_href.InnerText = "confirm delete of \"" + Convert.ToString(dr["ct_name"]) + "\"";


                    row_id.Value = id;
                }
            }

        }

    }
}
