﻿using System;
using System.IO;
using System.Web;
using System.Web.Caching;
using btnet.App_Start;
using NLog;

namespace btnet
{
    public class Global : HttpApplication
    {
        /*
    Copyright 2002 Corey Trager 
    Distributed under the terms of the GNU General Public License
    */

        public void Application_Error(Object sender, EventArgs e)
        {           
            Exception exc = Server.GetLastError().GetBaseException();
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Fatal(exc);
        }

        public void Application_OnStart(Object sender, EventArgs e)
        {
            LoggingConfig.Configure();
            HttpRuntime.Cache.Add("Application", Application, null, Cache.NoAbsoluteExpiration,
                Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, null);

            string dir = Util.GetAbsolutePath("App_Data");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            dir = Util.GetAbsolutePath("App_Data\\logs");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            dir = Util.GetAbsolutePath("App_Data\\uploads");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            Util.set_context(HttpContext.Current); // required for map path calls to work in util.cs

            StreamReader sr = File.OpenText(Util.GetAbsolutePath("custom\\custom_header.html"));
            Application["custom_header"] = sr.ReadToEnd();
            sr.Close();

            sr = File.OpenText(Util.GetAbsolutePath("custom\\custom_footer.html"));
            Application["custom_footer"] = sr.ReadToEnd();
            sr.Close();

            sr = File.OpenText(Util.GetAbsolutePath("custom\\custom_logo.html"));
            Application["custom_logo"] = sr.ReadToEnd();
            sr.Close();

            sr = File.OpenText(Util.GetAbsolutePath("custom\\custom_welcome.html"));
            Application["custom_welcome"] = sr.ReadToEnd();
            sr.Close();

            if (Util.get_setting("EnableVotes", "0") == "1")
            {
                Tags.count_votes(Application); // in tags file for convenience for me....
            }

            if (Util.get_setting("EnableTags", "0") == "1")
            {
                Tags.build_tag_index(Application);
            }
        }

    }
}