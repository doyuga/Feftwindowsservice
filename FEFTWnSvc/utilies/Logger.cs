using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FEFTWnSvc
{
    public enum LogLevel : int
    {
        DEBUG = 0,
        INFO = 1,
        WARN = 2,
        ERROR = 3,
        FATAL = 4
    }

    public enum LogModes : int
    {
        FILE_LOG = 0,
        FILE_DEBUG = 1,
        FILE_ERROR = 2,
        FILE_RAW = 3,
        FILE_LOG_KCB = 4,
        FILE_DEBUG_KCB = 5,
        FILE_ERROR_KCB = 6,
        FILE_RAW_KCB = 7,
        FILE_LOG_COMMON=8,


       FILE_LOG_EZZYPAY = 9,
       FILE_DEBUG_EZZYPAY = 10,
       FILE_ERROR_EZZYPAY = 11,
       FILE_RAW_EZZYPAY = 12,
       
    }

  
    public class Logger
    {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string logingmode;
        public void LogMsg(LogModes mode, LogLevel level, object msg)
        {
            string strLogFileName = String.Empty;

            switch (mode)
            {
                case LogModes.FILE_LOG:
                    strLogFileName = "EQUITY_feftLogs.log";
                    break;

                case LogModes.FILE_DEBUG:
                    strLogFileName = "EQUITY_Debug.log";
                    break;

                case LogModes.FILE_ERROR:
                    strLogFileName = "EQUITY_Errors.log";
                    break;

                case LogModes.FILE_RAW:
                    strLogFileName = "EQUITY_RawMsgs.log";
                    logingmode = "EQUITY";
                    break;
                case LogModes.FILE_LOG_KCB:
                    strLogFileName = "KCB_FEFTLogs.log";
                    break;

                case LogModes.FILE_DEBUG_KCB:
                    strLogFileName = "KCB_Debug.log";
                    break;

                case LogModes.FILE_ERROR_KCB:
                    strLogFileName = "KCB_Errors.log";
                    break;

                case LogModes.FILE_RAW_KCB:
                    strLogFileName = "KCB_RawMsgs.log";
                    logingmode = "KCB";
                    break;

                case LogModes.FILE_LOG_EZZYPAY:
                    strLogFileName = "KCB_FEFTLogs.log";
                    break;

                case LogModes.FILE_DEBUG_EZZYPAY:
                    strLogFileName = "EZZYPAY_Debug.log";
                    break;

                case LogModes.FILE_ERROR_EZZYPAY:
                    strLogFileName = "EZZYPAY_Errors.log";
                    break;

                case LogModes.FILE_RAW_EZZYPAY:
                    strLogFileName = "EZZYPAY_RawMsgs.log";
                    logingmode = "EZZYPAY";
                    break;
                case LogModes.FILE_LOG_COMMON:
                    strLogFileName = "COMMON_Debug.log";
                    break;
            }


            log4net.GlobalContext.Properties["LogFileName"] = strLogFileName;
            log4net.Config.XmlConfigurator.Configure();

            ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            switch (level)
            {
                case LogLevel.DEBUG:
                    log.Debug(msg);
                    break;

                case LogLevel.INFO:
                    log.Info(msg);
                    break;

                case LogLevel.WARN:
                    log.Warn(msg);
                    break;

                case LogLevel.ERROR:
                    log.Error(msg);
                    break;

                case LogLevel.FATAL:
                    log.Fatal(msg);
                    break;
            }
        }
    }
}
