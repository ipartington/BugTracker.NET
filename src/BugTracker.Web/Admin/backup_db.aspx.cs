using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace btnet.Admin
{
    public partial class backup_db : BasePage
    {

        protected Security Security;

        string _appDataFolder;

        ///////////////////////////////////////////////////////////////////////
        void Page_Load(Object sender, EventArgs e)
        {

            Util.do_not_cache(Response);

            Security = new Security();
            Security.check_security(HttpContext.Current, Security.MUST_BE_ADMIN);

            titl.InnerText = Util.get_setting("AppTitle", "BugTracker.NET") + " - " + "backup db";

            _appDataFolder = HttpContext.Current.Server.MapPath(null);
            _appDataFolder += "\\App_Data\\";

            if (!IsPostBack)
            {
                get_files();
            }

        }

        void get_files()
        {
            string[] backup_files = System.IO.Directory.GetFiles(_appDataFolder, "*.bak");

            if (backup_files.Length == 0)
            {
                MyDataGrid.Visible = false;
                return;
            }

            MyDataGrid.Visible = true;

            // sort the files
            var list = new ArrayList();
            list.AddRange(backup_files);
            list.Sort();

            var dt = new DataTable();

            dt.Columns.Add(new DataColumn("file", typeof(String)));
            dt.Columns.Add(new DataColumn("url", typeof(String)));

            foreach (object t in list)
            {
                DataRow dr = dt.NewRow();

                var just_file = System.IO.Path.GetFileName((string)t);
                dr[0] = just_file;
                dr[1] = "download_file.aspx?which=backup&filename=" + just_file;

                dt.Rows.Add(dr);
            }

            var dv = new DataView(dt);

            MyDataGrid.DataSource = dv;
            MyDataGrid.DataBind();
        }


        protected void on_backup(Object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string db = (string)btnet.DbUtil.execute_scalar(new SQLString("select db_name()"));
            string backup_file = _appDataFolder + "db_backup_" + date + ".bak";
            var sql = new SQLString("backup database " + db + " to disk = '" + backup_file + "'");
            btnet.DbUtil.execute_nonquery(sql);
            get_files();
        }


        protected void my_button_click(object sender, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "dlt")
            {
                int i = e.Item.ItemIndex;
                string file = MyDataGrid.Items[i].Cells[0].Text;
                System.IO.File.Delete(_appDataFolder + file);
                get_files();
            }

        }


    }
}
