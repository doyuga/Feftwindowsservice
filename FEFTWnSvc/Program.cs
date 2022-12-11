using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FEFTWnSvc
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static void Main()
        {

            try
            {
                ServiceBase.Run(new ServiceBase[1]
                {
                    new FEFTsvc()
                });
            }
            catch (Exception message)
            {
                log.Error(message);
            }

            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new FEFTsvc()
            //};
            //ServiceBase.Run(ServicesToRun);
        }
    }
}
