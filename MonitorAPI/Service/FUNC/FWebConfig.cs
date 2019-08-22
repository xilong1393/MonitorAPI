using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MonitorAPI.Service.FUNC
{
    public class FWebConfig
    {
        static public string EmailSever
        {
            get { return ConfigurationManager.AppSettings["emailserver"]; }
        }
        static public string SSOSever
        {
            get { return ConfigurationManager.AppSettings["CASClient_BaseUrl"]; }
        }
        static public string FileServerUsername
        {
            get { return ConfigurationManager.AppSettings["fileserverusername"]; }
        }
        static public string FileServerPassword
        {
            get { return ConfigurationManager.AppSettings["fileserverpassword"]; }
        }
        static public bool IsInsertSuccPrompt()
        {
            string value = ConfigurationManager.AppSettings["insertsuccprompt"];
            return (value != null && value.ToLower() == "true");
        }
        static public bool IsUpdateSuccPrompt()
        {
            string value = ConfigurationManager.AppSettings["updatesuccprompt"];
            return (value != null && value.ToLower() == "true");
        }
        static public bool IsDeleteSuccPrompt()
        {
            string value = ConfigurationManager.AppSettings["deletesuccprompt"];
            return (value != null && value.ToLower() == "true");
        }
        //added by weiyuw,2006.8.14,configurations for col palyer and java palyer
        static public string CodeBase
        {
            get { return ConfigurationManager.AppSettings["codebase"]; }
        }
        static public string Archive
        {
            get { return ConfigurationManager.AppSettings["archive"]; }
        }
        static public string SpeedLimit
        {
            get { return ConfigurationManager.AppSettings["speedlimit"]; }
        }
        static public string SocketConnection
        {
            get { return ConfigurationManager.AppSettings["socketconnection"]; }
        }
        static public string LogMode
        {
            get { return ConfigurationManager.AppSettings["logmode"]; }
        }
        static public string LogLevel
        {
            get { return ConfigurationManager.AppSettings["loglevel"]; }
        }
        static public string DataVersion
        {
            get { return ConfigurationManager.AppSettings["dataversion"]; }
        }
        static public string JavaPlayerDataService
        {
            get { return ConfigurationManager.AppSettings["javaplayerdataservice"]; }
        }
        static public string ColPlayerDataService
        {
            get { return ConfigurationManager.AppSettings["colplayerdataservice"]; }
        }
        static public string Mouse
        {
            get { return ConfigurationManager.AppSettings["mouse"]; }
        }
        static public string Vector
        {
            get { return ConfigurationManager.AppSettings["vector"]; }
        }
        static public string ZIPSC
        {
            get { return ConfigurationManager.AppSettings["zipsc"]; }
        }
        static public string ZIPWB
        {
            get { return ConfigurationManager.AppSettings["zipwb"]; }
        }
        static public byte[] Iv
        {
            get { return System.Text.ASCIIEncoding.ASCII.GetBytes(ConfigurationManager.AppSettings["iv"]); }
        }
        static public byte[] Key
        {
            get { return System.Text.ASCIIEncoding.ASCII.GetBytes(ConfigurationManager.AppSettings["key"]); }
        }
        static public string DefaultPassword
        {
            get { return ConfigurationManager.AppSettings["DefaultPassword"]; }
        }
        static public string Debug
        {
            get { return ConfigurationManager.AppSettings["debug"]; }
        }
        static public string IsLocal
        {
            get { return ConfigurationManager.AppSettings["islocal"]; }
        }
        static public int EventReportInterval
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["EventReportInterval"]); }
        }
        static public string PortalPage
        {
            get { return ConfigurationManager.AppSettings["PortalPage"]; }
        }
        static public ArrayList ClassStartTime
        {
            get { return ConfigurationManager.GetSection("ClassStartTime") as ArrayList; }
        }
        static public Dictionary<string, int> TimeZone
        {
            get { return ConfigurationManager.GetSection("TimeZone") as Dictionary<string, int>; }
        }
        static public ArrayList GetClassStartTime()
        {
            return FWebConfig.ClassStartTime;
        }
        static public ArrayList ClassLength
        {
            get { return ConfigurationManager.GetSection("ClassLength") as ArrayList; }
        }
        static public ArrayList GetClassLength()
        {
            return FWebConfig.ClassLength;
        }
        static public ArrayList ClassLengthForTestCourse
        {
            get { return ConfigurationManager.GetSection("ClassLengthForTestCourse") as ArrayList; }
        }
        static public ArrayList GetClassLengthForTestCourse()
        {
            return FWebConfig.ClassLengthForTestCourse;
        }
        static public string GetLogRootPath()
        {
            return ConfigurationManager.AppSettings["LogFilePath"];
        }
        static public bool GetLogDebugLog()
        {
            try
            {
                return bool.TrueString.ToLower() == ConfigurationManager.AppSettings["DebugLog"].ToLower();
            }
            catch (Exception)
            {
                return false;
            }
        }
        /*
         * add by shu chen, 1/10/2008 : get mediaServicePort
         */
        static public string mediaServicePort
        {
            get { return ConfigurationManager.AppSettings["mediaServicePort"]; }
        }

        /*
         * add by shu chen, 1/15/2008 : get testAppletCodebase
         */
        static public string testAppletCodebase
        {
            get { return ConfigurationManager.AppSettings["testAppletCodebase"]; }
        }

        /*
         * add by shu chen, 1/15/2008 : get testVideoPath
         */
        static public string testVideoPath
        {
            get { return ConfigurationManager.AppSettings["testVideoPath"]; }
        }

        static public string PPCPort
        {
            get { return ConfigurationManager.AppSettings["PPCPort"]; }
        }

        static public string IPCPort
        {
            get { return ConfigurationManager.AppSettings["IPCPort"]; }
        }
        static public string CurrentURL
        {
            get { return ConfigurationManager.AppSettings["CurrentURL"]; }
        }
        static public string FlashPlayerURL
        {
            get { return ConfigurationManager.AppSettings["FlashPlayerURL"]; }
        }
        static public string HTML5PlayerURL
        {
            get { return ConfigurationManager.AppSettings["HTML5WebPlayURL"]; }
        }
        static public string FlashStreamRootURL
        {
            get { return ConfigurationManager.AppSettings["FlashStreamRootUrl"]; }
        }
        static public string AccessTimeDurationInMin
        {
            get { return ConfigurationManager.AppSettings["AccessTimeDurationInMin"]; }
        }
        static public string UnlimitedTimeIPList
        {
            get { return ConfigurationManager.AppSettings["UnlimitedTimeIPList"]; }
        }
        static public string ScreenShrinkDeptList
        {
            get { return ConfigurationManager.AppSettings["ScreenShrinkDeptList"]; }
        }
        static public string ScreenShrinkToSizeInM
        {
            get { return ConfigurationManager.AppSettings["ScreenShrinkToSizeInM"]; }
        }
    }
}