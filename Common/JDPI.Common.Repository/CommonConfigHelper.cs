using JDPI.Common.Util;
using System;
using System.Configuration;

namespace JDPI.Common.Repository
{
    public class CommonConfigHelper : IConfigProvider
    {
        public static string GetConfiguration(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public string DbName
        {
            get
            {
                return ConfigurationManager.AppSettings["DbName"];
            }
        }

        public string DbUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["DbUrl"];
            }
        }
    }
}