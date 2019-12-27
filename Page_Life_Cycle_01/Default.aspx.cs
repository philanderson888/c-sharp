using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace Page_Life_Cycle_01
{
    public partial class _Default : Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Debug.WriteLine("Page_PreInit");
        }
        protected void Page_init(object sender, EventArgs e)
        {
            Debug.WriteLine("Page_init");
        }
        protected void Page_initComplete(object sender, EventArgs e)
        {
            Debug.WriteLine("Page_initComplete");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Page_Load");
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Debug.WriteLine("Page_LoadComplete");
        }


        protected void Page_prerender(object sender, EventArgs e)
        {
            Debug.WriteLine("Page_Prerender");
        }
        protected void Page_SaveState(object sender, EventArgs e)
        {
            Debug.WriteLine("Page_SaveState");
        }

        protected void Page_savestatecomplete(object sender, EventArgs e)
        {
            Debug.WriteLine("Page_SaveStateComplete");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            Debug.WriteLine("Page_Unload");
        }
    }
}