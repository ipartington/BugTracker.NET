using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace btnet.Admin
{
    public partial class ManageLogs : BasePage
    {

        
        protected Security Security;
        string _appDataFolder;

        
        void Page_Load(Object sender, EventArgs e)
        {

            Util.do_not_cache(Response);

            Security = new Security();
            Security.check_security(HttpContext.Current, Security.MUST_BE_ADMIN);

            titl.InnerText = Util.get_setting("AppTitle", "BugTracker.NET") + " - " + "manage logs";

            _appDataFolder = HttpContext.Current.Server.MapPath(null);
            _appDataFolder += "\\..\\App_Data\\logs\\";

            if (!IsPostBack)
            {
                get_files();
            }

        }

        void get_files()
        {
            var backupFiles = Directory.GetFiles(_appDataFolder, "*.txt");

            if (backupFiles.Length == 0)
            {
                MyDataGrid.Visible = false;
                return;
            }

            MyDataGrid.Visible = true;

            // sort the files
            var list = new ArrayList();
            list.AddRange(backupFiles);
            list.Sort();

            var dt = new DataTable();

            dt.Columns.Add(new DataColumn("file", typeof(String)));
            dt.Columns.Add(new DataColumn("url", typeof(String)));

            for (var i = list.Count - 1; i != -1; i--)
            {
                DataRow dr = dt.NewRow();

                var justFile = Path.GetFileName((string)list[i]);
                dr[0] = justFile;
                dr[1] = "download_file.aspx?which=log&filename=" + justFile;

                dt.Rows.Add(dr);
            }

            var dv = new DataView(dt);

            MyDataGrid.DataSource = dv;
            MyDataGrid.DataBind();
        }


        protected void my_button_click(object sender, DataGridCommandEventArgs e)
        {
            if (e.CommandName != "dlt") return;
            var i = e.Item.ItemIndex;
            var file = MyDataGrid.Items[i].Cells[0].Text;
            File.Delete(_appDataFolder + file);
            get_files();
        }


    }
}
