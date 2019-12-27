using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EventLog_04
{
    class Program
    {
        static void Main(string[] args)
        {

            EventLog.WriteEntry("Application", "Phil Logging To Event Log", EventLogEntryType.Information, 6782);

        }
    }
}
