using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Service_02
{
    public partial class PhilService2 : ServiceBase
    {
        public PhilService2()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            EventLog.WriteEntry("Application", "Service Starting", EventLogEntryType.Information, 123);
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("Application", "Service Stopping", EventLogEntryType.Information, 123);
        }
    }
}
