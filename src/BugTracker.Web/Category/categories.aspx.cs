using System;
using System.Data;
using System.Web;

namespace btnet.Category
{
    public partial class categories : BasePage
    {
        protected DataSet DataSet;

        protected Security security;

        void Page_Load(Object sender, EventArgs e)
        {

            Util.do_not_cache(Response);

            security = new Security();
            security.check_security(HttpContext.Current, Security.MUST_BE_ADMIN);

            titl.InnerText = Util.get_setting("AppTitle", "BugTracker.NET") + " - " + "categories";

            DataSet = btnet.DbUtil.get_dataset(new SQLString(@"select
		ct_id [id],
		ct_name [category],
		ct_sort_seq [sort seq],
		case when ct_default = 1 then 'Y' else 'N' end [default],
		ct_id [hidden]
		from categories order by ct_name"));

        }

    }
}
