using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Service_01
{
    partial class HRService : ServiceBase
    {
        public HRService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //  Add code here to start your service.
        }

        protected override void OnStop()
        {
            //  Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
