using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Configuration;
using System.IO;
using System.Collections;

namespace Helper
{
    public class Utils
    {
        public static string GetConfig(string skey)
        {
            string sValue = string.Empty;
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            if (appSettings[skey] != null)
                sValue = appSettings[skey];
            return sValue;
        }

        public static string[] getFiles(string SourceFolder, string Filter, System.IO.SearchOption searchOption)
        {
            ArrayList alFiles = new ArrayList();
            string[] MultipleFilters = Filter.Split('|');
            foreach (string FileFilter in MultipleFilters)
            {
                alFiles.AddRange(Directory.GetFiles(SourceFolder, "*." + FileFilter, searchOption));
            }
            return (string[])alFiles.ToArray(typeof(string));
        }
    }
}
