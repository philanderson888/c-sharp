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
    public partial class BlogService : ServiceBase
    {
        public BlogService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {


        }


        protected override void OnContinue()
        {
            base.OnContinue();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }



        protected override void OnStop()
        {



        }
    }
}
