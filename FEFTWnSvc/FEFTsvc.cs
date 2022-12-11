using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FEFTWnSvc
{
    public partial class FEFTsvc : ServiceBase
    {
        private const int SleepTime = 100;

        private EventLog _eventLog;

        private bool m_running;

        private Thread m_thread;

        private ServiceHost serviceHost;

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public FEFTsvc()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                log.Info("=====================================");
                log.Info("Starting Service ...");
                EventLogger("Starting Service...", EventLogEntryType.Information);
                m_running = true;
                m_thread = new Thread(ThreadMethod);
                m_thread.Start();
                EventLogger("Service Started...", EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                EventLogger(ex.Message, EventLogEntryType.Error);
            }
        }
        public void ThreadMethod()
        {
            try
            {
                serviceHost = new ServiceHost(typeof(FeftWnSvc));
                foreach (ServiceEndpoint endpoint in serviceHost.Description.Endpoints)
                {
                    endpoint.Behaviors.Add(new FEFTWnSvc.utilies.IncomingMessageLogger());
                    _ = endpoint;
                }
                serviceHost.Open();
                while (m_running)
                {
                    Thread.Sleep(100);
                }
                serviceHost.Close();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                EventLogger(ex.Message, EventLogEntryType.Error);
            }
        }

        private void EventLogger(string data, EventLogEntryType logType)
        {
            try
            {
                using (_eventLog = new EventLog())
                {
                    _eventLog.Source = "FeftWnSvcPremium";
                    if (!EventLog.SourceExists("FeftWnSvcPremium"))
                    {
                        EventLog.CreateEventSource("Logs for FeftWnSvc", "FeftWnSvcPremium");
                    }
                    _eventLog.WriteEntry(data, logType);
                }
            }
            catch (Exception)
            {
            }
        }
        protected override void OnStop()
        {
            log.Info("Stopping Service ...");
            log.Info("=====================================");
            EventLogger("Stopping Service ...", EventLogEntryType.Warning);
        }
    }
}
