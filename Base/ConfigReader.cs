using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Capsule.UI.Base
{
    public static class ConfigReader
    {

        static ConfigReader()
        {
            AppiumUri = ConfigurationManager.AppSettings["AppiumUri"];
            DeviceName = ConfigurationManager.AppSettings["DeviceName"];
            AppPackage = ConfigurationManager.AppSettings["AppPackage"];
            AppActivity = ConfigurationManager.AppSettings["AppActivity"];
            Platform = ConfigurationManager.AppSettings["Platform"];
        }
        public static string Platform { get; }
        public static string PlatformVersion { get; }

        public static string DeviceName { get; }

        public static string AppPackage { get; }

        public static string AppActivity { get; }

        public static string AppiumUri { get; }

        public static string GetUrl()
        {
            return ConfigurationManager.AppSettings["Url"].ToString();
        }

        public static string GetUsername()
        {
            return ConfigurationManager.AppSettings["Username"].ToString();
        }

        public static string GetPassword()
        {
            return ConfigurationManager.AppSettings["Password"].ToString();
        }


    }
}
