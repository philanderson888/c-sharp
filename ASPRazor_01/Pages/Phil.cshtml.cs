using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPRazor_01.Pages
{
    public class PhilModel : PageModel
    {

        public string ExposeMe { get; set; } = "Here is a default message";

        public void OnGet()
        {
            ExposeMe += " on " + DateTime.Now;
        }
    }
}