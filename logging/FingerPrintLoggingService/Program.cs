using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace FingerPrintLoggingService
{
    class Program
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory);
            log4net.Config.XmlConfigurator.Configure();
            //XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
            //new AttLogging().Start();

            var exitCode = HostFactory.Run(x =>
            {

                x.Service<AttLogging>(s =>
                {
                    s.ConstructUsing(log => new AttLogging());
                    s.WhenStarted(log => log.Start());
                    s.WhenStopped(log => log.Stop());
                });

                x.RunAsLocalSystem();
                x.SetServiceName("AttendanceLog");
                x.SetDisplayName("Attendance Log Service");
                x.SetDescription("This service use for get time attendance log from devices");


            });
            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            _logger.Info(exitCodeValue);
            Environment.ExitCode = exitCodeValue;

        }
    }
}
